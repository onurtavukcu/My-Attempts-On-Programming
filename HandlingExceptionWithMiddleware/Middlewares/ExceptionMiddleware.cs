namespace HandlingExceptionWithMiddleware.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
            }
            catch (Exception ex)
            {
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                await httpContext
                    .Response
                    .WriteAsJsonAsync("Test exception Middleware. Here is the response body", cancellationToken: CancellationToken.None);
                Console.WriteLine(ex.Message);
            }
        }
    }
}
