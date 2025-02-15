using ReadYourVoice.Services;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ReadYourVoice.Controllers;

class InlineKeyboardController
{
    private readonly ITelegramBotClient _telegramBotClient;
    private readonly IStorage _memoryStorage;

    public InlineKeyboardController(ITelegramBotClient telegramBotClient, IStorage memoryStorage)
    {
        _telegramBotClient = telegramBotClient;
        _memoryStorage = memoryStorage;
    }

    public async Task Handle(CallbackQuery? callbackQuery, CancellationToken ct)
    {
        if (callbackQuery?.Data == null)
        {
            return;
        }

        // Обновление пользовательской сессии новыми данными
        _memoryStorage.GetSession(callbackQuery.From.Id).LanguageCode = callbackQuery.Data;

        // Генерим информационное сообщение
        string languageText = callbackQuery.Data switch
        {
            "ru" => " Русский",
            "en" => " Английский",
            _ => String.Empty
        };

        // Отправляем в ответ уведомление о выборе
        await _telegramBotClient.SendTextMessageAsync(callbackQuery.From.Id,
            $"<b>Язык аудио - {languageText}.{Environment.NewLine}</b>" +
            $"{Environment.NewLine}Можно поменять в главном меню.", cancellationToken: ct,
            parseMode: ParseMode.Html);

        Console.WriteLine($"Контроллер {GetType().Name} получил сообщение");

        await _telegramBotClient.SendTextMessageAsync(callbackQuery.From.Id, $"Обнаружено нажатие на кнопку", cancellationToken: ct);
    }
}
