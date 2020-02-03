using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NumberToWords.Models
{
    public class Result<T>
    {
        public T data;
        public string errorMsg = "";
        public string token;

        public Result(T t, string errorMsg, string token)
        {
            this.data = t;
            this.errorMsg = errorMsg;
            this.token = token;
        }
        public Result()
        {

        }

    }
}