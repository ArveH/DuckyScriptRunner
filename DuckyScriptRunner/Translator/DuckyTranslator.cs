using System.Collections.Generic;
using WindowsInput;
using WindowsInput.Native;

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

        public void Run(IList<string> commands)
        {
            foreach (var command in commands)
            {
                // Ducky demands upper case for commands
                if (command.StartsWith("GUI "))
                {
                    _keyboard.ModifiedKeyStroke(VirtualKeyCode.LWIN, Converter.ToKeyCode(command.Substring(4)[0]));
                }
                else if (command.StartsWith("STRING "))
                {
                    _keyboard.TextEntry(command.Substring(7));
                }
                else if (command == "ENTER")
                {
                    _keyboard.KeyPress(VirtualKeyCode.RETURN);
                }
            }
        }
    }
}