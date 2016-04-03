using FlashLearnW.Interfaces;
using FlashLearnW.AppSettings;
using FlashLearnW.Common;
using System;
using Windows.UI.Popups;
using System.Text.RegularExpressions;

namespace FlashLearnW.Models
{
    public class CardSetMaintainer: ICardSetMaintainer
    {
        public ICardSet CardSet { get; private set; }

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

        public async void Export()
        {
            string path = AppSettingsWrapper.GetSetting(AppSettingsKeyNames.UserSetPath);

            bool ExportSucceeded = new DataSerializer().SerializeToLocalFolder(CardSet.Name, CardSet);

            string tmpName = Regex.Replace(CardSet.Name, "[^0-9a-zA-Z]+", "");
            tmpName += tmpName + ".json";

            if (ExportSucceeded)
            {
                MessageDialog messageBox = new MessageDialog("CardSet saved as " + tmpName + " in the Local folder.");
                await messageBox.ShowAsync();
            }
            else
            {
                MessageDialog messageBox = new MessageDialog("Oops. Something went wrong. Could not save this CardSet.");
                await messageBox.ShowAsync();
            }

        }

    }
}
