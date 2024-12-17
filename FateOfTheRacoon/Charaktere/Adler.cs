using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FateOfTheRacoon.Charaktere
{
    public class Adler : Gegner
    {
        public Adler()
        {
            Name = "Adler";
            Leben = 100;
            Staerke = 10;
        }
        

        public void Angreifen()
        {
            Console.WriteLine($"Du greifst den {Name} an.");
            Leben -= Start.spieler.Staerke;
            Thread.Sleep(1000);
            Console.WriteLine($"Der {Name} hat noch {Leben} Lebenspunkte.");
            Thread.Sleep(2000);
            Console.WriteLine($"\nDer {Name} wehrt sich.");
            Start.spieler.Leben -= Staerke;
            Thread.Sleep(1000);
            Console.WriteLine($"Du hast noch {Start.spieler.Leben} Lebenspunkte.");
            Console.ReadKey();
        }


    }
}
