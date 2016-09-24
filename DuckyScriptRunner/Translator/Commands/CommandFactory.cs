using System.Collections.Generic;
using System.Linq;
using DuckyScriptRunner.Exceptions;

namespace DuckyScriptRunner.Translator.Commands
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
                case "REM":
                    cmd = new RemCommand();
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