using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FateOfTheRacoon.Gegenstaende;

namespace FateOfTheRacoon.Charaktere
{
    public class MeisterNuss : NPC
    {
        public MeisterNuss()
        {
            Name = "Meister Nuss";
            Beschreibung = "Das Eichhörnchen Meister Nuss ist ein Waffenexperte und gibt dir einen Stärketrank";
        }

        public void TreffeMeisterNuss(Spieler spieler)
        {
            Console.WriteLine($"Du triffst auf {Name}.");
            Console.WriteLine(Beschreibung);
            Staerketrank staerketrank = new Staerketrank("Stärketrank", 20);
            staerketrank.Anwenden(spieler);
        }
    }
}
