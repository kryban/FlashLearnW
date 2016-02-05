using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashLearnW.Interfaces
{
    public interface ICardSetMaintainer
    {
        ICardSet CardSet { get; set; }

        void AddNewCard(string question, string answer);
    }
}
