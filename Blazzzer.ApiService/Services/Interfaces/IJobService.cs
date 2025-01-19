using Blazzzer.ApiService.Models;
using FluentResults;

namespace Blazzzer.ApiService.Services.Interfaces
{
	public interface IJobService
	{
		Task<Result<Job>> GetJobAsync(int id);
		Task<Result<IList<Job>>> GetJobsAsync();
		Task<Result<Guid>> AddJobAsync(JobRequest job);
	}
}
