using Mecalux.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Mecalux.Domain.Service.Impl
{
    public class TextService : ITextService
    {
        private readonly IWordsService _wordsService;
        private List<string> _options;

        public TextService(IWordsService wordsService)
        {
            _wordsService = wordsService;
            _options = new List<string>() { "AlphabeticAsc", "AlphabeticDesc", "LenghtAsc" };
        }

        public List<string> GetOptions()
        {
            return new List<string>() { "AlphabeticAsc", "AlphabeticDesc", "LenghtAsc" };
        }

        public List<string> GetOrderedText(string textOrdered, string option)
        {
            textOrdered=_wordsService.DeleteNotAlphanumericsChars(textOrdered);
            /*textOrdered = textOrdered.Replace(".", " ");
            textOrdered = textOrdered.Replace(",", " ");
            textOrdered = textOrdered.Replace(";", " ");
            textOrdered = textOrdered.Replace("  ", " ");*/
            List<String> words = textOrdered.Split(" ").ToList();
            Comparison<string> comparisor= (x, y) => 0;
            switch (option)
            {
                case "AlphabeticAsc":
                    comparisor = (x, y) => x.CompareTo(y);
                    break;
                case "AlphabeticDesc":
                    comparisor = (x, y) => y.CompareTo(x);
                    break;
                case "LenghtAsc":
                    comparisor = (x, y) => x.Length.CompareTo(y.Length);
                    break;
                default:
                    throw new ParamOptionWrongException();
            }
            var a = words[0];
            words.Sort(comparisor);
            a = words[0];
            return words;

        }
    }
}
