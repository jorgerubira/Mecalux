using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mecalux.Domain.Service
{
    public interface IWordsService
    {
        int CountWords(String text);

        //Delete not alphanumerics characters
        string DeleteNotAlphanumericsChars(String text);
    }
}
