using System;
using WindowsInput;

namespace DuckyScriptRunner.Translator.Commands
{
    public class DelayCommand : DuckyCommandBase
    {
        public override string Name { get; } = "DELAY";
        public override void Execute(IKeyboardSimulator keyboard)
        {
            keyboard.Sleep(Convert.ToInt32(Parameter));
        }
    }
}