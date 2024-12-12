using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FateOfTheRacoon.Gegenstaende
{
    internal class Heiltrank : Item
    {
        public Heiltrank(string name, int heilung)
           : base(name, Itemtyp.Heiltrank)
        {
            Effekte.Add(ItemEffekt.Heilung, heilung);
        }

        public void Anwenden()
        {
            Console.WriteLine($"Der {Name} wird angewendet und heilt dein Leben wieder Voll.");
        }
    }
}
