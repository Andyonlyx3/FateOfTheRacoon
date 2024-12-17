using System;
using FateOfTheRacoon.Charaktere;
using FateOfTheRacoon.Ebenen;

namespace FateOfTheRacoon
{
    public static class RaumAuswahl
    {
        private static readonly Random zufallsGenerator = new Random();

        public static void ZufallsRaum()
        {
            bool imSpiel = true; // Kontrollvariable für die Schleife

            while (imSpiel)
            {
                int zufall = zufallsGenerator.Next(0, 100); // Zufall von 0 bis 99

                if (zufall <= 1) // 2 % Wahrscheinlichkeit
                {
                    BetreteBossRaum();
                }
                else if (zufall >= 2 && zufall <= 21) // 20 % Wahrscheinlichkeit
                {
                    BetreteGegnerRaum();
                }
                else if (zufall >= 22 && zufall <= 56) // 35 % Wahrscheinlichkeit
                {
                    BetreteNPCRaum();
                }
                else // 43 % Wahrscheinlichkeit
                {
                    BetreteZwischenRaum();
                }

                // Option, das Spiel zu beenden
                Console.WriteLine("\nMöchtest du weitermachen? (Enter klicken zum weitermachen, Tippe 'n' und bestätige zum Speichern und Beenden.");
                string eingabe = Console.ReadLine()?.ToLower();

                if (eingabe == "n" || eingabe == "nein")
                {
                    Console.WriteLine("Das Abenteuer endet hier. Bis zum nächsten Mal!");
                    SpeicherVerwaltung.Speichern();
                    imSpiel = false;
                }
            }
        }

        private static void BetreteBossRaum()
        {
            Console.WriteLine("Du betrittst einen Bossraum!");
            BossRaum bossRaum = new BossRaum();
            bossRaum.GegnerInteraktion();
        }

        private static void BetreteGegnerRaum()
        {
            Console.WriteLine("Du betrittst einen Raum mit einem Gegner!");
            GegnerRaum gegnerRaum = new GegnerRaum();
            gegnerRaum.GegnerInteraktion();
        }

        private static void BetreteNPCRaum()
        {
            Console.WriteLine("Du betrittst einen Raum mit einem NPC!");
            NPCRaum npcRaum = new NPCRaum();
            npcRaum.NPCInteraktion();
        }

        private static void BetreteZwischenRaum()
        {
            Console.WriteLine("Du betrittst einen Zwischenraum.");
            ZwischenRaum zwischenRaum = new ZwischenRaum();
            zwischenRaum.Raumaktion();
        }
    }
}
