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

       public dynamic addProduct(Product product_info)
        {
            Product existingProduct = databaseContext.Product.SingleOrDefault(p => p.Name == product_info.Name);

            if(existingProduct != null ) {
                return new {
                   statusCode = 202,
                    errMsg = "Product Exist!"
                };
            }
            else {
                databaseContext.Product.Add(product_info);

            var product_id = databaseContext.SaveChanges();
            var product = databaseContext.Product.OrderBy(p => p.Id).LastOrDefault();

            return product;
            }

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

        public Stock purchase(Stock purchase_info) {
            var product = databaseContext.Product.Find(purchase_info.Productid);

            if(product != null) {
                product.Quantity += purchase_info.Quantity;
                databaseContext.Product.Update(product);
                databaseContext.SaveChanges();
            } 

            purchase_info.Treansactiondate = DateTime.Today;  
            
            databaseContext.Stock.Add(purchase_info);
            var pur_id =databaseContext.SaveChanges();
            // var purchase = databaseContext.Stock.OrderBy(a => a.Productid == purchase_info.Productid && a.Type == 1).LastOrDefault();
            var purchase = databaseContext.Stock.OrderBy(a => a.Id).LastOrDefault();

            return  purchase;
        }

        public Stock sale(Stock sale_info) {
            var product = databaseContext.Product.Find(sale_info.Productid);

            if(product != null) {
                product.Quantity -= sale_info.Quantity;
                databaseContext.Product.Update(product);
                databaseContext.SaveChanges();
            }   
            
            sale_info.Treansactiondate = DateTime.Today;

            databaseContext.Stock.Add(sale_info);
            var sale_id =databaseContext.SaveChanges();
            // var sale = databaseContext.Stock.OrderBy(a => a.Productid == sale_info.Productid && a.Type == 0).LastOrDefault();
            var sale = databaseContext.Stock.OrderBy(a => a.Id).LastOrDefault();

            return  sale;
        }

        public List<Stock> monthlyTransactionReport(string month) {
            var query = DateTime.Parse(month);

            var transations = databaseContext.Stock.Where(a => a.Treansactiondate.Month == query.Month && a.Treansactiondate.Year == query.Year).ToList();

            return transations;
        }

        public List<Stock> dailyTransactionReport(string date) {
            var query = DateTime.Parse(date);

            var transations = databaseContext.Stock
            .Where(a => a.Treansactiondate.Day == query.Day && a.Treansactiondate.Month == query.Month && a.Treansactiondate.Year == query.Year).ToList();

            return transations;
        }


    }
}


