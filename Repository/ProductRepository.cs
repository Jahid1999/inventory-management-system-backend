using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryManagementSystemBackend.Data;
using InventoryManagementSystemBackend.Model;
using InventoryManagementSystemBackend.Repository;

namespace InventoryManagementSystemBackend.Repository
{
    public class ProductRepository : DatabaseRepository
    {
       public  List<Product> getAllProducts() {
           return  databaseContext.Product.ToList();
       }

       public Product getProductById(int id) {
           var product = databaseContext.Product.Find(id);

           return product;
       }

       public Product addProduct(Product product_info)
        {
            databaseContext.Product.Add(product_info);
            var newAdmin = databaseContext.SaveChanges();

            return product_info;
        }

        public Product updateProduct(Product product_info)
        {
            databaseContext.Product.Update(product_info);
            var newProduct = databaseContext.SaveChanges();

            return product_info;
        }

        public bool deleteProduct(int id) {
            var product = databaseContext.Product.Find(id);

             if (product == null){
                return false;
             }
                
                databaseContext.Product.Remove(product);
                databaseContext.SaveChanges();
                
                return true;

        }

    }
}


