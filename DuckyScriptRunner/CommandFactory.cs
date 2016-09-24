using System.Collections.Generic;
using DuckyScriptRunner.Translator;

namespace DuckyScriptRunner
{
    internal class CommandFactory
    {
        public static List<IDuckyCommand> CreateCommands(IList<string> commandLines)
        {
            var commands = new List<IDuckyCommand>(commandLines.Count);

            foreach (var commandLine in commandLines)
            {
                
            }

            return commands;
        }
    }
}