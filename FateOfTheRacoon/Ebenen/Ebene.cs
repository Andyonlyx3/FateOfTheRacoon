using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FateOfTheRacoon.Ebenen
{
    public class Ebene
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            protected set { _name = value; }
        }
        
        private string _beschreibung;

        public string Beschreibung
        {
            get { return _beschreibung; }
            set { _beschreibung = value; }
        }

    }
}
