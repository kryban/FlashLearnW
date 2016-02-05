using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashLearnW.Models.LearnModel
{
    public enum enmAnswerQuality
    {
        Perfect = 5,
        Hesitation = 4,
        Difficult = 3,
        IncorrectButRemebered = 2,
        IncorrectAndHardlyRembered = 1,
        Blackout = 0,
    }
}
