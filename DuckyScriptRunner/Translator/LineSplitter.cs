using System;
using System.Collections.Generic;
using System.Linq;
using DuckyScriptRunner.Exceptions;

namespace DuckyScriptRunner.Translator
{
    public static class LineSplitter
    {
        public static List<string> SplitIntoLines(string allText)
        {
            return allText
                .Split(new [] {'\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(line => line.Trim()).ToList();
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

        public static string GetCommandParameter(string line)
        {
            if (string.IsNullOrWhiteSpace(line)) throw new DuckyScriptRunnerException("Line cannot be null or empty.");
            var indexOfFirstSpace = line.IndexOf(' ');
            return indexOfFirstSpace == -1 ? "" : line.Substring(indexOfFirstSpace + 1);
        }
    }
}