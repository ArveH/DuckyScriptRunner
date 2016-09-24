using System.Collections.Generic;
using System.Linq;
using DuckyScriptRunner.Exceptions;
using DuckyScriptRunner.Translator;
using DuckyScriptRunner.Translator.Commands;

namespace DuckyScriptRunner
{
    internal class CommandFactory
    {
        public static List<IDuckyCommand> CreateCommands(List<string> commandLines)
        {
            return commandLines.Select(CreateCommand).ToList();
        }

        private static IDuckyCommand CreateCommand(string line)
        {
            var cmdTxt = LineSplitter.GetCommand(line);
            IDuckyCommand cmd;
            switch (cmdTxt)
            {
                case "ENTER":
                    cmd = new EnterCommand();
                    break;
                case "GUI":
                    cmd = new GuiCommand();
                    break;
                case "STRING":
                    cmd = new StringCommand();
                    break;
                default:
                    throw new DuckyScriptRunnerException($"Command not found: '{cmdTxt}'.");
            }
            cmd.Parameter = LineSplitter.GetCommandParameter(line);

            return cmd;
        }
    }
}