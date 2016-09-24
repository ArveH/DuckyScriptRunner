using WindowsInput;
using WindowsInput.Native;

namespace DuckyScriptRunner.Translator.Commands
{
    public class ShiftCommand: DuckyCommandBase
    {
        public override string Name { get; } = "SHIFT";
        public override void Execute(IKeyboardSimulator keyboard)
        {
            keyboard.ModifiedKeyStroke(VirtualKeyCode.SHIFT, Converter.ToKeyCode(Parameter));
        }
    }
}