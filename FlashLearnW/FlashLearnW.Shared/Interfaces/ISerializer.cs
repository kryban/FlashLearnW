using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FlashLearnW.Models;
using Windows.Storage;

namespace FlashLearnW.Interfaces
{
    public interface ISerializer
    {
        bool SerializeToLocalFolder(string path, object objectToSerialize);
        bool Deserialize(string path, out UserSet retval);
        Task<CardSet> DeserializeFrom_StorageFile(StorageFile file);
		//string LoadUserSetPath();
    }
}
