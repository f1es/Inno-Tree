using InnoTree.Core.Exceptions;
using System.Net;
using System.Text.Json;

namespace InnoTree.API.Middlewares;

public class ExceptionHandlerMiddleware
{
	private readonly RequestDelegate _next;

	public ExceptionHandlerMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	public async Task InvokeAsync(HttpContext context)
	{
		try
		{
			await _next(context);
		}
		catch (Exception e) 
		{
			await HandleException(e, context);
		}
	}

	private async Task HandleException(Exception e, HttpContext context)
	{
		var statusCode = GetStatusCode(e);
		var message = e.Message;
		var stackTrace = e.StackTrace;

		var result = JsonSerializer.Serialize(new {error = message, stackTrace});

		context.Response.ContentType = "application/json";
		context.Response.StatusCode = (int)statusCode;

		await context.Response.WriteAsync(result);
	}

	private HttpStatusCode GetStatusCode(Exception exception) =>
		exception switch
		{
			NotFoundException => HttpStatusCode.NotFound,
			_ => HttpStatusCode.InternalServerError
		};
}
