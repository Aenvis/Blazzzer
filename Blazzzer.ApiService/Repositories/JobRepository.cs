using System.Linq.Expressions;
using Blazzzer.ApiService.Database;
using Blazzzer.ApiService.Models;
using Blazzzer.ApiService.Repositories.Interfaces;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace Blazzzer.ApiService.Repositories
{
	public class JobRepository : IJobRepository
	{
		private readonly JobContext _context;
		private readonly ILogger<JobRepository> _logger;

		public JobRepository(JobContext context, ILogger<JobRepository> logger)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		public async Task<Result> AddJobAsync(Job job)
		{
			try
			{
				await _context.Jobs.AddAsync(job);
				await _context.SaveChangesAsync();
			}
			catch (Exception e)
			{
				var message = "Failed to save job in the database.";
				_logger.LogError(e, message);
				return Result.Fail(message);
			}

			return Result.Ok();
		}

		public async Task<Result<Job?>> GetJobAsync(Guid id)
		{
			try
			{
				var job = await _context.Jobs.FindAsync(id);

				return Result.Ok(job);
			}
			catch (Exception e)
			{
				var message = "Failed to retrieve job (id: '{0}') from the database.";
				_logger.LogError(e, message, id.ToString());
				return Result.Fail(string.Format(message, id.ToString()));
			}
		}

		public async Task<Result<List<Job>>> GetJobsAsync()
		{
			try
			{
				var jobs = await _context.Jobs.ToListAsync();
				return Result.Ok(jobs);
			}
			catch (Exception e)
			{
				var message = "Failed to retrieve jobs from the database.";
				_logger.LogError(e, message);
				return Result.Fail(message);
			}
		}

		public async Task<Result<List<Job>>> GetJobsAsync(Expression<Func<Job, bool>>? filter)
		{
			try
			{
				var filteredJobs = await _context.Jobs.Where(filter).ToListAsync();
				return Result.Ok(filteredJobs);
			}
			catch (Exception e)
			{
				var message = "Failed to retrieve jobs from the database.";
				_logger.LogError(e, message);
				return Result.Fail(message);
			}
		}

		public async Task<Result> UpdateJobAsync(Job job)
		{
			try
			{
				_context.Jobs.Update(job);
				await _context.SaveChangesAsync();

				return Result.Ok();
			}
			catch (Exception e)
			{
				var message = "Failed to update job (id: '{0}').";
				_logger.LogError(e, message, job.Id);
				return Result.Fail(string.Format(message, job.Id));
			}
		}

		public async Task<Result> DeleteJobAsync(Guid id)
		{
			try
			{
				var job = await _context.Jobs.FirstOrDefaultAsync(x => x.Id == id);

				if (job is null)
				{
					var message = "Cannot remove a job (id: '{0}') that doesn't exist.";
					_logger.LogError(message, job.Id);
					return Result.Fail(string.Format(message, job.Id));
				}

				_context.Jobs.Remove(job);
				await _context.SaveChangesAsync();

				return Result.Ok();
			}
			catch (Exception e)
			{
				var message = "Failed to remove job (id: '{0}').";
				_logger.LogError(e, message, id);
				return Result.Fail(string.Format(message, id));
			}
		}
	}
}
