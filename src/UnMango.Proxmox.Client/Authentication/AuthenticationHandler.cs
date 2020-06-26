using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnMango.Proxmox.Client.Clients;

namespace UnMango.Proxmox.Client.Authentication
{
    internal class AuthenticationHandler : DelegatingHandler
    {
        private readonly IAccessClient _accessClient;

        public AuthenticationHandler(IAccessClient accessClient)
        {
            _accessClient = accessClient;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return base.SendAsync(request, cancellationToken);
        }
    }
}
