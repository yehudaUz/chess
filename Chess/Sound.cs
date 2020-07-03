using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Chess {
    public static class Sound {
        private static SoundPlayer soundp = new SoundPlayer();
        private static string sound_path = Path.Combine(System.IO.Path.GetFullPath(@"..\..\"), "Resources").Replace("\\", "/") + "/";
        public static void Play(string name) {
            if (name == "beep")
                Console.Beep();
            else {
                soundp = new SoundPlayer(sound_path + name + ".wav");
                soundp.Play();
            }
        }
    }
}
