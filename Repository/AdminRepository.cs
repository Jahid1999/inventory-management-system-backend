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
    public class AdminRepository : DatabaseRepository
    {
       public  List<Admin> getAllAdmins() {
           return  databaseContext.Admin.ToList();
       }

       public Admin getAdminById(int id) {
           var admin = databaseContext.Admin.Find(id);

           return admin;
       }

       public dynamic addAdmin(Admin admin_info)
        {
            Admin existingAdmin = databaseContext.Admin.SingleOrDefault(admin => admin.Email == admin_info.Email);

            if(existingAdmin != null ) {
                return new {
                   statusCode = 202,
                    errMsg = "Admin Exist!"
                };
            }
           else {
                databaseContext.Admin.Add(admin_info);
                var newAdmin = databaseContext.SaveChanges();

                return admin_info;
           }
           
        }

        public Admin updateAdmin(Admin admin_info)
        {
            databaseContext.Admin.Update(admin_info);
            var newAdmin = databaseContext.SaveChanges();

            return admin_info;
        }

        public bool deleteAdmin(int id) {
            var admin = databaseContext.Admin.Find(id);

             if (admin == null){
                return false;
             }
                
                databaseContext.Admin.Remove(admin);
                databaseContext.SaveChanges();
                
                return true;

        }

    }
}


