using System.Collections.Generic;
using System.Xml.Serialization;

using FlashLearnW.Interfaces;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Collections.ObjectModel;

namespace FlashLearnW.Models
{
    public class CardSet : ICardSet, INotifyPropertyChanged
    {
        // CardSet is a container to group a set of cards with the same relevance.

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

        public CardSet(string name, string description)
        {
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
