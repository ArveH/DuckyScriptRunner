using System.Collections.Generic;
using System.Linq;
using DuckyScriptRunner.Exceptions;

namespace DuckyScriptRunner.Translator.Commands
{
    internal class CommandFactory
    {
        public static List<IDuckyCommand> CreateCommands(List<string> commandLines)
        {
            // TODO: Add Delay after each command until next DEFAULTDELAY
            return commandLines.Select(CreateCommand).ToList();
        }

        private static IDuckyCommand CreateCommand(string line)
        {
            var cmdTxt = LineSplitter.GetCommand(line);
            IDuckyCommand cmd;
            switch (cmdTxt)
            {
                case "ALT":
                    cmd = new AltCommand();
                    break;
                case "CTRL":
                case "CONTROL":
                    cmd = new CtrlCommand();
                    break;
                case "DEFAULTDELAY":
                case "DEFAULT_DELAY":
                    cmd = new DefaultDelayCommand();
                    break;
                case "DELAY":
                    cmd = new DelayCommand();
                    break;
                case "ENTER":
                    cmd = new EnterCommand();
                    break;
                case "GUI":
                case "WINDOWS":
                    cmd = new GuiCommand();
                    break;
                case "SHIFT":
                    cmd = new ShiftCommand();
                    break;
                case "MENU":
                    cmd = new MenuCommand();
                    break;
                case "REM":
                    cmd = new RemCommand();
                    break;
                case "STRING":
                    cmd = new StringCommand();
                    break;
                default:
                    if (Converter.IsRecognizedKey(cmdTxt))
                    {
                        cmd = new ExtendedCommand(cmdTxt);
                    }
                    else
                    {
                        throw new DuckyScriptRunnerException($"Command not found: '{cmdTxt}'.");
                    }
                    break;
            }
            cmd.Parameter = LineSplitter.GetCommandParameter(line);

            return cmd;
        }
    }
}