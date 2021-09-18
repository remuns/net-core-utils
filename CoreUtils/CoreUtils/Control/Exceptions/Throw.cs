using REMuns.CoreUtils.CodeAnalysis;
using REMuns.CoreUtils.CodeAnalysis.Numerical;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace REMuns.CoreUtils.Control.Exceptions
{
    /// <summary>
    /// Contains a series of methods offering a small fluent API for throwing basic exceptions.
    /// </summary>
    public static class Throw
    {
        #region Numeric
        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument passed in is
        /// a negative number.
        /// </summary>
        /// <param name="arg">The argument to check.</param>
        /// <param name="argName">The name of the argument to use in the thrown exception.</param>
        /// <returns>The argument passed in.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The check failed.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return:NonNegative]
        public static int IfArgumentNegative(int arg, string argName)
            => arg < 0
                ? throw new ArgumentOutOfRangeException(
                    $"{argName} was negative", null as Exception)
                : arg;

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument passed in is
        /// a negative number.
        /// </summary>
        /// <param name="arg">The argument to check.</param>
        /// <param name="argName">The name of the argument to use in the thrown exception.</param>
        /// <returns>The argument passed in.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The check failed.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: NonNegative]
        public static double IfArgumentNegative(double arg, string argName)
            => arg < 0
                ? throw new ArgumentOutOfRangeException(
                    $"{argName} was negative", null as Exception)
                : arg;

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument passed in is
        /// a negative number.
        /// </summary>
        /// <param name="arg">The argument to check.</param>
        /// <param name="argName">The name of the argument to use in the thrown exception.</param>
        /// <returns>The argument passed in.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The check failed.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return:NonNegative]
        public static BigInteger IfArgumentNegative(BigInteger arg, string argName)
            => arg < 0
                ? throw new ArgumentOutOfRangeException(
                    $"{argName} was negative", null as Exception)
                : arg;

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value passed in is not in
        /// the range specified.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arg">The argument to check.</param>
        /// <param name="min">The minimum permitted value.</param>
        /// <param name="max">The maximum permitted value.</param>
        /// <param name="argName">
        /// The name of the argument to specify in the thrown exception.
        /// </param>
        /// <returns>The argument passed in.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The check failed.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T IfArgumentOutOfRange<T>(T arg, T min, T max, string argName)
        where T : IComparable<T>
            => arg.CompareTo(min) >= 0 && arg.CompareTo(max) <= 0
                ? arg
                : throw new ArgumentOutOfRangeException(argName);
        #endregion

        #region Control
        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if the argument passed in is null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arg">The argument to check.</param>
        /// <param name="argName">The name of the argument to use in the thrown exception.</param>
        /// <returns>The argument passed in.</returns>
        /// <exception cref="ArgumentNullException">The check failed.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T IfArgumentNull<T>(T? arg, string argName)
            => arg is null
                ? throw new ArgumentNullException(argName)
                : arg;

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if any of the arguments passed in
        /// are null.
        /// </summary>
        /// <param name="argDescriptions">
        /// A series of value-name pairs describing the arguments and their names.  The names will
        /// be used in any thrown exception.
        /// </param>
        /// <exception cref="ArgumentNullException">The check failed.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IfAnyArgumentNull(params (object? ArgValue, string ArgName)[] argDescriptions)
        {
            foreach (var (ArgValue, ArgName) in argDescriptions)
            {
                if (ArgValue is null) throw new ArgumentNullException(ArgName);
            }
        }

        /// <summary>
        /// Throws an <see cref="InvalidEnumArgumentException"/> if the argument passed in is
        /// not a named, defined value of type <typeparamref name="E"/>.
        /// </summary>
        /// <typeparam name="E"></typeparam>
        /// <param name="arg">The argument to check.</param>
        /// <param name="argName">The name of the argument to use in the thrown exception.</param>
        /// <returns>The argument passed in.</returns>
        /// <returns></returns>
        /// <exception cref="InvalidEnumArgumentException">The check failed.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return:NamedEnumValue]
        public static E IfEnumArgumentUnnamed<E>(E arg, string argName)
        where E : struct, Enum
            => Enum.IsDefined(typeof(E), arg)
                ? arg
                : throw new InvalidEnumArgumentException(
                    $"{argName} was not a named, defined value of type {nameof(E)}");
        #endregion
    }
}
