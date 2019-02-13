﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SistemaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaWeb.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {


                if (isAdminUser())
                {
                    ViewBag.displayMenu = "Admin";
                }
                else if (isManager())
                {
                    var usuario = User.Identity;
                    ViewBag.Name = usuario.Name;
                    ViewBag.displayMenu = "Manager";
                }
                else
                {
                    var usuario = User.Identity;
                    ViewBag.Name = usuario.Name;
                    ViewBag.displayMenu = "Usuario";
                }
            }
            else
            {
                ViewBag.Name = "El usuario no se ha logeado todavia";
            }
            return View();
        }

        private bool isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var usuario = User.Identity;
                ApplicationDbContext contexto = new ApplicationDbContext();
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(contexto));

                var roles = userManager.GetRoles(usuario.GetUserId());

                if (roles[0].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        private bool isManager()
        {
            if (User.Identity.IsAuthenticated)
            {
                var usuario = User.Identity;
                ApplicationDbContext contexto = new ApplicationDbContext();
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(contexto));

                var roles = userManager.GetRoles(usuario.GetUserId());

                if (roles[0].ToString() == "Manager")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;

        }
   
    }
}