using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FlashLearnW.Interfaces;

namespace FlashLearnW.Models.LearnModel
{
    public class Iterator : IIterator
    {
        // notCovered
        public DateTime NextIteration(double currentEF, DateTime lastIteration, int iterationNumber)
        {
            if (iterationNumber <= 1)
            {
                return lastIteration.AddDays(1);
            }
            else if (iterationNumber == 2)
            {
                return lastIteration.AddDays(6);
            }
            else
            {
                int daysToNextMoment = CalculateDays(currentEF, iterationNumber);

                // dit moet anders. Dit is gedaan, zodat bij een slecht antwoord niet verder wordt teruggegaan
                // dan waar een kaart gestart is. Maar hierdoor kom je ook niet meer verder bij een goed antwoord, 
                // want als je daarmee onder vandaag blijft, dan wordt elke keer alleen de laatste iteratie gehanteerd.
                if (lastIteration.AddDays(daysToNextMoment) < DateTime.Today) 
                {
                    return DateTime.Today;
                }

                return lastIteration.AddDays(daysToNextMoment);
            }
        }

        private int CalculateDays(double currentEF, int i)
        {
            double days = (i - 1) * currentEF;
            
            return (int)Math.Round(days);
        }
    }
}
