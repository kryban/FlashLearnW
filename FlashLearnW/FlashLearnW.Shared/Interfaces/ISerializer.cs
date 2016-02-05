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
        void Serialize(string path, object objectToSerialize);
        UserSet Deserialize(string path);
		//string LoadUserSetPath();
    }
}
