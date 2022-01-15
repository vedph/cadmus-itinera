using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Cadmus.Itinera.Parts.Codicology
{
    /// <summary>
    /// A range of two alphanumeric values, i.e. strings which always start
    /// by a digit, and may continue with digits only, or include non-digit
    /// characters.
    /// </summary>
    public class AlnumRange
    {
        private static readonly Regex _alnumRegex =
            new Regex(@"([0-9]+)([^-\s]*)");

        /// <summary>
        /// Gets or sets the start value in a range, or the unique value.
        /// </summary>
        public string A { get; set; }

        /// <summary>
        /// Gets or sets the end value in a range, or null for a unique value.
        /// </summary>
        public string B { get; set; }

        /// <summary>
        /// Parses the specified alphanumeric into its numeric value and suffix.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>Tuple with 1=number 2=suffix if any, or null if invalid.
        /// </returns>
        public static Tuple<int, string> ParseAlnum(string text)
        {
            if (string.IsNullOrEmpty(text)) return null;

            Match m = _alnumRegex.Match(text);
            if (!m.Success) return null;
            return Tuple.Create(
                    int.Parse(m.Groups[1].Value, CultureInfo.InvariantCulture),
                    m.Groups[2].Length > 0 ? m.Groups[2].Value : null);
        }

        /// <summary>
        /// Compares the specified alphanumerics.
        /// </summary>
        /// <param name="a">The first alphanumeric.</param>
        /// <param name="b">The second alphanumeric.</param>
        /// <returns>0=equal, less than 0=a is less than b, greater than 0=a
        /// is greater than b.</returns>
        public static int CompareAlnums(Tuple<int,string> a, Tuple<int,string> b)
        {
            if (a == null && b == null) return 0;
            if (a == null) return -1;
            if (b == null) return 1;
            if (a.Item1 != b.Item1) return a.Item1 - b.Item1;
            return string.Compare(a.Item2 ?? "", b.Item2 ?? "");
        }

        /// <summary>
        /// Interpolates the values between start and end (included).
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <returns>List of alphanumerics.</returns>
        public static IList<string> InterpolateAlnums(string start, string end)
        {
            var a = ParseAlnum(start);
            var b = ParseAlnum(end);
            if (a == null || b == null) return Array.Empty<string>();
            if (!string.IsNullOrEmpty(a.Item2) || !string.IsNullOrEmpty(b.Item2)
                || a.Item1 > b.Item1)
            {
                return new List<string> { start, end };
            }
            return (from n in Enumerable.Range(a.Item1, b.Item1 + 1 - a.Item1)
                   select n.ToString(CultureInfo.InvariantCulture)).ToList();
        }

        /// <summary>
        /// Returns the total count of values interpolated between start and
        /// end (included).
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <returns>List of alphanumerics.</returns>
        public static int CountInterpolatedAlnums(string start, string end)
        {
            var a = ParseAlnum(start);
            var b = ParseAlnum(end);
            if (a == null || b == null) return 0;
            if (!string.IsNullOrEmpty(a.Item2) || !string.IsNullOrEmpty(b.Item2)
                || a.Item1 > b.Item1)
            {
                return 2;
            }
            return b.Item1 + 1 - a.Item1;
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.IsNullOrEmpty(B) ? A : $"{A}-{B}";
        }
    }
}
