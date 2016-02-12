using System;
using System.Linq;
using FlashLearnW.Interfaces;


namespace FlashLearnW.Models
{
    public class CardSetLoader
    {
        public static CardSet LoadCardSetByName(string name)
        {
            var app = App.Current as App;

            UserSet userSet = app.AppWideUserSet;

            if (userSet.AllCardSets.Where(x => x.Name == name).Count() > 0)
            {
                return userSet.AllCardSets.FirstOrDefault(x => x.Name == name);
            }

            return userSet.AllCardSets.First();

        }

        //Filter only the relevant (to learn) sets 
        public CardSet FilterLearnSet(ICardSet cardSet, DateTime expectedLearnDay)
        {
            CardSet retval = new CardSet(cardSet.Name, cardSet.Description);
            retval.Cards = new CardExplorerNew().FilterLearnSet(cardSet, expectedLearnDay);
            return retval;
        }
    }
}