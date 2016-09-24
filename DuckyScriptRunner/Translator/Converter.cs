using System;
using WindowsInput.Native;
using DuckyScriptRunner.Exceptions;

namespace DuckyScriptRunner.Translator
{
    public static class Converter
    {
        public static VirtualKeyCode ToKeyCode(char ch)
        {
            // This method is only used in conjuntion with a modifier key,
            // so it should never be upper case (Ducky script)
            if (ch >= 'A' && ch <= 'Z')
            {
                throw new DuckyScriptRunnerException($"Can't convert upper case letter '{ch}'");
            }

            // But WindowsInput package uses upper case, so we need to convert case
            if (ch >= 'a' && ch <= 'z')
            {
                return (VirtualKeyCode)Convert.ToByte(char.ToUpper(ch));
            }

            return (VirtualKeyCode)Convert.ToByte(ch);
        }
    }
}