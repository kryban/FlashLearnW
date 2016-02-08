using FlashLearnW.Interfaces;
using System;
using System.ComponentModel;

namespace FlashLearnW.Models
{
    public class Card : ICard, INotifyPropertyChanged
    {
		public string ID { get; set; }

        private string question;
        public string Question
        {
            get { return question +"//ID: "+ ID; }
            set
            {
                question = value;
                NotifyPropertyChanged("Question");
            }
        }

        private string answer;
        public string Answer
        {
            get { return answer; }
            set
            {
                answer = value;
                NotifyPropertyChanged("Answer");
            }
        }

        // most difficults = 1.1 and most easy = 2.5
        private double easinessFactor;
        public double EasinessFactor
        {
            get { return easinessFactor; }
            set
            {
                easinessFactor = value;
                NotifyPropertyChanged("EasinessFactor");
            }
        }

        private int numberOfIterations;
        public int NumberOfIterations
        {
            get { return numberOfIterations; }
            set
            {
                numberOfIterations = value;
                NotifyPropertyChanged("NumberOfIterations");
            }
        }

        private DateTime showDate;
        public DateTime ShowDate
        {
            get { return showDate; }
            set
            {
                showDate = value;
                NotifyPropertyChanged("showDate");
            }
        }

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
			
			ID = IdGenerator.Generate("C_");
        }

        public Card(string question, string answer, DateTime showDate)
        {
            Question = question;
            Answer = answer;
            ShowDate = showDate;

            // default values of a new card
            NumberOfIterations = 0;
            EasinessFactor = 1.1;

			ID = IdGenerator.Generate("C");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
