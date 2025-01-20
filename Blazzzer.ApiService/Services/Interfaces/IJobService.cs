using System.Linq.Expressions;
using Blazzzer.ApiService.Models;
using FluentResults;

namespace Blazzzer.ApiService.Services.Interfaces
{
	public interface IJobService
	{
		Task<Result<Job>> GetJobAsync(Guid id);
		Task<Result<IList<Job>>> GetJobsAsync();
		Task<Result<IList<Job>>> GetJobsAsync(Expression<Func<Job, bool>> filter);
		Task<Result<Guid>> AddJobAsync(JobRequest job);
		Task<Result<Guid>> UpdateJobAsync(Job job);
		Task<Result<Guid>> DeleteJobAsync(Guid id);
	}
}
