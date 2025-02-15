using ReadYourVoice.Services;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ReadYourVoice.Controllers;

class VoiceMessageController
{
    private readonly IStorage _memoryStorage;
    private readonly ITelegramBotClient _telegramBotClient;
    private readonly IFileHandler _audioFileHandler;

    public VoiceMessageController(IStorage memoryStorage, ITelegramBotClient telegramBotClient, IFileHandler audioFileHandler)
    {
        _memoryStorage = memoryStorage;
        _telegramBotClient = telegramBotClient;
        _audioFileHandler = audioFileHandler;
    }

    public async Task Handle(Message message, CancellationToken ct)
    {
        var fileId = message.Voice?.FileId;

        if (fileId == null)
        {
            return;
        }

        await _audioFileHandler.Download(fileId, ct);

        string userLanguageCode = _memoryStorage.GetSession(message.Chat.Id).LanguageCode; // Здесь получим язык из сессии пользователя

        var result = _audioFileHandler.Process(userLanguageCode); // Запустим обработку

        await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, result, cancellationToken: ct);

        Console.WriteLine($"Контроллер {GetType().Name} получил сообщение");
    }
}
