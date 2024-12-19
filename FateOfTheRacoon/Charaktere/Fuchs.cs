using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FateOfTheRacoon.Charaktere
{
    public class Fuchs : Gegner
    {
        public Fuchs()
        {
            Name = "Fuchs";
            Leben = 100;
            Staerke = 10;
            Image = "Fuchs.png";
        }
    }
}
