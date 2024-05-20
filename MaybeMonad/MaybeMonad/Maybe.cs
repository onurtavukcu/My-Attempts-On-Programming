using System.Diagnostics.CodeAnalysis;

namespace Design_Patterns.MaybeMonad
{
    public readonly struct Maybe<TValue> : IEquatable<Maybe<TValue>>
    {
        private readonly MaybeValueWrapper _valueWrapper;
        public TValue MaybeValue
        {
            get
            {
                if (HasNoValue)
                    throw new InvalidOperationException($"Maybe<{typeof(TValue).Name}> construct has no value.");

                return _valueWrapper._value;
            }
        }

        public static Maybe<TValue> None => new();

        public bool HasValue => _valueWrapper != null;
        public bool HasNoValue => !HasValue;

        private Maybe([AllowNull] TValue value)
        {
            _valueWrapper = value is null ? null : new MaybeValueWrapper(value);
        }

        public static implicit operator Maybe<TValue>([AllowNull] TValue value)
        {
            if (value?.GetType() == typeof(Maybe<TValue>))
            {
                return (Maybe<TValue>)(object)value;
            }

            return new Maybe<TValue>(value);
        }

        public static Maybe<TValue> From([AllowNull] TValue obj)
        {
            return new Maybe<TValue>(obj);
        }

        public static bool operator ==([AllowNull] TValue value, Maybe<TValue> maybe)
        {
            if (value is Maybe<TValue>)
                return maybe.Equals(value);

            if (maybe.HasNoValue)
                return false;

            return maybe.MaybeValue.Equals(value);
        }

        public static bool operator !=([AllowNull] TValue value, Maybe<TValue> maybe)
        {
            return !(maybe == value);
        }

        public static bool operator ==(Maybe<TValue> maybe, [AllowNull] TValue value)
        {
            if (value is Maybe<TValue>)
                return maybe.Equals(value);

            if (maybe.HasNoValue)
                return false;

            return maybe.MaybeValue.Equals(value);
        }

        public static bool operator !=(Maybe<TValue> maybe, [AllowNull] TValue value)
        {
            return !(maybe == value);
        }

        public static bool operator ==(Maybe<TValue> first, Maybe<TValue> second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(Maybe<TValue> first, Maybe<TValue> second)
        {
            return !(first == second);
        }

        public override bool Equals(object obj)
        {
            if (obj?.GetType() != typeof(Maybe<TValue>))
            {
                if (obj is TValue value)
                {
                    obj = new Maybe<TValue>(value);
                }

                if (obj is not Maybe<TValue>)
                    return false;
            }

            var other = (Maybe<TValue>)obj;
            return Equals(other);
        }

        public bool Equals(Maybe<TValue> other)
        {
            if (HasNoValue && other.HasNoValue)
                return true;

            if (HasNoValue || other.HasNoValue)
                return false;

            return _valueWrapper._value.Equals(other._valueWrapper._value);
        }

        public override int GetHashCode()
        {
            return HasNoValue
                ? 0
                : _valueWrapper._value.GetHashCode();
        }

        public override string ToString()
        {
            return HasNoValue
                ? "<No value>"
                : MaybeValue.ToString();
        }

        private sealed class MaybeValueWrapper : IDisposable
        {
            private bool _disposed;

            public MaybeValueWrapper(TValue value)
            {
                _value = value;
            }

            internal TValue _value;

            public void Dispose()
            {
                if (_disposed)
                    return;

                _disposed = true;

                var value = _value;

                _value = default;

                if (value is not IDisposable disposableValue)
                    return;

                disposableValue.Dispose();
            }
        }
    }
}
