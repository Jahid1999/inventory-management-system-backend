using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagementSystemBackend.Model;
using InventoryManagementSystemBackend.Data;

namespace InventoryManagementSystemBackend.Repository
{
    public class DatabaseRepository
    {
        protected InventoryManagementSystemBackendContext databaseContext = new InventoryManagementSystemBackendContext();
    }
}