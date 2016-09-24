using WindowsInput;
using WindowsInput.Native;

namespace DuckyScriptRunner.Translator.Commands
{
    // TODO MENU doesn't work
    public class MenuCommand: DuckyCommandBase
    {
        public override string Name { get; } = "MENU";
        public override void Execute(IKeyboardSimulator keyboard)
        {
            keyboard.ModifiedKeyStroke(VirtualKeyCode.SHIFT, VirtualKeyCode.F10);
        }
    }
}