using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashLearnW.Interfaces
{
    public interface ICardMaintainer
    {
        void ModifyQuestion(ICard card, string newQuestion);
        void ModifyAnswer(ICard card, string newAnswer);
        void ModifyNextIteration(ICard card, int answerQuality);
        bool CardChanged(ICard card);
    }
}
