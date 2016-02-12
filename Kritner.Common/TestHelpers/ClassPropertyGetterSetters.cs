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
            TClass objectToModify = tClass.CloneObject<TClass>();

            PropertyInfo[] properties = typeof(TClass).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            List<string> unmodifyableProperties = new List<string>();

            // For every public property in the class
            foreach (PropertyInfo property in properties)
            {
                try
                {
                    objectToModify = ChangeClassProperty(objectToModify, property);
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

            return objectToModify;
        }

        /// <summary>
        /// Change the property value if of applicable type
        /// </summary>
        /// <typeparam name="TClass"></typeparam>
        /// <param name="modifiedClass">The class to modify</param>
        /// <param name="property">The property to modify</param>
        private static TClass ChangeClassProperty<TClass>(TClass modifiedClass, PropertyInfo property) where TClass : class
        {

            bool canSet = true;

            if (!property.CanWrite || !property.CanRead)
                canSet = false;

            MethodInfo mget = property.GetGetMethod(false);
            MethodInfo mset = property.GetSetMethod(false);

            if (mget == null || mset == null)
                canSet = false;

            if (canSet)
            {
                var currentValue = modifiedClass
                    .GetType()
                    .GetProperty(property.Name)
                    .GetValue(modifiedClass, null);

                switch (Type.GetTypeCode(property.PropertyType))
                {
                    case TypeCode.Boolean:
                        property.SetValue(modifiedClass, !(bool)currentValue);
                        break;

                    case TypeCode.String:
                        if (currentValue == null)
                            break;
                        property.SetValue(modifiedClass, string.Format("{0}1", currentValue));
                        break;

                    case TypeCode.DateTime:
                        DateTime dt = DateTime.Parse(currentValue.ToString());

                        if (dt == DateTime.MaxValue)
                            property.SetValue(modifiedClass, dt.AddDays(-1));
                        else
                            property.SetValue(modifiedClass, dt.AddDays(1));
                        break;

                    case TypeCode.Int16:
                        Int16 int16 = Convert.ToInt16(currentValue);
                        if (int16 == Int16.MaxValue)
                            property.SetValue(modifiedClass, int16--);
                        else
                            property.SetValue(modifiedClass, int16++);
                        break;

                    case TypeCode.Int32:
                        Int32 int32 = Convert.ToInt32(currentValue);
                        if (int32 == Int32.MaxValue)
                            property.SetValue(modifiedClass, int32--);
                        else
                            property.SetValue(modifiedClass, int32++);
                        break;

                    case TypeCode.Int64:
                        Int64 int64 = Convert.ToInt64(currentValue);
                        if (int64 == Int64.MaxValue)
                            property.SetValue(modifiedClass, int64--);
                        else
                            property.SetValue(modifiedClass, int64++);
                        break;

                    case TypeCode.Decimal:
                        Decimal decimalVal = Convert.ToDecimal(currentValue);
                        if (decimalVal == Decimal.MaxValue)
                            property.SetValue(modifiedClass, decimalVal--);
                        else
                            property.SetValue(modifiedClass, decimalVal++);
                        break;

                    case TypeCode.Double:
                        Double doubleVal = Convert.ToDouble(currentValue);
                        if (doubleVal == Double.MaxValue)
                            property.SetValue(modifiedClass, doubleVal--);
                        else
                            property.SetValue(modifiedClass, doubleVal++);
                        break;

                    default:
                        throw new UnmodifyablePropertyException(property.Name);
                }
            }

            return modifiedClass;
        }
    }
}
