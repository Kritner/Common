using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Kritner.Common.TestHelpers
{

    /// <summary>
    /// Class is used to take in a class and test the getter/setter of the public properties of that class.
    /// </summary>
    public static class ClassPropertyGetterSetters
    {

        /// <summary>
        /// Takes in a class which will then modify (applicable) public properties, 
        /// then assert that they were successfully set and get.
        /// </summary>
        /// <typeparam name="TClass">The class to reflect on</typeparam>
        /// <param name="tClass">The class to reflect on</param>
        /// <exception cref="UnmodifyablePropertyException">
        /// When an exception of this type is thrown, it signifies there is a property within the class that cannot
        /// automatically be tested.  The consumer should then take a look at the class being tested, and test the properties manually.
        /// </exception>
        public static TClass TestClassProperties<TClass>(TClass tClass)
            where TClass : class
        {
            var properties = tClass.GetType().GetProperties();
            List<string> unmodifyableProperties = new List<string>();

            // For every public property in the class
            foreach (PropertyInfo property in properties)
            {
                try
                {
                    tClass = ChangeClassProperty(tClass, property);
                }
                catch (UnmodifyablePropertyException ex)
                {
                    unmodifyableProperties.Add(ex.Message);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            // If a property exists that couldn't be updated automatically, throw an exception.
            if (unmodifyableProperties.Count > 0)
            {
                Dictionary<string, string> dictProperties = new Dictionary<string, string>();
                foreach (string item in unmodifyableProperties)
                {
                    if (!dictProperties.ContainsKey(item))
                        dictProperties.Add(item, null);
                }

                throw new UnmodifyablePropertyException(dictProperties);
            }

            return tClass;
        }

        /// <summary>
        /// Change the property value if of applicable type
        /// </summary>
        /// <typeparam name="TClass"></typeparam>
        /// <param name="modifiedClass">The class to modify</param>
        /// <param name="property">The property to modify</param>
        private static TClass ChangeClassProperty<TClass>(TClass modifiedClass, PropertyInfo property) where TClass : class
        {

            var propertyType = property.PropertyType;

            try
            {
                switch (Type.GetTypeCode(propertyType))
                {
                    case TypeCode.Boolean:
                        var currentValue = modifiedClass.GetType().GetProperty(property.Name).GetValue(modifiedClass, null);
                        property.SetValue(modifiedClass, !(bool)currentValue);

                        break;

                    default:
                        throw new UnmodifyablePropertyException(property.Name);
                }
            }
            catch
            {
                throw new UnmodifyablePropertyException(property.Name);
            }

            return modifiedClass;
        }
    }
}
