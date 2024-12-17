using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FateOfTheRacoon.Charaktere
{
    public class Boss : Gegner
    {
        public Boss()
        {
            Name = "Truck-Kun";
            Leben = 500;
            Staerke = 40;
        }
       
        public void Angreifen()
        {
            Console.WriteLine($"Du greifst {Name} an.");
            Leben -= Start.spieler.Staerke;
            Thread.Sleep(1000);
            Console.WriteLine($"{Name} hat noch {Leben} Lebenspunkte.");
            Thread.Sleep(2000);
            Console.WriteLine($"\n{Name} wehrt sich.");
            Start.spieler.Leben -= Staerke;
            Thread.Sleep(1000);
            Console.WriteLine($"Du hast noch {Start.spieler.Leben} Lebenspunkte.");
            Console.ReadKey();
        }

    }
}
