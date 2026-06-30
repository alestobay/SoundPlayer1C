using System;
using System.Runtime.InteropServices;

namespace SoundPlayer1C
{
    [ComVisible(true)]
    [Guid("D93B8B7A-AD13-4B5F-8C1D-1F5F8E9F0101")]
    [ProgId("SoundPlayer1C.Player")]
    public class Player
    {
        private const int SND_ASYNC = 0x0001;
        private const int SND_FILENAME = 0x00020000;
        private const int SND_NODEFAULT = 0x0002;

        private bool initialized = false;

        [DllImport("winmm.dll", CharSet = CharSet.Unicode)]
        private static extern bool PlaySound(string pszSound, IntPtr hmod, int fdwSound);

        public bool Initialize()
        {
            initialized = true;
            return true;
        }

        public bool PlayWav(string fileName)
        {
            if (!initialized)
                initialized = true;

            return PlaySound(fileName, IntPtr.Zero,
                SND_FILENAME | SND_ASYNC | SND_NODEFAULT);
        }

        public bool Stop()
        {
            return PlaySound(null, IntPtr.Zero, 0);
        }

        public bool Release()
        {
            Stop();
            initialized = false;
            return true;
        }
    }
}
