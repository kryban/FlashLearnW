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

        public void Serialize(string path, object objectToSerialize)
        {
            Stream stream = ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(path, CreationCollisionOption.ReplaceExisting).Result;

            using (StreamWriter sw = new StreamWriter(stream))
            using(JsonTextWriter jsonTextWriter = new JsonTextWriter(sw))
            {
                jsonSerializer.Serialize(jsonTextWriter, objectToSerialize);
            }
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
