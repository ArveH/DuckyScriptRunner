﻿using System.Collections.Generic;
using DuckyScriptRunner.Translator;
using NUnit.Framework;

namespace DuckyScriptRunnerTest
{
    [TestFixture]
    public class TestTranslator
    {
        [Test]
        public void TestOpenNotepad()
        {
            // Can't run tests because testrunner takes focus (sometimes)
        }
    }
}

/*
REM Test CTRL-BREAK
DELAY 1000
GUI r
DELAY 300
STRING cmd
ENTER
DELAY 1000
STRING dir
ENTER
CTRL BREAK
BREAK
 */

/*
REM Test lock keys
CAPSLOCK 
DELAY 2000
CAPSLOCK 
DELAY 2000
NUMLOCK 
DELAY 2000
NUMLOCK 
DELAY 2000
SCROLLLOCK 
DELAY 2000
SCROLLLOCK 
DELAY 2000
 */

/*
REM Testing SHIFT
DELAY 1000
GUI r
DELAY 300
STRING wordpad
ENTER
DELAY 1000
STRING Hello World
ENTER
STRING Another Line
ENTER
STRING Third Line
ENTER
SHIFT LEFTARROW
SHIFT LEFTARROW
SHIFT LEFTARROW
DELAY 2000
SHIFT UPARROW
DELAY 2000
SHIFT DOWNARROW
DELAY 2000
SHIFT HOME
DELAY 2000
SHIFT PAGEUP
DELAY 2000
SHIFT PAGEDOWN
DELAY 2000
SHIFT UPARROW
DELAY 2000
SHIFT DELETE
DELAY 2000
*/
