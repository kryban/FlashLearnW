using FlashLearnW.Interfaces;
using System;

namespace FlashLearnW.Models
{
    public class Card : ICard
    {
		public string ID { get; set; }
		
		public string Question { get; set; }
        public string Answer { get; set; }

        // most difficults = 1.1 and most easy = 2.5
        public double EasinessFactor { get; set; }

        public int NumberOfIterations { get; set; }

        public DateTime ShowDate { get; set; }

        public Card()
        {
            // this constructor is needed for deep copy object cloner
        }

        public Card(string question, string answer)
        {
            Question = question;
            Answer = answer;

            // default values of a new card
            ShowDate = DateTime.Now;
            NumberOfIterations = 0;
            EasinessFactor = 1.1;
			
			ID = IdGenerator.Generate();
        }

        public Card(string question, string answer, DateTime showDate)
        {
            Question = question;
            Answer = answer;
            ShowDate = showDate;

            // default values of a new card
            NumberOfIterations = 0;
            EasinessFactor = 1.1;

			ID = IdGenerator.Generate();
        }

    }
}
