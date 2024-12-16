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


        public NPCRaum(Spieler spieler)
        {
            NPC = npcAuswahl[zufallsGenerator.Next(npcAuswahl.Length)];
            Name = NPC.Name;
            Beschreibung = NPC.Beschreibung;
        }

        public void NPCInteraktion(Spieler spieler)
        {
            switch (NPC.Name)
            {
                case "Meister Nuss":
                MeisterNuss meisterNuss = new MeisterNuss();
                meisterNuss.TreffeMeisterNuss(spieler);
                break;
                case "Schildegart":
                Schildegart schildegart = new Schildegart();
                schildegart.TreffeSchildegart(spieler);
                break;
                case "Chimp Anse":
                ChimpAnse chimpAnse = new ChimpAnse();
                chimpAnse.TreffeChimpAnse(spieler);
                break;
                case "Meister Huhu":
                MeisterHuhu meisterHuhu = new MeisterHuhu();
                meisterHuhu.TreffeMeisterHuhu(spieler);
                break;
                    

            }
        }
    }
}
