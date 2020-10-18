using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController] //controller attribute
    [Route("api/[controller]")]//Route that will be used in domain to access methods of this class
    public class ProductsController : ControllerBase //Derive from ControllerBase since this class is a controller
    {
        private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet] //End point type
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _context.Products.ToListAsync(); //Reference products table from context to convert products in that table into a list

            return Ok(products);
        }

        [HttpGet("{id}")] //Takes in a route parameter to distingush the call of each method
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _context.Products.FindAsync(id);
        }

    }
}