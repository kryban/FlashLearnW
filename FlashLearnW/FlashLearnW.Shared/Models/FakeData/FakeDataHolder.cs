using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FlashLearnW.Models.FakeData
{
    public class FakeDataHolder
	{
		public UserSet loadedUserSet;

		StringRandomizer randomizer = new StringRandomizer();

		public void LoadFakeData()
		{
			loadedUserSet = new UserSet()
			{
				UserName = "Karoy",
				AllCardSets = new ObservableCollection<CardSet>()
				{
#region CardSet1
					new CardSet("Karoy's kaartenset",
									"Dit is een eerste kaartenset")
					{
						Cards = new ObservableCollection<Card>()
						{ new Card(randomizer.RandomizeString(20, "s1"), randomizer.RandomizeString(20, "s1"))
										 {ShowDate = DateTime.Today.AddDays(1), EasinessFactor = 1.5, NumberOfIterations = 2},
						  new Card(randomizer.RandomizeString(10, "s1"), randomizer.RandomizeString(30, "s1"))
										 {ShowDate = DateTime.Today.AddDays(2), EasinessFactor = 1.7, NumberOfIterations = 3},
						  new Card(randomizer.RandomizeString(20, "s1"), randomizer.RandomizeString(40, "s1"))
										 {ShowDate = DateTime.Today.AddDays(2), EasinessFactor = 1.9, NumberOfIterations = 4},
						  new Card(randomizer.RandomizeString(30, "s1"), randomizer.RandomizeString(50, "s1"))
										 {ShowDate = DateTime.Today.AddDays(1), EasinessFactor = 2.1, NumberOfIterations = 5},
						  new Card(randomizer.RandomizeString(40, "s1"), randomizer.RandomizeString(60, "s1"))
										 {ShowDate = DateTime.Today.AddDays(2), EasinessFactor = 2.3, NumberOfIterations = 6},
						  new Card(randomizer.RandomizeString(50, "s1"), randomizer.RandomizeString(70, "s1"))
										 {ShowDate = DateTime.Today.AddDays(-2), EasinessFactor = 2.3, NumberOfIterations = 6},
						  new Card(randomizer.RandomizeString(60, "s1"), randomizer.RandomizeString(80, "s1"))
										 {ShowDate = DateTime.Today.AddDays(-2), EasinessFactor = 2.3, NumberOfIterations = 6},
						  new Card(randomizer.RandomizeString(50, "s1"), randomizer.RandomizeString(90, "s1"))
										 {ShowDate = DateTime.Today.AddDays(-2), EasinessFactor = 2.3, NumberOfIterations = 6},
						  new Card(randomizer.RandomizeString(40, "s1"), randomizer.RandomizeString(100, "s1"))
										 {ShowDate = DateTime.Today.AddDays(-2), EasinessFactor = 2.3, NumberOfIterations = 6},
						  new Card(randomizer.RandomizeString(30, "s1"), randomizer.RandomizeString(20, "s1"))
										 {ShowDate = DateTime.Today.AddDays(4), EasinessFactor = 2.3, NumberOfIterations = 6},
						  new Card(randomizer.RandomizeString(20, "s1"), randomizer.RandomizeString(30, "s1"))
										 {ShowDate = DateTime.Today.AddDays(5), EasinessFactor = 2.3, NumberOfIterations = 6},
						  new Card(randomizer.RandomizeString(10, "s1"), randomizer.RandomizeString(40, "s1"))
										 {ShowDate = DateTime.Today.AddDays(-2), EasinessFactor = 2.3, NumberOfIterations = 6},
						  new Card(randomizer.RandomizeString(5, "s1"), randomizer.RandomizeString(50, "s1"))
										 {ShowDate = DateTime.Today.AddDays(-2), EasinessFactor = 2.3, NumberOfIterations = 6},
						  new Card(randomizer.RandomizeString(10, "s1"), randomizer.RandomizeString(60, "s1"))
										 {ShowDate = DateTime.Today.AddDays(-2), EasinessFactor = 2.3, NumberOfIterations = 6},
						  new Card(randomizer.RandomizeString(20, "s1"), randomizer.RandomizeString(80, "s1"))
										 {ShowDate = DateTime.Today.AddDays(-2), EasinessFactor = 2.3, NumberOfIterations = 6},
						  new Card(randomizer.RandomizeString(30, "s1"), randomizer.RandomizeString(2, "s1"))
										 {ShowDate = DateTime.Today.AddDays(4), EasinessFactor = 2.3, NumberOfIterations = 6},
						  new Card(randomizer.RandomizeString(40, "s1"), randomizer.RandomizeString(5, "s1"))
										 {ShowDate = DateTime.Today.AddDays(5), EasinessFactor = 2.3, NumberOfIterations = 6},
						}
					},
#endregion

# region CardSet2
					new CardSet("Een tweede kaartenset",
									"Nog een set om een verzameling van sets te krijgen")
					{	Cards = new ObservableCollection<Card>()
						{ new Card(randomizer.RandomizeString(20, "s2"), randomizer.RandomizeString(20, "s2")) 
										 {ShowDate = DateTime.Today.AddDays(1), EasinessFactor = 1.5, NumberOfIterations = 2},
						  new Card(randomizer.RandomizeString(10, "s2"), randomizer.RandomizeString(30, "s2"))
										 {ShowDate = DateTime.Today.AddDays(2), EasinessFactor = 1.7, NumberOfIterations = 3},
						  new Card(randomizer.RandomizeString(20, "s2"), randomizer.RandomizeString(40, "s2")) 
										 {ShowDate = DateTime.Today.AddDays(3), EasinessFactor = 1.9, NumberOfIterations = 4},
						  new Card(randomizer.RandomizeString(30, "s2"), randomizer.RandomizeString(50, "s2")) 
										 {ShowDate = DateTime.Today.AddDays(4), EasinessFactor = 2.1, NumberOfIterations = 5},
						  new Card(randomizer.RandomizeString(20, "s2"), randomizer.RandomizeString(60, "s2")) 
										 {ShowDate = DateTime.Today.AddDays(5), EasinessFactor = 2.3, NumberOfIterations = 6},
					      new Card(randomizer.RandomizeString(10, "s2"), randomizer.RandomizeString(40, "s2")) 
										 {ShowDate = DateTime.Today.AddDays(4), EasinessFactor = 2.3, NumberOfIterations = 7},
						  new Card(randomizer.RandomizeString(20, "s2"), randomizer.RandomizeString(30, "s2")) 
										 {ShowDate = DateTime.Today.AddDays(3), EasinessFactor = 2.1, NumberOfIterations = 8},
						  new Card(randomizer.RandomizeString(30, "s2"), randomizer.RandomizeString(60, "s2")) 
										 {ShowDate = DateTime.Today.AddDays(0), EasinessFactor = 1.2, NumberOfIterations = 3},
						  new Card(randomizer.RandomizeString(20, "s2"), randomizer.RandomizeString(50, "s2"))
										 {ShowDate = DateTime.Today.AddDays(5), EasinessFactor = 1.1, NumberOfIterations = 2},
						}
					}
# endregion
				}
			};

//          string pathToSerialize = new AppSettings.AppSettingsWrapper().
//			new Serializer().Serialize(Convert.ToString(ConfigurationManager.AppSettings["UserSetPath"]), loadedUserSet); 
		}
	}
}