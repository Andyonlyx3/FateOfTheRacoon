using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FateOfTheRacoon.Charaktere;

namespace FateOfTheRacoon.Ebenen
{
    public class ZwischenRaum : Ebene
    {
        public static readonly string[] raum = {"Treppe hoch", "Treppe runter", "Weggabelung", "Leerer Gang" };
        private static readonly Random zufallsGenerator = new Random();
        private int aktuellerIndex = 0;
        private readonly string[] Optionen =
        {
            "Links Lang",
            "Rechts Lang",
        };

        public string AktuellerRaum { get; private set; }
        public ZwischenRaum()
        {
            AktuellerRaum = raum[zufallsGenerator.Next(raum.Length)];
        
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
        }
        private void Auswaehlen(string option)
        {
            switch (option)
            {
                case "Links Lang":
                    
                    break;
                case "Rechts Lang":
                    Console.WriteLine("Du betrittst einen Bossraum!");
                    BossRaum bossRaum = new BossRaum();
                    bossRaum.GegnerInteraktion();
                    break;
                default:

                    break;
            }
        }
        public void Raumaktion()
        {
            Console.Clear();
            switch (AktuellerRaum)
            {
                case "Treppe hoch":
                    Console.Clear();
                    BildAusgabe.MyIMG("TreppeHoch.png");
                    Console.WriteLine("Du siehst eine Treppe die nach oben führt.\nDu gehst die Treppe hinauf und erreichst eine neue Ebene.");
                    Console.ReadKey();
                    break;

                case "Treppe runter":
                    Console.Clear();
                    BildAusgabe.MyIMG("TreppeRunter.png");
                    Console.WriteLine("Du siehst eine Treppe die nach unten führt.\nDu gehst die Treppe hinunter und erreichst einen tiefergelegenen Raum.");
                    Console.ReadKey();
                    break;

                case "Weggabelung":
                    Console.Clear();
                    BildAusgabe.MyIMG("WegeKreuz.png");
                    Console.WriteLine("Du stehst vor einer Weggabelung. \nWähle deinen Weg weise.");
                    ConsoleKey gedrueckt;
                    do
                    {
                        Console.SetCursorPosition(0, 52); // Text wird nach jedem wechsel Überschrieben
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
                    break;

                case "Leerer Gang":
                    Console.Clear();
                    BildAusgabe.MyIMG("LangerGang.png");
                    Console.WriteLine("Du stehst in einem Leeren Gang. \nDu gehst weiter, ohne etwas zu finden.");
                    Console.ReadKey();
                    break;

            }

        }
    }
}
