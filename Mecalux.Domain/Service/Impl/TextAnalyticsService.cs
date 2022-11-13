using Mecalux.Domain.ObjectValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mecalux.Domain.Service.Impl
{
    public class TextAnalyticsService : ITextAnalyticsService
    {
        private readonly ICharacterCounterService _characterCounterService;
        private readonly IWordsService _wordsCounterService;

        public TextAnalyticsService(ICharacterCounterService characterCounterService, IWordsService wordsCounterService)
        {
            _characterCounterService = characterCounterService;
            _wordsCounterService = wordsCounterService;
        }

        public Statistics GetAnalytics(string text)
        {
            Statistics statistics = new Statistics()
            {
                Hyphens = _characterCounterService.CountCharacter(text, '-'),
                Words = _wordsCounterService.CountWords(text),
                Spaces = _characterCounterService.CountCharacter(text, ' '),
            };
            return statistics;
        }


    }
}
