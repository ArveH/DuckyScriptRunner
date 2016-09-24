using System;
using WindowsInput;
using DuckyScriptRunner.Exceptions;

namespace DuckyScriptRunner.Translator.Commands
{
    public class DefaultDelayCommand: DuckyCommandBase
    {
        public override string Name { get; } = "DEFAULTDELAY";
        public override void Execute(IKeyboardSimulator keyboard)
        {
            // Do nothing
        }

        public override string Parameter
        {
            get
            {
                return base.Parameter;
            }

            set
            {
                int tmp;
                if (!int.TryParse(value, out tmp))
                {
                    throw new DuckyScriptRunnerException($"'{value}' not a legal value for DEFAULTDELAY");
                }
                base.Parameter = value;
            }
        }
    }
}