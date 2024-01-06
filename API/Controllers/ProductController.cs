

using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly StoreContext _context;

         public ProductController(StoreContext context)
         {
            _context = context;
                      
         }
          [HttpGet]
          public async Task<ActionResult<List<Product>>> GetProducts(){
            var products = await _context.Products.ToListAsync();
            return products;
          }

          [HttpGet("{id}")]
          public async Task<ActionResult<Product>> GetProduct(int id){
            #pragma warning disable CS8604 // Possible null reference argument.
            return await _context.Products.FindAsync(id);
            #pragma warning restore CS8604 // Possible null reference argument.
        }

        [HttpDelete("{id}")]
        public string delete(int id){
            return "this has been deleted";
        }

    }
}