using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;


using FlashLearnW.Interfaces;
using System.Reflection;

namespace FlashLearnW.Models
{
    public class CardExplorerNew
	{
		public CardSet ComposeToLearnCardSet(ICardSet cardSet, DateTime expectedLearnDay)
		{
			string learnSetName = cardSet.Name;
			string learnSetDescription = "This is the set of cards which are composed te be shown on " +
											String.Format("{0:D}", expectedLearnDay) + ".";

			CardSet tmpSet = new CardSet(learnSetName, learnSetDescription);

			tmpSet.Cards = new ObservableCollection<Card>(cardSet.Cards.Where(x => x.ShowDate <= expectedLearnDay).ToList<Card>());

			return tmpSet;
		}

		public ObservableCollection<Card> FilterLearnSet(ICardSet CardSet, DateTime expectedLearnDay)
		{
			return new ObservableCollection<Card>(CardSet.Cards.Where(x => x.ShowDate <= expectedLearnDay).ToList<Card>());
		}

		public void ProcessResponse(IUserSet currentUserSet, int answerQuality)
		{
			new CardMaintainer().ModifyNextIteration(currentUserSet.CurrentCard, answerQuality);

            DateTime learnDay = Convert.ToDateTime(AppSettings.AppSettingsWrapper.GetSetting(AppSettings.AppSettingsKeyNames.ExpectedLearnDay));

			currentUserSet.CurrentCardSet = ComposeToLearnCardSet(currentUserSet.CurrentCardSet, learnDay);
			//NumberOfCardsInLearnSet(currentUserSet);

            SaveChangesToCard(currentUserSet, currentUserSet.CurrentCard);

			NextCard(currentUserSet, currentUserSet.CurrentCard);
		}

        private void SaveChangesToCard(IUserSet currentUserSet, ICard currentCard)
        {       
            Card existingCard = FindCard(currentUserSet, currentCard);
            Card modifiedCard = (Card)currentCard;

            Type typeOfExistingCard = existingCard.GetType();
            Type typeOfModifiedCard = modifiedCard.GetType();

            List<PropertyInfo> propertiesExistingCard = new List<PropertyInfo>(typeOfExistingCard.GetRuntimeProperties());
            List<PropertyInfo> propertiesModifiedCard = new List<PropertyInfo>(typeOfModifiedCard.GetRuntimeProperties());

            // check if the properties are changed in the meantime. Should not be.
            for (int i = 0; i < propertiesExistingCard.Count; i++)
            {
                if(propertiesExistingCard[i].Name == propertiesModifiedCard[i].Name)
                {
                    propertiesExistingCard[i].SetValue(existingCard, propertiesModifiedCard[i].GetValue(modifiedCard));
                }
                else
                {
                    throw new ArrayTypeMismatchException("Cannot save the modified Card information",
                                                            new Exception(
                                                                "The type of the card is changed, because the properties ofthe existing and modified cards are not the same "));
                }
            }
        }

        private Card FindCard(IUserSet currentUserSet, ICard currentCard)
        {
            foreach (var CardSet in currentUserSet.AllCardSets)
            {
                return CardSet.Cards.FirstOrDefault(x => x.ID == currentCard.ID);
            }

            return null;
        }

        private int NumberOfCardsInLearnSet(IUserSet currentUserSet)
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

		public void setCurrentCardSet(IUserSet currentUserSet, string cardSetName = null)
		{
			if (cardSetName != null)
			{
				// notCovered
				currentUserSet.CurrentCardSet = currentUserSet.AllCardSets.Where(x => x.Name.Equals(cardSetName)).First();
				return;
			}

			currentUserSet.CurrentCardSet = currentUserSet.AllCardSets.First();
		}

        public void setCurrentCardSet(UserSet userSet, ICardSet cardSet)
        {
            userSet.CurrentCardSet = cardSet;
        }
    }
}