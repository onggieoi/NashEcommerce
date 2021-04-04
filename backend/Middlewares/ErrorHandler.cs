using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using backend.Exceptions;
using Microsoft.AspNetCore.Http;

namespace backend.Middlewares
{
    public class ErrorHandler
    {
        private readonly RequestDelegate _next;

        public ErrorHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                string errMessage;

                switch (error)
                {
                    case NotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        errMessage = error.Message;
                        break;

                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        errMessage = "Something go wrong";
                        break;
                }

                var result = JsonSerializer.Serialize(new { error = true, message = errMessage });

                await response.WriteAsync(result);
            }
        }
    }
}