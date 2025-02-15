using Telegram.Bot;
using Telegram.Bot.Types;

namespace ReadYourVoice.Controllers;

class VoiceMessageController
{
    private readonly ITelegramBotClient _telegramBotClient;

    public VoiceMessageController(ITelegramBotClient telegramBotClient)
    {
        _telegramBotClient = telegramBotClient;
    }

    public async Task Handle(Message message, CancellationToken ct)
    {
        Console.WriteLine($"Контроллер {GetType().Name} получил сообщение");
        await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, $"Получено голосовое сообщение", cancellationToken: ct);
    }
}
