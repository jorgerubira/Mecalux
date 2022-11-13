using Mecalux.Domain.Service;
using Mecalux.Domain.Service.Impl;
using Moq;
using NUnit.Framework;

namespace Mecalux.Domain.Service.Impl.Test
{
    public class WordsServiceTest
    {

        [SetUp]
        public void Setup()
        {
        }

        [TestCase("Z4-A44-D-  C2523", 4)]
        [TestCase("Z4-A44-D-  C2523 .. AA BB C2C ..CC.C", 9)]
        [TestCase("", 0)]
        public void CountWordsTest(String text, int count)
        {
            WordsService instance = new WordsService();

            var result = instance.CountWords(text);
            Assert.IsNotNull(result);
            Assert.That(count, Is.EqualTo(result));
        }

        [TestCase("Z4-A44-D-  C2523", "Z4 A44 D C2523")]
        [TestCase("Z4-A44-D-  C2523 .. AA BB C2C ..CC.C", "Z4 A44 D C2523 AA BB C2C CC C")]
        [TestCase("", "")]
        public void DeleteNotAlphanumericsCharsTest(String text, string expect)
        {
            WordsService instance = new WordsService();

            var result = instance.DeleteNotAlphanumericsChars(text);
            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo(expect));
        }


    }
}