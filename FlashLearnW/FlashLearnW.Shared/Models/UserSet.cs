using System.Collections.Generic;

using FlashLearnW.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace FlashLearnW.Models
{
    [JsonObject(MemberSerialization.OptOut)]
    public class UserSet : IUserSet
    {
        public Guid ID { get; set; }

        public virtual ObservableCollection<CardSet> AllCardSets { get; set; }

        [JsonIgnore]
        public ICardSet CurrentCardSet { get; set; }
		[JsonIgnore]
		public ICard CurrentCard { get; set; }

        public string UserName { get; set; }

        public UserSet()
        {
            AllCardSets = new ObservableCollection<CardSet>();
            ID = new Guid();
        }
		
    }
}
