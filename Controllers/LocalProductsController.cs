// Agregamos la referencia a HybridApi.Data para poder usar LocalProduct
using HybridApi.Data;
using HybridApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HybridApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalProductsController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public LocalProductsController(ApiDbContext context)
        {
            _context = context;
        }
        /* 
         * El constructor del controlador toma una instancia de ApiDbContext como parámetro. 
         * Gracias al registro en Program.cs, el sistema de inyección de dependencias proporcionará automáticamente 
         * una instancia de ApiDbContext cada vez que se cree una instancia de LocalProductsController para manejar una solicitud.
         */

        // GET: api/localproducts
        [HttpGet] // Atributo que designa este método para manejar solicitudes HTTP GET.
        public async Task<ActionResult<IEnumerable<LocalProduct>>> GetLocalProducts()
        {
            // Consulta asincrónicamente todos los registros de la tabla LocalProducts y los devuelve como una lista.
            return await _context.LocalProducts.ToListAsync();
        }

        // GET: api/localproducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LocalProduct>> GetLocalProduct(int id)
        {
            var localProduct = await _context.LocalProducts.FindAsync(id);

            if (localProduct == null)
            {
                return NotFound(); // Returns a 404 Not Found response
            }

            return localProduct;
        }

        // POST: api/localproducts
        [HttpPost] // Le dice a ASP.NET Core que intente vincular el cuerpo de la solicitud HTTP (que se espera que sea JSON) a un objeto LocalProduct
        public async Task<ActionResult<LocalProduct>> PostLocalProduct(LocalProduct localProduct)
        {
            _context.LocalProducts.Add(localProduct);
            await _context.SaveChangesAsync();

            // Devuelve una respuesta HTTP 201 Created, que es la respuesta estándar para un POST exitoso que resulta en la creación de un recurso
            return CreatedAtAction(nameof(GetLocalProduct), new { id = localProduct.Id }, localProduct);
        }

        // PUT: api/localproducts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocalProduct(int id, LocalProduct localProduct)
        {
            if (id != localProduct.Id)
            {
                return BadRequest(); // Returns a 400 Bad Request response
            }

            // Le dice a EF Core que la entidad localProduct adjunta debe ser marcada como modificada. Cuando se llame a SaveChangesAsync, EF Core generará una instrucción SQL UPDATE.
            _context.Entry(localProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.LocalProducts.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent(); // Devuelve una respuesta HTTP 204, que indica que la solicitud se procesó con éxito pero no hay contenido que devolver.
        }

        // DELETE: api/localproducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocalProduct(int id)
        {
            var localProduct = await _context.LocalProducts.FindAsync(id);
            if (localProduct == null)
            {
                return NotFound();
            }

            _context.LocalProducts.Remove(localProduct); //arca la entidad para su eliminación.
            await _context.SaveChangesAsync(); // Ejecuta el comando SQL DELETE en la base de datos.

            return NoContent();
        }
    }
}
