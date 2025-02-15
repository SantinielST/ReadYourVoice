﻿using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace ReadYourVoice.Controllers;

class TextMessageController
{
    private readonly ITelegramBotClient _telegramBotClient;

    public TextMessageController(ITelegramBotClient telegramBotClient)
    {
        _telegramBotClient = telegramBotClient;
    }

    public async Task Handle(Message message, CancellationToken ct)
    {
        switch (message.Text)
        {
            case "/start":
                // Объект, представляющий кнопки
                var buttons = new List<InlineKeyboardButton[]>();
                buttons.Add(new[]
                {
                    InlineKeyboardButton.WithCallbackData($" Русский", $"ru"),
                    InlineKeyboardButton.WithCallbackData($" English", $"en"),
                    InlineKeyboardButton.WithCallbackData($" Français", $"fr"),
                });

                // передаем кнопки вместе с сообщением (параметр ReplyMarkup)
                await _telegramBotClient.SendTextMessageAsync(message.Chat.Id,
                    $"<b> Наш бот превращает аудио в текст." +
                    $"</b> {Environment.NewLine}" +
                    $"{Environment.NewLine}Можно записать сообщение и переслать другу, " +
                    $"если лень печатать.{Environment.NewLine}",
                    cancellationToken: ct,
                    parseMode: ParseMode.Html,
                    replyMarkup: new InlineKeyboardMarkup(buttons));
                break;

            default:
                await _telegramBotClient.SendTextMessageAsync(message.Chat.Id,
                    "Отправьте аудио для превращения в текст.",
                    cancellationToken: ct);
                break;
        }
    }
}
