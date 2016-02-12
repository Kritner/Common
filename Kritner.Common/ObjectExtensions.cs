using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kritner.Common
{

    /// <summary>
    /// Extensions for objects
    /// </summary>
    public static class ObjectExtensions
    {

        /// <summary>
        /// Creates and returns a clone of the object passed in
        /// </summary>
        /// <typeparam name="T">object to clone</typeparam>
        /// <param name="source">Object to clone</param>
        /// <returns>Cloned object</returns>
        public static T CloneObject<T> (this T source)
            where T : class
        {
            var serializedT = JsonConvert.SerializeObject(source);

            return JsonConvert.DeserializeObject<T>(serializedT);
        }

    }
}
