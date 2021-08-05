﻿using Application.DTOs;
using Application.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context => {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (context != null)
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        context.Response.ContentType = "application/json";

                        string errorMessage = contextFeature.Error.GetType() == typeof(BaseException) ? contextFeature.Error.Message : "Internal Server Error.";

                        var errorResponse = new ErrorDetailsDTO
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = errorMessage
                        };

                        Log.Error(contextFeature.Error, contextFeature.Error.Message);

                        await context.Response.WriteAsync(errorResponse.ToString());
                    }
                });
            });
        }
    }
}
