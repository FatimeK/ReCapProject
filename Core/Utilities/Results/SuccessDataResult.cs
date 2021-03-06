using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(bool success, string message, T data) : base(true, message, data)
        {


        }

        public SuccessDataResult(T data) : base(data, true)
        {


        }
        public SuccessDataResult(T data, string message) : base(data, true)
        {


        }

        public SuccessDataResult() : base(default, true)
        {
        }
        public SuccessDataResult(string message) : base(default,true)
        {
        }
    }
}
