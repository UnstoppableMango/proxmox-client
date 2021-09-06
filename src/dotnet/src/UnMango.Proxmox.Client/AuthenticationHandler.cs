using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace UnMango.Proxmox.Client
{
    [PublicAPI]
    public class AuthenticationHandler : DelegatingHandler
    {
        private readonly string _baseUrl;
        private readonly string _username;
        private readonly string _password;
        private string? _ticket;
        private string? _token;

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

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return base.SendAsync(request, cancellationToken);
        }
    }
}
