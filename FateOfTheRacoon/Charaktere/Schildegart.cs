using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FateOfTheRacoon.Gegenstaende;

namespace FateOfTheRacoon.Charaktere
{
    public class Schildegart : NPC
    {
        public Schildegart()
        {
            Name = "Schildegart";
            Beschreibung = "Die alte Schildkröte Schildegart ist eine Schamanin und gibt dir einen Lebenstrank";
        }
        
        public void TreffeSchildegart()
        {
            Console.WriteLine($"Du triffst auf {Name}.");
            Console.WriteLine(Beschreibung);
            Ruestungstrank ruestungstrank = new Ruestungstrank("Lebenstrank", 20);
            ruestungstrank.Anwenden();
        }
    }
}
