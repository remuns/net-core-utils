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

        /// <summary>
        /// Tests that the rotation method works on zero length collections without any exceptions.
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
        /// Tests the rotation method on general non-empty collections when rotating more elements
        /// than the length of the collection, in order to ensure the original collection is
        /// returned in this case.
        /// </summary>
        [TestMethod, TestCategory(nameof(Enumerables.Rotate))]
        public void TestRotate_TooManyPlaces()
        {
            var arr = new int[] { Random.Next(), Random.Next(), Random.Next() };
            Assert.IsTrue(arr.Rotate(10).SequenceEqual(arr));
        }

        /// <summary>
        /// Tests the rotation method on general non-empty collections.
        /// </summary>
        [TestMethod, TestCategory(nameof(Enumerables.Rotate))]
        public void TestRotate_NonEmpty()
        {
            var arr = new int[] { Random.Next(), Random.Next(), Random.Next(), Random.Next() };
            Assert.IsTrue(arr.Rotate(2).SequenceEqual(arr.Skip(2).Concat(arr.Take(2))));
        }
    }
}
