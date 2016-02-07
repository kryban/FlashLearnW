using System;

using FlashLearnW.Interfaces;
using FlashLearnW.AppSettings;
using FlashLearnW.Models.FakeData;
using FlashLearnW.Models;

namespace FlashLearnW.Common
{
    public class DataLoader
	{
		private ISerializer serializer;
        private AppSettingsWrapper appSettingsWrapper;
		
		public DataLoader(ISerializer serializer)
		{
			this.serializer = serializer;
		}

        public DataLoader() : this(new DataSerializer()) { }

        public UserSet Load()
        {
            string recentUSerSet = AppSettingsWrapper.GetSetting(AppSettingsKeyNames.RecentlyUsedUserSet);

            if (recentUSerSet == String.Empty)
            {
                FakeDataHolder fakeDataHolder = new FakeDataHolder();
                fakeDataHolder.LoadFakeData();

                return fakeDataHolder.loadedUserSet;
            }
            else
            {
                return LoadFromFile(AppSettingsWrapper.GetSetting(AppSettingsKeyNames.RecentlyUsedUserSet));
            }
        }

		private UserSet LoadFromFile(string filePath)
		{
			UserSet loadedUserSet = serializer.Deserialize(filePath);

			//set current cardset
			loadedUserSet.CurrentCardSet = loadedUserSet.AllCardSets[0];

			//set card to show
			loadedUserSet.CurrentCard = loadedUserSet.CurrentCardSet.Cards[0];

			return loadedUserSet;
		}
	}
}