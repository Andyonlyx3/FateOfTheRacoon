using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FateOfTheRacoon.Charaktere;

namespace FateOfTheRacoon.Ebenen
{
    public class BossRaum : Ebene
    {
        Boss truck = new Boss();
        private static readonly Random zufallsGenerator = new Random();
        private int aktuellerIndex = 0;
        private readonly string[] Optionen =
        {
            "Angreifen",
            "Fliehen",
        };

        public BossRaum(Spieler spieler)
        {
            Name = truck.Name;
            Beschreibung = $"Coonie kommt in einen Raum, in dem {truck.Name} auf ihn wartet.";
        }

        // Hauptmethode für die Interaktion mit Truck-Kuhn
        public void GegnerInteraktion(Spieler spieler)
        {
            ConsoleKey gedrueckt;
            do
            {
                Console.Clear();
                Console.WriteLine(Beschreibung); // Zeigt den Gegner und seine Details an
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
                    Auswaehlen(Optionen[aktuellerIndex], spieler);
                }
            } while (gedrueckt != ConsoleKey.Enter);
        }

        // Zeigt das Menü und hebt die aktuelle Auswahl hervor
        private void ZeigeMenu()
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
        private void Auswaehlen(string option, Spieler spieler)
        {
            switch (option)
            {
                case "Angreifen":
                    Angreifen(spieler);
                    break;
                case "Fliehen":
                    Fliehen(spieler);
                    break;
                default:
                    
                    break;
            }
        }

        // Methode zum Angriff des Spielers auf den Gegner
        private void Angreifen(Spieler spieler)
        {
            Console.WriteLine($"{spieler.Name} greift {truck.Name} an!");
            truck.Leben -= spieler.Staerke;
            Console.WriteLine($"{truck.Name} verliert {spieler.Staerke} Leben. Aktuelles Leben: {truck.Leben}");

            if (truck.Leben <= 0)
            {
                Console.WriteLine($"{truck.Name} wurde besiegt!");
                spieler.ErhoeheExp(100);
            }
            else
            {
                GegnerAngreifen(spieler);
            }
        }

        // Gegner greift den Spieler an
        private void GegnerAngreifen(Spieler spieler)
        {
            Console.WriteLine($"{truck.Name} greift {spieler.Name} an!");
            spieler.Leben -= truck.Staerke;
            Console.WriteLine($"{spieler.Name} verliert {truck.Staerke} Leben. Aktuelles Leben: {spieler.Leben}");

            if (spieler.Leben <= 0)
            {
                GameOver.GameOverInteraktion();
            }
            else
            {
                Console.ReadKey();
                GegnerInteraktion(spieler);
            }
        }

        // Methode zum Fliehen mit einer Wahrscheinlichkeit von 20% 
        private void Fliehen(Spieler spieler)
        {
            bool fluchtErfolgreich = zufallsGenerator.Next(5) == 0;

            if (fluchtErfolgreich)
            {
                Console.WriteLine("Die Flucht war erfolgreich!");
            }
            else
            {
                Console.WriteLine("Die Flucht ist fehlgeschlagen!");
                Console.ReadKey();
                GegnerInteraktion(spieler);
            }
        }
    }
}
