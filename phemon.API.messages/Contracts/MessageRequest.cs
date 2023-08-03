namespace phemon.API.messages.Contracts
{
    public class MessageRequest
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public Guid UserId { get; set; }
    }
}
