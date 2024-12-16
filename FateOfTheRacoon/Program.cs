using System;
using FateOfTheRacoon.Charaktere;
using FateOfTheRacoon.Ebenen;
using FateOfTheRacoon.Gegenstaende;

namespace FateOfTheRacoon
{
    class Program
    {
        static void Main(string[] args)
        {
        
            GegnerRaum gegnerRaum = new GegnerRaum();
            
            Spieler spieler = new Spieler();

            HintergrundMusik.Mp3Abspielen("");

            Start.MenuAnzeigen();




        }
    }
}
