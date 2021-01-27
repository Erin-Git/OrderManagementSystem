using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MetaOMS.Models;
using MetaOMS.ViewModels;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace MetaOMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService userService;

        public HomeController(IUserService _userService)
        {
            userService = _userService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(UserVM userVM)
        {
            var userIsAdmin = userService.GetMatchedAdminforLogin(userVM.UserVMName, userVM.PasswordVM);
            if (userIsAdmin != null) //admin found
            {
                HttpContext.Session.SetString("UserId", userIsAdmin.UserId.ToString());
                HttpContext.Session.SetString("UserRoleId", userIsAdmin.UserRoleId.ToString());
                return RedirectToAction("Index", "Admin");
            }
            else if (userIsAdmin == null) //admin not found, check for manager
            {
                var userIsManager = userService.GetMatchedManagerforLogin(userVM.UserVMName, userVM.PasswordVM);
                if (userIsManager != null) //manager found
                {
                    HttpContext.Session.SetString("UserId", userIsManager.UserId.ToString());
                    HttpContext.Session.SetString("UserRoleId", userIsManager.UserRoleId.ToString());
                    return RedirectToAction("Index", "Manager");
                }
                else if (userIsManager == null) //manager not found, check for staff
                {
                    var userIsStaff = userService.GetMatchedStaffforLogin(userVM.UserVMName, userVM.PasswordVM);
                    if (userIsStaff != null) //staff found
                    {
                        HttpContext.Session.SetString("UserId", userIsStaff.UserId.ToString());
                        HttpContext.Session.SetString("UserRoleId", userIsStaff.UserRoleId.ToString());
                        return RedirectToAction("Index", "Staff");
                    }
                    else if (userIsStaff == null) //staff not found, check for deliverystaff
                    {
                        var userIsDeliveryStaff = userService.GetMatchedDeliveryStaffforLogin(userVM.UserVMName, userVM.PasswordVM);
                        if (userIsDeliveryStaff != null) //deliverystaff found
                        {
                            HttpContext.Session.SetString("UserId", userIsDeliveryStaff.UserId.ToString());
                            HttpContext.Session.SetString("UserRoleId", userIsDeliveryStaff.UserRoleId.ToString());
                            return RedirectToAction("Index", "DeliveryStaff");
                        }
                        else if (userIsDeliveryStaff == null) //deliverystaff not found even
                        {
                            ViewBag.notFound = "Invalid Username or Password!";
                            //return RedirectToAction("Index", "Home");
                            return View();
                        }
                    }
                }
            }
            else //nothing matched
            {
                ViewBag.notFound = "Invalid UserName or Password!";
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
