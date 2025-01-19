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
			});

			app.MapGet("/jobs/{id}", async (IJobService jobService, [FromQuery] int id) =>
			{
			});

			app.MapPost("/jobs", async (IJobService jobService, [FromBody] JobRequest job) =>
			{
			});
		}
	}
}
