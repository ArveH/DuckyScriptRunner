using System.Collections.Generic;
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
 * 
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
