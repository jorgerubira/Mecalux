using Mecalux.Domain.Service;
using Mecalux.Domain.Service.Impl;
using Moq;

namespace Mecalux.Domain.Service.Impl.Test
{
    public class TextAnalyticsServiceTest
    {
        Mock<ICharacterCounterService> _characterCounterService = new Mock<ICharacterCounterService>();
        Mock<IWordsService> _wordsCounterService = new Mock<IWordsService>();

        [SetUp]
        public void Setup()
        {
        }

        [TestCase("A- A A--A", 3, 2, 4)]
        [TestCase("13 A421 AA --", 2, 3, 2)]
        [TestCase("", 0 ,0 , 0)]
        public void GetAnaliticsTest(String word, int hyphens, int words, int spaces)
        {
            _characterCounterService.Setup(x => x.CountCharacter(word, '-')).Returns(hyphens);
            _wordsCounterService.Setup(x => x.CountWords(word)).Returns(words);
            _characterCounterService.Setup(x => x.CountCharacter(word, ' ')).Returns(spaces);

            TextAnalyticsService instance = new TextAnalyticsService(_characterCounterService.Object, _wordsCounterService.Object);
            var result=instance.GetAnalytics(word);
            Assert.IsNotNull(result);
            Assert.That(result.Hyphens, Is.EqualTo(hyphens));
            Assert.That(result.Words, Is.EqualTo(words));
            Assert.That(result.Spaces, Is.EqualTo(spaces));

        }


    }
}