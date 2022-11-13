using Mecalux.Domain.Service;
using Mecalux.Domain.Service.Impl;
using Moq;
using NUnit.Framework;

namespace Mecalux.Domain.Service.Impl.Test
{
    public class TextServiceTest
    {
        Mock<IWordsService> _wordsService = new Mock<IWordsService>();

        [SetUp]
        public void Setup()
        {
        }

        [TestCase("Z4-A44-D-  C2523", "AlphabeticAsc", "Z4 A44 D C2523", "A44", "Z4")]
        [TestCase("Z4-A44-D-  C2523", "AlphabeticDesc", "Z4 A44 D C2523", "Z4", "A44")]
        [TestCase("Z4-A44-D-  C2523", "LenghtAsc", "Z4 A44 D C2523", "D", "C2523")]
        public void GetOrderedTest(String originalText, String option, String cleanText, String firstWord, String lastWord)
        {
            _wordsService.Setup(x => x.DeleteNotAlphanumericsChars(originalText)).Returns(cleanText);

            TextService instance = new TextService(_wordsService.Object);
            var result= instance.GetOrderedText(originalText, option);
            Assert.IsNotNull(result);
            Assert.That(result.First(), Is.EqualTo(firstWord));
            Assert.That(result.Last(), Is.EqualTo(lastWord));
        }


    }
}