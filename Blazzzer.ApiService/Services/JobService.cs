using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.JavaScript;
using Blazzzer.ApiService.Models;
using Blazzzer.ApiService.Repositories.Interfaces;
using Blazzzer.ApiService.Services.Interfaces;
using FluentResults;

namespace Blazzzer.ApiService.Services
{
	public class JobService : IJobService
	{
		private readonly IJobRepository _jobRepository;

		public JobService(IJobRepository jobRepository)
		{
			_jobRepository = jobRepository ?? throw new ArgumentNullException(nameof(jobRepository));
		}

		public async Task<Result<Job?>> GetJobAsync(Guid id)
		{
			var getJobResult = await _jobRepository.GetJobAsync(id);

			if (getJobResult.IsFailed)
				return Result.Fail(string.Format("Failed to retrieve job for id='{0}'.", id));

			return getJobResult.Value is null
				? Result.Fail(string.Format("No job found for id={0}", id))
				: Result.Ok(getJobResult.Value);
		}

		public async Task<Result<IList<Job>>> GetJobsAsync()
		{
			var getJobsResult = await _jobRepository.GetJobsAsync();

			if (getJobsResult.IsFailed)
				return Result.Fail("Failed to retrieve jobs.");

			return getJobsResult.Value;
		}

		public async Task<Result<IList<Job>>> GetJobsAsync(Expression<Func<Job, bool>> filter)
		{
			var getJobsResult = await _jobRepository.GetJobsAsync(filter);

			if (getJobsResult.IsFailed)
				return Result.Fail("Failed to retrieve jobs.");

			return getJobsResult.Value;
		}

		public async Task<Result<Guid>> AddJobAsync(JobRequest job)
		{
			// Add job to the db
			var id = Guid.NewGuid();
			var newJob = new Job(id, job.Message, nameof(JobStatus.New), DateTime.UtcNow, DateTime.MinValue);

			var addJobResult = await _jobRepository.AddJobAsync(newJob);

			if (addJobResult.IsFailed)
				return Result.Fail("Failed to add new job");

			// Enqueue job
			// TODO 


			return Result.Ok(id);
		}

		public async Task<Result<Guid>> UpdateJobAsync(Job job)
		{
			throw new NotImplementedException();
		}

		public async Task<Result<Guid>> DeleteJobAsync(Guid id)
		{
			throw new NotImplementedException();
		}
	}
}
