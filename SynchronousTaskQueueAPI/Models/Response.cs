namespace SynchronousTaskQueueAPI.Models
{
    public class Response
    {
        public DateTime RequestTime { get; set; }
        public DateTime WriteTime { get; set; }
        public int ProcessingTime { get; set; }
    }
}
