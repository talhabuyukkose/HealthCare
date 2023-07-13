using HealthCare.Infrastructure.Quartz;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CronController : ControllerBase
    {
        private readonly MyScheduler scheduler;

        public CronController(MyScheduler scheduler)
        {
            this.scheduler = scheduler;
        }
        [HttpGet("Start")]
        public async Task<IActionResult> Start()
        {
            await scheduler.Start();
            return Ok($"Cron started");
        }
        [HttpGet("Stop")]
        public async Task<IActionResult> Stop()
        {
            await scheduler.Stop();
            return Ok("Cron stoped");
        }
    }
}
