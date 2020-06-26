using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnMango.Proxmox.Client.Messages;

namespace UnMango.Proxmox.Client.Clients.Access
{
    public interface IUserClient
    {
        string UserId { get; }

        Task<GetUserResponse> GetAsync(CancellationToken cancellationToken = default);

        Task<GetTokenResponse> GetTokenAsync(string tokenId, CancellationToken cancellationToken = default);

        IAsyncEnumerable<GetTokenResponse> GetAllTokens();

        IAsyncEnumerable<GetTokenResponse> GetAllTokens(CancellationToken cancellationToken);

        Task<IEnumerable<GetTokenResponse>> GetAllTokensAsync(CancellationToken cancellationToken = default);

        Task<GetTfaTypesResponse> GetTfaTypesAsync(CancellationToken cancellationToken = default);
    }
}
