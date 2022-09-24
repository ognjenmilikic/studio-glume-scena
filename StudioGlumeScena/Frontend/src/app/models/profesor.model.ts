import { Korisnik } from "./korisnik.model";

export interface Profesor {
  id : number;
  ime : string;
  prezime : string;
  brojTelefona : string;
  adresa : string;
  email: string;
  korisnikId: number;
  korisnik: Korisnik
}
