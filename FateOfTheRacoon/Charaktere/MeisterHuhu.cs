using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FateOfTheRacoon.Gegenstaende;

namespace FateOfTheRacoon.Charaktere
{
    public class MeisterHuhu : NPC
    {
        public MeisterHuhu()
        {
            Name = "Meister Huhu";
            Beschreibung = "Die Eule Meister Huhu ist ein Heiler und gibt dir einen Heiltrank";
        }
        
        public void TreffeMeisterHuhu()
        {
            Console.WriteLine($"Du triffst auf {Name}.");
            Console.WriteLine(Beschreibung);
            Heiltrank heiltrank = new Heiltrank("Heiltrank");
            heiltrank.Anwenden();
        }
    }
}
