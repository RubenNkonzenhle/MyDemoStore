using OnlineShoppingStoreFix.DAL;
using OnlineShoppingStoreFix.Repository;
using OnlineShoppingStoreFix.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStoreFix.Controllers
{
    public class LoginController : Controller
    {
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        private dbMyOnlineShoppingEntities _context;
        public LoginController()
        {
            _context = new dbMyOnlineShoppingEntities();
        }
        // GET: Login
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Register(Tbl_Users tbl)
        {
            tbl.IsDelete = false;
            tbl.IsActive = true;
            tbl.CreatedOn = DateTime.Now;
            if (_context.Tbl_Users.Where(u => u.EmailId == tbl.EmailId).Any())
            {
                ModelState.AddModelError("EmailId", "this email already exists");
                return View("Register", tbl);
            } else {
                if (tbl.UserId > 0)
                {
                    _unitOfWork.GetRepositoryInstance<Tbl_Users>().Update(tbl);

                }
                else
                {
                    _unitOfWork.GetRepositoryInstance<Tbl_Users>().Add(tbl);
                }

                return Content("Successfully Registered");
            }
        }

        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(LoginFormViewModel user)
        {
            if(!ModelState.IsValid)
            {
                return View("login", user);
            }

            var LoginUser = _context.Tbl_Users.Where(u => u.EmailId == user.EmailId && u.Password == user.Password && u.IsActive == true).FirstOrDefault();
             if(LoginUser == null)
                {
                    ModelState.AddModelError("EmailId", "email or password is incorrect.");
                return View("login", user);
                }
             else
            {
                Session["User"] = LoginUser.EmailId;

                if (LoginUser.EmailId == "admin@demo.com")
                {
                    return RedirectToAction("Dashboard", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }


            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("login");
        }
    }
}