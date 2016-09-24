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
            var translator = new DuckyTranslator();
            var commands = new List<string>
            {
                "GUI R",
                "STRING notepad"
            };
            translator.Run(commands);
        }
    }}