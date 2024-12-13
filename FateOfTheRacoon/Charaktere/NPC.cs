using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FateOfTheRacoon.Charaktere
{
    public abstract class NPC : Charakter
    {
        public string Beschreibung { get; set; }
        public NPC()
        {
            Name = string.Empty;
            Beschreibung = string.Empty;
            Leben = MaxLeben;
            Staerke = 0;
        }
    }
}
