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
            Name = Gegner.Name;
            Beschreibung = $"Coonie kommt in einen Raum, in dem ein/e {Name} auf ihn wartet.";
        }

        public void GegnerInteraktion()
        {
            Gegner.Leben = Gegner.MaxLeben;
            Console.Clear();
            BildAusgabe.MyIMG(Gegner.Image);
            ConsoleKey gedrueckt;
            while (Gegner.Leben > 0 && Start.spieler.Leben > 0)
            {
                Console.SetCursorPosition(0, 50);
                Console.WriteLine(Beschreibung);
                Console.WriteLine($"Gegner: {Gegner.Name} | Leben: {Gegner.Leben} | Stärke: {Gegner.Staerke} ");
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
                        break; // Flucht erfolgreich -> Schleife verlassen
                }
                
            }

            if (Start.spieler.Leben <= 0)
            {
                Console.WriteLine("Coonie wurde besiegt...");
                GameOver.GameOverInteraktion();
            }
        }

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

        private void Angreifen()
        {
            Console.WriteLine($"{Start.spieler.Name} greift {Gegner.Name} an!");
            Gegner.Leben -= Start.spieler.Staerke;
            Console.WriteLine($"{Gegner.Name} verliert {Start.spieler.Staerke} Leben. Aktuelles Leben: {Gegner.Leben}");

            if (Gegner.Leben <= 0)
            {
                Console.WriteLine($"{Gegner.Name} wurde besiegt!");
                Start.spieler.ErhoeheExp(20);
            }
            else
            {
                GegnerAngreifen();
            }

            Console.ReadKey();
            Console.SetCursorPosition(0, 55);
            Console.WriteLine("                        \n                                                       \n                              \n                                                    ");

        }

        private void GegnerAngreifen()
        {
            Console.WriteLine($"{Gegner.Name} greift {Start.spieler.Name} an!");
            Start.spieler.Leben -= Gegner.Staerke;
            Console.WriteLine($"{Start.spieler.Name} verliert {Gegner.Staerke} Leben. Aktuelles Leben: {Start.spieler.Leben}");
        }

        private bool Fliehen()
        {
            bool fluchtErfolgreich = zufallsGenerator.Next(2) == 0; // 50% Chance auf Erfolg

            if (fluchtErfolgreich)
            {
                Console.WriteLine("Die Flucht war erfolgreich!");
                return true; // Flucht erfolgreich
            }
            else
            {
                Console.WriteLine("Die Flucht ist fehlgeschlagen!");
                GegnerAngreifen(); // Gegner greift an, wenn Flucht misslingt
                return false; // Flucht nicht erfolgreich
            }
        }
    }
}
