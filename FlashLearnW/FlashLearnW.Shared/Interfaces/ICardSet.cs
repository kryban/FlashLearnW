using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FlashLearnW.Models;
using System.Collections.ObjectModel;

namespace FlashLearnW.Interfaces
{
    public interface ICardSet
    {
		string Name { get; set; }
        string Description { get; set; }
        ObservableCollection<Card> Cards { get; set; }
    }
}
