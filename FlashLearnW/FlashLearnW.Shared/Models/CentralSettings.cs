using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using FlashLearnW.Interfaces;

namespace FlashLearnW.Models
{
    /// <summary>
    /// One class for registering the path of the saved cardSet file. 
    /// </summary>
    public sealed class CentralSettings
    {
		
# region Singleton pattern

		private static volatile CentralSettings instance;
		private static object lockObject = new Object();
		
		private CentralSettings() { }

		public static CentralSettings Instance
		{
			get
			{
				if (instance == null)
				{
					lock(lockObject)
					{
						if (instance == null)
							instance = new CentralSettings();
					}
				}
				
				return instance;
			}
		}

# endregion
	
		public bool directoryToSave_hasValue { get; private set; }

        private string directoryToSave;
        public string DirectoryToSave
        {
            get 
            { 
                return directoryToSave; 
            }
            set
            {
                directoryToSave = value;
                directoryToSave_hasValue = true; 
            }
        }

        public string FullPath { get; set; }
    }
}
