using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryManagementSystemBackend.Data;
using InventoryManagementSystemBackend.Model;
using InventoryManagementSystemBackend.Repository;

namespace InventoryManagementSystemBackend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly ProductRepository _productRepository = new ProductRepository(); 

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productRepository.getAllProducts();

            return  Ok(products);
        }

        // GET: api/product/5
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productRepository.getProductById(id);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }


        // POST: api/product/add
        [HttpPost("add")]
        public IActionResult AddProduct([FromBody] Product product)
        {
            var new_product = _productRepository.addProduct(product);
        
            return Ok(new_product);
        }

        // PUT: api/product/update
        [HttpPut("update")]
        public IActionResult UpdateProduct([FromBody] Product product)
        {
            var updated_product = _productRepository.updateProduct(product);
        
            return Ok(updated_product);
        }

        // DELETE: api/product/delete/5
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteProduct(int id)
        {
        
            var isDeleted = _productRepository.deleteProduct(id);
            if (!isDeleted){
                return NotFound();
            }

            return Ok("Product deleted Successfully.");
        }


    }
}
