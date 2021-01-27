using Core.DataAccess;
using Core.Entities;
using Core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Services
{
    public class UserService:IUserService
    {
        private readonly DatabaseContext _context;

        public UserService(DatabaseContext context)
        {
            _context = context;
        }
        public User GetMatchedAdminforLogin(string userName, string password)
        {
            try
            {
                return _context.User.Where(q => q.UserName == userName && q.Password == password && q.UserRoleId == 1).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public User GetMatchedManagerforLogin(string userName, string password)
        {
            try
            {
                return _context.User.Where(q => q.UserName == userName && q.Password == password && q.UserRoleId == 2).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public User GetMatchedStaffforLogin(string userName, string password)
        {
            try
            {
                return _context.User.Where(q => q.UserName == userName && q.Password == password && q.UserRoleId == 3).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public User GetMatchedDeliveryStaffforLogin(string userName, string password)
        {
            try
            {
                return _context.User.Where(q => q.UserName == userName && q.Password == password && q.UserRoleId == 4).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public void AddorUpdateUser(User user)
        {
            try
            {
                if (user.UserId == 0)
                {
                    _context.User.Add(user);
                    _context.SaveChanges();
                }
                else
                {
                    _context.User.Update(user);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public List<User> UserList()
        {
            try
            {
                return _context.User.Where(q=>q.UserRoleId==3 || q.UserRoleId == 4)
                    .ToList();

            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                return new List<User>();
            }
        }
    }
}
