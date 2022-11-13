using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Mecalux.Infraestructure.ApiRest
{
    public class BaseApiRest
    {
        protected static HttpClient client { get; set; }

        public BaseApiRest()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}
