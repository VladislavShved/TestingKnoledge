using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcPL.Providers;
using MvcPL.ViewModels;

namespace MvcPL.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid) return View(model);
            if (Membership.ValidateUser(model.Login, model.Password))
            {
                FormsAuthentication.SetAuthCookie(model.Login, model.RememberMe);
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Неправильный пароль или логин");
            }
            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Account");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                MembershipUser membershipUser = ((CustomMemberShipProvider)Membership.Provider).CreateUser(model.Login, model.Name, model.Surname, model.Password);

                if (membershipUser != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Login, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Ошибка при регистрации");
                }
            }
            return View(model);
        }

    }
}
