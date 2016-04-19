using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FlashLearnW.Models;

namespace FlashLearnW.Interfaces
{
    public interface ISerializer
    {
        bool SerializeToLocalFolder(string path, object objectToSerialize);
        bool Deserialize(string path, out UserSet retval);
		//string LoadUserSetPath();
    }
}
