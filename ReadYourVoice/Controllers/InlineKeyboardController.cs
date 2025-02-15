﻿using Telegram.Bot;
using Telegram.Bot.Types;

namespace ReadYourVoice.Controllers;

class InlineKeyboardController
{
    private readonly ITelegramBotClient _telegramBotClient;

    public InlineKeyboardController(ITelegramBotClient telegramBotClient)
    {
        _telegramBotClient = telegramBotClient;
    }

    public async Task Handle(CallbackQuery? callbackQuery, CancellationToken ct)
    {
        Console.WriteLine($"Контроллер {GetType().Name} обнаружил нажатие на кнопку");

        await _telegramBotClient.SendTextMessageAsync(callbackQuery.From.Id, $"Обнаружено нажатие на кнопку", cancellationToken: ct);
    }
}
