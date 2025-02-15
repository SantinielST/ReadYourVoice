using ReadYourVoice.Models;

namespace ReadYourVoice.Services;

interface IStorage
{
    /// <summary>
    /// Получение сессии пользователя по идентификатору
    /// </summary>
    Session GetSession(long chatId);
}
