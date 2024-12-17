using System;
using System.IO;
using System.Text.Json;
using FateOfTheRacoon.Charaktere;

namespace FateOfTheRacoon
{
    public static class SpeicherVerwaltung
    {
        private static readonly string SpeicherPfad = "spielstand.json";

        /// <summary>
        /// Speichert den aktuellen Zustand des Spielers in einer Datei.
        /// </summary>
        /// <param name="spieler">Der Spieler, dessen Zustand gespeichert werden soll.</param>
        public static void Speichern()
        {
            try
            {
                string json = JsonSerializer.Serialize(Start.spieler, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(SpeicherPfad, json);
                Console.WriteLine("Spielstand erfolgreich gespeichert!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Speichern: {ex.Message}");
            }
        }

        /// <summary>
        /// Lädt den gespeicherten Zustand des Spielers aus einer Datei.
        /// </summary>
        /// <returns>Ein Spieler-Objekt, das aus der Datei geladen wurde.</returns>
        public static Spieler Laden()
        {
            try
            {
                if (!File.Exists(SpeicherPfad))
                {
                    Console.WriteLine("Kein gespeicherter Spielstand gefunden. Ein neuer Spieler wird erstellt.");
                    return new Spieler();
                }

                string json = File.ReadAllText(SpeicherPfad);
                Spieler spieler = JsonSerializer.Deserialize<Spieler>(json);
                Console.WriteLine("Spielstand erfolgreich geladen!");
                return spieler;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Laden: {ex.Message}");
                Console.WriteLine("Ein neuer Spieler wird erstellt.");
                return new Spieler();
            }
        }
    }
}
