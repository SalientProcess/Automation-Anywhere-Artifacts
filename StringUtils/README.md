# StringUtils
This C# class is the source for a Metabot DLL that provides additional string processing functions.

## RegexMatch
Perform Regex pattern match against an input string returning an array of results.  If there is no match, then `null` is returned.  If there is a match, an array of one row is returned that contains the complete match.  If we have specified a pattern that contains captures, then an additional row will be found in the returned array for each contained pattern matched.