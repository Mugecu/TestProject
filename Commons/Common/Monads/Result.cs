using Common.Errors;

namespace Common.Monads
{
    public class Result
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; }
        public static Result Success()
            => new(true, Error.None);
        public static Result Failure(Error error)
            => new(false, error);

        protected Result(bool isSuccess, Error error)
        {
            if (isSuccess && error != Error.None || !isSuccess && error == Error.None)
            {
                throw new ArgumentException("Invalid error", nameof(error));
            }
            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Combine(params Result[] results)
        {
            foreach(Result result in results)
            {
                if(result.IsFailure)
                    return result;
            }
            return Success();
        }

        public static Result<T> Success<T>(T value)
        {
            return new Result<T>(value, true, Error.None);
        }

        internal static Result<T> Failure<T>(Error error)
        {
            return new Result<T>(default(T), false, error);
        }
    }
}
