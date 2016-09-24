using WindowsInput;

namespace DuckyScriptRunner.Translator
{
    public abstract class DuckyCommandBase: IDuckyCommand
    {
        public abstract string Name { get; }
        public abstract void Execute(IKeyboardSimulator keyboard);

        public string Parameter { get; set; }
    }
}