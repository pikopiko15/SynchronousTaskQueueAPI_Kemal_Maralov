namespace SynchronousTaskQueueAPI.Services
{
    public interface IQueueService
    {
        Task<int> EnqueueRequest(string message);
    }
}
