using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mecalux.Domain.Service
{
    public interface ITextService
    {
        List<String> GetOptions();
        List<String> GetOrderedText(String textOrdered, String option);

    }
}
