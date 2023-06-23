﻿using FluentValidation.Results;

namespace Store.Service.Services
{
    public class ResultService
    {
        public bool IsSucess { get; set; }
        public string Message { get; set; }
        public ICollection<ErrorValidation> Errors { get; set; }

        public static ResultService RequestError(string message, ValidationResult validationResult)
        {
            return new ResultService
            {
                IsSucess = false,
                Message = message,
                Errors = validationResult.Errors.Select(s => new ErrorValidation(s.PropertyName, s.ErrorMessage)).ToList()
            };
        }

        public static ResultService<T> RequestError<T>(string message, ValidationResult validationResult)
        {
            return new ResultService<T>
            {
                IsSucess = false,
                Message = message,
                Errors = validationResult.Errors.Select(s => new ErrorValidation(s.PropertyName, s.ErrorMessage)).ToList()
            };
        }

        public static ResultService Fail(string message) => new()
        {
            IsSucess = false,
            Message = message
        };

        public static ResultService<T> Fail<T>(string message) => new()
        {
            IsSucess = false,
            Message = message
        };

        public static ResultService Ok(string message) => new()
        {
            IsSucess = true,
            Message = message
        };

        public static ResultService<T> Ok<T>(T data) => new()
        {
            IsSucess = true,
            Data = data
        };
    }

    public class ResultService<T> : ResultService
    {
        public T Data { get; set; }
    }
}
