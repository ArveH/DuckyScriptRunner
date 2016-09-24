using System;
using System.Collections.Generic;
using System.Linq;
using DuckyScriptRunner.Exceptions;

namespace DuckyScriptRunner.Translator
{
    public static class LineSplitter
    {
        public static IList<string> SplitIntoLines(string allText)
        {
            return allText
                .Split(new [] {'\n'}, StringSplitOptions.RemoveEmptyEntries)
                .Select(line => line.Trim().TrimEnd('\r')).ToList();
        }

        public static string GetCommand(string line)
        {
            if (string.IsNullOrWhiteSpace(line)) throw new DuckyScriptRunnerException("Line cannot be null or empty.");
            var cmd = line.Split(' ')[0];
            if (!cmd.All(char.IsUpper))
                throw new DuckyScriptRunnerException(
                    $"Ducky says that all commands should be upper case. '{cmd}' is not.");

            return cmd;
        }
    }
}