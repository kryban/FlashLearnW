using System.Collections.Generic;
using System.Xml.Serialization;

using FlashLearnW.Interfaces;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Linq;

using FlashLearnW.AppSettings;
using System;

namespace FlashLearnW.Models
{
    public class CardSet : ICardSet, INotifyPropertyChanged
    {
        // CardSet is a container to group a set of cards with the same relevance.

        public string ID { get; private set; }

        private string name;
        public string Name
        {
            get { return name; }
            set
            { name = value;
                NotifyPropertyChanged("Name");
            }
        }

        private string descrition;
        public string Description
        {
            get { return descrition; }
            set
            {
                descrition = value;
                NotifyPropertyChanged("Description");
            }
        }

        public ObservableCollection<Card> Cards { get; set; }

        private int numberOfCardsToLearn;
        public int NumberOfCardsToLearn
        {
            get
            {
                DateTime learnDate = Convert.ToDateTime(AppSettingsWrapper.GetSetting(AppSettingsKeyNames.ExpectedLearnDay));
                numberOfCardsToLearn = Cards.Where(x => x.ShowDate <= learnDate).ToList<Card>().Count();
                return numberOfCardsToLearn;
            }

            private set
            {
                numberOfCardsToLearn = value;
            }
        }

        public CardSet(string name, string description)
        {
            ID = IdGenerator.Generate("CS_");
            Name = name;
            Description = description;
            Cards = new ObservableCollection<Card>();


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
