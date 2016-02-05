using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashLearnW.Interfaces
{
    /// <summary>
    /// Easiness Factor (EF) classifies the position of a Card on the learning curve.
    /// The lower the EF of a Card, the more difficult that Card is.
    /// </summary>
    public interface IEasinessFactorMaintainer
    {        
        // After answering a Card, the quality of a given answer leads to a new EF value.
        double CalculateNewEF(bool useMinimumEasinessFactor);
    }
}
