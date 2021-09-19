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
        /// Note that rotation is cyclical; that is, if the number of places chosen exceeds the
        /// count of the collection, the rotation will be equivalent to rotating by the number of
        /// places modulo the count of the collection.
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
            // Error checking
            Throw.IfArgumentNull(source, nameof(source));

            // Filter out empty collections by breaking
            if (!source.Any()) yield break;

            if (places == 0)
            {
                // Filter out empty rotations by simply returning the original collection
                foreach (var item in source) yield return item;
            }
            else if (places < 0)
            {
                // Will need the count of the collection to interpret the negative rotation
                var count = source.Count();

                // Rewrite the negative rotation as a positive rotation
                places = places % count + count;

                if (places == 0) 
                {
                    // Avoid having to iterate twice through the collection
                    foreach (var item in source) yield return item;
                }
                else
                {
                    // Yield the items after skipping places elements
                    foreach (var item in source.Skip(places)) yield return item;

                    // Yield the items initially skipped
                    foreach (var item in source.Take(places)) yield return item;
                }
            }
            else // Handle positive case
            {
                /*
                 * Shift the collection by the specified number of places
                 * 
                 * If there are too many places, we can use this to get the count of the collection
                 * and use that in turn to get a correct rotation
                 */
                var enumerator = source.GetEnumerator();
                int count = 0;
                bool tooManyPlaces = false;
                while (count < places)
                {
                    if (enumerator.MoveNext())
                    {
                        // We counted another element of the collection
                        count++;
                    }
                    else
                    {
                        /*
                         * The end of the collection was reached before reaching the specified
                         * number of places
                         * 
                         * We counted the collection, so we can use the count to properly rotate
                         * the collection
                         */
                        tooManyPlaces = true;
                        break;
                    }
                }

                if (tooManyPlaces)
                {
                    // Redefine places to get the actual shift
                    places %= count;

                    // Yield the items after skipping places elements
                    foreach (var item in source.Skip(places)) yield return item;

                    // Yield the items initially skipped
                    foreach (var item in source.Take(places)) yield return item;
                }
                else
                {
                    // Filter out the case where we have rotated by exactly the number of elements
                    // in the collection to avoid having to count to the length of the collection
                    // while iterating
                    if (enumerator.MoveNext())
                    {
                        yield return enumerator.Current;

                        // Yield the remaining elements of the collection
                        while (enumerator.MoveNext())
                        {
                            yield return enumerator.Current;
                        }

                        // Yield the elements initially skipped
                        foreach (var item in source.Take(places)) yield return item;
                    }
                    else
                    {
                        // Just return the original collection, since we have rotated the collection
                        // exactly once
                        foreach (var item in source) yield return item;
                    }
                }
            }
        }
    }
}
