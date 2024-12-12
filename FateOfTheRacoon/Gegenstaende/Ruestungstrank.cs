using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FateOfTheRacoon.Gegenstaende
{
    public class Ruestungstrank : Item
    {
        public Ruestungstrank(string name, int staerkeBonus)
            : base(name, Itemtyp.Ruestungstrank)
        {
            Effekte.Add(ItemEffekt.Leben, staerkeBonus);
        }

        public void Anwenden()
        {
            Console.WriteLine($"Der {Name} wird angewendet und gibt dir {Effekte[ItemEffekt.Leben]} zusätzliches Leben.");
        }
    }
}
