using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;


namespace FateOfTheRacoon
{
    internal class HintergrundMusik
    {
        private static WaveOutEvent outputDevice;
        private static AudioFileReader audioFile;
        

        public static void Mp3Abspielen(string mp3Pfad)
        {
            //Einstellungen Implementieren
            
          

            mp3Pfad = @"Hintergrundmusik\Dschafar-DifferentStories.wav";
            string hauptOrdner = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string ganzerPfad = Path.Combine(hauptOrdner, mp3Pfad);

            // Audio abspielen in einem separaten Thread
            System.Threading.Thread thread = new System.Threading.Thread(() =>
            {
                using (audioFile = new AudioFileReader(ganzerPfad))
                using (outputDevice = new WaveOutEvent())
                {
                    outputDevice.Init(audioFile);
                    outputDevice.Volume = 0.5f;
                    outputDevice.Play();

                    // Starte den Playback-Thread
                    while (outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        System.Threading.Thread.Sleep(1000); // Verhindere, dass der Thread endet, bevor die Musik vorbei ist
                    }
                }
            });

            thread.IsBackground = true;
            thread.Start();
        }

        // Diese Methode wird aufgerufen, wenn die Lautstärke geändert wird
        public static void LautstaerkeGeaendert(float neueLautstaerke)
        {
            if (outputDevice != null)
            {
                if (neueLautstaerke > 1) neueLautstaerke = 1;
                else if (neueLautstaerke < 0) neueLautstaerke = 0;
                outputDevice.Volume = neueLautstaerke;
                // Lautstärke des AudioPlayers anpassen
            }
        }

        // Methode zum Handling der Pfeiltasten-Ereignisse
        public static void PfeiltastenVerarbeiten(ConsoleKey key)
        {
            if (key == ConsoleKey.RightArrow)
            {
                Einstellungen.LautstaerkeErhoehen(); // Lautstärke erhöhen
            }
            else if (key == ConsoleKey.LeftArrow)
            {
                Einstellungen.LautstaerkeVerringern(); // Lautstärke verringern
            }
        }
    }
}

