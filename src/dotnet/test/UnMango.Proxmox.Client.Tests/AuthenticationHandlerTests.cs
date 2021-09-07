using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Moq;
using Moq.Contrib.HttpClient;
using UnMango.Proxmox.Generated.Model;
using Xunit;

namespace UnMango.Proxmox.Client.Tests
{
    public class AuthenticationHandlerTests
    {
        private readonly Mock<HttpMessageHandler> _innerHandler = new();
        private readonly Mock<HttpMessageHandler> _outerHandler = new();
        private const string Username = "TestUsername";
        private const string Password = "TestPassword";
        private readonly HttpClient _client;

        public AuthenticationHandlerTests()
        {
            var client = _innerHandler.CreateClient();
            client.BaseAddress = new("https://example.com");
            var handler = new AuthenticationHandler(client, Username, Password);
            handler.InnerHandler = _outerHandler.Object;
            _client = new(handler) {
                BaseAddress = new("https://example.com")
            };
        }

        public static IEnumerable<object[]> RequestsTicketArgs = new[] {
            new object[] { HttpMethod.Delete },
            new object[] { HttpMethod.Get },
            new object[] { HttpMethod.Patch },
            new object[] { HttpMethod.Post },
            new object[] { HttpMethod.Put }
        };

        [Theory]
        [MemberData(nameof(RequestsTicketArgs))]
        public async Task RequestsTicket(HttpMethod method)
        {
            const string expectedTicket = "Ticket";
            var ticketResponse = new CreateTicketResponse {
                Ticket = expectedTicket
            };
            
            var responseJson = JsonSerializer.Serialize(ticketResponse);
            _innerHandler.SetupRequest(HttpMethod.Post, "https://example.com/access/ticket")
                .ReturnsResponse(HttpStatusCode.OK, responseJson);

            const string route = "https://example.com/does/not/matter";
            _outerHandler.SetupRequest(method, route).ReturnsResponse(HttpStatusCode.OK);
            var request = new HttpRequestMessage(method, route);

            _ = await _client.SendAsync(request);
            
            _innerHandler.Verify();
            _outerHandler.VerifyRequest(message => {
                if (!message.Options.TryGetValue(new("CookieContainer"), out List<Cookie>? cookies))
                    return false;

                if (cookies is not { Count: > 0 })
                    return false;
                
                return cookies[0] is {
                    Name: "PVEAuthCookie",
                    Value: expectedTicket
                };
            });
        }
    }
}
