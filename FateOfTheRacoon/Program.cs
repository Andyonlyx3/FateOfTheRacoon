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

            Spieler spieler = new Spieler();
            GegnerRaum gegnerRaum = new GegnerRaum(spieler);
            
           
            HintergrundMusik.Mp3Abspielen("");

            Start.MenuAnzeigen();




        }
    }
}
