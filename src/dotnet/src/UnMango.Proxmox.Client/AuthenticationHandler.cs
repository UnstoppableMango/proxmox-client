using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using UnMango.Proxmox.Generated.Model;

namespace UnMango.Proxmox.Client
{
    [PublicAPI]
    public class AuthenticationHandler : DelegatingHandler
    {
        private readonly string _baseUrl;
        private readonly string _username;
        private readonly string _password;
        private CreateTicketResponse? _ticketResponse;

        public AuthenticationHandler(string baseUrl, string username, string password)
        {
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(baseUrl));
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(username));
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(password));

            _baseUrl = baseUrl;
            _username = username;
            _password = password;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (_ticketResponse == null)
            {
                using var client = new HttpClient {
                    BaseAddress = new($"{_baseUrl}/api2/json")
                };

                var content = new FormUrlEncodedContent(new Dictionary<string, string> {
                    ["username"] = _username,
                    ["password"] = _password,
                }!);

                using var response = await client.PostAsync("access/ticket", content, cancellationToken);
                response.EnsureSuccessStatusCode();

#if NETSTANDARD2_0
                using var responseStream = await response.Content.ReadAsStreamAsync();
#else
                await using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken);
#endif

                _ticketResponse = await JsonSerializer.DeserializeAsync<CreateTicketResponse>(
                    responseStream, null, cancellationToken);
            }

            if (_ticketResponse == null) throw new("Unable to authenticate");

            var cookies = new List<Cookie> {
                new("PVEAuthCookie", _ticketResponse.Ticket)
            };

#if NETSTANDARD2_0
            request.Properties["CookieContainer"] = cookies;
#else
            request.Options.Set(new("CookieContainer"), cookies);
#endif

            if (request.Method == HttpMethod.Post || request.Method == HttpMethod.Put || request.Method == HttpMethod.Delete)
            {
                request.Headers.Add("CSRFPreventionToken", _ticketResponse.CSRFPreventionToken);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
