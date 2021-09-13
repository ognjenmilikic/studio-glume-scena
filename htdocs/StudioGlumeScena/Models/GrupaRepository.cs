using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudioGlumeScena.Models
{
    public class GrupaRepository
    {
        StudioGlumeScenaEntities studioGlumeScenaEntities = new StudioGlumeScenaEntities();
        public void Edit(Grupa grupa)
        {
            Grupa original = studioGlumeScenaEntities.Grupa.Single(t => t.BrojGrupe == grupa.BrojGrupe);
            original.AktivniZadatak = grupa.AktivniZadatak;
            studioGlumeScenaEntities.SaveChanges();
        }
        public void DeleteZadatak(Grupa grupa)
        {
            Grupa grupa1 = studioGlumeScenaEntities.Grupa.Single(t => t.BrojGrupe == grupa.BrojGrupe);
            grupa1.AktivniZadatak = "";
            studioGlumeScenaEntities.SaveChanges();
        }
    }
}