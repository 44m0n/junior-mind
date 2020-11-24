using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            return input[0] == '\"' || input[^1] == '\"';
        }

        private static string Quoted(string input)
        {
            return "\"" + input + "\"";
        }
    }
}
