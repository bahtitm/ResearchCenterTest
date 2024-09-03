using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InfoTehTestTask.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IMediator mediator => HttpContext.RequestServices.GetService<IMediator>();

        protected ILogger logger => HttpContext.RequestServices.GetService<ILogger<BaseController>>();
    }
}
