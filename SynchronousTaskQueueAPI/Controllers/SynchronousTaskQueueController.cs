using Microsoft.AspNetCore.Mvc;
using SynchronousTaskQueueAPI.Models;
using SynchronousTaskQueueAPI.Services;

namespace SynchronousTaskQueueAPI.Controllers
{
    public class SynchronousTaskQueueController : Controller
    {
        private readonly IQueueService _queueService;

        public SynchronousTaskQueueController(IQueueService queueService)
        {

            _queueService = queueService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("api/process")]
        public async Task<IActionResult> ProcessRequest([FromBody] Request request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid request format");
            }

            var processingTime = await _queueService.EnqueueRequest(request.Message);

            var response = new Response
            {
                RequestTime = DateTime.UtcNow,
                WriteTime = DateTime.UtcNow.AddMilliseconds(processingTime),
                ProcessingTime = processingTime
            };

            return Ok(response);
        }
    }
}
