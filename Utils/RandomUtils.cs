using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Utils {
    public static class RandomUtils {
    
        private static readonly Random rnd = new Random();
        
        public struct RegexExpressions { // Add more expressions
            public static string OnlyNumbers = @"\B[0-9]";
            public static string OnlyUpper = @"\B[A-Z]";
            public static string OnlyLower = @"\B[a-z]";
            public static string FirstLower = @"^[a-z]";
            public static string FirstUpper = @"^[A-Z]";
            public static string FirstNumber = @"^[0-9]";
            public static string ValidIp = @"";
        }

        public static string ReverseString(this string txtToReverse) => new string(txtToReverse.Reverse().ToArray());

        public static string RemoveWhitespaceFromString(this string txt) => string.Concat(txt.Where(x => !char.IsWhiteSpace(x)));

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

        public static int EuclidAlgo(int a, int b) {
            while (b > 0) {
                int c = a % b;
                a = b;
                b = c;
            }
            return a;
        }

        public static string[] Similar(this string txt){
            HashSet<string> similars = new HashSet<string>{txt.ToLower(), txt.ToUpper(), txt.Capitalize()};
            if (txt.Contains('i') || txt.Contains('I')) {
                similars.Add(Regex.Replace(txt, "I", "1"));
                similars.Add(Regex.Replace(txt, "i", "1"));
                similars.Add(Regex.Replace(txt, @"[Ii]", "1"));
            }

            if (txt.Contains('E') || txt.Contains('e')) {
                similars.Add(Regex.Replace(txt, "E", "€"));
                similars.Add(Regex.Replace(txt, "e", "€"));
                similars.Add(Regex.Replace(txt, @"[Ee]", "€"));
            }
            if (txt.Contains('O') || txt.Contains('o')) {
                similars.Add(Regex.Replace(txt, "O", "0"));
                similars.Add(Regex.Replace(txt, "o", "0"));
                similars.Add(Regex.Replace(txt, @"[Oo]", "0"));
            }
            if (txt.Contains('S') || txt.Contains('s')) {
                similars.Add(Regex.Replace(txt, "S", "$"));
                similars.Add(Regex.Replace(txt, "s", "$"));
                similars.Add(Regex.Replace(txt, @"[Ss]", "$"));
            }
            if (txt.Contains(' ')) {
                similars.Add(Regex.Replace(txt, @"\s", "_"));
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
            if (txt == string.Empty) {
                return string.Empty;
            }
            string[] sr = new string[txt.Length];
            for (int i = 0; i < txt.Length; i++) {
                if (rnd.Next(0, 3) == 1) {
                    sr[i] = txt[i].ToString().ToUpper();
                    continue;
                }

                sr[i] = txt[i].ToString().ToLower();
            }

            return string.Concat(sr);
        }
        
        public static string RandomString(int length, bool firstUpper = false) {
            if (length < 1) {
                return string.Empty;
            }
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
        
        public static double RadianToDegrees(double radian) => (radian * 180) / Math.PI;
        public static double DegreesToRadians(double degree) => (degree * Math.PI) / 180;
        public static float FahrenhaitToCelsius(float fahrenhait) => (float) ((fahrenhait - 32) / 1.8);
        public static float CelsiusToFahrenhait(float celsius) => (float) (celsius * 1.8 + 32);

        public static string ReverseCase(this string txt) { // Optimize this
            char[] charsArr = txt.ToCharArray();
            MatchCollection coll = Regex.Matches(txt, @"[A-Z]");
            MatchCollection colls = Regex.Matches(txt, @"[a-z]");
            foreach (Match s in coll) {
                charsArr[s.Groups[0].Index] = Convert.ToChar(s.Groups[0].Value.ToLower());
            }
            foreach (Match s in colls) {
                charsArr[s.Groups[0].Index] = Convert.ToChar(s.Groups[0].Value.ToUpper());
            }
            return new string(charsArr);
        }

        public static int[] PatternSearch(string txtToFindPatternIn, string pattern) {
            MatchCollection coll = Regex.Matches(txtToFindPatternIn, pattern);
            int[] indexes = (from Match match in coll select match.Index).ToArray();
            return indexes;
        }

        public static List<string> StringAutocompletionList(List<string> words, string wordToAutocomplete) => words.Where(wr => wr.StartsWith(wordToAutocomplete) || wr.StartsWith(wordToAutocomplete.ToLower())).ToList();

        public static void HideInImage(string path, string txtToWrite) {
            if (txtToWrite.Length <= 1) {
                return;
            }
            byte[] b = Encoding.ASCII.GetBytes(txtToWrite);
            using FileStream stream = new FileStream(path, FileMode.Append);
            stream.Write(b, 0, b.Length);
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
    }
}