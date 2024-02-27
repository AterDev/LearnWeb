using Microsoft.FluentUI.AspNetCore.Components;

namespace Vote.Services;

public class MessageService(IMessageService msg)
{
    private readonly IMessageService _messageService = msg;

    public Message ShowSuccess(string msg, int timeout = 3000)
    {
        return _messageService.ShowMessageBar(option =>
        {
            option.Intent = MessageIntent.Success;
            option.Title = msg;
            option.Timeout = timeout;
        });
    }

    public Message ShowError(string? title, string? msg = "", int timeout = 3000)
    {
        return _messageService.ShowMessageBar(option =>
        {
            option.Intent = MessageIntent.Error;
            option.Title = title;
            option.Body = msg;
            option.Timeout = timeout;
        });
    }
}
