using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mecalux.Domain.Service.Impl
{
    public class CharacterCounterService : ICharacterCounterService
    {
        public int CountCharacter(string text, char character)
        {
            return text.Count(x => x == character);
        }
    }
}
