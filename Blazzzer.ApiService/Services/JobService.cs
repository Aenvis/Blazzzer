using Blazzzer.ApiService.Models;
using Blazzzer.ApiService.Services.Interfaces;
using FluentResults;

namespace Blazzzer.ApiService.Services
{
	public class JobService : IJobService
	{
		public async Task<Result<Guid>> AddJobAsync(JobRequest job)
		{
			throw new NotImplementedException();
		}

		public async Task<Result<Job>> GetJobAsync(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<Result<IList<Job>>> GetJobsAsync()
		{
			return Result.Ok();
		}
	}
}
