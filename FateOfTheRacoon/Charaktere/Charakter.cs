using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FateOfTheRacoon.Gegenstaende;

namespace FateOfTheRacoon.Charaktere
{
    public abstract class Charakter
    {
        private int maxLeben = 100;

        public int MaxLeben { get => maxLeben; set => maxLeben = value; }

        private string _name;

        public string Name          //Namenszuweisung
        {
            get { return _name; }
            protected set { _name = value; }
        }

        private int _staerke;

        public int Staerke          //Stärkezuweisung
        {
            get { return _staerke; }
            set { _staerke = value; }
        }

        private int _leben;         //Lebenszuweisung

        public int Leben
        {
            get { return _leben; }
            set { _leben = value; }
        }

        
    }
}
