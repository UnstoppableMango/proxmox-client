using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnMango.Proxmox.Client.Messages;

namespace UnMango.Proxmox.Client.Clients.Access
{
    internal class UserClient : IUserClient
    {
        private readonly IUsersClient _users;

        public UserClient(string userId, IUsersClient users)
        {
            UserId = userId;
            _users = users;
        }

        public string UserId { get; }

        public IAsyncEnumerable<GetTokenResponse> GetAllTokens()
        {
            return _users.GetAllTokens();
        }

        public IAsyncEnumerable<GetTokenResponse> GetAllTokens(CancellationToken cancellationToken)
        {
            return _users.GetAllTokens(cancellationToken);
        }

        public Task<IEnumerable<GetTokenResponse>> GetAllTokensAsync(CancellationToken cancellationToken = default)
        {
            return _users.GetAllTokensAsync(UserId, cancellationToken);
        }

        public Task<GetUserResponse> GetAsync(CancellationToken cancellationToken = default)
        {
            return _users.GetAsync(UserId, cancellationToken);
        }

        public Task<GetTfaTypesResponse> GetTfaTypesAsync(CancellationToken cancellationToken = default)
        {
            return _users.GetTfaTypesAsync(UserId, cancellationToken);
        }

        public Task<GetTokenResponse> GetTokenAsync(string tokenId, CancellationToken cancellationToken = default)
        {
            return _users.GetTokenAsync(UserId, tokenId, cancellationToken);
        }
    }
}
