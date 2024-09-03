using Application.Features.Patients.Commands.CreatePatient;
using Application.Features.Patients.Commands.DeletePatient;
using Application.Features.Patients.Commands.UpdatePatient;
using Application.Features.Patients.Queries.GetAll;
using Application.Features.Patients.Queries.GetDetail;
using Microsoft.AspNetCore.Mvc;

namespace InfoTehTestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PatientsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var dataSource = await mediator.Send(new GetAllPatientQuery());
            return Ok(dataSource.AsQueryable());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(uint id)
        {
            return Ok(await mediator.Send(new GetDetailPatientQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePatientCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }





        [HttpPut("{id}")]
        public async Task<IActionResult> Put(uint id, [FromBody] UpdatePatientCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest($"Check request: {id} not equals {command.Id}");
            }
            await mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(uint id)
        {
            await mediator.Send(new DeletePatientCommand(id));
            return NoContent();
        }
    }
}
