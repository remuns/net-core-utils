using Microsoft.VisualStudio.TestTools.UnitTesting;
using REMuns.CoreUtils.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMuns.CoreUtils.Test.Extensions
{
    [TestClass]
    public class EnumerablesTest
    {
        private static Random Random { get; } = new();

        private static int Count { get; } = Random.Next(2000, 3000);
        private static IEnumerable<int> Collection { get; } = Enumerable.Range(0, Count);

        /// <summary>
        /// Tests that the rotation method works on zero-length collections without any exceptions.
        /// </summary>
        /// <remarks>
        /// This is an edge case test.
        /// </remarks>
        [TestMethod, TestCategory(nameof(Enumerables.Rotate))]
        public void TestRotate_Empty()
        {
            var arr = Array.Empty<int>();
            Assert.IsTrue(arr.Rotate(0).SequenceEqual(arr));
            Assert.IsTrue(arr.Rotate(4).SequenceEqual(arr));
        }

        /// <summary>
        /// Tests that the rotation method works on a non-zero-length collection when performing
        /// a rotation of 0 places (in which case the original collection should be returned).
        /// </summary>
        [TestMethod, TestCategory(nameof(Enumerables.Rotate))]
        public void TestNoRotation()
        {
            Assert.IsTrue(Collection.Rotate(0).SequenceEqual(Collection));
        }

        /// <summary>
        /// Tests the rotation method on general non-empty collections when rotating more elements
        /// than the length of the collection, in order to ensure the rotation is handled properly
        /// despite the overflow.
        /// </summary>
        [TestMethod, TestCategory(nameof(Enumerables.Rotate))]
        public void TestRotate_TooManyPlaces()
        {
            var arr = new int[] { Random.Next(), Random.Next(), Random.Next() };
            Assert.IsTrue(
                Collection.Rotate(4000).SequenceEqual(
                    Collection.Skip(4000 % Count).Concat(Collection.Take(4000 % Count))));
        }

        /// <summary>
        /// Tests that the rotation method returns the initial collection when rotating by the
        /// exact count of the collection.
        /// </summary>
        [TestMethod, TestCategory(nameof(Enumerables.Rotate))]
        public void TestRotate_WholeCollection()
        {
            Assert.IsTrue(Collection.Rotate(Count).SequenceEqual(Collection));
        }

        /// <summary>
        /// Tests the rotation method on general non-empty collections.
        /// </summary>
        [TestMethod, TestCategory(nameof(Enumerables.Rotate))]
        public void TestRotate_NonEmpty()
        {
            Assert.IsTrue(Collection.Rotate(1000).SequenceEqual(
                Collection.Skip(1000).Concat(Collection.Take(1000))));
        }
    }
}
