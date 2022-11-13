using Mecalux.Domain.ObjectValue;
using Mecalux.Domain.Service;
using Nito.AsyncEx;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Mecalux.Infraestructure.ApiRest
{
    public class TextServiceApiRest : BaseApiRest, ITextService
    {
        public TextServiceApiRest()
        {

        }

        private async Task<List<string>> GetOptionsAsync()
        {
            HttpResponseMessage response = await client.GetAsync("/api/v1/word/order_options");
            List<string> result = null;
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<List<string>>();
            }
            return result;

        }

        public List<string> GetOptions()
        {
            return AsyncContext.Run(() => this.GetOptionsAsync());
        }

        private async Task<List<string>> GetOrderedTextAsync(string text, string option)
        {
            HttpResponseMessage response = await client.GetAsync(String.Format("/api/v1/word/ordered_text?text={0}&option={1}", text, option));
            List<string> result = null;
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<List<string>>();
            }
            return result;
        }


        public List<string> GetOrderedText(string text, string option)
        {
            return AsyncContext.Run(() => this.GetOrderedTextAsync(text,option));
        }
    }
}
