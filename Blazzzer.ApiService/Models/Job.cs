namespace Blazzzer.ApiService.Models
{
	public enum JobStatus
	{
		New,
		InProgress,
		Completed,
		Failed,
	}
	public record Job(Guid Id, string Message, JobStatus Status, DateTime DateCreated, DateTime DateFinished);

	public record JobRequest(string Message);
}
