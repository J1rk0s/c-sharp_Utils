using System;
using System.Threading;

namespace Utils {
    public static class MusicConsole {

        public ref struct PianoChords {
            public static int C0 = 16;
            public static int Cs0 = 17;
            public static int D0 = 18;
            public static int Ds0 = 19;
            public static int E0 = 20;
            public static int F0 = 21;
            public static int Fs0 = 23;
            public static int G0 = 24;
            public static int Gs0 = 25;
            public static int A0 = 27;
            public static int As0 = 29;
            public static int B0 = 30;
            public static int C1 = 32;
            public static int Cs1 = 34;
            public static int D1 = 36;
            public static int Ds1 = 38;
            public static int E1 = 41;
            public static int F1 = 43;
            public static int Fs1 = 46;
            public static int G1 = 49;
            public static int Gs1 = 51;
            public static int A1 = 55;
            public static int As1 = 58;
            public static int B1 = 61;
            public static int C2 = 65;
            public static int Cs2 = 69;
            public static int D2 = 73;
            public static int Ds2 = 77;
            public static int E2 = 82;
            public static int F2 = 87;
            public static int Fs2 = 92;
            public static int G2 = 98;
            public static int Gs2 = 103;
            public static int A2 = 110;
            public static int As2 = 116;
            public static int B2 = 123;
            public static int C3 = 130;
            public static int Cs3 = 138;
            public static int D3 = 146;
            public static int Ds3 = 155;
            public static int E3 = 164;
            public static int F3 = 174;
            public static int Fs3 = 185;
            public static int G3 = 196;
            public static int Gs3 = 207;
            public static int A3 = 220;
            public static int As3 = 233;
            public static int B3 = 246;
            public static int C4 = 261;
            public static int Cs4 = 277;
            public static int D4 = 293;
            public static int Ds4 = 311;
            public static int E4 = 329;
            public static int F4 = 349;
            public static int Fs4 = 369;
            public static int G4 = 392;
            public static int Gs4 = 415;
            public static int A4 = 440;
            public static int As4 = 466;
            public static int B4 = 493;
            public static int C5 = 523;
            public static int Cs5 = 554;
            public static int D5 = 587;
            public static int Ds5 = 622;
            public static int E5 = 659;
            public static int F5 = 698;
            public static int Fs5 = 739;
            public static int G5 = 783;
            public static int Gs5 = 830;
            public static int A5 = 880;
            public static int As5 = 932;
            public static int B5 = 987;
            public static int C6 = 1046;
            public static int Cs6 = 1108;
            public static int D6 = 1174;
            public static int Ds6 = 1244;
            public static int E6 = 1318;
            public static int F6 = 1396;
            public static int Fs6 = 1479;
            public static int G6 = 1567;
            public static int Gs6 = 1661;
            public static int A6 = 1760;
            public static int As6 = 1864;
            public static int B6 = 1975;
            public static int C7 = 2093;
            public static int Cs7 = 2217;
            public static int D7 = 2349;
            public static int Ds7 = 2489;
            public static int E7 = 2637;
            public static int F7 = 2793;
            public static int Fs7 = 2959;
            public static int G7 = 3135;
            public static int Gs7 = 3322;
            public static int A7 = 3520;
            public static int As7 = 3729;
            public static int B7 = 3951;
            public static int C8 = 4186;
            public static int Cs8 = 4434;
            public static int D8 = 4698;
            public static int Ds8 = 4978;
            public static int Wait = 0;
        }
        public static void PlaySong(int[] song, int beepInterval = 300, int sleepInterval = 200, int sleepDelayOnWait = 500) {
            foreach (int c in song) {
                if (c == PianoChords.Wait) {
                    Thread.Sleep(sleepDelayOnWait);
                    continue;
                }
                Console.Beep(c, beepInterval);
                Thread.Sleep(sleepInterval);
            }
        }

        public static float Wavelength(float frequency) => (float) (MathUtils.c / frequency);
        public static float Frequency(float wavelength) => (float) (MathUtils.c / wavelength);
    }
}