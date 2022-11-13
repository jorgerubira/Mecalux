using Mecalux.Domain.ObjectValue;
using Mecalux.Domain.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mecalux.Application.Controllers
{
    [Route("/api/v1/word")]
    [ApiController]
    public class WordController : ControllerBase
    {

        private readonly ITextService _textService;
        private readonly ITextAnalyticsService _textAnalyticsService;

        public WordController(ITextService textService, ITextAnalyticsService textAnalyticsService)
        {
            _textService = textService;
            _textAnalyticsService = textAnalyticsService;
        }

        [Route("check")]
        public String Check()
        {
            return "Working";
        }


        [Route("order_options")]
        public List<string> Options()
        {
            return _textService.GetOptions();
        }

        [Route("ordered_text")]
        public List<string> OrderedText(string text, string option)
        {
            return _textService.GetOrderedText(text, option);
        }

        [Route("statistics")]
        public Statistics Analitics(string text)
        {
            return _textAnalyticsService.GetAnalytics(text);
        }

    }
}
