using WindowsInput;

namespace DuckyScriptRunner.Translator.Commands
{
    public abstract class DuckyCommandBase: IDuckyCommand
    {
        public abstract string Name { get; }
        public abstract void Execute(IKeyboardSimulator keyboard);

        public virtual string Parameter { get; set; }
    }
}