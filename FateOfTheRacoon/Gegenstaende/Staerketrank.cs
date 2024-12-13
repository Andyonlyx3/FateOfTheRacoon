using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FateOfTheRacoon.Charaktere;

namespace FateOfTheRacoon.Gegenstaende
{
    public class Staerketrank : Item
    {
        
        public Staerketrank(string name, int staerkeBonus)
            : base(name, Itemtyp.Staerketrank)
        {
            Effekte.Add(ItemEffekt.Schaden, staerkeBonus);
        }
        
        // Methode, die den Effekt des Staerketrankes anzeigt
        public void Anwenden(Spieler spieler)
        {
            spieler.Staerke += Effekte[ItemEffekt.Schaden];
            Console.WriteLine($"Der Stärketrank wird angewendet und gibt dir {Effekte[ItemEffekt.Schaden]} zusätzliche Stärke.");
        }

    }
}