using System;
using System.Collections.Generic;
using System.Text;

namespace REMuns.CoreUtils.CodeAnalysis
{
    /// <summary>
    /// Indicates that the enumeration-type property, field or return value is always a named,
    /// defined value of the enumeration type.
    /// </summary>
    [AttributeUsage(
            AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.ReturnValue,
            AllowMultiple = false,
            Inherited = false)]
    public class NamedEnumValueAttribute : Attribute { }
}
