namespace eCommerce.API.Middlewares;

public static class ExceptionHandingMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionHandlingMiddleware(this
        IApplicationBuilder builder)
    {
        return
            builder.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}


public class ExceptionHandlingMiddleware(
    RequestDelegate next,
    ILogger<ExceptionHandlingMiddleware> logger)
{

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception ex)
        {
           logger.LogError($"{ex.GetType().Name}: {ex.Message}");

           if (ex.InnerException is not null)
           {
               logger.LogError($"{ex.InnerException.GetType().Name}: {ex.Message}");
           }

           httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

           await httpContext.Response.WriteAsJsonAsync(
               new
               {
                   Message = ex.Message,
                   Type = ex.GetType()
               });
        }
    }
}