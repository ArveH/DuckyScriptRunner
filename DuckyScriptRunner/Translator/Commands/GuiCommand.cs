using WindowsInput;
using WindowsInput.Native;

namespace DuckyScriptRunner.Translator.Commands
{
    public class GuiCommand: DuckyCommandBase
    {
        public override string Name { get; } = "GUI";

        public override void Execute(IKeyboardSimulator keyboard)
        {
            keyboard.ModifiedKeyStroke(VirtualKeyCode.LWIN, Converter.ToKeyCode(Value[0]));
        }
    }
}