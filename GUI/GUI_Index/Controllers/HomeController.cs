﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GUI_Index.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace GUI_Index.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult LogInd()
        {
            if (UserList.Users == null)
                UserList.Users = new List<User>();

            return View();
        }

        [HttpPost]
        public IActionResult LogInd(User user)
        {
            foreach (User item in UserList.Users)
            {
                if (item.Username == user.Username && item.Password == user.Password)
                {
                    return View("PostLogInd",item);
                }

            }
            return View("LogInd");
        }

        public IActionResult OpretKonto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult OpretKonto(User user)
        {
            bool flag = true;
            try
            {
                //ugly fix for no data storage
                if (UserList.Users.Count != 0)
                {
                    foreach (User item in UserList.Users)
                    {
                        if (item.Username == user.Username && item.Password == user.Password)
                        {
                            flag = false;
                        }

                    }
                }
                if (flag)
                {
                    UserList.Users.Add(user);
                    return RedirectToAction("LogInd");
                }
                
            }
            catch 
            {
                return RedirectToAction("OpretKonto");
            }
            


            return RedirectToAction("OpretKonto");
        }

        public IActionResult PostLogInd(User user)
        {
            
            return View();
        }

        public IActionResult UserListView()
        {
            var model = UserList.Users;
            return View(model);
        }

    }
}
