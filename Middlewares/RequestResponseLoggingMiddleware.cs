namespace MiddlewarePOC.Middlewares
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestResponseLoggingMiddleware> _logger;

        public RequestResponseLoggingMiddleware(RequestDelegate requestDelegate, ILogger<RequestResponseLoggingMiddleware> logger)
        {
            _next = requestDelegate;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // request is received 
            var requestTime = DateTime.Now;
            var requestMethod = context.Request.Method;
            var requestPath = context.Request.Path;
            _logger.LogInformation($" Request\n Time : {requestTime}\n Method Type :{requestMethod}\n  Path :{requestPath}");

            /*
             * above peace of  code  will be executed when request is sent
            */
            await _next(context);

            /*
            * below peace of  code  will be executed when response is sent
           */


            // response received
            var responseTime = DateTime.Now;
            var statusCode = context.Response.StatusCode;
            _logger.LogInformation($"Response \n Time : {responseTime} \n Status Code : {statusCode}");
        }
            
    }

}
