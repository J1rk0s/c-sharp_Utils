using System;
using System.Collections.Generic;
using System.Numerics;

namespace Utils {
    public static class MathUtils {
        public const double GoldenRatio = 1.618033988;
        public static BigInteger Factorial(int A) => A <= 0 ? 1 : A * Factorial(A - 1);

        public static int CombinationNumber(int A, int B) => checked((int)(Factorial(A) / (Factorial(A - B) * Factorial(B))));
        
        public static int QuadraticEquationDiscriminant(int a, int b, int c) => (int)Math.Pow(b,2) - 4 * a * c;

        public static (ulong iterations, ulong highestNumberReached) CollatzConjecture(ulong startingNumber) {
            ulong iterations = 0;
            ulong max = 0;
            ulong temp = 0;
            while (startingNumber != 1) {
                if (startingNumber % 2 == 0) {
                    startingNumber /= 2;
                }
                else if(startingNumber % 2 != 0){
                    startingNumber = startingNumber * 3 + 1;
                }
                temp = startingNumber;
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
            int c = 0;
            for (int i = startingNumber; i < endNumber; i++) {
                c = a + b;
                b = a;
                a = c;
                yield return c;
            }
        }

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

        public static BigInteger FermatNumber(int n) => (BigInteger)Math.Pow(2, Math.Pow(2, n)) + 1;
        
    }
}