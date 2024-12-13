using System;
using FateOfTheRacoon.Charaktere;
using FateOfTheRacoon.Gegenstaende;

namespace FateOfTheRacoon
{
    class Program
    {
        static void Main(string[] args)
        {
        
            
            
            Spieler spieler = new Spieler();

            HintergrundMusik.Mp3Abspielen("");

            Start.MenuAnzeigen();


            
        }
    }
}
