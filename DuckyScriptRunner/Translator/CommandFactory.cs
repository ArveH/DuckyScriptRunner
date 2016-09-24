using System;
using System.Collections.Generic;
using System.Linq;
using DuckyScriptRunner.Exceptions;
using DuckyScriptRunner.Translator.Commands;

namespace DuckyScriptRunner.Translator
{
    internal class CommandFactory
    {
        public static List<IDuckyCommand> CreateCommands(List<string> commandLines)
        {
            List<IDuckyCommand> commands = new List<IDuckyCommand>(commandLines.Count*2); // 
            var defaultDelay = 0;
            if (commandLines.Count > 0 && (CreateCommand(commandLines[0]).Name == "DEFAULTDELAY"))
            {
                defaultDelay = Convert.ToInt32(CreateCommand(commandLines[0]).Parameter);
            }

            for (var i = 0; i < commandLines.Count; i++)
            {
                var command = CreateCommand(commandLines[i]);
                if (command.Name == "REPLAY")
                {
                    ReplayCommands(CreateCommand(commandLines[i-1]), Convert.ToInt32(command.Parameter), commands);
                    continue;
                }

                commands.Add(command);
                if (defaultDelay > 0)
                {
                    if (IgnoreDelayForThisCommand(command)) continue;
                    commands.Add(new DelayCommand() { Parameter = defaultDelay.ToString() });
                }
            }

            return commands;
        }

        private static bool IgnoreDelayForThisCommand(IDuckyCommand command)
        {
            return command.Name == "REM" || command.Name == "DELAY" || command.Name == "DEFAULTDELAY";
        }

        private static void ReplayCommands(IDuckyCommand command, int replayCount, List<IDuckyCommand> commands)
        {
            for (var i = 0; i < replayCount; i++)
            {
                commands.Add(command);
            }
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