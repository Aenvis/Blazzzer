using Blazzzer.ApiService.Models;
using FluentResults;
using System.Linq.Expressions;

namespace Blazzzer.ApiService.Repositories.Interfaces
{
	public interface IJobRepository
	{
		Task<Result<Job?>> GetJobAsync(Guid id);
		Task<Result<List<Job>>> GetJobsAsync(Expression<Func<Job, bool>>? filter);
		Task<Result<List<Job>>> GetJobsAsync();
		Task<Result> AddJobAsync(Job job);
		Task<Result> UpdateJobAsync(Job job);
		Task<Result> DeleteJobAsync(Guid id);
	}
}
