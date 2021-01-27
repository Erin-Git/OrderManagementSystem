using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Interfaces
{
    public interface IUserService
    {
        User GetMatchedAdminforLogin(string UserName, string Password);
        User GetMatchedManagerforLogin(string UserName, string Password);
        User GetMatchedStaffforLogin(string UserName, string Password);
        User GetMatchedDeliveryStaffforLogin(string UserName, string Password);
        void AddorUpdateUser(User user);
        List<User> UserList();
    }
}
