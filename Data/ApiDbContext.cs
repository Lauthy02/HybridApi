using HybridApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HybridApi.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
            // Se utilizará para pasar la configuración de la base de datos (como la cadena de conexión) a través de la inyección de dependencias
        }

        public DbSet<LocalProduct> LocalProducts { get; set; }
        // Le dice a EF Core que queremos una tabla para nuestra entidad LocalProduct, y que esta tabla se llamará LocalProducts
    }
}
