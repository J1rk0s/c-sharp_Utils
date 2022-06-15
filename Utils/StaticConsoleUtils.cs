using System;
using System.Linq;

namespace Utils {
    public static class StaticConsoleUtils {
        public static string ReverseString(this string txtToReverse) => new string(txtToReverse.Reverse().ToArray());

        public static dynamic Input<T>(string txtToBeShown)
        {
            Console.Write(txtToBeShown);
            string inp = Console.ReadLine();
            
            if (typeof(T) == typeof(int))
            {
                return Convert.ToInt32(inp);
            }

            if (typeof(T) == typeof(string))
            {
                return inp;
            }

            if (typeof(T) == typeof(bool))
            {
                return Convert.ToBoolean(inp);
            }

            return null;
        }

        public static string Capitalize(this string txt) {
            if (txt.Length == 1)
            {
                return txt.ToUpper();
            }
            char[] chars = txt.ToCharArray();
            string letter = Convert.ToString(txt[0]);
            letter = letter.ToUpper();
            chars[0] = Convert.ToChar(letter);
            return new string(chars);
        }

        public static int QuadraticEquationDiscriminant(int a, int b, int c) => (b * b) - 4 * a * c;

        public static int? BinarySearch(int[] array, int targetNumber) {   // Useless
            int mid = (array.Length + 1) / 2;
            int[] first = array.Take(mid).ToArray();
            int[] second = array.Skip(mid).ToArray();

            if (mid > targetNumber) {
                foreach (int firstAr in first) {
                    return Array.IndexOf(first, targetNumber);
                }
            }
            else if(mid < targetNumber){
                foreach (int secondAr in second) {
                    return Array.IndexOf(second, targetNumber);
                }
            }

            return null;
        }

        public static int EuclidAlgo(int a, int b) {
            while (b > 0) {
                int c = a / b;
                int d = a - c * b;
                a = b;
                b = d;
            }
            return a;
        }

        public static int MultiplyAllInList(this int[] arr) {
            int val = 0;
            foreach (int i in arr) {
                val *= i;
            }
            return val;
        }
    }
}