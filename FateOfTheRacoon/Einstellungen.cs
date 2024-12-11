using System;

namespace FateOfTheRacoon
{
    public class Einstellungen
    {
        public static float Lautstaerke = 0.5f;


   
        public static void LautstaerkeErhoehen()
        {
            if (Lautstaerke < 1.0)
            {
                Lautstaerke += 0.1f; // Erhöht die Lautstärke um 10%
                HintergrundMusik.LautstaerkeGeaendert(Lautstaerke);
            }
        }

 
        public static void LautstaerkeVerringern()
        {
            if (Lautstaerke > 0)
            {
                Lautstaerke -= 0.1f; // Verringert die Lautstärke um 10%
                HintergrundMusik.LautstaerkeGeaendert(Lautstaerke);
            }
        }


        public static void SoundEinstellung()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
           
            int aktuelleLautstaerke = (int)(Einstellungen.Lautstaerke * 100);

            

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Drücke die Pfeiltasten, um die Lautstärke zu ändern.");
                Console.WriteLine($"Aktuelle Lautstärke:{aktuelleLautstaerke}%");
                Console.WriteLine(" '->' : Lautstärke erhöhen");
                Console.WriteLine(" '<-' : Lautstärke verringern");
                Console.WriteLine("'Esc' bringt dich ins Startmenü zurück.");
                
                var key = Console.ReadKey(intercept: true).Key;
                
                if (key == ConsoleKey.RightArrow && aktuelleLautstaerke < 100)
                {
                    HintergrundMusik.PfeiltastenVerarbeiten(key);
                    aktuelleLautstaerke += 10;
                }
                else if (key == ConsoleKey.LeftArrow && aktuelleLautstaerke > 0)
                {
                    HintergrundMusik.PfeiltastenVerarbeiten(key);
                    aktuelleLautstaerke -= 10;
                }
                else if (key == ConsoleKey.Escape)
                {
                    Start.MenuAnzeigen();
                    break;
                }


            }
        }
    }
}
