using HealthCare.Core.Cqrs.Commands.Patients;
using HealthCare.Core.Cqrs.Queries.Patients;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly ILogger<PatientController> logger;
        private readonly IMediator mediator;

        public PatientController(ILogger<PatientController> logger, IMediator mediator)
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
                    var queryIncluded = new GetPatientsIncludedQuery();

                    var patientsIncluded = await mediator.Send(queryIncluded);

                    return Ok(patientsIncluded);
                case false:
                    var query = new GetPatientsQuery();

                    var patients = await mediator.Send(query);

                    return Ok(patients);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreatePatientCommand patientCommand)
        {
            return Ok(await mediator.Send(patientCommand));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdatePatientCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeletePatientCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
