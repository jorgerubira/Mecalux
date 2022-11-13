using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mecalux.Domain.Service.Impl
{
    public class WordsService : IWordsService
    {
        public int CountWords(string text)
        {
            text=DeleteNotAlphanumericsChars(text);
            if (text == "")
            {
                return 0;
            }
            return text.Count(x => x == ' ')+1;
        }

        public string DeleteNotAlphanumericsChars(string text)
        {
            string result = "";
            Boolean space = false; 
            for (var n = 0; n < text.Length; n++)
            {
                if (Char.IsLetter(text[n]) || Char.IsNumber(text[n]))
                {
                    result += text[n];
                    space = false;
                }
                else
                {
                    if (!space)
                    {
                        result += " ";
                        space = true;
                    }
                }
            }
            return result.Trim();
        }
    }
}
