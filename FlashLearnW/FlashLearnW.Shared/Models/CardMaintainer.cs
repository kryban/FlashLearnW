using System;

using FlashLearnW.Interfaces;
using FlashLearnW.Models.LearnModel;
using FlashLearnW.AppSettings;

namespace FlashLearnW.Models
{
    public class CardMaintainer : ICardMaintainer
    {
        public ICard Card;
        private IIterator Iterator;
        private IEasinessFactorMaintainer EasinessFactorMaintainer;
        private bool useMinimumEasinessFactor;

        public CardMaintainer()
        {
        }

        public void ModifyQuestion(ICard card, string newQuestion)
        {
            Card = card;
            card.Question = newQuestion;
        }

        public void ModifyAnswer(ICard card, string newAnswer)
        {
            Card = card;
            card.Answer = newAnswer;
        }

        public void ModifyNextIteration(ICard card, int answerQuality)
        {
            Iterator = new Iterator();
            EasinessFactorMaintainer = new EasinessFactorMaintainer(answerQuality, card.EasinessFactor);
            useMinimumEasinessFactor = Convert.ToBoolean(AppSettingsWrapper.GetSetting(AppSettingsKeyNames.UseMinimumEasinessFactor));

            DateTime newShowDate = Iterator.NextIteration(card.EasinessFactor, card.ShowDate, card.NumberOfIterations);

            card.ShowDate = newShowDate;
            card.EasinessFactor = new EasinessFactorMaintainer(answerQuality, card.EasinessFactor).CalculateNewEF(useMinimumEasinessFactor);
            card.NumberOfIterations++;
        }

        public bool CardChanged(ICard card)
        {
            throw new NotImplementedException();
        }
    }
}
