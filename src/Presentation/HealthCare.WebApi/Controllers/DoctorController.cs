using HealthCare.Core.Cqrs.Commands.Doctors;
using HealthCare.Core.Cqrs.Queries.Doctors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly ILogger<DoctorController> logger;
        private readonly IMediator mediator;

        public DoctorController(ILogger<DoctorController> logger,IMediator mediator)
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
                    var queryIncluded = new GetDoctorsIncludedQuery();

                    var responseIncluded = await mediator.Send(queryIncluded);

                    return Ok(responseIncluded);
                case false:
                    var query = new GetDoctorsQuery();

                    var response = await mediator.Send(query);

                    return Ok(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateDoctorCommand patientCommand)
        {
            return Ok(await mediator.Send(patientCommand));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateDoctorCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteDoctorCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
