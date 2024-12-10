using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace FateOfTheRacoon
{
    internal class HintergrundMusik
    {
        public static void Mp3Abspielen(string mp3Pfad)
        {
            string hauptOrdner = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            mp3Pfad = @"Hintergrundmusik\Moana.wav";
            string ganzerPfad = Path.Combine(hauptOrdner, mp3Pfad);
            using (var audioFile = new AudioFileReader(ganzerPfad))
            using (var outputDevice = new WaveOutEvent())
            {
                outputDevice.Init(audioFile);
                outputDevice.Play();
                while (outputDevice.PlaybackState == PlaybackState.Playing)
                {
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
