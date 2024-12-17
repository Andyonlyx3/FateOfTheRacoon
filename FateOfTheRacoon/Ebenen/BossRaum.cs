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

        public BossRaum()
        {
            
            Name = truck.Name;
            Beschreibung = $"Coonie kommt in einen Raum, in dem {truck.Name} auf ihn wartet.";
        }

        // Hauptmethode für die Interaktion mit Truck-Kuhn
        public void GegnerInteraktion()
        {
            ConsoleKey gedrueckt;
            while (truck.Leben > 0 && Start.spieler.Leben > 0)
            {
                Console.Clear();
                Console.WriteLine(Beschreibung);
                Console.WriteLine($"Gegner: {truck.Name} | Leben: {truck.Leben} | Stärke: {truck.Staerke}");
                Console.WriteLine($"Spieler: {Start.spieler.Name} | Leben: {Start.spieler.Leben} | Stärke: {Start.spieler.Staerke}");
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
                    break;
                }
            } 
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
        private void Auswaehlen(string option)
        {
            switch (option)
            {
                case "Angreifen":
                    Angreifen();
                    break;
                case "Fliehen":
                    Fliehen();
                    break;
                default:
                    
                    break;
            }
        }

        // Methode zum Angriff des Spielers auf den Gegner
        private void Angreifen()
        {
            Console.WriteLine($"{Start.spieler.Name} greift {truck.Name} an!");
            truck.Leben -= Start.spieler.Staerke;
            Console.WriteLine($"{truck.Name} verliert {Start.spieler.Staerke} Leben. Aktuelles Leben: {truck.Leben}");

            if (truck.Leben <= 0)
            {
                Console.WriteLine($"{truck.Name} wurde besiegt!");
                Start.spieler.ErhoeheExp(100);
            }
            else
            {
                GegnerAngreifen();
            }
        }

        // Gegner greift den Spieler an
        private void GegnerAngreifen()
        {
            Console.WriteLine($"{truck.Name} greift {Start.spieler.Name} an!");
            Start.spieler.Leben -= truck.Staerke;
            Console.WriteLine($"{Start.spieler.Name} verliert {truck.Staerke} Leben. Aktuelles Leben: {Start.spieler.Leben}");

            if (Start.spieler.Leben <= 0)
            {
                GameOver.GameOverInteraktion();
            }
            else
            {
                Console.ReadKey();
                GegnerInteraktion();
            }
        }

        // Methode zum Fliehen mit einer Wahrscheinlichkeit von 20% 
        private void Fliehen()
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
                GegnerInteraktion();
            }
        }
    }
}
