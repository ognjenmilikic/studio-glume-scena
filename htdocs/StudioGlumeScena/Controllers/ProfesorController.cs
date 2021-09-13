using StudioGlumeScena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudioGlumeScena.Controllers
{
    [Authorize(Roles = "profesor")]
    public class ProfesorController : Controller
    {
        GrupaRepository grupaRepository = new GrupaRepository();
        ProfesorRepository profesorRepository = new ProfesorRepository();
        UcenikRepository ucenikRepository = new UcenikRepository();
        StudioGlumeScenaEntities studioGlumeScenaEntities = new StudioGlumeScenaEntities();
        // GET: Profesor
        public ActionResult Pocetna()
        {
            List<Grupa> grupe = profesorRepository.getGrupeForProfesor(User.Identity.Name).ToList();
            return View(grupe);
        }
        public ActionResult PretragaUcenika()
        {
            return View();
        }
        public ActionResult PretrazeniUcenik(string jmbg)
        {
            Ucenik ucenik = ucenikRepository.getUcenikByJmbg(jmbg);
            return PartialView("PretrazeniUcenik", ucenik);
        }
        public ActionResult ProveriJMBG()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ProveriJMBG(string jmbg)
        {
            if(studioGlumeScenaEntities.Ucenik.Any(t=> t.JMBGu == jmbg))
            {
                return View("Greska");
            }
            else
            {
                TempData["jmbgUnos"] = jmbg;
                return RedirectToAction("UnosUcenika");
            }
        }
        public ActionResult UnosUcenika()
        {
            if (TempData["jmbgUnos"] == null)
                return View("Greska");
            else
            {
                ViewBag.JMBG = TempData["jmbgUnos"];
                TempData.Keep("jmbgUnos");
                return View();
            }
        }
        [HttpPost]
        public ActionResult UnosUcenika(Ucenik ucenik)
        {
            ucenikRepository.Add(ucenik);
            return View("Uspeh");
        }
        public ActionResult BrisanjeUcenika()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BrisanjeUcenika(string jmbg)
        {
            if(!(studioGlumeScenaEntities.Ucenik.Any(t => t.JMBGu == jmbg)))
            {
                return View("Greska");
            }
            else
            {
                TempData["jmbgBrisanje"] = jmbg;
                return RedirectToAction("PotvrdaBrisanja");
            }
        }
        public ActionResult PotvrdaBrisanja()
        {
            if (TempData["jmbgBrisanje"] == null)
                return View("Greska");
            else
            {
                string jmbg = TempData["jmbgBrisanje"].ToString();
                TempData.Keep("jmbgBrisanje");
                Ucenik ucenik = ucenikRepository.getUcenikByJmbg(jmbg);
                return View(ucenik);
            } 
        }
        [HttpPost]
        public ActionResult PotvrdaBrisanja(Ucenik ucenik)
        {
            ucenikRepository.Delete(ucenik);
            return View("Uspeh");
        }
        public ActionResult ProveraIzmene()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ProveraIzmene(string jmbg)
        {
            if (!(studioGlumeScenaEntities.Ucenik.Any(t => t.JMBGu == jmbg)))
            {
                return View("Greska");
            }
            else
            {
                TempData["jmbgIzmena"] = jmbg;
                return RedirectToAction("IzmenaUcenika");
            }
        }
        public ActionResult IzmenaUcenika()
        {
            if (TempData["jmbgIzmena"] == null)
                return View("Greska");
            else
            {
                Ucenik ucenik = ucenikRepository.getUcenikByJmbg(TempData["jmbgIzmena"].ToString());
                TempData.Keep("jmbgIzmena");
                return View(ucenik);
            }
        }
        [HttpPost]
        public ActionResult IzmenaUcenika(Ucenik ucenik)
        {
            ucenikRepository.Edit(ucenik);
            return View("Uspeh");
        }
        public ActionResult PretragaGrupa()
        {
            List<Grupa> grupe = new List<Grupa>();
            grupe = profesorRepository.getGrupeForProfesor(User.Identity.Name).ToList();
            return View(grupe);
        }
        [HttpPost]
        public ActionResult PretragaGrupa(string brGrupe)
        {
            TempData["brGrupePretraga"] = brGrupe;
            return RedirectToAction("ListaUcenika");
        }
        public ActionResult ListaUcenika()
        {
            if (TempData["brGrupePretraga"] == null)
                return View("Greska");
            else
            {
                string brGrupe = TempData["brGrupePretraga"].ToString();
                TempData.Keep("brGrupePretraga");
                List<Ucenik> ucenici = ucenikRepository.getUcenikeByGrupa(brGrupe);
                if (ucenici == null)
                    return View("Greska");
                else
                    return View(ucenici);
            } 
        }
        public ActionResult IzaberiGrupu()
        {
            List<Grupa> grupe = new List<Grupa>();
            grupe = profesorRepository.getGrupeForProfesor(User.Identity.Name).ToList();
            return View(grupe);
        }
        [HttpPost]
        public ActionResult IzaberiGrupu(string brGrupe)
        {
            TempData["brGrupeZadavanje"] = brGrupe;
            return RedirectToAction("ZadajNoviZadatak");
        }
        public ActionResult ZadajNoviZadatak()
        {
            if (TempData["brGrupeZadavanje"] == null)
                return View("Greska");
            else
            {
                string brGrupe = TempData["brGrupeZadavanje"].ToString();
                TempData.Keep("brGrupeZadavanje");
                int br;
                if (int.TryParse(brGrupe, out br))
                {
                    Grupa grupa = studioGlumeScenaEntities.Grupa.Single(t => t.BrojGrupe == br);
                    return View(grupa);
                }
                else
                    return View("Greska");
            }   
        }
        [HttpPost]
        public ActionResult ZadajNoviZadatak(Grupa grupa)
        {
            grupaRepository.Edit(grupa);
            return View("Uspeh");
        }
        public ActionResult ObrisiZadatak()
        {
            List<Grupa> grupe = new List<Grupa>();
            grupe = profesorRepository.getGrupeForProfesor(User.Identity.Name).ToList();
            return View(grupe);
        }
        [HttpPost]
        public ActionResult ObrisiZadatak(string brGrupe)
        {
            TempData["brGrupeBrisanje"] = brGrupe;
            return RedirectToAction("PotvrdaBrisanjaZadatka");
        }
        public ActionResult PotvrdaBrisanjaZadatka()
        {
            if (TempData["brGrupeBrisanje"] == null)
                return View("Greska");
            else
            {
                string brGrupe = TempData["brGrupeBrisanje"].ToString();
                TempData.Keep("brGrupeBrisanje");
                int br;
                if (int.TryParse(brGrupe, out br))
                {
                    Grupa grupa = studioGlumeScenaEntities.Grupa.Single(t => t.BrojGrupe == br);
                    return View(grupa);
                }
                else
                    return View("Greska");
            }
        }
        [HttpPost]
        public ActionResult PotvrdaBrisanjaZadatka(Grupa grupa)
        {
            grupaRepository.DeleteZadatak(grupa);
            return View("Uspeh");
        }
    }
}