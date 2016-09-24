using WindowsInput;

namespace DuckyScriptRunner.Translator
{
    public interface IDuckyCommand
    {
        string Name { get; }
        void Execute(IKeyboardSimulator keyboard);
        string Value { get; set; }
    }
}