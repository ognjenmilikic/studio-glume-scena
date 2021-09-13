using StudioGlumeScena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudioGlumeScena.Controllers
{
    [Authorize(Roles ="ucenik")]
    public class UcenikController : Controller
    {
        UcenikRepository ucenikRepository = new UcenikRepository();
        ProfesorRepository profesorRepository = new ProfesorRepository();
        // GET: Ucenik
        public ActionResult Pocetna()
        {
            Ucenik ucenik = ucenikRepository.getUcenikByEmail(User.Identity.Name);
            return View(ucenik);
        }
        public ActionResult PretragaProfesora()
        {
            return View();
        }
        public ActionResult PretrazeniProfesor(string ime)
        {
            Profesor profesor = profesorRepository.getProfesorByIme(ime);
            return PartialView("PretrazeniProfesor", profesor);
        }
    }
}