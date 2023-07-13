using HealthCare.Core.Cqrs.Commands.Appointments;
using HealthCare.Core.Cqrs.Queries.Appointments;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly ILogger<AppointmentController> logger;
        private readonly IMediator mediator;

        public AppointmentController(ILogger<AppointmentController> logger, IMediator mediator)
        {
            this.logger = logger;
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get(bool IsIncluded)
        {
            switch (IsIncluded)
            {
                case true:
                    var queryIncluded = new GetAppointmentIncludedQuery();

                    var responseIncluded = await mediator.Send(queryIncluded);

                    return Ok(responseIncluded);
                case false:
                    var query = new GetAppointmentQuery();

                    var response = await mediator.Send(query);

                    return Ok(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateAppointmentCommand patientCommand)
        {
            return Ok(await mediator.Send(patientCommand));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateAppointmentCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteAppointmentCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
