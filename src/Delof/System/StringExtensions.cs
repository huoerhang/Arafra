using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string source, bool allowWhiteSpace = false)
        {
            if (!allowWhiteSpace)
            {
                source = source?.Trim();
            }

            return string.IsNullOrEmpty(source);
        }

        public static bool IsNullOrWhiteSpace(this string source)
        {
            return string.IsNullOrWhiteSpace(source);
        }

        public static T ToEnum<T>(this string source, bool ignoreCase)
            where T : Enum
        {
            source.CheckNotNull(nameof(source));

            return (T)Enum.Parse(typeof(T), source, ignoreCase);
        }

        public static T ToEnum<T>(this string source)
            where T : Enum
        {
            source.CheckNotNull(nameof(source));

            return (T)Enum.Parse(typeof(T), source);
        }

        public static byte[] GetBytes(this string source, Encoding encoding)
        {
            source.CheckNotNull(nameof(source));
            encoding.CheckNotNull(nameof(encoding));

            return encoding.GetBytes(source);
        }

        public static byte[] GetBytes(this string source)
        {
            return source.GetBytes(Encoding.UTF8);
        }

        public static string ToMd5(this string source)
        {
            if (source.IsNullOrWhiteSpace())
            {
                return source;
            }

            using (var md5 = MD5.Create())
            {
                byte[] sourceBytes = Encoding.UTF8.GetBytes(source);
                byte[] hashBytes = md5.ComputeHash(sourceBytes);

                StringBuilder sb = new StringBuilder();

                foreach (var b in hashBytes)
                {
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }

        public static string ToBase64(this string source, Encoding encoding)
        {
            encoding.CheckNotNull(nameof(encoding));

            if (source.IsNullOrWhiteSpace())
            {
                return source;
            }

            byte[] bytes = source.GetBytes();

            return Convert.ToBase64String(bytes);
        }

        public static string ToBase64(this string source)
        {
            return source.ToBase64(Encoding.UTF8);
        }

        public static string FromBase64(this string base64Source, Encoding encoding)
        {
            encoding.CheckNotNull(nameof(encoding));

            if (base64Source.IsNullOrWhiteSpace())
            {
                return base64Source;
            }

            byte[] bytes = Convert.FromBase64String(base64Source);

            return encoding.GetString(bytes);
        }

        public static string FromBase64(this string base64Source)
        {
            return base64Source.FromBase64(Encoding.UTF8);
        }

        public static string[] SplitToLines(this string source, string separator)
        {
            return source.Split(Environment.NewLine);
        }

        public static string NormalizeLines(this string str)
        {
            return str.Replace("\r\n", "\n").Replace("\r", "\n").Replace("\n", Environment.NewLine);
        }


        public static ReadOnlySpan<char> Left(this string source, int length)
        {
            source.CheckNotNull(nameof(source));

            if (source.Length < length)
            {
                throw new ArgumentException($"{nameof(length)} argument can not be bigger than string's length!");
            }

            return source.AsSpan(0, length);
        }

        public static ReadOnlySpan<char> Right(this string source, int length)
        {
            source.CheckNotNull(source);

            if (source.Length < length)
            {
                throw new ArgumentException($"{nameof(length)} argument can not be bigger than string's length!");
            }

            return source.AsSpan(0, length);
        }

        public static bool StartsWith(this string source, char c, StringComparison comparisonType = StringComparison.Ordinal)
        {
            if (source.IsNullOrEmpty())
            {
                return false;
            }

            return source.StartsWith(c.ToString(), comparisonType);
        }

        public static bool EndsWith(this string source, char c, StringComparison comparisonType = StringComparison.Ordinal)
        {
            if (source.IsNullOrEmpty())
            {
                return false;
            }

            return source.EndsWith(c.ToString(), comparisonType);
        }

        public static string EnsureStartsWith(this string source, char c, StringComparison comparisonType = StringComparison.Ordinal)
        {
            if (source.IsNullOrEmpty())
            {
                return source;
            }

            if (source.StartsWith(c, comparisonType))
            {
                return source;
            }

            return c + source;
        }

        public static string EnsureEndsWith(this string source, char c, StringComparison comparisonType = StringComparison.Ordinal)
        {
            if (source.IsNullOrEmpty())
            {
                return source;
            }

            if (source.EndsWith(c, comparisonType))
            {
                return source;
            }

            return source + c;
        }
    }
}
