using System.Collections.Generic;

using FlashLearnW.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace FlashLearnW.Models
{
    [JsonObject(MemberSerialization.OptOut)]
    public class UserSet : IUserSet, INotifyPropertyChanged
    {
        public string ID { get; private set; }

        public virtual ObservableCollection<CardSet> AllCardSets { get; set; }

        [JsonIgnore]
        public ICardSet CurrentCardSet { get; set; }

        [JsonIgnore]
		public ICard CurrentCard { get; set; }

        private string userName;
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                NotifyPropertyChanged("UserName");
            }
        }

        public UserSet()
        {
            AllCardSets = new ObservableCollection<CardSet>();
            ID = IdGenerator.Generate("US_");
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
