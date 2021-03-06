using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace REMuns.CoreUtils.Control
{
    /// <summary>
    /// Extensions for the <see cref="Option{TObject}"/> struct when the wrapped type is a
    /// value type.
    /// </summary>
    public static class StructOptionExtensions
    {
        /// <summary>
        /// Unwraps the current option as a nullable value.
        /// </summary>
        /// <typeparam name="TObject"></typeparam>
        /// <param name="opt"></param>
        /// <returns>
        /// The value wrapped in the option if it was non-empty, or null otherwise.
        /// </returns>
        public static TObject? ToNullable<TObject>(this Option<TObject> opt) where TObject : struct
            => opt.HasValue ? opt.ValueOrDefault : null;

        /// <summary>
        /// Collapses an option wrapping null into an empty option, simplifying the type of
        /// the option.
        /// </summary>
        /// <typeparam name="TObject"></typeparam>
        /// <param name="opt"></param>
        /// <returns>
        /// An option wrapping the value wrapped in the option passed in if the wrapped value was
        /// non-null, or an empty option otherwise.
        /// </returns>
        public static Option<TObject> CollapseNullable<TObject>(this Option<TObject?> opt)
        where TObject : struct
        {
            if (opt.HasValue)
            {
                return opt.ValueOrDefault is TObject value ? new(value) : default;
            }
            else
            {
                return default;
            }
        }
    }

    /// <summary>
    /// Extensions for the <see cref="Option{TObject}"/> struct when the wrapped type is a
    /// reference type.
    /// </summary>
    public static class ClassOptionExtensions
    {
        /// <inheritdoc cref="StructOptionExtensions.ToNullable{TObject}(Option{TObject})"/>
        public static TObject? ToNullable<TObject>(this Option<TObject> opt) where TObject : class
            => opt.HasValue ? opt.ValueOrDefault : null;

        /// <inheritdoc cref="StructOptionExtensions.CollapseNullable{TObject}(Option{TObject?})"/>
        public static Option<TObject> CollapseNullable<TObject>(this Option<TObject?> opt)
        where TObject : class
        {
            if (opt.HasValue)
            {
                return opt.ValueOrDefault is TObject value ? new(value) : default;
            }
            else
            {
                return default;
            }
        }
    }

    /// <summary>
    /// Applicable extensions for the <see cref="Option{TObject}"/> struct.
    /// </summary>
    /// <remarks>
    /// The methods in this class are named "Invoke" to match C# function naming conventions.
    /// </remarks>
    public static class ApplicableOptionExtensions
    {
        /// <summary>
        /// Invokes the function wrapped in the current instance if it wraps a value.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="opt"></param>
        /// <returns></returns>
        public static Option<TResult> Invoke<TResult>(this Option<Func<TResult>> opt)
            => opt.Select(f => f());

        /// <summary>
        /// Invokes the function wrapped in the current instance if it wraps a value.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="opt"></param>
        /// <returns></returns>
        public static Option<TResult> Invoke<T, TResult>(
            this Option<Func<T, TResult>> opt, T arg)
            => opt.Select(f => f(arg));

        /// <summary>
        /// Invokes the function wrapped in the current instance if it wraps a value.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="opt"></param>
        /// <returns></returns>
        public static Option<TResult> Invoke<T1, T2, TResult>(
            this Option<Func<T1, T2, TResult>> opt, T1 arg1, T2 arg2)
            => opt.Select(f => f(arg1, arg2));

        /// <summary>
        /// Invokes the function wrapped in the current instance if it wraps a value.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="opt"></param>
        /// <returns></returns>
        public static Option<TResult> Invoke<T1, T2, T3, TResult>(
            this Option<Func<T1, T2, T3, TResult>> opt, T1 arg1, T2 arg2, T3 arg3)
            => opt.Select(f => f(arg1, arg2, arg3));

        /// <summary>
        /// Invokes the function wrapped in the current instance if it wraps a value.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="opt"></param>
        /// <returns></returns>
        public static Option<TResult> Invoke<T1, T2, T3, T4, TResult>(
            this Option<Func<T1, T2, T3, T4, TResult>> opt, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
            => opt.Select(f => f(arg1, arg2, arg3, arg4));

        /// <summary>
        /// Invokes the function wrapped in the current instance if it wraps a value.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="opt"></param>
        /// <returns></returns>
        public static Option<TResult> Invoke<T1, T2, T3, T4, T5, TResult>(
            this Option<Func<T1, T2, T3, T4, T5, TResult>> opt,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
            => opt.Select(f => f(arg1, arg2, arg3, arg4, arg5));

        /// <summary>
        /// Invokes the function wrapped in the current instance if it wraps a value.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="opt"></param>
        /// <returns></returns>
        public static Option<TResult> Invoke<T1, T2, T3, T4, T5, T6, TResult>(
            this Option<Func<T1, T2, T3, T4, T5, T6, TResult>> opt,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
            => opt.Select(f => f(arg1, arg2, arg3, arg4, arg5, arg6));

        /// <summary>
        /// Invokes the function wrapped in the current instance if it wraps a value.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="opt"></param>
        /// <returns></returns>
        public static Option<TResult> Invoke<T1, T2, T3, T4, T5, T6, T7, TResult>(
            this Option<Func<T1, T2, T3, T4, T5, T6, T7, TResult>> opt,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
            => opt.Select(f => f(arg1, arg2, arg3, arg4, arg5, arg6, arg7));

        /// <summary>
        /// Invokes the function wrapped in the current instance if it wraps a value.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="opt"></param>
        /// <returns></returns>
        public static Option<TResult> Invoke<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(
            this Option<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>> opt,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
            => opt.Select(f => f(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8));

        /// <summary>
        /// Invokes the function wrapped in the current instance if it wraps a value.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="opt"></param>
        /// <returns></returns>
        public static Option<TResult> Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
            this Option<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>> opt,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
            => opt.Select(f => f(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9));

        /// <summary>
        /// Invokes the function wrapped in the current instance if it wraps a value.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="opt"></param>
        /// <returns></returns>
        public static Option<TResult> Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(
            this Option<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>> opt,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8,
            T9 arg9, T10 arg10)
            => opt.Select(f =>
                f(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10));

        /// <summary>
        /// Invokes the function wrapped in the current instance if it wraps a value.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="opt"></param>
        /// <returns></returns>
        public static Option<TResult> Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
            this Option<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>> opt,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8,
            T9 arg9, T10 arg10, T11 arg11)
            => opt.Select(f =>
                f(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11));

        /// <summary>
        /// Invokes the function wrapped in the current instance if it wraps a value.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="opt"></param>
        /// <returns></returns>
        public static Option<TResult> Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(
            this Option<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>> opt,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8,
            T9 arg9, T10 arg10, T11 arg11, T12 arg12)
            => opt.Select(f =>
                f(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12));

        /// <summary>
        /// Invokes the function wrapped in the current instance if it wraps a value.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="opt"></param>
        /// <returns></returns>
        public static Option<TResult> Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(
            this Option<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>> opt,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8,
            T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
            => opt.Select(f =>
                f(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13));

        /// <summary>
        /// Invokes the function wrapped in the current instance if it wraps a value.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="opt"></param>
        /// <returns></returns>
        public static Option<TResult> Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(
            this Option<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>> opt,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8,
            T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
            => opt.Select(f =>
                f(
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8,
                    arg9, arg10, arg11, arg12, arg13, arg14));

        /// <summary>
        /// Invokes the function wrapped in the current instance if it wraps a value.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="opt"></param>
        /// <returns></returns>
        public static Option<TResult> Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(
            this Option<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>> opt,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8,
            T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
            => opt.Select(f =>
                f(
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8,
                    arg9, arg10, arg11, arg12, arg13, arg14, arg15));

        /// <summary>
        /// Invokes the function wrapped in the current instance if it wraps a value.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="opt"></param>
        /// <returns></returns>
        public static Option<TResult> Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
            this Option<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>> opt,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8,
            T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16)
            => opt.Select(f =>
                f(
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8,
                    arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16));
    }

    /// <summary>
    /// General-purpose extensions and static functionality relating to the
    /// <see cref="Option{TObject}"/> struct.
    /// </summary>
    public static class Option
    {
        /// <summary>
        /// Creates a new <see cref="Option{TObject}"/> from the nullable value passed in.
        /// </summary>
        /// <typeparam name="TObject"></typeparam>
        /// <param name="nullableValue"></param>
        /// <returns>
        /// An option wrapping the value if the value was not null, otherwise an empty option.
        /// </returns>
        public static Option<TObject> FromNullable<TObject>(TObject? nullableValue)
            => nullableValue is null ? new() : new(nullableValue);

        /// <summary>
        /// Creates a new non-empty <see cref="Option{TObject}"/> wrapping the value passed in.
        /// </summary>
        /// <typeparam name="TObject"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Option<TObject> Some<TObject>(TObject value) => new(value);

        /// <summary>
        /// Creates a new empty <see cref="Option{TObject}"/>.
        /// </summary>
        /// <typeparam name="TObject"></typeparam>
        /// <returns></returns>
        public static Option<TObject> None<TObject>() => default;
    }

    /// <summary>
    /// Represents an optional value, either wrapping a value ("Some") or empty ("None").
    /// </summary>
    /// <remarks>
    /// This struct can be used as a simple, lightweight, type-safe alternative to
    /// <see cref="Nullable{T}"/>.
    /// </remarks>
    /// <typeparam name="TObject"></typeparam>
    public readonly struct Option<TObject> : IEnumerable<TObject>, IEquatable<Option<TObject>>
    {
        /// <summary>
        /// Gets the value wrapped in this option.
        /// </summary>
        /// <exception cref="EmptyOptionException">
        /// The option was empty.
        /// </exception>
        public TObject Value => HasValue ? _value : throw new EmptyOptionException();

        /// <summary>
        /// Gets the value wrapped in this option, or the default value of type
        /// <typeparamref name="TObject"/> if the option is empty.
        /// </summary>
        public TObject ValueOrDefault => _value;

        /// <summary>
        /// Internally represents the wrapped value.
        /// </summary>
        private readonly TObject _value;

        /// <summary>
        /// Gets whether or not this option is empty (i.e. does not wrap a value).
        /// </summary>
        public bool IsEmpty => !HasValue;

        /// <summary>
        /// Gets whether or not this option wraps a value.
        /// </summary>
        public bool HasValue { get; }

        /// <summary>
        /// Constructs a new <see cref="Option{TObject}"/> wrapping the value passed in.
        /// </summary>
        /// <param name="value"></param>
        public Option(TObject value)
        {
            HasValue = true;
            _value = value;
        }

        /// <inheritdoc cref="IEnumerable.GetEnumerator"/>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc cref="IEnumerable{T}.GetEnumerator"/>
        public IEnumerator<TObject> GetEnumerator()
        {
            if (HasValue) yield return _value;
        }

        /// <summary>
        /// Attempts to set the out parameter to the value wrapped in this option.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>
        /// true if the option wraps a value and the out parameter was set to it, otherwise false.
        /// </returns>
        public bool TryGetValue(out TObject value)
        {
            value = _value;
            return HasValue;
        }

        /// <summary>
        /// Maps a selector over this option.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="selector"></param>
        /// <returns></returns>
        public Option<TResult> Select<TResult>(Func<TObject, TResult> selector)
            => HasValue ? new(selector(_value)) : default;

        /// <summary>
        /// Binds a selector to this option.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="selector"></param>
        /// <returns></returns>
        public Option<TResult> SelectMany<TResult>(Func<TObject, Option<TResult>> selector)
            => HasValue ? selector(_value) : default;

        /// <summary>
        /// Merges this option with another, using the merger function passed in to create the
        /// wrapped result.
        /// </summary>
        /// <typeparam name="TOther"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="other"></param>
        /// <param name="merger"></param>
        /// <returns>
        /// An option wrapping the result of the merge operation if both options are non-empty,
        /// otherwise an empty option.
        /// </returns>
        public Option<TResult> MergeWith<TOther, TResult>(
            Option<TOther> other, Func<TObject, TOther, TResult> merger)
        {
            if (HasValue && other.HasValue)
            {
                return new(merger(_value, other._value));
            }
            else
            {
                return default;
            }
        }

        /// <summary>
        /// Replaces the value wrapped in the option with the value passed in if it wraps a value,
        /// and returns an empty option otherwise.
        /// </summary>
        /// <typeparam name="TOther"></typeparam>
        /// <param name="other"></param>
        /// <returns></returns>
        public Option<TOther> Replace<TOther>(TOther other) => HasValue ? new(other) : default;

        /// <summary>
        /// Gets an option wrapping the value passed in if this option is empty.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>
        /// An option wrapping the value passed in if this option is empty, otherwise the option
        /// passed in.
        /// </returns>
        public Option<TObject> FillIfEmpty(TObject value) => HasValue ? this : new(value);

        /// <summary>
        /// Filters this option using a predicate.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Option<TObject> Where(Func<TObject, bool> predicate)
        {
            if (HasValue)
            {
                return predicate(_value) ? this : default;
            }
            else
            {
                return default;
            }
        }

        /// <inheritdoc cref="object.Equals(object)"/>
        public override bool Equals(object obj) => obj switch
        {
            Option<TObject> other => Equals(other),
            _ => false,
        };

        /// <summary>
        /// Determines if the two options passed in are equal.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator ==(Option<TObject> lhs, Option<TObject> rhs)
            => lhs.Equals(rhs);

        /// <summary>
        /// Determines if the two options passed in are not equal.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator !=(Option<TObject> lhs, Option<TObject> rhs)
            => !lhs.Equals(rhs);

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode() => HashCode.Combine(HasValue, _value);

        /// <inheritdoc cref="IEquatable{T}.Equals(T)"/>
        public bool Equals(Option<TObject> other)
        {
            if (HasValue == other.HasValue)
            {
                if (_value is null)
                {
                    return other._value is null;
                }
                else
                {
                    return _value.Equals(other._value);
                }
            }
            else
            {
                return false;
            }
        }

        /// <inheritdoc cref="object.ToString"/>
        public override string ToString()
        {
            if (HasValue)
            {
                return $"Some({_value})";
            }
            else
            {
                return "None";
            }
        }
    }

    /// <summary>
    /// An exception thrown if an attempt is made to unwrap an empty option.
    /// </summary>
    public class EmptyOptionException : InvalidOperationException
    {
        /// <summary>
        /// Constructs a new instance of the <see cref="EmptyOptionException"/> class with a
        /// default message.
        /// </summary>
        public EmptyOptionException() : this("attempt to unwrap empty option") { }

        /// <summary>
        /// Constructs a new instance of the <see cref="EmptyOptionException"/> class with the
        /// descriptive message passed in.
        /// </summary>
        /// <param name="message"></param>
        public EmptyOptionException(string message) : base(message) { }
    }
}
