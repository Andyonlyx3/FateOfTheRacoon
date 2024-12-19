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
            truck.Leben = 500;
            Console.Clear();
            BildAusgabe.MyIMG("TruckKun.png");
            ConsoleKey gedrueckt;
            while (truck.Leben > 0 && Start.spieler.Leben > 0)
            {
                Console.SetCursorPosition(0, 50);
                Console.WriteLine(Beschreibung);
                Console.WriteLine($"Gegner: {truck.Name} | Leben: {truck.Leben} | Stärke: {truck.Staerke}");
                Console.WriteLine($"Spieler: {Start.spieler.Name} | Leben: {Start.spieler.Leben} | Stärke: {Start.spieler.Staerke} ");
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
                    if (Auswaehlen(Optionen[aktuellerIndex]))
                            break;
                }
                
            }
            if (Start.spieler.Leben <= 0)
            {
                Console.WriteLine("Coonie wurde besiegt...");
                GameOver.GameOverInteraktion();
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
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine(Optionen[i]);
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        // Führt die ausgewählte Aktion aus
        private bool Auswaehlen(string option)
        {
            switch (option)
            {
                case "Angreifen":
                    Angreifen();
                    return false;
                case "Fliehen":
                    return Fliehen();
                default:
                    return false;
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

            Console.ReadKey();
            Console.SetCursorPosition(0, 55);
            Console.WriteLine("                              \n                                                             \n                                    \n                                                          ");

        }

        // Gegner greift den Spieler an
        private void GegnerAngreifen()
        {
            Console.WriteLine($"{truck.Name} greift {Start.spieler.Name} an!");
            Start.spieler.Leben -= truck.Staerke;
            Console.WriteLine($"{Start.spieler.Name} verliert {truck.Staerke} Leben. Aktuelles Leben: {Start.spieler.Leben}");
        
        }

        // Methode zum Fliehen mit einer Wahrscheinlichkeit von 20% 
        private bool Fliehen()
        {
            bool fluchtErfolgreich = zufallsGenerator.Next(5) == 0;

            if (fluchtErfolgreich)
            {
                Console.WriteLine("Die Flucht war erfolgreich!");
                return true;
            }
            else
            {
                Console.WriteLine("Die Flucht ist fehlgeschlagen!");
                GegnerAngreifen();
                return false;
            }
        }
    }
}
