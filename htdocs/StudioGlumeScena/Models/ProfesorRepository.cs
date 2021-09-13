using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudioGlumeScena.Models
{
    public class ProfesorRepository
    {
        private StudioGlumeScenaEntities studioGlumeScenaEntities = new StudioGlumeScenaEntities();

        public bool userExists(string email, string password)
        {
            return studioGlumeScenaEntities.Profesor.Any(t => t.Email == email && t.Password == password);
        }
        public Profesor getProfesorByIme(string ime)
        {
            if (studioGlumeScenaEntities.Profesor.Any(t => t.Ime == ime))
            {
                Profesor profesor = studioGlumeScenaEntities.Profesor.Single(t => t.Ime == ime);
                return profesor;
            }
            else
                return null;
        }
        public IEnumerable<Grupa> getGrupeForProfesor(string email)
        {
            Profesor profesor = studioGlumeScenaEntities.Profesor.Single(t => t.Email == email);
            List<Grupa> grupe = new List<Grupa>();
            foreach (Grupa grupa in studioGlumeScenaEntities.Grupa.Where(t => t.JMBGp == profesor.JMBGp))
                grupe.Add(grupa);
            return grupe;
        }
    }
}