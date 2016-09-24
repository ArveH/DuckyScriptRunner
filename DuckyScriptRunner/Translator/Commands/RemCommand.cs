using WindowsInput;

namespace DuckyScriptRunner.Translator.Commands
{
    public class RemCommand: DuckyCommandBase
    {
        public override string Name { get; } = "REM";
        public override void Execute(IKeyboardSimulator keyboard)
        {
            // Do nothing
        }
    }
}