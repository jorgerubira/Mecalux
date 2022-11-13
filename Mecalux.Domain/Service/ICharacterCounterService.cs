using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mecalux.Domain.Service
{
    public interface ICharacterCounterService
    {
        int CountCharacter(String text, char character);
    }
}
