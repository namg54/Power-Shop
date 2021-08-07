using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PowerShop.Models;

namespace PowerShop.Data.Repositories
{
    public  interface IUserRepository
    {
        Users GetUserForLogin(string email,string password);
        bool IsExistUserByEmail(string Email);
        void AddUser(Users user);

    }
}
