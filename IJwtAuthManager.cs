using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSystemBackend
{
    public interface IJwtAuthManager
    {
        string Authenticate(string email, string password);
    }
}
