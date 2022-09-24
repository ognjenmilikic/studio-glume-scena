using AutoMapper;
using StudioGlumeScena.BusinessLogic.ViewModels;
using StudioGlumeScena.DataAccess.Models;

namespace StudioGlumeScena.BusinessLogic.MappingProfile
{
    public class StudioGlumeScenaProfile : Profile
    {
        public StudioGlumeScenaProfile()
        {
            CreateMap<PrijavaZaUpis, PrijavaZaUpisVM>().ReverseMap();
            CreateMap<Lokacija, LokacijaVM>().ReverseMap();
            CreateMap<Profesor, ProfesorVM>().ReverseMap();
            CreateMap<Ucenik, UcenikVM>().ReverseMap();
            CreateMap<Uzrast, UzrastVM>().ReverseMap();
            CreateMap<Grupa, GrupaVM>().ReverseMap();
            CreateMap<Korisnik, KorisnikVM>().ReverseMap();
            CreateMap<KorisnickaUloga, KorisnickaUlogaVM>().ReverseMap();
        }
    }
}
