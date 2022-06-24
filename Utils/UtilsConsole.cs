using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Utils {
    public static class UtilsConsole {
        
        public struct RegexExpressions {
            public static string OnlyNumbers = @"\B[0-9]";
            public static string OnlyUpper = @"\B[A-Z]";
            public static string OnlyLower = @"\B[a-z]";
            public static string FirstLower = @"^[a-z]";
            public static string FirstUpper = @"^[A-Z]";
            public static string FirstNumber = @"^[0-9]";
        }
        public static string ReverseString(this string txtToReverse) => new string(txtToReverse.Reverse().ToArray());

        public static dynamic Input<T>(string txtToBeShown, ConsoleColor color = ConsoleColor.White) {
            Console.ForegroundColor = color;
            Console.Write(txtToBeShown);
            Console.ResetColor();
            string inp = Console.ReadLine();

            if (string.IsNullOrEmpty(inp)) return null;
            
            if (typeof(T) == typeof(int)) return Convert.ToInt32(inp);

            if (typeof(T) == typeof(string)) return inp;

            if (typeof(T) == typeof(bool)) return Convert.ToBoolean(inp);

            return null;
        }

        [Obsolete("Use Capitalize instead", false)]
        public static string FirstUp(this string txt) {
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

        public static string Capitalize(this string txt) => txt[0].ToString().ToUpper() + txt.Substring(1);
        
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
            int val = 1;
            foreach (int i in arr) {
                val *= i;
            }
            return val;
        }
        public static float MultiplyAllInList(this float[] arr) {
            float val = 1;
            foreach (float i in arr) {
                val *= i;
            }
            return val;
        }

        public static string[] Similar(this string txt){
            HashSet<string> similars = new HashSet<string>(){txt.ToLower(), txt.ToUpper(), txt.Capitalize()};
            if (txt.Contains('i') || txt.Contains('I')) {
                similars.Add(txt.Replace('i', '1'));
                similars.Add(txt.Replace('I', '1'));
                similars.Add(Regex.Replace(txt, @"[Ii]", "1"));
            }

            if (txt.Contains('E') || txt.Contains('e')) {
                similars.Add(txt.Replace('E', '€'));
                similars.Add(txt.Replace('e', '€'));
                similars.Add(Regex.Replace(txt, @"[Ee]", "€"));
            }
            return similars.ToArray();
        }

        public static List<T> RemoveDuplicates<T>(this List<T> list) => new HashSet<T>(list).ToList();
        public static T[] RemoveDuplicates<T>(this T[] array) => new HashSet<T>(array).ToArray();

        public static void Predictor(string pathToData) { // Make predictor in other language and pass data to it
            Console.WriteLine("Undergoing work!");
        }
    }
}