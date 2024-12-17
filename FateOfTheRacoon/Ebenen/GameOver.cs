using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FateOfTheRacoon.Charaktere;

namespace FateOfTheRacoon.Ebenen
{
    public class GameOver : Ebene
    {
        private static int aktuellerIndex = 0;
        private static readonly string[] Optionen =
        {
            "Zurück zum Hauptmenü",
            "Spiel Beenden",
        };
        public  GameOver() 
        {
            Name = "Game Over";
            Beschreibung = "Du hast verloren.";
        }
        public static void GameOverInteraktion()
        {
            ConsoleKey gedrueckt;
            do
            {
                Console.Clear();
                Console.WriteLine("Coonie ist gestorben.\nWas möchtest du nun tun?"); // Zeigt an das du gestorben bist.
                ZeigeMenu();
                gedrueckt = Console.ReadKey(true).Key;

                if (gedrueckt == ConsoleKey.UpArrow)
                {
                    aktuellerIndex = (aktuellerIndex - 1 + Optionen.Length) % Optionen.Length;
                }
                else if (gedrueckt == ConsoleKey.DownArrow)
                {
                    aktuellerIndex = (aktuellerIndex + 1) % Optionen.Length;
                }
                else if (gedrueckt == ConsoleKey.Enter)
                {
                    Auswaehlen(Optionen[aktuellerIndex]);
                }
            } while (gedrueckt != ConsoleKey.Enter);
        }

        // Zeigt das Menü und hebt die aktuelle Auswahl hervor
        private static void ZeigeMenu()
        {
            for (int i = 0; i < Optionen.Length; i++)
            {
                if (i == aktuellerIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ResetColor();
                }

                Console.WriteLine(Optionen[i]);
            }

            Console.ResetColor();
        }

        // Führt die ausgewählte Aktion aus
        private static void Auswaehlen(string option)
        {
            switch (option)
            {
                case "Zurück zum Hauptmenü":
                    
                    Start.MenuAnzeigen();
                    break;
                case "Spiel Beenden":
                    break;
                default:

                    break;
            }
        }

    }
}
