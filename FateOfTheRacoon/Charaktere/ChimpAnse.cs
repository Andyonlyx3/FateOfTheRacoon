﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FateOfTheRacoon.Charaktere
{
    public class ChimpAnse : NPC
    {
        
        public ChimpAnse() 
        {
            Name = "Chimp Anse";
            Beschreibung = "Chimp Anse ist ein Meister der Kampfkünste. Er Trainiert mit dir eine Runde.";
        }
        
        public void TreffeChimpAnse()
        {
            Console.Clear();
            BildAusgabe.MyIMG("ChimpAnse.png");
            Console.WriteLine($"Du triffst auf {Name}.");
            Console.WriteLine(Beschreibung);
            Start.spieler.ErhoeheExp(40);

        }
    }
}
