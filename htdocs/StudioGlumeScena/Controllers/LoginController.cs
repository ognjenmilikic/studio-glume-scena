using StudioGlumeScena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace StudioGlumeScena.Controllers
{
    public class LoginController : Controller
    {
        StudioGlumeScenaEntities studioGlumeScenaEntities = new StudioGlumeScenaEntities();
        private UcenikRepository ucenikRepository = new UcenikRepository();
        private ProfesorRepository profesorRepository = new ProfesorRepository();
        // GET: Login
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (studioGlumeScenaEntities.Profesor.Any(t => t.Email == User.Identity.Name))
                    ViewBag.Role = "Profesor";
                else if (studioGlumeScenaEntities.Ucenik.Any(t => t.Email == User.Identity.Name))
                    ViewBag.Role = "Ucenik";
            }

            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            if (profesorRepository.userExists(email, password))
            {
                FormsAuthentication.SetAuthCookie(email, false);
                return RedirectToAction("Pocetna", "Profesor");
            }
            else if (ucenikRepository.userExists(email, password))
            {
                FormsAuthentication.SetAuthCookie(email, false);
                return RedirectToAction("Pocetna", "Ucenik");
            }
            else {
                ModelState.AddModelError("", "Pogresan email ili password");
                return View();
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}