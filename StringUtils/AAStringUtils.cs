using System;
using System.Text.RegularExpressions;

namespace AAStringUtils
{
    public class AAStringUtils
    {
        public static string[] RegexMatch(string pattern, string text)
        {
            Regex regexPattern = new Regex(pattern);
            Match m = regexPattern.Match(text);
            // We could also have used:
            // Match m = Regex.Match(text, pattern);
            // The value m.Success is true if a match was found.
            // m.Groups returns a GroupCollection containing the capturing groups.
            // m.Groups.Count is the number of collections available.
            // m.Groups[0] is the entire match
            // 
            if (!m.Success) {
                return null;
            }

            // Iterate over each of the matches and return the array of matches.
            string[] ret = new string[m.Groups.Count + 1];
            for (int i = 0; i < m.Groups.Count; i++) {
                ret[i] = m.Groups[i].Value;
            }
            return ret;           // Return the array of matched captures.
        } // MatchGroup1
    } // class AAStringUtils
} // namespace AAStringUtils
