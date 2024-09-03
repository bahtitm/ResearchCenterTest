using Application.Features.Cabinets.Commands.CreateCabinet;
using Application.Features.Cabinets.Commands.DeleteCabinet;
using Application.Features.Cabinets.Commands.UpdateCabinet;
using Application.Features.Cabinets.Queries.GetAll;
using Application.Features.Cabinets.Queries.GetDetail;
using Microsoft.AspNetCore.Mvc;

namespace InfoTehTestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CabinetsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var dataSource = await mediator.Send(new GetAllCabinetQuery());
            return Ok(dataSource.AsQueryable());
        }




        [HttpGet("{id}")]
        public async Task<IActionResult> Get(uint id)
        {
            return Ok(await mediator.Send(new GetDetailCabinetQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CreateCabinetCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }





        [HttpPut("{id}")]
        public async Task<IActionResult> Put(uint id, [FromBody] UpdateCabinetCommand command)
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
            await mediator.Send(new DeleteCabinetCommand(id));
            return NoContent();
        }
    }
}
