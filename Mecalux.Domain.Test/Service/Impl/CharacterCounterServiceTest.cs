using Mecalux.Domain.Service;
using Mecalux.Domain.Service.Impl;
using Moq;

namespace Mecalux.Domain.Service.Impl.Test
{
    public class CharacterCounterServiceTest
    {

        [SetUp]
        public void Setup()
        {
        }

        [TestCase("Z4-A44-D  C252 3", ' ', 3)]
        [TestCase("Z4-A44-D  C252 3", '-', 2)]
        [TestCase("", ' ', 0)]
        public void CountCharacterTest(String text, char character, int expect)
        {
            CharacterCounterService instance = new CharacterCounterService();

            var result = instance.CountCharacter(text, character);
            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo(expect));
        }

    }
}