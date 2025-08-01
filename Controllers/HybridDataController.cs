using HybridApi.Data;
using HybridApi.Models;
using HybridApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HybridApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HybridDataController : ControllerBase
    {
        private readonly ApiDbContext _context;
        private readonly IPublicApiService _publicApiService;

        public HybridDataController(ApiDbContext context, IPublicApiService publicApiService)
        {
            _context = context;
            _publicApiService = publicApiService;
        }

        // GET: api/publicposts
        [HttpGet]
        public async Task<ActionResult<HybridData>> GetHybridData()
        {
            // Empieza dos tareas asincrónicas: una para obtener productos locales y otra para obtener publicaciones públicas
            var localProductsTask = _context.LocalProducts.ToListAsync();
            var publicPostsTask = _publicApiService.GetPosts();

            // Espera a que ambas tareas se completen
            await Task.WhenAll(localProductsTask, publicPostsTask);

            // Obtiene los resultados de las tareas
            var localProducts = await localProductsTask;
            var publicPosts = await publicPostsTask;

            var hybridData = new HybridData
            {
                LocalProducts = localProducts,
                PublicPosts = publicPosts
            };

            return Ok(hybridData);
        }
    }
}
