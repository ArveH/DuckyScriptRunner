using WindowsInput;

namespace DuckyScriptRunner.Translator.Commands
{
    public class StringCommand: DuckyCommandBase
    {
        public override string Name { get; } = "STRING";
        public override void Execute(IKeyboardSimulator keyboard)
        {
            keyboard.TextEntry(Value);
        }
    }
}