using MediatR;
using Microsoft.AspNetCore.Mvc;
using phemon.API.messages.Contracts;
using phemon.API.messages.Routes;
using phemon.Application.message.Command.CreateMessage;
using phemon.Application.message.Query.Messages.GetMessageById;
using phemon.Application.message.Query.Messages.GetMessages;

namespace phemon.API.messages.Controllers
{
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MessageController(IMediator mediator)
        {
            _mediator = mediator;
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
                UserId= request.UserId
            };

            await _mediator.Send(command);

            return Created(ApiRoutes.Message.Create, command);
        }

        [HttpGet]
        [Route(ApiRoutes.Message.GetAll)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetMessagesQuery();
            var results = await _mediator.Send(query);

            return Ok(results);
        }

        [HttpGet]
        [Route(ApiRoutes.Message.Get)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            var query = new GetMessageByIdQuery()
            {
                Id = id
            };
            await _mediator.Send(query);

            return Ok(query);
        }

    }
}
