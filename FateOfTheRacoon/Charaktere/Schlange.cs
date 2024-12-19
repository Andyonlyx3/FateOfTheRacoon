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
            Staerke = 10;
            Image = "Kobra.png";
        }
    }
}
