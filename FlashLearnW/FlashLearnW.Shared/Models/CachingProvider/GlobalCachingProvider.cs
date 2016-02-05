//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


//namespace FlashLearnW.Models.CachingProvider
//{
//    public class GlobalCachingProvider : CachingProviderBase, IGlobalCachingProvider
//    {
//        # region Singleton

//        protected GlobalCachingProvider()
//        {
//        }

//        public static GlobalCachingProvider Instance
//        {
//            get
//            {
//                return Nested.instance;
//            }
//        }

//        class Nested
//        {
//            // Explicit static constructor to tell C# compiler
//            // not to mark type as beforefieldinit
//            static Nested() { }

//            internal static readonly GlobalCachingProvider instance = new GlobalCachingProvider();
//        }
//        # endregion Singleton

//        //implementation IGlobalCachingProvider
        
//        // notCovered
//        public virtual new void AddItem(string key, object value)
//        {
//            base.AddItem(key, value);
//        }

//        // notCovered
//        public virtual object GetItem(string key)
//        {
//            return base.GetItem(key, false); // True removed becuase it is a Global Cache.
//        }

//        // notCovered
//        public virtual new object GetItem(string key, bool remove)
//        {
//            return base.GetItem(key, remove);
//        }

//        public List<string> DescriptionOfItemsInCache()
//        {
//            List<string> itemDescriptions = new List<string>();

//            foreach(var item in cache)
//            {
//                itemDescriptions.Add(item.Key);
//            }

//            return itemDescriptions;
//        }

//        public virtual new void RemoveItem(string key)
//        {
//            base.RemoveItem(key);
//        }
//    }
//}
