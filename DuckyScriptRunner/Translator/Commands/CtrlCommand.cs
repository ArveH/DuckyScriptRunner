using WindowsInput;
using WindowsInput.Native;

namespace DuckyScriptRunner.Translator.Commands
{
    public class CtrlCommand : DuckyCommandBase
    {
        public override string Name { get; } = "CTRL";
        public override void Execute(IKeyboardSimulator keyboard)
        {
            keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, Converter.ToKeyCode(Parameter));
        }
    }
}