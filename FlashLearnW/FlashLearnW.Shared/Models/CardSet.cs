using System.Collections.Generic;
using System.Xml.Serialization;

using FlashLearnW.Interfaces;

namespace FlashLearnW.Models
{
    public class CardSet : ICardSet
    {
        // CardSet is a container to group a set of cards with the same relevance.
		public string Name { get; set; }
        public string Description { get; set; }
        public List<Card> Cards { get; set; }
        
        public CardSet(string name, string description)
        {
            Name = name;
            Description = description;
            Cards = new List<Card>();
        }
    }
}
