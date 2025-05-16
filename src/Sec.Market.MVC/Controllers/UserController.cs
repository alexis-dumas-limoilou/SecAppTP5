using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sec.Market.MVC.Interfaces;
using Sec.Market.MVC.Models;

namespace Sec.Market.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }


        // GET: UserController/SignIn
        public ActionResult SignIn(string? returnurl)
        {
            ViewBag.ReturnUrl = returnurl;
            return View();
        }

        // POST: UserController/SignOut
        [HttpPost]
        public async Task<ActionResult> SignIn(UserToLogin userToLogin, string? returnurl)
        {
            var user = await _userService.Obtenir(userToLogin.UserName, userToLogin.Password);

            if (user == null)
                ModelState.AddModelError("Erreur", "Email ou mot de passe incorrect");
            else
            {
                HttpContext.Session.SetString("name", user.Nom);
                HttpContext.Session.SetInt32("id", user.Id);
                HttpContext.Session.SetString("email", user.Email);
                HttpContext.Session.SetString("role", user.Role);

                if (returnurl == null)
                    return RedirectToAction("Index", "Product");
                else
                  return Redirect(returnurl);

            }

            return View();
        }

        public  ActionResult LogOut()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Product");
        }



        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
    
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
      
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
