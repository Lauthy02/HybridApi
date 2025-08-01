using HybridApi.Models;

namespace HybridApi.Services
{
    public interface IPublicApiService
    {
        Task<List<PublicPost>> GetPosts();
    }
}
