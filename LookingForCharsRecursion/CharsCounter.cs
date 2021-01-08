using System;

namespace LookingForCharsRecursion
{
    public static class CharsCounter
    {
        /// <summary>
        /// Searches a string for all characters that are in <see cref="Array" />, and returns the number of occurrences of all characters.
        /// </summary>
        /// <param name="str">String to search.</param>
        /// <param name="chars">One-dimensional, zero-based <see cref="Array"/> that contains characters to search for.</param>
        /// <returns>The number of occurrences of all characters.</returns>
        public static int GetCharsCount(string str, char[] chars)
        {
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (chars is null)
            {
                throw new ArgumentNullException(nameof(chars));
            }

            return GetResult(str, chars);
        }

        /// <summary>
        /// Searches a string for all characters that are in <see cref="Array" />, and returns the number of occurrences of all characters within the range of elements in the <see cref="string"/> that starts at the specified index and ends at the specified index.
        /// </summary>
        /// <param name="str">String to search.</param>
        /// <param name="chars">One-dimensional, zero-based <see cref="Array"/> that contains characters to search for.</param>
        /// <param name="startIndex">A zero-based starting index of the search.</param>
        /// <param name="endIndex">A zero-based ending index of the search.</param>
        /// <returns>The number of occurrences of all characters within the specified range of elements in the <see cref="string"/>.</returns>
        public static int GetCharsCount(string str, char[] chars, int startIndex, int endIndex)
        {
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (chars is null)
            {
                throw new ArgumentNullException(nameof(chars));
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            if (endIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(endIndex));
            }

            if (endIndex < startIndex)
            {
                throw new ArgumentOutOfRangeException($"startIndex is greater endIndex");
            }

            if (str.Length <= endIndex)
            {
                throw new ArgumentOutOfRangeException($"startIndex of endIndex greater string lenght");
            }

            return GetResult(str, chars, startIndex: startIndex, endIndex: endIndex);
        }

        /// <summary>
        /// Searches a string for a limited number of characters that are in <see cref="Array" />, and returns the number of occurrences of all characters within the range of elements in the <see cref="string"/> that starts at the specified index and ends at the specified index.
        /// </summary>
        /// <param name="str">String to search.</param>
        /// <param name="chars">One-dimensional, zero-based <see cref="Array"/> that contains characters to search for.</param>
        /// <param name="startIndex">A zero-based starting index of the search.</param>
        /// <param name="endIndex">A zero-based ending index of the search.</param>
        /// <param name="limit">A maximum number of characters to search.</param>
        /// <returns>The limited number of occurrences of characters to search for within the specified range of elements in the <see cref="string"/>.</returns>
        public static int GetCharsCount(string str, char[] chars, int startIndex, int endIndex, int limit)
        {
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (chars is null)
            {
                throw new ArgumentNullException(nameof(chars));
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            if (endIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(endIndex));
            }

            if (endIndex < startIndex)
            {
                throw new ArgumentOutOfRangeException($"startIndex is greater endIndex");
            }

            if (str.Length <= endIndex)
            {
                throw new ArgumentOutOfRangeException($"startIndex and endIndex greater string lenght");
            }

            if (limit <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(limit));
            }

            return GetResult(str, chars, startIndex: startIndex, endIndex: endIndex, limit: limit);
        }

        public static int GetResult(string str, char[] chars, int i = 0, int result = 0, int startIndex = 0, int endIndex = int.MaxValue, int limit = int.MaxValue)
        {
            if (chars is null)
            {
                throw new ArgumentNullException(nameof(chars));
            }

            if (i < chars.Length)
            {
                result += SearchChar(str, chars[i], startIndex, endIndex);
                i++;
                return GetResult(str, chars, i, result, startIndex, endIndex, limit);
            }

            if (result > limit)
            {
                return limit;
            }
            else
            {
                return result;
            }
        }

        public static int SearchChar(string str, char ch, int i, int endIndex, int count = 0)
        {
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (i < str.Length && i <= endIndex)
            {
                if (str[i] == ch)
                {
                    count++;
                }

                i++;
                return SearchChar(str, ch, i, endIndex, count);
            }

            return count;
        }
    }
}
