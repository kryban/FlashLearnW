using System;
using Windows.Storage;

namespace FlashLearnW.AppSettings
{
    public class AppSettingsWrapper
    {
        private static ApplicationDataContainer appSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

        public AppSettingsWrapper()
        {
            //LoadDefaultSettingsAtFirstRun();
        }

        /// <summary>
        // some default settings are default beause they are required through the app
        // therefor, the default settings needs to be placed when they are not set yet
        /// </summary>
        private static void LoadDefaultSettingsAtFirstRun()
        {
            var defaultSettings = new DefaultSettings().DefaultSettingsDictionary;

            foreach (var setting in defaultSettings)
            {
                if (!appSettings.Values.ContainsKey(setting.Key))
                {
                    appSettings.Values.Add(setting.Key, setting.Value);
                    continue;
                }

                string foo = appSettings.Values[setting.Key].ToString();

                if (appSettings.Values[setting.Key] == null || appSettings.Values[setting.Key] == string.Empty)
                {
                    appSettings.Values.Add(setting.Key, setting.Value);
                }
            }
        }

        public static string GetSetting(string settingName)
        {
            LoadDefaultSettingsAtFirstRun();

            if (appSettings.Values.ContainsKey(settingName))
            {
                return appSettings.Values[settingName].ToString();
            }

            return String.Empty;
        }

        public static void AddSetting(string settingName, object value)
        {
            if (appSettings.Values.ContainsKey(settingName))
            {
                appSettings.Values[settingName] = value;
            }
            else
            {
                appSettings.Values.Add(settingName, value);
            }
        }

        public static void ChangeSetting(string settingName, object value)
        {
            if (appSettings.Values.ContainsKey(settingName))
            {
                appSettings.Values[settingName] = value;
            }
        }

        public static void RemoveSetting(string settingName)
        {
            if(appSettings.Values.ContainsKey(settingName))
            {
                appSettings.Values.Remove(settingName);
            }
        }
    }
}
