using System;
using System.Collections.Generic;
using System.Linq;
//using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

// an abstract wrapper for the System.Runtime.Caching.MemoryCache
/*
namespace FlashLearnW.Models.CachingProvider
{
    public abstract class CachingProviderBase
    {
        protected MemoryCache cache = new MemoryCache("CachingProvider");
        static readonly object padlock = new object();

        public CachingProviderBase()
        {
            DeleteLog();
        }

        // notCovered
        // adds an item to the cache 
        protected virtual void AddItem(string key, object value)
        {
            lock(padlock)
            {
                cache.Add(key, value, DateTimeOffset.MaxValue);
            }
        }

        // notCovered
        // removes an item from the cache
        protected virtual void RemoveItem(string key)
        {
            lock(padlock)
            {
                cache.Remove(key);
            }
        }

        // notCovered
        protected virtual object GetItem(string key, bool remove)
        {
            lock(padlock)
            {
                var res = cache[key];

                if (res != null)
                {
                    if(remove == true)
                    {
                        cache.Remove(key);
                    }
                }
                else 
                {
                    DateTime timeStamp = DateTime.Now;
                    WriteToLog(timeStamp + " - CachingProvider-GetItem: Don't contains the given key: "+ key);
                }

                return res;
            }
        }


       // ErrorLogs
        string LogPath = System.Environment.GetEnvironmentVariable("TEMP");

        // notCovered
        protected void DeleteLog()
        {
            System.IO.File.Delete(string.Format("{0}\\CachingProvider_Errors.txt", LogPath));
        }

        // notCovered
        protected void WriteToLog(string text)
        {
            using(System.IO.TextWriter writer = System.IO.File.AppendText(string.Format("{0}\\CachingProvider_Errors.txt", LogPath)))
            {
                writer.WriteLine(text);
                writer.Close();
            }
        }
    }
}
*/