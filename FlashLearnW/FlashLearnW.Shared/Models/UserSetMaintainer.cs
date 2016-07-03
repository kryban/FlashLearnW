using System.Linq;
using System;
using FlashLearnW.Interfaces;
using System.Collections.Generic;

namespace FlashLearnW.Models
{
    public class UserSetMaintainer : IUserSetMaintainer
    {
        public IUserSet UserSet { get; set; }

        public UserSetMaintainer(IUserSet userSet)
        {
            UserSet = userSet;
        }

        public UserSetMaintainer()
        {
        }

        public void AddNewCardSet(string name, string description)
        {
            if (AllowToAddCardSet(name))
            {
                UserSet.AllCardSets.Add(new CardSet(name, description));
                return;
            }

            // not covered
            throw new ArgumentException("The given CardSet already exists within the current UserSet."
                , "UserSetName");
        }

        public void AddNewCardSet(ICardSet cardSet)
        {
            if (AllowToAddCardSet(cardSet.Name))
            {
                UserSet.AllCardSets.Add(cardSet as CardSet);
            }
            else
            {
                throw new ArgumentException("The given CardSet already exists within the current UserSet."
               , "UserSetName");
            }

        }

        public bool AllowToAddCardSet(string name)
        {
            bool retval = true;

            foreach (var set in UserSet.AllCardSets)
            {
                if (set.Name == name)
                {
                    retval = false;
                }
            }
            return retval;
        }
    }
}
