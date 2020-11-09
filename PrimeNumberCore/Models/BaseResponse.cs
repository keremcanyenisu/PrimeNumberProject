using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeNumberCore.Models
{
    public class BaseResponse
    {
        public BaseResponse(object data)
        {
            this.Data = data;
            this.Succeeded = true;
        }

        public BaseResponse(string errorMessage)
        {
            this.ErrorMessage = errorMessage;
            this.Succeeded = false;
        }

        public object Data { get; set; }
        public bool Succeeded { get; set; }
        public string ErrorMessage { get; set; }
    }
}
