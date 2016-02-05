using System;
using System.Linq;


namespace FlashLearnW.Models.FakeData
{
    public class StringRandomizer
	{
		Random random = new Random();

		public string RandomizeString(int length, object prefix = null)
		{
			string prfx = prefix == null ? "" : prefix.ToString();

			if (length < 1)
				return "no value";

			string letters = "abcde fghij klmno pqrst uvwxy z ";

			char[] letterSeq = letters.ToArray();
			char[] retValSeq = new char[length];

			for (int i = 0; i < length; i++)
			{
				retValSeq[i] = letterSeq[random.Next(letterSeq.Length)];
			}

			return prfx + new string(retValSeq);
		}
	}
}