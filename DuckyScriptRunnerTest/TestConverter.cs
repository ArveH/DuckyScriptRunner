using WindowsInput.Native;
using DuckyScriptRunner.Exceptions;
using DuckyScriptRunner.Translator;
using NUnit.Framework;

namespace DuckyScriptRunnerTest
{
    [TestFixture]
    public class TestConverter
    {
        [Test]
        public void TestConverter_When_LowerChar()
        {
            var keyCode = Converter.ToKeyCode('r');

            Assert.That(keyCode, Is.EqualTo(VirtualKeyCode.VK_R));
        }

        [Test]
        public void TestConverter_When_UpperChar_Then_Exception()
        {
            Assert.That(() =>
            {
                var keyCode = Converter.ToKeyCode('R');
            }, 
            Throws.InstanceOf<ConverterException>().With.Message.EqualTo("Can't convert upper case letter 'R'"));
        }

    }
}