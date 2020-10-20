using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers 
{
    [ApiController] //controller attribute
    [Route ("api/[controller]")] //Route that will be used in domain to access methods of this class
    public class ProductsController : ControllerBase //Derive from ControllerBase since this class is a controller
    {
        private readonly IProductRepository _repo;
        public ProductsController (IProductRepository repo) {
            _repo = repo;
        }

        [HttpGet] //End point type
        public async Task<ActionResult<List<Product>>> GetProducts () {
            
            var products = await _repo.GetProductsAsync(); //Reference method from infrastructure class that populates that repo and return list of products

            return Ok (products);
        }

        [HttpGet ("{id}")] //Takes in a route parameter to distingush the call of each method
        public async Task<ActionResult<Product>> GetProduct (int id) {
            return await _repo.GetProductByIdAsync(id);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _repo.GetProductBrandsAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _repo.GetProductTypesAsync());
        }



    }
}