using System;
using FateOfTheRacoon.Charaktere;

namespace FateOfTheRacoon.Ebenen
{
    public class GegnerRaum : Ebene
    {
        private static readonly Gegner[] gegnerAuswahl = { new Fuchs(), new Adler(), new Schlange() };
        private static readonly Random zufallsGenerator = new Random();
        public Gegner Gegner { get; private set; }

        private int aktuellerIndex = 0;
        private readonly string[] Optionen =
        {
            "Angreifen",
            "Fliehen",
        };

        public GegnerRaum()
        {
            Gegner = gegnerAuswahl[zufallsGenerator.Next(gegnerAuswahl.Length)];
            Beschreibung = $"Du kommst in einen Raum, in dem ein/e {Gegner.Name} auf dich wartet.";
        }

        // Hauptmethode für die Interaktion mit dem Gegner
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
                    Fliehen();
                    break;
                default:
                    Console.WriteLine("Ungültige Option.");
                    break;
            }
        }

        // Methode zum Angriff des Spielers auf den Gegner
        private void Angreifen(Spieler spieler)
        {
            Console.WriteLine($"{spieler.Name} greift {Gegner.Name} an!");
            Gegner.Leben -= spieler.Staerke;
            Console.WriteLine($"{Gegner.Name} verliert {spieler.Staerke} Leben. Aktuelles Leben: {Gegner.Leben}");

            if (Gegner.Leben <= 0)
            {
                Console.WriteLine($"{Gegner.Name} wurde besiegt!");
                spieler.ErhoeheExp(20);
            }
            else
            {
                GegnerAngreifen(spieler);
            }
        }

        // Gegner greift den Spieler an
        private void GegnerAngreifen(Spieler spieler)
        {
            Console.WriteLine($"{Gegner.Name} greift {spieler.Name} an!");
            spieler.Leben -= Gegner.Staerke;
            Console.WriteLine($"{spieler.Name} verliert {Gegner.Staerke} Leben. Aktuelles Leben: {spieler.Leben}");

            if (spieler.Leben <= 0)
            {
                Console.WriteLine($"{spieler.Name} wurde besiegt! Spiel vorbei.");
            }
            else
            {
                Console.ReadKey();
                GegnerInteraktion(spieler);
            }
        }

        // Methode zum Fliehen
        private void Fliehen()
        {
            bool fluchtErfolgreich = zufallsGenerator.Next(2) == 0;

            if (fluchtErfolgreich)
            {
                Console.WriteLine("Die Flucht war erfolgreich!");
            }
            else
            {
                Console.WriteLine("Die Flucht ist fehlgeschlagen!");
            }
        }
    }
}
