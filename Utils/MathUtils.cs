using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;

namespace Utils {
    public static class MathUtils {

        public const double GoldenRatio = 1.618033988;
        
        [Description("BoltzmannConstant")]
        public static readonly double k = 1.380649 * Math.Pow(10, -23);
    
        [Description("Speed of sound")]
        public static readonly double c = 3 * Math.Pow(10, 8);
        
        public static BigInteger Factorial(int A) => A <= 0 ? 1 : A * Factorial(A - 1);

        public static int CombinationNumber(int A, int B) => checked((int)(Factorial(A) / (Factorial(A - B) * Factorial(B))));
        
        public static int QuadraticEquationDiscriminant(int a, int b, int c_) => (int)Math.Pow(b,2) - 4 * a * c_;

        public static (ulong iterations, ulong highestNumberReached) CollatzConjecture(ulong startingNumber) {
            ulong iterations = 0;
            ulong max = 0;
            while (startingNumber != 1) {
                if (startingNumber % 2 == 0) {
                    startingNumber /= 2;
                }
                else if(startingNumber % 2 != 0){
                    startingNumber = startingNumber * 3 + 1;
                }
                ulong temp = startingNumber;
                if (temp > max) {
                    max = temp;
                }
                iterations++;
            }

            return (iterations, max);
        }

        public static IEnumerable<int> FibbonacciSequence(int endNumber, int startingNumber = 0) {
            int a = 0;
            int b = 1;
            for (int i = startingNumber; i < endNumber; i++) {
                int c_ = a + b;
                b = a;
                a = c_;
                yield return c_;
            }
        }

        public static double RadianToDegrees(double radian) => (radian * 180) / Math.PI;
        public static double DegreesToRadians(double degree) => (degree * Math.PI) / 180;
        public static float FahrenhaitToCelsius(float fahrenhait) => (float) ((fahrenhait - 32) / 1.8);
        public static float CelsiusToFahrenhait(float celsius) => (float) (celsius * 1.8 + 32);
        
        public static ulong BinetFormula(int nthNumber) => checked((ulong) ((Math.Pow((1 + Math.Sqrt(5)) / 2, nthNumber) - Math.Pow((1 - Math.Sqrt(5)) / 2, nthNumber)) / Math.Sqrt(5)));

        public static int EuclideanDistance(int x1, int x2, int y1, int y2) => (int)Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));

        public static double PropabilityWithCombinationNumber(int a, int b) => a / CombinationNumber(a, b);

        public static bool IsPrime(this int a) {
            switch (a) { case 2: case 3: return true; }
            if (a <= 1 || a % 2 == 0) return false;
            int aX = (int)Math.Ceiling(Math.Sqrt(a));
            for (int i = 2; i <= aX; ++i) {
                if (a % i == 0) return false;
            }
            return true;
        }
        
        public static int[] LevenshteinDistance(string a, string b) {
            List<int> indexes = new List<int>();
            for (int i = 0; i < a.Length; i++) {
                if (a[i] != b[i]) {
                    indexes.Add(i);
                }
                if (i > b.Length - 1|| i > a.Length - 1) {
                    break;
                }
            }
            return indexes.ToArray();
        } 

        public static BigInteger FermatNumber(int n) => (BigInteger)Math.Pow(2, Math.Pow(2, n)) + 1;

        public static int Permutation(int n, int k_) => (int) checked(Factorial(n) / Factorial(n - k_));
    }
}