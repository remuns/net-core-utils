using System;
using System.Collections.Generic;
using System.Text;

namespace REMuns.CoreUtils.CodeAnalysis.Numerical
{
    /// <summary>
    /// Indicates a detail about the sign of a numerical return value, parameter or property,
    /// even if the corresponding type allows the detail to be false.
    /// </summary>
    [AttributeUsage(
        AttributeTargets.ReturnValue
            | AttributeTargets.Parameter
            | AttributeTargets.Property,
        AllowMultiple = false,
        Inherited = false)]
    public abstract class SignAttribute : Attribute { }

    /// <summary>
    /// Indicates that a return value, parameter or property is positive even if the corresponding
    /// type allows non-positive values.
    /// </summary>
    public class PositiveAttribute : SignAttribute { }

    /// <summary>
    /// Indicates that a return value, parameter or property is negative even if the corresponding
    /// type allows non-negative values.
    /// </summary>
    public class NegativeAttribute : SignAttribute { }

    /// <summary>
    /// Indicates that a return value, parameter or property is non-negative even if the
    /// corresponding type allows negative values.
    /// </summary>
    public class NonNegativeAttribute : SignAttribute { }

    /// <summary>
    /// Indicates that a return value, parameter or property is non-positive even if the
    /// corresponding type allows positive values.
    /// </summary>
    public class NonPositiveAttribute : SignAttribute { }
}
