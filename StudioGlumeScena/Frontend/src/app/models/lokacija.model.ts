import { SafeResourceUrl } from "@angular/platform-browser";

export interface Lokacija {
  id: number;
  naziv: string
  adresa: string
  kontaktTelefon: string
  mapaSource: string;
  mapaSafeSource: SafeResourceUrl;
}
