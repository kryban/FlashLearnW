using System;
using System.Collections.Generic;
using FlashLearnW.Models;
using System.Collections.ObjectModel;

namespace FlashLearnW.Interfaces
{
    public interface IUserSet
    {
        string ID { get; }
        ObservableCollection<CardSet> AllCardSets { get; set; }
        ICardSet CurrentCardSet { get; set; }
		ICard CurrentCard { get; set; }
        string UserName { get; set; }
    }
}
