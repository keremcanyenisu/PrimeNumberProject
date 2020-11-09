using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PrimeNumberCore.Exceptions;
using PrimeNumberCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumberCore.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
            }
            catch (Exception ex)
            {
                if(ex is BusinessException)
                {
                    // custom exception handling.
                    await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new BaseResponse(ex.Message), new JsonSerializerSettings { ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver() }));
                }
                else
                {
                    await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new BaseResponse(ex.Message), new JsonSerializerSettings { ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver() }));
                }

            }
        }
    }
}   
