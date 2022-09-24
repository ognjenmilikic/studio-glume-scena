import { Grupa } from "./grupa.model";
import { Korisnik } from "./korisnik.model";

export interface Ucenik {
  id : number;
  ime : string;
  prezime : string;
  godinaRodjenja: string;
  brojTelefona : string;
  adresa : string;
  email: string;
  grupaId: number;
  grupa: Grupa;
  korisnikId: number;
  korisnik: Korisnik;
}
