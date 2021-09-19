using REMuns.CoreUtils.Control.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REMuns.CoreUtils.Extensions
{
    /// <summary>
    /// Static and extension methods for working with <see cref="IEnumerable{T}"/> instances.
    /// </summary>
    public static class Enumerables
    {
        /// <summary>
        /// Rotates the current <see cref="IEnumerable{T}"/> by a specified number of places.
        /// </summary>
        /// <remarks>
        /// Note that rotation is not cyclical; that is, if the number of places chosen exceeds the
        /// count of the collection, the original collection will be returned, rather than allowing
        /// the rotation to start again at the beginning when the count has been reached.
        /// </remarks>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="places">The number of places to rotate by.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> was null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="places"/> was negative.
        /// </exception>
        public static IEnumerable<TSource> Rotate<TSource>(
            this IEnumerable<TSource> source, int places)
        {
            Throw.IfArgumentNull(source, nameof(source));
            Throw.IfArgumentNegative(places, nameof(places));

            // Skip the number of places rotated and yield the rest of the enumerable
            foreach (var t in source.Skip(places))
            {
                yield return t;
            }

            // Go back to the beginning and return the elements skipped initially
            var enumerator = source.GetEnumerator();
            int i = 0;
            do
            {
                if (!enumerator.MoveNext())
                {
                    /*
                     * Have past the end of the collection; just break out of the loop
                     * 
                     * In this case, the method will have returned the original collection,
                     * since the number of places to rotate exceeded the count
                     */
                    yield break;
                }

                yield return enumerator.Current;
                i++;
            }
            while (i < places);
        }
    }
}
