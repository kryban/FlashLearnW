using System.Linq;

namespace FlashLearnW.Models
{
    public class CardSetLoader
    {
        public static CardSet LoadCardSetByName(string name)
        {
            var app = App.Current as App;

            UserSet userSet = app.AppWideUSerSet;

            if (userSet.AllCardSets.Where(x => x.Name == name).Count() > 0)
            {
                return userSet.AllCardSets.FirstOrDefault(x => x.Name == name);
            }

            return userSet.AllCardSets.First();

        }
    }
}