using System;
using System.Collections.Generic;
using System.Linq;

namespace DuckyScriptRunner.Translator
{
    public static class LineSplitter
    {
        public static IList<string> Split(string allText)
        {
            return allText
                .Split(new [] {'\n'}, StringSplitOptions.RemoveEmptyEntries)
                .Select(line => line.Trim().TrimEnd('\r')).ToList();
        }
    }
}