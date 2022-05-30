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

        public static string Capitalize(this string txt)
        {
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
    }
}