using System.Collections.Generic;
using WindowsInput;
using WindowsInput.Native;
using System.Linq;

namespace DuckyScriptRunner.Translator
{
    public class DuckyTranslator
    {
        private readonly IKeyboardSimulator _keyboard;

        public DuckyTranslator()
        {
            var inputSimulator = new InputSimulator();
            _keyboard = inputSimulator.Keyboard;
        }

        public void Run(List<IDuckyCommand> commands)
        {
            commands.ForEach(c => c.Execute(_keyboard));

            //foreach (var command in commands)
            //{
            //    command.Execute(_keyboard);
            //    // Ducky demands upper case for commands
            //    if (command.StartsWith("GUI "))
            //    {
            //        _keyboard.ModifiedKeyStroke(VirtualKeyCode.LWIN, Converter.ToKeyCode(command.Substring(4)[0]));
            //    }
            //    else if (command.StartsWith("STRING "))
            //    {
            //        _keyboard.TextEntry(command.Substring(7));
            //    }
            //    else if (command == "ENTER")
            //    {
            //        _keyboard.KeyPress(VirtualKeyCode.RETURN);
            //    }
            //}
        }
    }
}