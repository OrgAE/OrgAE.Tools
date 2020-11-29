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
    /// <summary>
    /// A set of String methods to facilitate development and don't repeat your self.
    /// </summary>
    public static class String
    {
        /// <summary>
        /// Converts a string to kebab case.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToKebabCase(string str)
        {
            Regex pattern = new Regex(@"[A-Z]{2,}(?=[A-Z][a-z]+[0-9]*|\b)|[A-Z]?[a-z]+[0-9]*|[A-Z]|[0-9]+");
            return string.Join("-", pattern.Matches(str)).ToLower();
        }

        /// <summary>
        /// Combines the elements of an enumerable object into a string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elements"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static string Stringify<T>(IEnumerable<T> elements, string delimiter = ",")
        {
            return string.Join(delimiter, elements);
        }

        /// <summary>
        /// Filter a string's contents to include only alphanumeric and allowed characters.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static string FilterString(string s, string filter = "")
        {
            return new string(
              Array.FindAll(s.ToCharArray(), c => char.IsLetterOrDigit(c) || filter.Contains(c))
            );
        }
        /// <summary>
        /// Converts a string to camel case.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Converts a hexadecimal string to a byte array.
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static byte[] HexToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
              .Where(x => x % 2 == 0)
              .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
              .ToArray();
        }

        /// <summary>
        /// Replaces all but the last n characters in a string with the specified mask character.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="n"></param>
        /// <param name="mask"></param>
        /// <returns></returns>
        public static string Mask(string str, int n = 4, char mask = '*')
        {
            return str.Substring(str.Length - n).PadLeft(str.Length, mask);
        }

        /// <summary>
        /// Splits a multiline string into an array of lines.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string[] SplitLines(string s)
        {
            return s.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
        }

        /// <summary>
        /// Splits a string into an array of strings using a multicharacter (string) separator.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string[] SplitStringBy(string s, string separator)
        {
            return s.Split(new[] { separator }, StringSplitOptions.None);
        }

        /// <summary>
        /// Converts a string to snake case.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToSnakeCase(string str)
        {
            Regex pattern = new Regex(@"[A-Z]{2,}(?=[A-Z][a-z]+[0-9]*|\b)|[A-Z]?[a-z]+[0-9]*|[A-Z]|[0-9]+");
            return string.Join("_", pattern.Matches(str)).ToLower();
        }
        /// <summary>
        /// Converts a string to title case.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToTitleCase(string str)
        {
            Regex pattern = new Regex(@"[A-Z]{2,}(?=[A-Z][a-z]+[0-9]*|\b)|[A-Z]?[a-z]+[0-9]*|[A-Z]|[0-9]+");
            return new CultureInfo("en-US", false)
              .TextInfo
              .ToTitleCase(
                string.Join(" ", pattern.Matches(str)).ToLower()
              );
        }
        /// <summary>
        /// Returns a string with whitespaces compacted.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string CompactWhiteSpace(string str)
        {
            return Regex.Replace(str, @"\s{2,}", " ");
        }

        /// <summary>
        /// Capitalizes the first letter of a string.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Capitalize(string str)
        {
            char[] chars = str.ToCharArray();
            chars[0] = char.ToUpper(chars[0]);
            return new string(chars);
        }
        /// <summary>
        /// Decapitalizes the first letter of a string.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Decapitalize(string str)
        {
            char[] chars = str.ToCharArray();
            chars[0] = char.ToLower(chars[0]);
            return new string(chars);
        }

        /// <summary>
        /// Reverses a string.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Reverse(string s)
        {
            return new string(s.ToCharArray().Reverse().ToArray());
        }

        /// <summary>
        /// Pads a given number to the specified length.
        /// </summary>
        /// <param name="n"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string PadNumber(int n, int length)
        {
            return n.ToString($"D{length}");
        }

        /// <summary>
        /// Checks if a string is lower case.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsLower(string str)
        {
            return str.ToLower() == str;
        }

        /// <summary>
        /// Checks if a string is upper case.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsUpper(string str)
        {
            return str.ToUpper() == str;
        }
        /// <summary>
        /// Creates a new string by repeating the given string n times.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string Repeat(string s, int n)
        {
            return string.Concat(Enumerable.Repeat(s, n));
        }
    }
}
