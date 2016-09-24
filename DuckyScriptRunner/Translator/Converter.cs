using System;
using System.Collections.Generic;
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

        public static VirtualKeyCode ToKeyCode(string parameter)
        {
            switch (parameter)
            {
                case "DELETE":
                    return VirtualKeyCode.DELETE;
                case "HOME":
                    return VirtualKeyCode.HOME;
                case "INSERT":
                    return VirtualKeyCode.INSERT;
                case "PAGEUP":
                    return VirtualKeyCode.PRIOR;
                case "PAGEDOWN":
                    return VirtualKeyCode.NEXT;
                case "GUI":
                case "WINDOWS":
                    return VirtualKeyCode.LWIN;
                case "UPARROW":
                    return VirtualKeyCode.UP;
                case "DOWNARROW":
                    return VirtualKeyCode.DOWN;
                case "LEFTARROW":
                    return VirtualKeyCode.LEFT;
                case "RIGHTARROW":
                    return VirtualKeyCode.RIGHT;
                case "TAB":
                    return VirtualKeyCode.TAB;
                default:
                    throw new DuckyScriptRunnerException($"Illegal name '{parameter}' for KeyCode.");
            }
        }
    }
}