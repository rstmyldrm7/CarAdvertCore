using CarAdvertCore.Application.Features.Tasks.Queries.QueryModels.Request;
using CarAdvertCore.Application.Features.Tasks.Queries.QueryModels.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using System.Threading.Tasks;

namespace CarAdvertCore.Api.Controllers
{
    [ApiController]
    [Route("advert")]
    public class AdvertController : ControllerBase
    {
        private readonly IMediator mediator;

        public AdvertController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet("get")]
        public async Task<ActionResult<GetAdvertByIdQueryResponse>> GetAdvertById([FromQuery]GetAdvertByIdQueryRequest request)
        {
            var response = await mediator.Send(request);
            if(response == null)
            {
                return NoContent();
            }
            return Ok(response);
        }
        [HttpGet("all")]
        public async Task<ActionResult<GetAllAdvertsQueryResponse>> GetAllAdverts([FromQuery] GetAllAdvertsQueryRequest request)
        {
            var response = await mediator.Send(request);
            if (response == null)
            {
                return NoContent();
            }
            return Ok(response);
        }
    }
}
