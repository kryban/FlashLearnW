using System;

using FlashLearnW.Interfaces;

namespace FlashLearnW.Models.LearnModel
{
    /// <summary>
    /// Easiness Factor (EF) classifies the position of a Card on the learning curve.
    /// The lower the EF of a Card, the more difficult that Card is.
    /// </summary>
    public class EasinessFactorMaintainer : IEasinessFactorMaintainer
    {
        private int providedAnswerQuality { get; set; }
        private double currentEF { get; set; }
        private double minimumEasinessFactor = Convert.ToDouble(AppSettings.AppSettingsWrapper.GetSetting(AppSettings.AppSettingsKeyNames.MinimumEasinessFactor));

        public EasinessFactorMaintainer(int answerQuality, double currentEF)
        {
            this.providedAnswerQuality = answerQuality;
            this.currentEF = currentEF;
        }

        public double CalculateNewEF(bool useMinimumEasinessFactor)
        {
            const int maxAnswerQuality = (int)enmAnswerQuality.Perfect; 
            int missingQuality = maxAnswerQuality - providedAnswerQuality;
            
            // notice that when EF = 4; then EF will not change.
            double retVal = currentEF +
                            ( 0.1 - missingQuality *
                              (0.08 + missingQuality * 0.02)
                            );

            // There is a minimum for Cards that are not new anymore,
            // so a Card will not be annoyingly presented on daily basis.
            // New cards start with EF under the minimum.
            if(useMinimumEasinessFactor)
            {
                retVal = minimumEasinessFactor;
            }

            return retVal;
        }
    }
}
