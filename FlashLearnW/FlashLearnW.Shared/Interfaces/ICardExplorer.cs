using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FlashLearnW.Models;
using FlashLearnW.Interfaces;

namespace FlashLearnW.Interfaces
{
    public interface ICardExplorer
    {
        IUserSet CurrentUserSet { get; set; }
        Card CardToShow { get; set; }

		void SetCurrentCardSet(string cardSetName = null);
		CardSet ComposeToLearnCardSet(IUserSet currentUserSet, DateTime expectedLearnDay);

        void NextCard(IUserSet currentUserSet, Card currentCard);
        void PreviousCard(IUserSet currentUserSet, Card currentCard);
        void SetCardToShow(int index = 0);
    }
}
