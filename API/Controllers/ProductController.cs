

using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
      
        private readonly IProductRepository _repo;

        public ProductController(IProductRepository repo)
         {
            _repo = repo;
        }
        
          [HttpGet]
          public async Task<ActionResult<List<Product>>> GetProducts(){
            var products = await _repo.GetProductsAsync();
            return Ok(products);
          }

          [HttpGet("{id}")]
          public async Task<ActionResult<Product>> GetProduct(int id){
            return await _repo.GetProductByIdAsync(id);
          }

        [HttpDelete("{id}")]
        public string delete(int id){
            return "this has been deleted";
        }

    }
}