using MediatR;
using phemon.Application.message.Command.DeleteMessage;
using phemon.Persistence.message;

namespace phemon.Application.message;

public class DeleteMessageCommandHandler
{
    private readonly IMediator _mediator;
    private readonly IMessageDbContext _dbcontext;

    public DeleteMessageCommandHandler(IMediator mediator, IMessageDbContext dbcontext){
        _mediator = mediator;
        _dbcontext = dbcontext;
    }

    public async Task<bool> Handle(DeleteMessageCommand request, CancellationToken cancellationToken){
        var message = await _dbcontext.Message.FindAsync(request.Id, cancellationToken);

        _dbcontext.Message.Remove(message);
        await _dbcontext.SaveChangesAsync(cancellationToken);

        return true;
    }
}
