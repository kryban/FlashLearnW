using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace FlashLearnW.Models
{
    public class ObjectCloner
    {
        /// <summary>
        /// Generic method that receives an object and returns an identical copy of that object
        /// </summary>
        /// <typeparam name="T">Type of the object that needs to be copied</typeparam>
        /// <param name="originalObject">Object that needs to be copied</param>
        /// <returns></returns>
        public T Clone<T>(T originalObject)
        {
            Type givenType = originalObject.GetType();
            // create new object of the given type
            T newInstance = (T)Activator.CreateInstance(givenType);

            IList<PropertyInfo> propsOriginalObject = new List<PropertyInfo>(givenType.GetRuntimeProperties());
            IList<PropertyInfo> propsNewInstance = new List<PropertyInfo>(givenType.GetRuntimeProperties());

            //set all the properties of the new class with the values of the original class
            foreach (var propOriginal in propsOriginalObject)
            {
                foreach(var propNewInstance in propsNewInstance)
                {
                    if (propOriginal == propNewInstance)
                    {
                        propNewInstance.SetValue(newInstance, propOriginal.GetValue(originalObject));
                        break;
                    }
                }
            }

            return newInstance;
        }
    }
}
