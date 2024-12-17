using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FateOfTheRacoon.Charaktere;

namespace FateOfTheRacoon.Ebenen
{
    public class NPCRaum : Ebene
    {
        private static readonly NPC[] npcAuswahl = { new ChimpAnse(), new MeisterHuhu(), new MeisterNuss(), new Schildegart() };
        private static readonly Random zufallsGenerator = new Random();

        public NPC NPC {  get; private set; }


        public NPCRaum()
        {
            NPC = npcAuswahl[zufallsGenerator.Next(npcAuswahl.Length)];
            Name = NPC.Name;
            Beschreibung = NPC.Beschreibung;
        }
        
        public void NPCInteraktion()
        {
            Console.Clear();
            switch (NPC)
            {
                case MeisterNuss meisterNuss:
                    meisterNuss.TreffeMeisterNuss();
                    break;

                case Schildegart schildegart:
                    schildegart.TreffeSchildegart();
                    break;

                case ChimpAnse chimpAnse:
                    chimpAnse.TreffeChimpAnse();
                    break;

                case MeisterHuhu meisterHuhu:
                    meisterHuhu.TreffeMeisterHuhu();
                    break;

                default:
                    Console.WriteLine("Unbekannter NPC.");
                    break;
            }
        }
    }
}
