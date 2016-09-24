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
                return (VirtualKeyCode) Convert.ToByte(char.ToUpper(ch));
            }

            return (VirtualKeyCode) Convert.ToByte(ch);
        }

        public static bool IsRecognizedKey(string parameter)
        {
            try
            {
                var tmp = ToKeyCode(parameter);
                return true;
            }
            catch (DuckyScriptRunnerException)
            {
                return false;
            }
        }

        public static VirtualKeyCode ToKeyCode(string parameter)
        {
            switch (parameter)
            {
                case "BREAK":
                    return VirtualKeyCode.CANCEL;
                case "CAPSLOCK":
                    return VirtualKeyCode.CAPITAL;
                case "DELETE":
                    return VirtualKeyCode.DELETE;
                case "DOWNARROW":
                case "DOWN":
                    return VirtualKeyCode.DOWN;
                case "END":
                    return VirtualKeyCode.END;
                case "ESC":
                case "ESCAPE":
                    return VirtualKeyCode.ESCAPE;
                case "F1":
                    return VirtualKeyCode.F1;
                case "F2":
                    return VirtualKeyCode.F2;
                case "F3":
                    return VirtualKeyCode.F3;
                case "F4":
                    return VirtualKeyCode.F4;
                case "F5":
                    return VirtualKeyCode.F5;
                case "F6":
                    return VirtualKeyCode.F6;
                case "F7":
                    return VirtualKeyCode.F7;
                case "F8":
                    return VirtualKeyCode.F8;
                case "F9":
                    return VirtualKeyCode.F9;
                case "F10":
                    return VirtualKeyCode.F10;
                case "F11":
                    return VirtualKeyCode.F11;
                case "F12":
                    return VirtualKeyCode.F12;
                case "GUI":
                case "WINDOWS":
                    return VirtualKeyCode.LWIN;
                case "HOME":
                    return VirtualKeyCode.HOME;
                case "INSERT":
                    return VirtualKeyCode.INSERT;
                case "LEFTARROW":
                case "LEFT":
                    return VirtualKeyCode.LEFT;
                case "NUMLOCK":
                    return VirtualKeyCode.NUMLOCK;
                case "PAGEDOWN":
                    return VirtualKeyCode.NEXT;
                case "PAGEUP":
                    return VirtualKeyCode.PRIOR;
                case "PAUSE":
                    return VirtualKeyCode.PAUSE;
                case "PRINTSCREEN":
                    return VirtualKeyCode.SNAPSHOT;
                case "RIGHTARROW":
                case "RIGHT":
                    return VirtualKeyCode.RIGHT;
                case "SCROLLLOCK":
                    return VirtualKeyCode.SCROLL;
                case "SPACE":
                    return VirtualKeyCode.SPACE;
                case "TAB":
                    return VirtualKeyCode.TAB;
                case "UPARROW":
                case "UP":
                    return VirtualKeyCode.UP;
                default:
                    throw new DuckyScriptRunnerException($"Illegal name '{parameter}' for KeyCode.");
            }
        }
    }
}