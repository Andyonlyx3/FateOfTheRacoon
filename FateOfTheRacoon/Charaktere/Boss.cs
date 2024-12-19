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
    }
}
