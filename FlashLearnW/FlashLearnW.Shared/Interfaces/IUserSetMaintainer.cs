using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FlashLearnW.Models;

namespace FlashLearnW.Interfaces
{
    public interface IUserSetMaintainer
    {
        IUserSet UserSet { get; set; }

        void AddNewCardSet(string name, string description);
        bool AllowToAddCardSet(string name);
    }
}
