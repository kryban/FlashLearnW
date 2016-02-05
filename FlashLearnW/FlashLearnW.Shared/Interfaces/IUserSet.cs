using System;
using System.Collections.Generic;
using FlashLearnW.Models;

namespace FlashLearnW.Interfaces
{
    public interface IUserSet
    {
        Guid ID { get; set; }
        List<CardSet> AllCardSets { get; set; }
        ICardSet CurrentCardSet { get; set; }
		ICard CurrentCard { get; set; }
        string UserName { get; set; }
    }
}
