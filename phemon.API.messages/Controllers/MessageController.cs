using MediatR;
using Microsoft.AspNetCore.Mvc;
using phemon.API.messages.Contracts;
using phemon.API.messages.Routes;
using phemon.API.messages.Services;
using phemon.Application.message.Command.CreateMessage;
using phemon.Application.message.Command.DeleteMessage;
using phemon.Application.message.Query.Messages.GetMessageById;
using phemon.Application.message.Query.Messages.GetMessages;

namespace phemon.API.messages.Controllers
{
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICacheKeyService _cacheKeyService;

        public MessageController(IMediator mediator, ICacheKeyService cacheKeyService)
        {
            _mediator = mediator;
            _cacheKeyService = cacheKeyService;
        }

        [HttpPost]
        [Route(ApiRoutes.Message.Create)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] MessageRequest request)
        {
            var command = new CreateMessageCommand()
            {
                Message = request.Message,
                UserId = request.UserId
            };

            var result = await _mediator.Send(command);

            if (result is null) return BadRequest("Could not create new message.");

            return Created(ApiRoutes.Message.Create, command);
        }

        [HttpGet]
        [Route(ApiRoutes.Message.GetAll)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            string cacheKey = _cacheKeyService.GenerateCacheKey("MyData");
            var results = await _mediator.Send(new GetMessagesQuery { Cachekey = cacheKey });

            return Ok(results);
        }

        [HttpGet]
        [Route(ApiRoutes.Message.Get)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            var query = new GetMessageByIdQuery()
            {
                Id = id
            };
            await _mediator.Send(query);

            if (query is null) return NotFound("Can't find hero with that id.");

            return Ok(query);
        }

        [HttpDelete]
        [Route(ApiRoutes.Message.Delete)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            var command = new DeleteMessageCommand(){ Id = id };
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
