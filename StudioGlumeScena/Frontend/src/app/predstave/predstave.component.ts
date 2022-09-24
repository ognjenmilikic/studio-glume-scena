import { Component, OnInit } from '@angular/core';
import { Predstava } from '../models/predstava.model';

@Component({
  selector: 'app-predstave',
  templateUrl: './predstave.component.html',
  styleUrls: ['./predstave.component.scss']
})
export class PredstaveComponent implements OnInit {

  predstave: Predstava[] = [];

  constructor() { }

  ngOnInit(): void { 
    this.predstave = [
      {
        naziv : "„Autobiografija”",
        rezija : "Vladimir Popadić",
        produkcija : "Miloš Lazić",
        organizator : "Jasmina Senić",
        opis : "Ovo je uzbudljiva priča koja nas uvodi u nušićevski svet i likove kojima se podsmevao s blagonaklonošću, ali govori i o nama i o našem vremenu. \"Autobiografija\" je nešto što je Nušić izabrao da napiše vrlo duhovito, ali i da ne napiše pravu autobiografiju. Nije obuhvatio ceo život, već period do svog venčanja, jer, kako je duhovito rekao posle toga nema života...",
        putanjaDoSlike : "assets/images/predstave/autobiografija-pinned.png"
      },
      {
        naziv : "„Zeko zeko”",
        rezija : "Predrag Stojmenović",
        produkcija : "Miloš Lazić",
        organizator : "Mina Vujović",
        opis : "\"Zeko, Zeko\" je komedija, farsa ali i satira. To je priča o porodici s margina, porodici koja u vremenu krize pokušava da opstane, prolazeći kroz niz komičnih, ali i gorkih situacija.",
        putanjaDoSlike : "assets/images/predstave/zeko-zeko-pinned.png"
      },
      {
        naziv : "„Talas”",
        rezija : "Vladimir Popadić",
        produkcija : "Miloš Lazić",
        organizator : "Mina Vujović",
        opis : "Rajner Venger je profesor u srednjoj školi. Trener je školskog vaterpolo tima, i oženjen je sa Anke, profesorkom u istoj školi. U ponedeljak, dolazeći u školu, dobio je zadatak da tokom jedne školske nedelje organizuje predavanja o autokratiji (drugi izborni predmet pored anarhizma), iako je i sam anarhista. Prvog dana projekta, on postavlja pitanje učenicima, trećoj generaciji rođenoj posle Drugog svetskog rata, da li je moguća obnova diktature u Nemačkoj.",
        putanjaDoSlike : "assets/images/predstave/talas-pinned.png"
      },
      {
        naziv : "„Sedam i po”",
        rezija : "Vladimir Popadić",
        produkcija : "Miloš Lazić",
        organizator : "Mina Vujović, Katarina Dimitrijević",
        opis : "Predstava \"Sedam i po\" je komična priča  koja povezuje 7 različitih priča kroz prizmu 7 smrtnih grehova. U predstavi se govori o svakodnevnici različitih Novobeogradjana, vodjenih svojim strastima i opsednutih svojim slabostima. Svako od njih ima svoj lični osećaj moralnosti, iz čega proizilaze i različita shvatanja iste. Ovo je priča koja govori o nekim od najprisutnijih smrtnih grehova, koji iako jesu gresi, u aspektu modernog doba oni postaju gotovo apsurdni u poplavi mnogo većih civilizacijskih problema i ljudi na njih više gotovo da ni ne obraćaju pažnju. Zato ova predstava poziva na smeh i na komičan način pokusava da nas upozna sa nekim od naših grehova i da nam ukaže na njih i njihov apsurd...",
        putanjaDoSlike : "assets/images/predstave/sedam-i-po-pinned.png"
      },
      {
        naziv : "„Kako je propao rock 'n' roll”",
        rezija : "Predrag Stojmenović",
        produkcija : "Miloš Lazić",
        organizator : "Mina Vujović, Katarina Dimitrijević",
        opis : "Predstava je sačinjena od 3 priče koju čine 3 nezavisna dela; Do izvora dva putića, Nije sve u ljubavi (ima nešto i u lovi) i Ne šalji mi pisma. Do izvora dva putića – Mladić Koma je pokazao da sve može bolje da uradi od svog tate, makar pri tome morao da postane i „nindža“. Ko mrzi narodnjake, naročito novokomponovane, otkriva se na kraju. Nije sve u ljubavi, ima nešto i u lovi – Drakula je opet nastradao. Međutim, ovoga puta glogov kolac, srebrni metak ili krst nisu mu došli glave. Jedna plavuša uspela je da ga liši večnog života (momačkog) i bez pomoći izlaska sunca! Ne šalji mi pisma – Eva šije, Đuro svira. Ono što im ne da mira je Pismo. Ne samo da se ne zna ko ga je napisao, već se ne zna ni kome je upućeno. Kad se sve sazna možda će sve biti kasno za Evu i Đuru.",
        putanjaDoSlike : "assets/images/predstave/kako-je-propao-rnr-pinned.png"
      },
      {
        naziv : "„Majstori, majstori”",
        rezija : "Predrag Stojmenović",
        produkcija : "Miloš Lazić",
        organizator : "Mina Vujović",
        opis : "Ovaj komad je komedija. Nastala je na osnovu adaptacije istoimenog filmskog scenarija Gorana Markovića. Priča ostaje ista, smeštena u jednu beogradsku osnovnu školu, krajem sedamdesetih godina prošlog veka. U školu dolazi mladi i ambiciozni inspektor kako bi istražio navode o seksualnom zlostavljanju profesorke engleskog jezika, za šta je optužen zamenik direktorke škole, a istog dana odvijaju se pripreme za ispraćaj u penziju tetkice Keve. Kroz ova dva događaja upoznajemo lice i naličje školskog sistema, i sistema uopšte.",
        putanjaDoSlike : "assets/images/predstave/majstori-majstori-pinned.png"
      }
    ]
   }
}
