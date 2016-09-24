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
                if (command.StartsWith("GUI ", System.StringComparison.InvariantCultureIgnoreCase))
                {
                    _keyboard.ModifiedKeyStroke(VirtualKeyCode.LWIN, Converter.ToKeyCode(command.Substring(4)[0]));
                }
            }
        }
    }
}