import { KorisnickaUloga } from "./korisnicka-uloga.model";

export interface Korisnik {
   id: number;
   email: string;
   password: string;
   korisnickaUloga: KorisnickaUloga;
   korisnickaUlogaId: number;
}
