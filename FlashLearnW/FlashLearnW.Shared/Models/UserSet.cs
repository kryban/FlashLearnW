using System.Collections.Generic;

using FlashLearnW.Interfaces;
using Newtonsoft.Json;
using System;

namespace FlashLearnW.Models
{
    [JsonObject(MemberSerialization.OptOut)]
    public class UserSet : IUserSet
    {
        public Guid ID { get; set; }

        public virtual List<CardSet> AllCardSets { get; set; }

        [JsonIgnore]
        public ICardSet CurrentCardSet { get; set; }
		[JsonIgnore]
		public ICard CurrentCard { get; set; }

        public string UserName { get; set; }

        public UserSet()
        {
            AllCardSets = new List<CardSet>();
            ID = new Guid();
        }
		
    }
}
