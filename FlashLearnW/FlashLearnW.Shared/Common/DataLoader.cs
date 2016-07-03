using System;

using FlashLearnW.Interfaces;
using FlashLearnW.AppSettings;
using FlashLearnW.Models.FakeData;
using FlashLearnW.Models;
using Windows.Storage;
using System.Threading.Tasks;

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

            if (recentUSerSet == "Unknown" || string.IsNullOrEmpty(recentUSerSet))
            {
                FakeDataHolder fakeDataHolder = new FakeDataHolder();
                fakeDataHolder.LoadFakeData();

                return fakeDataHolder.loadedUserSet;
            }
            else
            {
                return LoadFromFilePath(AppSettingsWrapper.GetSetting(AppSettingsKeyNames.RecentlyUsedUserSet));
            }
        }

		private UserSet LoadFromFilePath(string filePath)
		{
            UserSet loadedUserSet;

            serializer.Deserialize(filePath, out loadedUserSet);

            if (loadedUserSet != null)
            {
                //set current cardset
                loadedUserSet.CurrentCardSet = loadedUserSet.AllCardSets[0];
                //set card to show
                loadedUserSet.CurrentCard = loadedUserSet.CurrentCardSet.Cards[0];
            }
            else
                loadedUserSet = null;

			return loadedUserSet;
		}

        public async Task<CardSet> LoadFrom_StorageFile(StorageFile file)
        {
            return await serializer.DeserializeFrom_StorageFile(file);
        }
	}
}