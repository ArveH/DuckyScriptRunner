using WindowsInput;
using WindowsInput.Native;

namespace DuckyScriptRunner.Translator.Commands
{
    public class ExtendedCommand : DuckyCommandBase
    {
        public ExtendedCommand(string key)
        {
            Name = key;
        }

        public override string Name { get; }
        public override void Execute(IKeyboardSimulator keyboard)
        {
            var keyCode = Converter.ToKeyCode(Name);
            if (keyCode == VirtualKeyCode.CANCEL || keyCode == VirtualKeyCode.PAUSE)
            {
                keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.CANCEL);
            }
            else
            {
                keyboard.KeyPress(keyCode);
            }
        }
    }
}