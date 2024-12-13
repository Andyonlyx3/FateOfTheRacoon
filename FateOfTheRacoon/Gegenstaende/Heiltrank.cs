using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FateOfTheRacoon.Charaktere;

namespace FateOfTheRacoon.Gegenstaende
{
    internal class Heiltrank : Item
    {
        public Heiltrank(string name)
           : base(name, Itemtyp.Heiltrank)
        {
            Effekte.Add(ItemEffekt.Heilung, 0);
        }

        public void Anwenden(Spieler spieler)
        {
            spieler.Leben = spieler.MaxLeben;
            Console.WriteLine($"Der {Name} wird angewendet und heilt dein Leben wieder Voll.");
        }
    }
}
