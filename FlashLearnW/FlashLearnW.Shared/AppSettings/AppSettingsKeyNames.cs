using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Windows.Storage;

namespace FlashLearnW.AppSettings
{
    public static class AppSettingsKeyNames
    {
        /// <summary>
        /// String value. Full path where the current userset should be persisted
        /// </summary>
        public static string UserSetPath { get { return "UserSetPath"; } }

        /// <summary>
        /// String value. in case no data is loaded, default data can be loaded in case user want so
        /// </summary>
        public static string FakeUserSetName { get { return "FakeUserSetName"; } }

        /// <summary>
        /// Boolean value to indicate the use of a minimum in EasinessFactor
        /// </summary>
        public static string UseMinimumEasinessFactor { get { return "UseMinimumEasinessFactor"; } } // true 

        /// <summary>
        /// Double value. Represents the minimum of Easiness Factor to work with
        /// </summary>
        public static string MinimumEasinessFactor { get { return "minimumEasinessFactor"; } } // 1.3

        /// <summary>
        /// String value. Contains the full path of the most recent user set.
        /// </summary>
        public static string RecentlyUsedUserSet { get { return "recentlyUsedUserSet"; } }

        /// <summary>
        /// DateTime value. Represents a date. Cards will be selected that has the next iteration before this date.
        /// </summary>
        public static string ExpectedLearnDay { get { return "expectedLearnDay"; } }
    }
}
