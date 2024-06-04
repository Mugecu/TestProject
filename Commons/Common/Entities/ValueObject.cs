namespace Common.Entities
{
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        public override bool Equals(object? obj)
        {
            var valueObject = obj as T;
            if(ReferenceEquals(valueObject, null)) return false;
            return EqualsCore(valueObject);
        }

        protected abstract bool EqualsCore(T valueObject);

        public override int GetHashCode() 
        {
            return GetHashCodeCore();
        }

        protected abstract int GetHashCodeCore();

        public static bool operator ==(ValueObject<T> x, ValueObject<T> y)
        {
            if(ReferenceEquals(x, null) && ReferenceEquals(y, null))
                return true;

            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;

            return x.Equals(y);
        }

        public static bool operator != (ValueObject<T> x, ValueObject<T> y)
            => !(x == y);
    }
}
