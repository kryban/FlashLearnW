using System.ComponentModel;
using System.Linq;

namespace FlashLearnW.Models
{
    public class CardSetLoader: INotifyPropertyChanged
    {
        public CardSet usrSet;

        public void LoadCardSetByName(string name)
        {
            var app = App.Current as App;

            UserSet userSet = app.AppWideUSerSet;

            if (userSet.AllCardSets.Exists(x => x.Name == name))
            {
                usrSet = userSet.AllCardSets.FirstOrDefault(x => x.Name == name);
            }
            else
            {
                usrSet = userSet.AllCardSets.First();
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}