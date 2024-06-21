﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCollection.Infrastructure.Error
{
    public class AppException : Exception
    {
        public string ErrorCode { get; set; }

        public AppException(string errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }

        public AppException(string errorCode, string message,Exception innerException):base(message,innerException)
        {
            ErrorCode = errorCode;
        }
    }
}
