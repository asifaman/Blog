using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Blog.Models;
using WebMatrix.WebData;

namespace Blog.Controllers
{
    public class AccountController : Controller
    {
        private Gateway db = new Gateway();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login login, string ReturnUrl)
        {
            base.Session["Login"] = login;

            if (ModelState.IsValid)
            {
                if (WebSecurity.Login(login.Username, login.Password))
                {
                    if (ReturnUrl != null)
                    {
                        return Redirect(ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Sorry The User Name and Password Invalid");
                    return View(login);
                }

            }
            ModelState.AddModelError("", "Sorry The User Name and Password Invalid");
            return View(login);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register register)
        {
          
            if (ModelState.IsValid)
            {
               
                try
                {
                    WebSecurity.CreateUserAndAccount(register.Username, register.Password);
                    return RedirectToAction("Index", "Home");
                }
                catch (MembershipCreateUserException ex)
                {
                    ModelState.AddModelError("", "Sorry The User Name Already Exitis");
                    return View(register);
                }
            }
            ModelState.AddModelError("","Sorry The User Name Already Exitis");
            return View(register);
        }

        public ActionResult Logout()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}