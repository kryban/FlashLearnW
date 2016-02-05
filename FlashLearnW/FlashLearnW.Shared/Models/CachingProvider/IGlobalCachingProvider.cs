using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashLearnW.Models.CachingProvider
{
    public interface IGlobalCachingProvider
    {
        void AddItem(string key, object value);
        object GetItem(string key, bool remove);
        void RemoveItem(string key);

        List<string> DescriptionOfItemsInCache();
    }
}
