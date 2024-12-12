using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FateOfTheRacoon.Gegenstaende
{
    public enum Itemtyp     //Ein Enum ist ein Datentyp, der eine benannte Sammlung von konstanten Werten definiert.
    {                       //Hier verwende ich Enums um Variablen vom Typ: "Itemtyp" und "ItemEffekt" zu erstellen. 
        Staerketrank,
        Ruestungstrank,
        Heiltrank
    }

    public enum ItemEffekt
    {
        Schaden,
        Leben,
        Heilung
    }

    public abstract class Item      //abstract wird verwendet um eine Basisklasse zu erstellen, die all ihre Werte an andere Klassen weitervererbt  
    {                               //dadurch wird gewährleistet das die Erbenden Klassen alle Parameter übernehmen müssen. 
        public readonly string Name;

        public readonly Itemtyp Itemtyp;

        protected Dictionary<ItemEffekt, int> Effekte { get; set; }

        public Item(string name, Itemtyp typ)
        {
            Name = name;
            Itemtyp = typ;
            Effekte = new Dictionary<ItemEffekt, int>();
        }

        public override string ToString()
        {
            return $"Name: {Name}, Typ: {Itemtyp}";
        }
    }
}
