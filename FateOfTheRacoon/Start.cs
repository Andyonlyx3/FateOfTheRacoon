using System;
using FateOfTheRacoon.Charaktere;
using FateOfTheRacoon.Ebenen;

namespace FateOfTheRacoon
{
    internal class Start
    {
        private static int aktuellerIndex = 0; // Der Index der aktuell ausgewählten Option
        private static readonly string[] Optionen =
        {
            "Neues Spiel",
            "Spielstand Laden",
            "Einstellungen",
            "Spiel Beenden"
        };

        public static void MenuAnzeigen()
        {
            ConsoleKey gedrueckt;
            do
            {
                Console.Clear(); // Das Konsolenfenster wird bei jeder Schleife gelöscht
                ZeigeMenu();
                gedrueckt = Console.ReadKey(true).Key; // Die gedrückte Taste wird abgefragt

                // Pfeiltasten verarbeiten
                if (gedrueckt == ConsoleKey.UpArrow)
                {
                    aktuellerIndex = (aktuellerIndex - 1 + Optionen.Length) % Optionen.Length; // Nach oben navigieren
                }
                else if (gedrueckt == ConsoleKey.DownArrow)
                {
                    aktuellerIndex = (aktuellerIndex + 1) % Optionen.Length; // Nach unten navigieren
                }
                // Bestätigen der Auswahl mit Enter
                else if (gedrueckt == ConsoleKey.Enter)
                {
                    Auswaehlen(Optionen[aktuellerIndex]);
                    break; // Nach Auswahl das Menü beenden
                }
              

            } while (gedrueckt != ConsoleKey.Enter); // Solange Enter nicht gedrückt wurde, bleibt das Menü aktiv
        }

        // Diese Methode zeigt das Menü und hebt die aktuelle Auswahl hervor
        private static void ZeigeMenu()
        {
            for (int i = 0; i < Optionen.Length; i++)
            {
                if (i == aktuellerIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green; // Die aktuelle Auswahl in grün hervorheben
                }
                else
                {
                    Console.ResetColor();
                }

                Console.WriteLine(Optionen[i]);
            }
        }

        // Diese Methode führt die gewählte Option aus
        public static NPCRaum npcRaum = new NPCRaum(spieler);

        public static Spieler spieler = new Spieler();
        private static void Auswaehlen(string option)
        {
            switch (option)
            {
                case "Neues Spiel":
                    npcRaum.NPCInteraktion(spieler);
                    break;
                case "Spielstand Laden":
                    Console.WriteLine("Spielstand wird geladen.");
                    // Hier wird die Option zum Laden des Spielstands eingefügt
                    break;
                case "Einstellungen":
                    Einstellungen.SoundEinstellung();
                    break;
                case "Spiel Beenden":
                    Console.WriteLine("Spiel wird beendet...");
                    Environment.Exit(0); // Das Spiel beenden
                    break;
                default:
                    break;
            }
        }
    }
}
