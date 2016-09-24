using WindowsInput;
using WindowsInput.Native;

namespace DuckyScriptRunner.Translator.Commands
{
    public class EnterCommand: DuckyCommandBase
    {
        public override string Name { get; } = "ENTER";
        public override void Execute(IKeyboardSimulator keyboard)
        {
            keyboard.KeyPress(VirtualKeyCode.RETURN);
        }
    }
}