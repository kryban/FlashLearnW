using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;


using FlashLearnW.Interfaces;

namespace FlashLearnW.Models
{
    public class CardExplorerNew
	{
		public CardSet ComposeToLearnCardSet(ICardSet cardSet, DateTime expectedLearnDay)
		{
			string learnSetName = cardSet.Name;
			string learnSetDescription = "This is the set of cards which are composed te be shown on " +
											String.Format("{0:D}", expectedLearnDay);

			CardSet tmpSet = new CardSet(learnSetName, learnSetDescription);

			tmpSet.Cards = new ObservableCollection<Card>(cardSet.Cards.Where(x => x.ShowDate <= expectedLearnDay).ToList<Card>());

			return tmpSet;
		}

		public List<Card> FilterLearnSet(ICardSet CardSet, DateTime expectedLearnDay)
		{
			return CardSet.Cards.Where(x => x.ShowDate <= expectedLearnDay).ToList<Card>();
		}

		public void setCurrentCardSet(IUserSet userSet, ICardSet cardSet)
		{
			userSet.CurrentCardSet = cardSet;
		}

		public void ProcessResponse(IUserSet currentUserSet, int answerQuality)
		{
			new CardMaintainer().ModifyNextIteration(currentUserSet.CurrentCard, answerQuality); 

			currentUserSet.CurrentCardSet = ComposeToLearnCardSet(currentUserSet.CurrentCardSet, DateTime.Today.AddDays(1));
			SetNumberOfCardsInLearnSet(currentUserSet);

			NextCard(currentUserSet, currentUserSet.CurrentCard);
		}

		private int SetNumberOfCardsInLearnSet(IUserSet currentUserSet)
		{
			return currentUserSet.CurrentCardSet.Cards.Count;
		}

		public void PreviousCard(IUserSet currentUserSet, ICard currentCard)
		{
			int index = currentUserSet.CurrentCardSet.Cards.IndexOf((Card)currentCard);
			index--;

			if (index < 0)
			{
				index = currentUserSet.CurrentCardSet.Cards.IndexOf(currentUserSet.CurrentCardSet.Cards.Last());
			}

			SetCardToShow(currentUserSet, index);
		}

		public void NextCard(IUserSet currentUserSet, ICard currentCard)
		{
			int index = currentUserSet.CurrentCardSet.Cards.IndexOf((Card)currentCard);
			index++;

			if (index >= currentUserSet.CurrentCardSet.Cards.Count() && index > 0)
			{
				// notCovered
				index = currentUserSet.CurrentCardSet.Cards.IndexOf(currentUserSet.CurrentCardSet.Cards.First());
			}

			SetCardToShow(currentUserSet, index);
		}

		public void SetCardToShow(IUserSet currentUserSet, int index = 0)
		{
			// if there are no more cards to learn in the set, then show that to user
			if (currentUserSet.CurrentCardSet != null &&
				currentUserSet.CurrentCardSet.Cards.Count() == 0)
			{
				currentUserSet.CurrentCard = new Card() { Question = "No card to learn.", Answer = "No card to learn.", };
			}
			else
			{
				currentUserSet.CurrentCard = (Card)currentUserSet.CurrentCardSet.Cards[index];
			}
		}

		public void SetCurrentCardSet(IUserSet currentUserSet, string cardSetName = null)
		{
			if (cardSetName != null)
			{
				// notCovered
				currentUserSet.CurrentCardSet = currentUserSet.AllCardSets.Where(x => x.Name.Equals(cardSetName)).First();
				return;
			}

			currentUserSet.CurrentCardSet = currentUserSet.AllCardSets.First();
		}
	}
}