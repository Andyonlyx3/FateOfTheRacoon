﻿using System;
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
            Staerke = 10;
            Image = "Kobra.png";
        }
       
        public void Angreifen()
        {
            Console.WriteLine($"Du greifst die {Name} an.");
            Leben -= Start.spieler.Staerke;
            Thread.Sleep(1000);
            Console.WriteLine($"Die {Name} hat noch {Leben} Lebenspunkte.");
            Thread.Sleep(2000);
            Console.WriteLine($"\nDie {Name} wehrt sich.");
            Start.spieler.Leben -= Staerke;
            Thread.Sleep(1000);
            Console.WriteLine($"Du hast noch {Start.spieler.Leben} Lebenspunkte.");
            Console.ReadKey();
        }

        
    }
}
