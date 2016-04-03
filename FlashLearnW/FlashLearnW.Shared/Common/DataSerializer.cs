using System;
using System.Collections.Generic;
//using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

using FlashLearnW.Interfaces;
using Newtonsoft.Json; // http://james.newtonking.com/json
using System.IO;
using Windows.Storage;
using FlashLearnW.Models;
using System.Text.RegularExpressions;

namespace FlashLearnW.Common
{
    public class DataSerializer : ISerializer
    {
        private JsonSerializer jsonSerializer;
		private string DefaultPathUserSet;

        public DataSerializer()
        {
            jsonSerializer = new JsonSerializer();
            jsonSerializer.NullValueHandling = NullValueHandling.Ignore;
        }

        public bool SerializeToLocalFolder(string name, object objectToSerialize)
        {
            bool SerializeResult;

            try
            {
                string tmpName = Regex.Replace(name, "[^0-9a-zA-Z]+", "");
                tmpName += tmpName + ".json";

                Stream stream = ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(tmpName, CreationCollisionOption.ReplaceExisting).Result;

                using (StreamWriter sw = new StreamWriter(stream))
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(sw))
                {
                    jsonSerializer.Serialize(jsonTextWriter, objectToSerialize);
                }

                SerializeResult = true;
            }
            catch (Exception)
            {
                SerializeResult = false;
                throw;
            }

            return SerializeResult;
        }

        public UserSet Deserialize(string path) 
        {
            Stream stream = ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(path).Result;

            using (StreamReader sr = new StreamReader(stream))
            using(JsonTextReader jsonTextReader = new JsonTextReader(sr))
            {
                return jsonSerializer.Deserialize<UserSet>(jsonTextReader);
            }
        }

		//public string LoadUserSetPath()
		//{
     //    return Convert.ToString(ConfigurationManager.AppSettings["UserSetPath"]);
		//}

		//public void SaveToFile(object objectToSerialize, string userSetPath = null)
		//{
		//	string path = userSetPath == null ? LoadUserSetPath() : userSetPath;

		//	Serialize(path, objectToSerialize);
		//}
    }
}
