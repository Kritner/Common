using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kritner.Common.TestHelpers
{

    /// <summary>
    /// Exception used for Unmodifyable properties within a class.
    /// </summary>
    public class UnmodifyablePropertyException : Exception
    {

        #region Private
        IDictionary _propertiesThatCouldNotBeModified;
        #endregion Private

        #region Public properties
        /// <summary>
        /// The properties that could not be modified
        /// </summary>
        public override IDictionary Data
        {
            get
            {
                return _propertiesThatCouldNotBeModified;
            }
        }
        #endregion Public properties

        #region ctor
        /// <summary>
        /// Exception when a property was not modifyable
        /// </summary>
        /// <param name="propertyThatCouldNotBeModified">The property name that couldn't be modified</param>
        public UnmodifyablePropertyException(string propertyThatCouldNotBeModified) :
            base(propertyThatCouldNotBeModified) { }

        /// <summary>
        /// Exception describing the properties that couldn't be modified.  Properties are contained within "Data"
        /// </summary>
        /// <param name="propertiesThatCouldNotBeModified">List of properties that couldn't be modified.</param>
        public UnmodifyablePropertyException(IDictionary propertiesThatCouldNotBeModified)
        {
            this._propertiesThatCouldNotBeModified = propertiesThatCouldNotBeModified;
        }
        #endregion ctor
    }
}
