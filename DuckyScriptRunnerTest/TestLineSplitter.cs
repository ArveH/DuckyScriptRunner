using DuckyScriptRunner.Exceptions;
using DuckyScriptRunner.Translator;
using NUnit.Framework;

namespace DuckyScriptRunnerTest
{
    [TestFixture]
    public class TestLineSplitter
    {
        [Test]
        public void TestGetCommand()
        {
            var cmd = LineSplitter.GetCommand("GUI r");
            Assert.That(cmd, Is.EqualTo("GUI"));
        }

        [Test]
        public void TestGetCommand_When_NotAllUpperCase()
        {
            Assert.That(() =>
            {
                var cmd = LineSplitter.GetCommand("gui r");
            },
            Throws.InstanceOf<DuckyScriptRunnerException>().With.Message.EqualTo("Ducky says that all commands should be upper case. 'gui' is not."));
        }

        [Test]
        public void TestGetCommand_When_LineIsNull()
        {
            Assert.That(() =>
            {
                var cmd = LineSplitter.GetCommand(null);
            },
            Throws.InstanceOf<DuckyScriptRunnerException>().With.Message.EqualTo("Line cannot be null or empty."));
        }

    }
}