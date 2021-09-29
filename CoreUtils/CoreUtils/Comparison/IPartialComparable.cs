using System;
using System.Collections.Generic;
using System.Text;

namespace REMuns.CoreUtils.Comparison
{
    /// <summary>
    /// Defines a generalized comparison method for partially ordered types.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPartialComparable<T>
    {
        /// <summary>
        /// Compares this instance with the other instance passed in.
        /// </summary>
        /// <param name="other"></param>
        /// <returns>
        /// An nullable integer describing the result of the comparison as follows:
        /// <list type="bullet">
        /// <item>
        /// <term>-1</term>
        /// <description>This value is less than <paramref name="other"/>.</description>
        /// </item>
        /// <item>
        /// <term>0</term>
        /// <description>This value is equal to <paramref name="other"/>.</description>
        /// </item>
        /// <item>
        /// <term>1</term>
        /// <description>This value is greater than <paramref name="other"/>.</description>
        /// </item>
        /// <item>
        /// <term>null</term>
        /// <description>The two values do not compare.</description>
        /// </item>
        /// </list>
        /// </returns>
        public int? CompareTo(T other);
    }
}
