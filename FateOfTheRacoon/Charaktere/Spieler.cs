using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FateOfTheRacoon.Charaktere
{
    public class Spieler : Charakter
    {
        public int Level { get; set; }
        public int Erfahrungspunkte { get; set; }
        public Spieler()
        {
            Name = "Coonie";
            Leben = MaxLeben;
            Staerke = 20;
            Level = 1;
            Erfahrungspunkte = 0;
        }

    }
}
