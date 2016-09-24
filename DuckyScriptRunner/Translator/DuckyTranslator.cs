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
        }
    }
}