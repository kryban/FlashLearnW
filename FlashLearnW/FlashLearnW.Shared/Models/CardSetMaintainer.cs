using FlashLearnW.Interfaces;
using System;

namespace FlashLearnW.Models
{
    public class CardSetMaintainer: ICardSetMaintainer
    {
        public ICardSet CardSet { get; set; }

        public CardSetMaintainer(ICardSet cardSet)
        {
            CardSet = cardSet;
        }

        public void AddNewCard(string question, string answer)
        {
            Card c = new Card(question, answer);

            if (AllowToAddCard(c))
            {
                CardSet.Cards.Add(c);
            }
        }

		public void AddExistingCard(Card card)
		{

			if (AllowToAddCard(card))
			{
				CardSet.Cards.Add(card);
			}
		}

        private bool AllowToAddCard(ICard card)
        {
            // if card exists, then it is not allowed to add it again
            foreach(var crd in CardSet.Cards)
            {
                if (crd.Question.Equals(card.Question))
                {
                    return false;
                }
            }

            return true;
        }

        public void DeleteCard(ICard cardToDelete)
        {
            CardSet.Cards.Remove((Card)cardToDelete);
        }

    }
}
