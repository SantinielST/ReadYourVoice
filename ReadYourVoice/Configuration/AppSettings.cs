namespace ReadYourVoice.Configuration;

public class AppSettings
{
    /// <summary>
    /// Токен Telegram API
    /// </summary>
    public string BotToken { get; set; }

    /// <summary>
    /// Входящий битрейт аудио файлов
    /// </summary>
    public float InputAudioBitrate { get; set; }

    /// <summary>
    /// Папка загрузки аудио файлов
    /// </summary>
    public string DownloadsFolder { get; set; }

    /// <summary>
    /// Имя файла при загрузке
    /// </summary>
    public string AudioFileName { get; set; }

    /// <summary>
    /// Формат аудио при загрузке
    /// </summary>
    public string InputAudioFormat { get; set; }

    /// <summary>
    /// Формат аудио при загрузке
    /// </summary>
    public string OutputAudioFormat { get; set; }
}
