using Mecalux.Domain.ObjectValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mecalux.Domain.Service
{
    public interface ITextAnalyticsService
    {
        Statistics GetAnalytics(String text);
    }
}
