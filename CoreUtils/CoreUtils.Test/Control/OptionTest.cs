using Microsoft.VisualStudio.TestTools.UnitTesting;
using REMuns.CoreUtils.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMuns.CoreUtils.Test.Control
{
    [TestClass]
    public class OptionTest
    {
        [TestMethod]
        public void TestToNullable()
        {
            // Should be non-null
            Assert.AreEqual(1, Option.Some(1).ToNullable());
            Assert.AreEqual("string", Option.Some("string").ToNullable());

            // Should be null
            Assert.IsNull(Option.None<int>().ToNullable());
            Assert.IsNull(Option.None<string>().ToNullable());
        }

        [TestMethod]
        public void TestCollapseNullable()
        {
            // Ensure collapsing nullable yields non-empty options when the options do not wrap null
            AssertHasValue(Option.Some<string?>("string").CollapseNullable(), "string");
            AssertHasValue(Option.Some<int?>(4).CollapseNullable(), 4);

            // Ensure collapsing nullable yields empty options when the options wrap null
            AssertIsNone(Option.Some<string?>(null).CollapseNullable());
            AssertIsNone(Option.Some<int?>(null).CollapseNullable());

            // Ensure collapsing nullable yields empty options when the original options are empty
            AssertIsNone(Option.None<string?>().CollapseNullable());
            AssertIsNone(Option.None<int?>().CollapseNullable());
        }

        [TestMethod]
        public void TestEnumeration()
        {
            Assert.IsTrue(new[] { 1 }.SequenceEqual(Option.Some(1)));
            Assert.IsTrue(Array.Empty<int>().SequenceEqual(Option.None<int>()));
        }

        [TestMethod]
        public void TestTryGetValue()
        {
            Assert.IsTrue(Option.Some(4).TryGetValue(out var result));
            Assert.AreEqual(4, result);

            Assert.IsFalse(Option.None<int>().TryGetValue(out _));
        }

        [TestMethod]
        public void TestSelect()
        {
            AssertHasValue(Option.Some(11).Select(i => i.ToString()), "11");
            AssertIsNone(Option.None<int>().Select<string>(i => throw new Exception()));
        }

        [TestMethod]
        public void TestSelectMany()
        {
            AssertHasValue(Option.Some(4).SelectMany(i => Option.Some((i * i).ToString())), "16");

            AssertIsNone(Option.Some(5).SelectMany(i => Option.None<string>()));
            AssertIsNone(Option.None<int>().SelectMany(i => Option.Some(i.ToString())));
        }

        [TestMethod]
        public void TestReplace()
        {
            AssertHasValue(Option.Some("").Replace(4), 4);
            AssertIsNone(Option.None<string>().Replace(5));
        }

        [TestMethod]
        public void TestWhere()
        {
            AssertHasValue(Option.Some(2).Where(i => i % 2 == 0), 2);
            AssertIsNone(Option.Some(3).Where(i => i % 2 == 0));
        }

        [TestMethod]
        public void TestEquality()
        {
            Assert.AreEqual(Option.Some(4), Option.Some(4));
            Assert.AreEqual(Option.Some("sdfd"), Option.Some("sdfd"));
            Assert.AreEqual(Option.Some<string?>(null), Option.Some<string?>(null));
            Assert.AreEqual(Option.None<int>(), Option.None<int>());
        }

        [TestMethod]
        public void TestMergeWith()
        {
            AssertHasValue(Option.Some(3).MergeWith(Option.Some(4.5), (i, d) => i * d), 13.5);
            AssertIsNone(Option.Some(4).MergeWith(Option.None<double>(), (i, d) => i * d));
            AssertIsNone(Option.None<int>().MergeWith(Option.Some(2.3), (i, d) => i * d));
            AssertIsNone(Option.None<int>().MergeWith(Option.None<double>(), (i, d) => i * d));
        }

        [TestMethod]
        public void TestFillIfEmpty()
        {
            AssertHasValue(Option.None<int>().FillIfEmpty(2), 2);
            AssertHasValue(Option.Some(3).FillIfEmpty(2), 3);
        }

        /// <summary>
        /// Asserts that the option passed in is non-empty and wraps a specific value.
        /// </summary>
        /// <typeparam name="TObject"></typeparam>
        /// <param name="option"></param>
        /// <param name="expectedValue"></param>
        public static void AssertHasValue<TObject>(Option<TObject> option, TObject expectedValue)
        {
            Assert.IsTrue(option.TryGetValue(out var value));
            Assert.AreEqual(expectedValue, value);
        }

        /// <summary>
        /// Asserts that the option passed in is non-empty.
        /// </summary>
        /// <typeparam name="TObject"></typeparam>
        /// <param name="option"></param>
        public static void AssertIsSome<TObject>(Option<TObject> option)
            => Assert.IsTrue(option.HasValue);

        /// <summary>
        /// Asserts that the option passed in is empty.
        /// </summary>
        /// <typeparam name="TObject"></typeparam>
        /// <param name="option"></param>
        public static void AssertIsNone<TObject>(Option<TObject> option)
            => Assert.IsTrue(option.IsEmpty);
    }
}
