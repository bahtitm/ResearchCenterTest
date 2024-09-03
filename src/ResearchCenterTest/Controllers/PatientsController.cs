using Application.Features.Cabinets.Queries.GetAll;
using Application.Features.Patients.Commands.CreatePatient;
using Application.Features.Patients.Commands.DeletePatient;
using Application.Features.Patients.Commands.UpdatePatient;
using Application.Features.Patients.Queries.GetAll;
using Application.Features.Patients.Queries.GetDetail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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


        [HttpGet("WithParametres")]
        public async Task<IActionResult> Get(string sortBy = "Id",
                                            string sortOrder = "asc",
                                            int pageNumber = 1,
                                            int pageSize = 10)
        {

            var dataSource = await mediator.Send(new GetAllPatientQuery());
            var records = dataSource.AsQueryable();
            // Сортировка
            if (sortOrder.ToLower() == "asc")
            {
                records = records.OrderBy(r => EF.Property<object>(r, sortBy));
            }
            else
            {
                records = records.OrderByDescending(r => EF.Property<object>(r, sortBy));
            }

            // Постраничный возврат данных
            var paginatedRecords = records
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return Ok(paginatedRecords);




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
