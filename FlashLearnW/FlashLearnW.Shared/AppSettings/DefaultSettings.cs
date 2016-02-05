using System;
using System.Collections.Generic;
using System.Text;

namespace FlashLearnW.AppSettings
{
    internal class DefaultSettings
    {
        public Dictionary<string, string> DefaultSettingsDictionary;

        public DefaultSettings()
        {
            string localSettingsPath = Windows.Storage.ApplicationData.Current.LocalFolder.Path;

            DefaultSettingsDictionary = new Dictionary<string, string>()
            {
                {AppSettingsKeyNames.FakeUserSetName, "Default" },
                {AppSettingsKeyNames.MinimumEasinessFactor, "1.3" },
                {AppSettingsKeyNames.UseMinimumEasinessFactor, "true" },
                {AppSettingsKeyNames.UserSetPath, localSettingsPath  },
                {AppSettingsKeyNames.RecentlyUsedUserSet, String.Empty }
            };
        }


    }
}
