using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudioGlumeScena.Models
{
    public class UcenikRepository
    {
        private StudioGlumeScenaEntities studioGlumeScenaEntities = new StudioGlumeScenaEntities();

        public bool userExists(string email, string password)
        {
            return studioGlumeScenaEntities.Ucenik.Any(t => t.Email == email && t.Password == password);
        }
        
        public Ucenik getUcenikByJmbg(string jmbg)
        {
            if (studioGlumeScenaEntities.Ucenik.Any(t => t.JMBGu == jmbg))
            {
                Ucenik ucenik = studioGlumeScenaEntities.Ucenik.Single(t => t.JMBGu == jmbg);
                return ucenik;
            }
            else
                return null;
        }
        public Ucenik getUcenikByEmail(string email)
        {
            Ucenik ucenik = studioGlumeScenaEntities.Ucenik.Single(t => t.Email == email);
            return ucenik;
        }
        public void Add(Ucenik ucenik)
        {
            Ucenik ucenik1 = new Ucenik();
            ucenik1 = ucenik;
            studioGlumeScenaEntities.Ucenik.Add(ucenik1);
            studioGlumeScenaEntities.SaveChanges();
        }
        public void Delete(Ucenik ucenik)
        {
            Ucenik ucenik1 = studioGlumeScenaEntities.Ucenik.Single(t => t.JMBGu == ucenik.JMBGu);
            studioGlumeScenaEntities.Ucenik.Remove(ucenik1);
            studioGlumeScenaEntities.SaveChanges();
        }
        public void Edit(Ucenik ucenik)
        {
            Ucenik original = studioGlumeScenaEntities.Ucenik.Single(t => t.JMBGu == ucenik.JMBGu);
            original.Ime = ucenik.Ime;
            original.Prezime = ucenik.Prezime;
            original.GodinaRodjenja = ucenik.GodinaRodjenja;
            original.BrojGrupe = ucenik.BrojGrupe;
            original.PoslednjaPlacenaClanarina = ucenik.PoslednjaPlacenaClanarina;
            original.BrTelefona = ucenik.BrTelefona;
            original.Email = ucenik.Email;
            original.Adresa = ucenik.Adresa;
            original.Password = ucenik.Password;
            studioGlumeScenaEntities.SaveChanges();
        }
        public List<Ucenik> getUcenikeByGrupa(string brGrupe)
        {
            int br;
            if(int.TryParse(brGrupe, out br))
            {
                List<Ucenik> ucenici = new List<Ucenik>();
                ucenici = studioGlumeScenaEntities.Ucenik.Where(t => t.Grupa.BrojGrupe == br).ToList();
                return ucenici;
            }
            else
            {
                return null;
            }
        }
    }
}