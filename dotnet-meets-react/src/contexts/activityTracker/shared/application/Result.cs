using System;

namespace dotnet_meets_react.src.contexts.activityTracker.activity.application.Shared
{
    public class Result<T>
    {
        public Result(bool isSuccess, T value)
        {
            IsSuccess = isSuccess;
            Value = value;
        }

        public Result(bool isSuccess, Exception error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public bool IsSuccess { get; set; }
        public T Value { get; set; }
        public Exception Error { get; set; }

        public static Result<T> Success(T value) => new(true, value);

        public static Result<T> Failure(Exception error) => new(false, error);
    }
}
