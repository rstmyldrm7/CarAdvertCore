using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarAdvertCore.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CarAdvertController : ControllerBase
    {
        private readonly IMediator mediator;

        public CarAdvertController(IMediator mediator)
        {
            this.mediator = mediator;
        }

    }
}
