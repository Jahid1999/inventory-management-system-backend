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

        // GET: api/product/report/monthly/2021-07-14T00:00:00+06:00
        [HttpGet("report/monthly/{month}")]
        public IActionResult GetMonthlyTransactionReport(string month)
        {
            var transactions = _productRepository.monthlyTransactionReport(month);

            if (transactions == null)
            {
                return NotFound();
            }
            return Ok(transactions);
        }

        // GET: api/product/report/daily/2021-07-14T00:00:00+06:00
        [HttpGet("report/daily/{date}")]
        public IActionResult GetDailyTransactionReport(string date)
        {
            var transactions = _productRepository.dailyTransactionReport(date);

            if (transactions == null)
            {
                return NotFound();
            }
            return Ok(transactions);
        }


        // POST: api/product/add
        [HttpPost("add")]
        public dynamic AddProduct([FromBody] Product product)
        {
            var new_product = _productRepository.addProduct(product);
        
            return Ok(new_product);
        }

         // POST: api/product/purchase
        [HttpPost("purchase")]
        public IActionResult PurchaseProduct([FromBody] Stock stock)
        {
            var new_product = _productRepository.purchase(stock);
        
            return Ok(new_product);
        }

         // POST: api/product/purchase
        [HttpPost("sale")]
        public IActionResult SaleProduct([FromBody] Stock stock)
        {
            var new_product = _productRepository.sale(stock);
        
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
            if (isDeleted == false){
                return NotFound();
            }
                
            return Ok();
        }


    }
}
