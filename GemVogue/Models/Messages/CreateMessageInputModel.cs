namespace GemVogue.Models.Messages;

public class CreateMessageInputModel
{
    public string Name { get; set; }

    public string Email { get; set; }

    public string Subject { get; set; }

    public string Content { get; set; }
}