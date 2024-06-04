using Common.Errors;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;

namespace Common.Monads
{
    public class Result<T>: Result
    {
        private T _value;
        public T Value
        {
            get 
            { 
                Contract.Requires(IsSuccess);
                return _value;
            }

            [param:AllowNull]
            private set 
            {
                _value = value;
            }
        }
        protected internal Result([AllowNull] T value, bool isSucces, Error error)
            : base(isSucces, error)
        {
            Contract.Requires(value != null || !isSucces);
            Value = value;
        }
    }
}
