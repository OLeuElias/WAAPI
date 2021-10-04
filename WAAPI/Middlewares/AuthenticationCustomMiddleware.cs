using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WAAPI.Middlewares
{
    public class AuthenticationCustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private IConfiguration Configuration { get; }

        public AuthenticationCustomMiddleware(RequestDelegate next, ILoggerFactory loggerFactory, IConfiguration configuration)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<AuthenticationCustomMiddleware>();
            Configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {
            string authHeader = context.Request.Headers["Authorization"];
            string token = Configuration["AuthToken"];
            if (authHeader == null)
            {
                _logger.LogError("Authorization Header Not Allowed!");
                context.Response.StatusCode = 401;
                return;
            }

            if (authHeader != token)
            {
                _logger.LogError("Authorization Header Not Allowed!");
                context.Response.StatusCode = 401;
                return;
            }

            _logger.LogInformation("Authorization Accept: {auth}", authHeader);
            await _next.Invoke(context);
            return;
        }
    }
}