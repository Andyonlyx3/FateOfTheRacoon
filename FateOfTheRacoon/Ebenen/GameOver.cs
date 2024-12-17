using System;
using System.IO; // Für Dateimanipulation
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

        private static readonly string SpeicherPfad = "spielstand.json";

        public GameOver()
        {
            Name = "Game Over";
            Beschreibung = "Du hast verloren.";
        }

        public static void GameOverInteraktion()
        {
            // Lösche den gespeicherten Spielstand
            SpielstandLoeschen();

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
                    Environment.Exit(0); // Beendet das Programm
                    break;
                default:
                    break;
            }
        }

        // Löscht die Spielstand-Datei
        private static void SpielstandLoeschen()
        {
            if (File.Exists(SpeicherPfad))
            {
                try
                {
                    File.Delete(SpeicherPfad);
                    Console.WriteLine("Der gespeicherte Spielstand wurde gelöscht.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fehler beim Löschen des Spielstands: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Kein gespeicherter Spielstand gefunden, der gelöscht werden könnte.");
            }
        }
    }
}
