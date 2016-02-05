using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashLearnW.Interfaces
{
    public interface IIterator
    {
        DateTime NextIteration(double currentEF, DateTime lastIteration, int iterationNumber);
    }
}
