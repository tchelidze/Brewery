using CSharpFunctionalExtensions;
using System;

namespace Brewery.CrossEdge
{
    public static class ResultExtensions
    {
        public static Result<K> OnFailure<T, K>(this Result<T> result, Func<T, K> func)
        {
            if (result.IsFailure)
                return Result.Fail<K>(result.Error);
            return Result.Ok(func(result.Value));
        }
    }
}