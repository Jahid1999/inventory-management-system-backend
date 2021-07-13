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
using InventoryManagementSystemBackend.ViewModel;
using InventoryManagementSystemBackend.Repository;

namespace InventoryManagementSystemBackend.Repository
{
    public class LoginRepository : DatabaseRepository
    {

       public Admin login(UserLogin userLogin) {
          var user = databaseContext.Admin.Where(p => p.Email == userLogin.email && p.Password == userLogin.password).FirstOrDefault();
           return user;  
       }

    }
}


