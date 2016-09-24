using WindowsInput;
using WindowsInput.Native;

namespace DuckyScriptRunner.Translator.Commands
{
    public class AltCommand: DuckyCommandBase
    {
        public override string Name { get; } = "ALT";
        public override void Execute(IKeyboardSimulator keyboard)
        {
            keyboard.ModifiedKeyStroke(VirtualKeyCode.MENU, Converter.ToKeyCode(Parameter));
        }
    }
}