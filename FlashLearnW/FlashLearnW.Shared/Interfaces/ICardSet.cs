using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FlashLearnW.Models;

namespace FlashLearnW.Interfaces
{
    public interface ICardSet
    {
		string Name { get; set; }
        string Description { get; set; }
        List<Card> Cards { get; set; }
    }
}
