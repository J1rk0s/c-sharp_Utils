using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Utils {
    public static class UtilsConsole {
    
        private static readonly Random rnd = new Random();
        public struct RegexExpressions { // Add more expressions
            public static string OnlyNumbers = @"\B[0-9]";
            public static string OnlyUpper = @"\B[A-Z]";
            public static string OnlyLower = @"\B[a-z]";
            public static string FirstLower = @"^[a-z]";
            public static string FirstUpper = @"^[A-Z]";
            public static string FirstNumber = @"^[0-9]";
        }
        public static string ReverseString(this string txtToReverse) => new string(txtToReverse.Reverse().ToArray());

        public static int ReverseInt(this int intToReverse) => Convert.ToInt32(intToReverse.ToString().ReverseString());
        
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
            else if(mid < targetNumber) {
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

        public static int? LinearSearchAlgo(IEnumerable<int> arrayOfNumbers, int targetNumber) {
            foreach (int numba in arrayOfNumbers) {
                if (numba == targetNumber) {
                    return numba;
                }
            }
            return null;
        }

        public static IEnumerable<(int firstNumber, int secondNumber)?> GetSumPairs(int[] array, int targetNumber) {
            foreach (int x in array) {
                foreach (int y in array) {
                    if (x + y == targetNumber) {
                        yield return (x, y);
                    }
                }
            }
            yield return null;
        }
        
        public static IEnumerable<(int firstNumber, int secondNumber, int thirdNumber)?> GetSumTripletPairs(int[] array, int targetNumber) {
            foreach (int x in array) {
                foreach (int y in array) {
                    foreach (int z in array) {
                        if (x + y + z == targetNumber) {
                            yield return (x, y, z);
                        }   
                    }
                }
            }
            yield return null;
        }

        public static int[] AlternatingSubarray(int[] arr) { // Working on this
            List<int> ints = new List<int>();
            for (int i = 0; i < arr.Length; i++) {
                if (arr[i] > 0 && arr[i + 1] < 0) {
                    ints.Add(arr[i]);
                    ints.Add(arr[i + 1]);
                }
            }

            return ints.ToArray();
        }

        public static int MultiplyAllInList(this IEnumerable<int> arr) => arr.Aggregate((current, i) => current * i);

        public static float MultiplyAllInList(this float[] arr) {
            float val = 1;
            foreach (float i in arr) {
                val *= i;
            }
            return val;
        }

        public static string[] Similar(this string txt){
            HashSet<string> similars = new HashSet<string>{txt.ToLower(), txt.ToUpper(), txt.Capitalize()};
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
            if (txt.Contains('O') || txt.Contains('o')) {
                similars.Add(txt.Replace('O', '0'));
                similars.Add(txt.Replace('o', '0'));
                similars.Add(Regex.Replace(txt, @"[Oo]", "0"));
            }
            if (txt.Contains('S') || txt.Contains('s')) {
                similars.Add(txt.Replace('S', '$'));
                similars.Add(txt.Replace('s', '$'));
                similars.Add(Regex.Replace(txt, @"[Ss]", "$"));
            }
            if (txt.Contains(' ')) {
                similars.Add(txt.Replace(' ', '_'));
            }
            
            return similars.ToArray();
        }

        public static string SpongebobCase(this string txt) {
            string[] sr = new string[txt.Length];
            for (int i = 0; i < txt.Length; i++) {
                if (i % 2 == 0) {
                    sr[i] = txt[i].ToString().ToUpper();
                    continue; 
                }
                sr[i] = txt[i].ToString().ToLower();
            }
            return string.Concat(sr);
        }

        public static string RandomCase(this string txt) {
            string[] sr = new string[txt.Length];
            for (int i = 0; i < txt.Length; i++) {
                if (rnd.Next(0, 2) == 1) {
                    sr[i] = txt[i].ToString().ToUpper();
                    continue;
                }

                sr[i] = txt[i].ToString().ToUpper();
            }

            return string.Concat(sr);
        }

        public static unsafe IntPtr GetAddressOfIntArray(int[] array) {
            fixed (int* ptr = array) {
                return new IntPtr(&ptr);
            }
        }
        
        public static List<T> RemoveDuplicates<T>(this List<T> list) => new HashSet<T>(list).ToList();
        public static T[] RemoveDuplicates<T>(this T[] array) => new HashSet<T>(array).ToArray();
        
        public static string RandomString(int length, bool firstUpper = false) {
            List<char> list = new List<char>();
            if (firstUpper) {
                list.Add((char) rnd.Next(65,90));
                length -= 1;
            }
            for (int i = 0; i < length; i++) {
                list.Add((char) rnd.Next(97,122));
            }

            return string.Join("", list);
        }

        public static List<T> ListWithRandomValues<T>(int length) { // Optimize this 
            if (typeof(T) == typeof(string)) {
                string[] list = new string[length];
                for (int i = 0; i < length; i++) {
                    list[i] = RandomString(5);
                }
                return list.ToList() as List<T>;
            }
            
            if (typeof(T) == typeof(int)) {
                int[] list = new int[length];
                for (int i = 0; i < length; i++) {
                    list[i] = rnd.Next(500);
                }

                return list.ToList() as List<T>;
            }
            return null;
        }
        
    }
}