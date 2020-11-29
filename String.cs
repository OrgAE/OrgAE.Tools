//-----------------------------------------------------------------------
// 
//      Author: Abdelhalim EL HADI (elhadi.abdelhalim@gmail.com)
//      OrgAE Tools
//      Copyright (c) Abdelhalim EL HADI. All rights reserved.
//      This program is free software: you can redistribute it and/or modify
//      it under the terms of the GNU General Public License v3.0 as published by
//      the Free Software Foundation, either version 3 of the License, or
//      (at your option) any later version.
//      This program is distributed in the hope that it will be useful,
//      but WITHOUT ANY WARRANTY; without even the implied warranty of
//      MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//      GNU General Public License for more details.
//      You should have received a copy of the GNU General Public License
//      along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace OrgAE.Tools
{
    public static class String
    {
        public static string ToKebabCase(string str)
        {
            Regex pattern = new Regex(@"[A-Z]{2,}(?=[A-Z][a-z]+[0-9]*|\b)|[A-Z]?[a-z]+[0-9]*|[A-Z]|[0-9]+");
            return string.Join("-", pattern.Matches(str)).ToLower();
        }

        public static string Stringify<T>(IEnumerable<T> elements, string delimiter = ",")
        {
            return string.Join(delimiter, elements);
        }

        public static string FilterString(string s, string filter = "")
        {
            return new string(
              Array.FindAll(s.ToCharArray(), c => char.IsLetterOrDigit(c) || filter.Contains(c))
            );
        }
        public static string ToCamelCase(string str) //toDo : CultureInfo
        {
            Regex pattern = new Regex(@"[A-Z]{2,}(?=[A-Z][a-z]+[0-9]*|\b)|[A-Z]?[a-z]+[0-9]*|[A-Z]|[0-9]+");
            return new string(
              new CultureInfo("en-US", false)
                .TextInfo
                .ToTitleCase(
                  string.Join(" ", pattern.Matches(str)).ToLower()
                )
                .Replace(@" ", "")
                .Select((x, i) => i == 0 ? char.ToLower(x) : x)
                .ToArray()
            );
        }

        public static byte[] HexToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
              .Where(x => x % 2 == 0)
              .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
              .ToArray();
        }

        public static string Mask(string str, int n = 4, char mask = '*')
        {
            return str.Substring(str.Length - n).PadLeft(str.Length, mask);
        }

        public static string[] SplitLines(string s)
        {
            return s.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
        }

        public static string[] SplitStringBy(string s, string separator)
        {
            return s.Split(new[] { separator }, StringSplitOptions.None);
        }

        public static string ToSnakeCase(string str)
        {
            Regex pattern = new Regex(@"[A-Z]{2,}(?=[A-Z][a-z]+[0-9]*|\b)|[A-Z]?[a-z]+[0-9]*|[A-Z]|[0-9]+");
            return string.Join("_", pattern.Matches(str)).ToLower();
        }
        public static string ToTitleCase(string str)
        {
            Regex pattern = new Regex(@"[A-Z]{2,}(?=[A-Z][a-z]+[0-9]*|\b)|[A-Z]?[a-z]+[0-9]*|[A-Z]|[0-9]+");
            return new CultureInfo("en-US", false)
              .TextInfo
              .ToTitleCase(
                string.Join(" ", pattern.Matches(str)).ToLower()
              );
        }

        public static string CompactWhitespace(string str)
        {
            return Regex.Replace(str, @"\s{2,}", " ");
        }

        public static string Capitalize(string str)
        {
            char[] chars = str.ToCharArray();
            chars[0] = char.ToUpper(chars[0]);
            return new string(chars);
        }

        public static string Decapitalize(string str)
        {
            char[] chars = str.ToCharArray();
            chars[0] = char.ToLower(chars[0]);
            return new string(chars);
        }

        public static string Reverse(string s)
        {
            return new string(s.ToCharArray().Reverse().ToArray());
        }

        public static string PadNumber(int n, int length)
        {
            return n.ToString($"D{length}");
        }

        public static bool IsLower(string str)
        {
            return str.ToLower() == str;
        }

        public static bool IsUpper(string str)
        {
            return str.ToUpper() == str;
        }

        public static string Repeat(string s, int n)
        {
            return string.Concat(Enumerable.Repeat(s, n));
        }
    }
}
