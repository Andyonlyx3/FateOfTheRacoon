using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FateOfTheRacoon.Charaktere
{
    public class Schlange : Gegner
    {
        public Schlange()
        {
            Name = "Kobra";
            Leben = 100;
            Staerke = 20;
        }

        public void Angreifen(Spieler spieler)
        {
            Console.WriteLine($"Du greifst die {Name} an.");
            Leben -= spieler.Staerke;
            Thread.Sleep(1000);
            Console.WriteLine($"Die {Name} hat noch {Leben} Lebenspunkte.");
            Thread.Sleep(2000);
            Console.WriteLine($"\nDie {Name} wehrt sich.");
            spieler.Leben -= Staerke;
            Thread.Sleep(1000);
            Console.WriteLine($"Du hast noch {spieler.Leben} Lebenspunkte.");
            Console.ReadKey();
        }

        
    }
}
