﻿using Course_Work.Areas.Admin.Models;
using Course_Work.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Course_Work.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Admin/Admin
        public ActionResult Index()
        {
            List<userModel> list = new List<userModel>();
            foreach(var i in _context.Users.ToList())
            {
                if (User.Identity.GetUserId() != i.Id)
                list.Add(new userModel
                {
                    Id = i.Id,
                    Name = i.UserName,
                    Email = i.Email,
                    Password = i.PasswordHash,
                    PhoneNumber = i.PhoneNumber,
                });
            }
            return View(list);
        }
    }
}