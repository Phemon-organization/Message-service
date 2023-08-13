namespace phemon.API.messages.Contracts
{
    public class MessageRequest
    {
        public string? Message { get; set; }
        public Guid UserId { get; set; }
    }
}
