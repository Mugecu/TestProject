using Common.Monads;

namespace Common.Extensions
{
    public static class ResultExtensions
    {
        public static Result OnSuccess(this Result result, Func<Result> fn)
        {
            if (result.IsFailure)
                return result;

            return fn();
        }

        public static Result OnSuccess(this Result result, Action action)
        {
            if (result.IsSuccess)
                return result;

            action();

            return Result.Success();
        }

        public static Result OnSuccess<T>(this Result<T> result, Action<T> action)
        {
            if (result.IsFailure)
                return result;

            action(result.Value);

            return Result.Success();
        }

        public static Result<T> OnSuccess<T>(this Result result, Func<Result<T>> fn)
        {
            if (result.IsFailure)
                return Result.Failure<T>(result.Error);

            return fn();
        }


        public static Result OnSuccess<T>(this Result<T> result, Func<T, Result> fn)
        {
            if (result.IsFailure)
                return result;

            return fn(result.Value);
        }

        public static Result OnFailure(this Result result, Action action)
        {
            if (result.IsFailure)
                action();

            return result;
        }

        public static Result OnBoth(this Result result, Action<Result> action)
        {
            action(result);

            return result;
        }

        public static T OnBoth<T>(this Result result, Func<Result, T> fn)
        {
            return fn(result);
        }
    }
}
