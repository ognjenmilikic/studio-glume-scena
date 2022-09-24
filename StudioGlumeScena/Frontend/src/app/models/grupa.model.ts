import { Lokacija } from "./lokacija.model"
import { Profesor } from "./profesor.model"
import { Ucenik } from "./ucenik.model";
import { Uzrast } from "./uzrast.model"

export interface Grupa {
  id: number;
  vremeOdrzavanjaCasa: string;
  danOdrzavanjaCasa: string;
  aktivanZadatak: string;
  lokacijaId: number;
  lokacija: Lokacija;
  profesorId: number;
  profesor: Profesor;
  uzrastId: number;
  uzrast: Uzrast;
  ucenik: Ucenik[];
}
