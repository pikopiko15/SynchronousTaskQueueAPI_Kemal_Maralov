namespace SynchronousTaskQueueAPI.Services
{
    public class QueueService : IQueueService
    {
        private readonly Queue<string> requestQueue = new Queue<string>();

        public async Task<int> EnqueueRequest(string message)
        {
            requestQueue.Enqueue(message);

            await Task.Delay(TimeSpan.FromMilliseconds(new Random().Next(50, 100)));

            return new Random().Next(500, 1500);
        }
    }
}
