using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnMango.Proxmox.Client.Messages;

namespace UnMango.Proxmox.Client.Clients.Access
{
    public class DefaultUsersClient : IUsersClient
    {
        public DefaultUsersClient()
        {

        }

        public IAsyncEnumerable<GetUserResponse> GetAll()
        {
            throw new NotImplementedException();
        }

        public IAsyncEnumerable<GetUserResponse> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetUserResponse>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public IAsyncEnumerable<GetTokenResponse> GetAllTokens()
        {
            throw new NotImplementedException();
        }

        public IAsyncEnumerable<GetTokenResponse> GetAllTokens(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetTokenResponse>> GetAllTokensAsync(string userId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<GetUserResponse> GetAsync(string userId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<GetTfaTypesResponse> GetTfaTypesAsync(string userId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<GetTokenResponse> GetTokenAsync(string userId, string tokenId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public IUserClient User(string userId)
        {
            return new UserClient(userId, this);
        }
    }
}
