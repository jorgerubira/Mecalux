using Mecalux.Domain.ObjectValue;
using Mecalux.Domain.Service;
using Microsoft.VisualBasic.FileIO;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Mecalux.Infraestructure.ApiRest
{
    public class TextAnalyticsApiRest : BaseApiRest, ITextAnalyticsService
    {

        public async Task<Statistics> GetAnalyticsAsync(string text)
        {
            HttpResponseMessage response = await client.GetAsync(String.Format("/api/v1/word/statistics?text={0}", text));
            Statistics result = null;
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<Statistics>();
            }
            return result;
        }



        public Statistics GetAnalytics(string text)
        {
            return AsyncContext.Run(() => this.GetAnalyticsAsync(text));
        }
    }
}
