using System;

namespace FlashLearnW.Models
{
    public class IdGenerator
	{
		// once an id is given it cannot change anymore
		// an id must be unique throughout the whole cardset
		// since a card can move from one set to another, it must be unique globally

		public static string Generate()
		{
            return Guid.NewGuid().ToString();
		}
	}
}