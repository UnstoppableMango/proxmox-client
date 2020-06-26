using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnMango.Proxmox.Client.Messages;

namespace UnMango.Proxmox.Client.Clients.Access
{
    public interface IUsersClient
    {
        Task<IEnumerable<GetUserResponse>> GetAllAsync(CancellationToken cancellationToken = default);

        IAsyncEnumerable<GetUserResponse> GetAll();

        IAsyncEnumerable<GetUserResponse> GetAll(CancellationToken cancellationToken);

        Task<GetUserResponse> GetAsync(string userId, CancellationToken cancellationToken = default);

        IAsyncEnumerable<GetTokenResponse> GetAllTokens();

        IAsyncEnumerable<GetTokenResponse> GetAllTokens(CancellationToken cancellationToken = default);

        Task<IEnumerable<GetTokenResponse>> GetAllTokensAsync(
            string userId,
            CancellationToken cancellationToken = default);

        Task<GetTfaTypesResponse> GetTfaTypesAsync(string userId, CancellationToken cancellationToken = default);

        Task<GetTokenResponse> GetTokenAsync(
            string userId,
            string tokenId,
            CancellationToken cancellationToken = default);

        IUserClient User(string userId);
    }
}
