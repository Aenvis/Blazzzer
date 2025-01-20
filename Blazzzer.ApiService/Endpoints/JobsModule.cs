using Blazzzer.ApiService.Models;
using Blazzzer.ApiService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blazzzer.ApiService.Endpoints
{
	public static class JobsModule
	{
		public static void AddJobsEndpoints(this IEndpointRouteBuilder app)
		{
			app.MapGet("/jobs", async (IJobService jobService) =>
			{
				return Results.Ok("hello");
			});

			app.MapGet("/jobs/{id}", async (IJobService jobService, [FromQuery] int id) =>
			{
			});

			app.MapPost("/jobs", async (IJobService jobService, [FromBody] JobRequest job) =>
			{
				var result = await jobService.AddJobAsync(job);

				if (result.IsFailed)
					return Results.BadRequest(result.Errors);

				return Results.Created($"/jobs/{result.Value}", job);
			})
			.WithName("PostJob");
		}
	}
}
