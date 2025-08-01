namespace HybridApi.Models
{
    public class HybridData
    {
        public IEnumerable<LocalProduct> LocalProducts { get; set; }
        public IEnumerable<PublicPost> PublicPosts { get; set; }
    }
}
