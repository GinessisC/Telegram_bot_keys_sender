using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bots.Http;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace TestForTutorial
{
    class GenerateDescriptionForProductcs
    {
        public string ProductName { get; set; }
        public kb.Category Category { get; set; }
        
        
        public GenerateDescriptionForProductcs(string productName, kb.Category category)
        {
            ProductName = productName;
            Category = category;

        }
        
        public async Task SendDescriptionAsync(TelegramBotCommand command, ITelegramBotClient botClient, InlineKeyboardMarkup inlinereplyMarkup)
        {

            if (Category == kb.Category.AndroidNoRoot)
            {
                switch (ProductName)
                {
                    case "Zolo":
                        await botClient.SendVideoAsync(chatId: command.Callback.Message.Chat.Id,
                    video: Telegram.Bot.Types.InputFile.FromUri("https://t.me/Death_games_1234567890/18"),
                    //caption: "Lol",
                    caption: "☠️ZOLO☠️\r\n(No-Root•••Root)\r\n\r\n\r\n\U0001f977Идеальный вариант для начинающих софтеров ! видно людей на расстоянии 250м , автоприцеливание в голову или тело )\U0001f977\r\n\r\nЦена:\r\n🔑1 день – 80₴🇺🇦 | 190₽ 🇷🇺\r\n🔑3 дня - 180₴ 🇺🇦| 430₽ 🇷🇺\r\n🔑7 дней - 325₴🇺🇦 | 800₽ 🇷🇺\r\n🔑14 дней - 400₴🇺🇦 | 1000₽ 🇷🇺\r\n🔑30 дней - 700₴🇺🇦 | 1400₽ 🇷🇺\r\n🔑60 дней - 900₴🇺🇦 | 1800₽ 🇷🇺\r\n\r\n\r\n\r\nЗа покупкой:\r\n✍️@MANAGER_DEATH_GAMES🌎",
                    parseMode: Telegram.Bot.Types.Enums.ParseMode.Html,
                    replyMarkup: inlinereplyMarkup);
                        break;


                    //description = "[ Android NRoot • БЕЗ РУТ ]  ›  𝐙𝐎𝐋𝐎 𝐂𝐇𝐄𝐀𝐓\r\n\r\n \r\n\r\nZoLo - чит для Android  без рут прав \r\n\r\n\r\n Основные особенности: \r\n\r\n•Aimbot - автонаведение на врага\r\n\r\n•ESP - показывает врагов, их ники, транспорт, лут и т.п.\r\n\r\n•Visible Check - позволяет определить противника за преградой\r\n\r\n✅ Поддерживает все версии Android\r\n!!! 13й андроид иногда есть вылеты.\r\n\r\nработает для версий Global, Korea, Vietnam, BGMI\r\n\r\n (Можно установить до покупки)\r\n\r\n❗️ Использование aimbot функций всегда имеют повышенный риск бана.\r\n\r\n⚠️ Вход  Twitter, игровая почта, номер, Facebook при этом приложение нужно удалить с устройства\r\n\r\n❗️Что бы активировать ключ, скопируйте его и войдите в чит!";

                    case "Nerohol":
                        await botClient.SendVideoAsync(chatId: command.Callback.Message.Chat.Id,
                    video: Telegram.Bot.Types.InputFile.FromUri("https://t.me/Death_games_1234567890/24"),
                    caption: "•••••••••••NEROHOLE••••••••••\r\n  • NEROHOLE -  версия игры (GL/KR/VN) для вашего вкуса, присутствуют такие функции как 𝐀𝐢𝐦𝐛𝐨𝐭 𝐒𝐢𝐥𝐞𝐧𝐭 и Esp (Player's / Bots). Чит для не рутированых телефонов 64 битных устройст\r\n\r\n\r\n\r\nОбновление :\r\nКрутейший скин ченджер, где можно проставить абсолютно любой скин из игры (костюм икс с килл чатом.) любую пушку так же с килл чатом\r\nСоветую к покупке\r\n\r\n\r\n\r\n🔑1 день - 120🇺🇦| 250🇷🇺\r\n🔑 7 дней - 450🇺🇦| 1000🇷🇺\r\n🔑30 дней - 1100🇺🇦| 2400🇷🇺\r\n             \r\n\r\n\r\nЗа покупкой:\r\n✍️@MANAGER_DEATH_GAMES🌎",
                    parseMode: Telegram.Bot.Types.Enums.ParseMode.Html,
                    replyMarkup: inlinereplyMarkup);
                        break;

                    case "SHIELD": 
                        await botClient.SendVideoAsync(chatId: command.Callback.Message.Chat.Id,
                    video: Telegram.Bot.Types.InputFile.FromUri("https://t.me/Death_games_1234567890/27"),
                    caption: "⁠••••••••••SHIELD•••••••••\r\n\U0001f5a4Лучший ANDROID софт. Подходит для абсолютно всех режимов. Прост в управлении даже новичку , понравится  каждому ✅\r\n\r\nОсобенности:\r\nудобное ВХ\r\nотключение отдачи\r\nбыстрое обновление\r\nустановка лоадером\r\nНЕТ ЖАЛОБ НА БАН\r\n\r\n\r\n\r\n🔑1 день – 80🇺🇦 | 240🇷🇺\r\n🔑7 дней - 330🇺🇦 | 900🇷🇺 \r\n🔑30 дней - 730🇺🇦 | 1900🇷🇺\r\n\r\n\r\nЗа покупкой:\r\n✍️@MANAGER_DEATH_GAMES🌎",
                    parseMode: Telegram.Bot.Types.Enums.ParseMode.Html,
                    replyMarkup: inlinereplyMarkup);
                        break;

                    case "KING MOD": //Not given
                        await botClient.SendVideoAsync(chatId: command.Callback.Message.Chat.Id,
                    video: Telegram.Bot.Types.InputFile.FromUri("https://t.me/Death_games_1234567890/34"),
                    caption: "••••••••••KING MODE•••••••••\r\n\r\n\r\nОдин из Лучших ! читов для Андроид , без рут прав!Достойный конкурент Нерохолла, имеющий не плохую защиту !\r\n\r\nОсобенности: \r\n-отличный аим 200м\r\n-Вх паутина (идут линии к врагам)\r\n-быстрые обновления\r\n\r\n \r\n🔑1 день - 100🇺🇦 | 280🇷🇺\r\n🔑7 дней - 450🇺🇦 | 1000🇷🇺 \r\n🔑30 дней - 1100🇺🇦 | 2400🇷🇺 \r\n             \r\n\r\nкупить:\r\n✍️@MANAGER_DEATH_GAMES🌎",
                    parseMode: Telegram.Bot.Types.Enums.ParseMode.Html,
                    replyMarkup: inlinereplyMarkup);
                        break;
                    case "FITE MOD":
                        await botClient.SendVideoAsync(chatId: command.Callback.Message.Chat.Id,
                    video: Telegram.Bot.Types.InputFile.FromUri("https://t.me/Death_games_1234567890/29"),
                    caption: "FITE MOD - BEST HACK - NEW PROJECT 3.2\r\n\r\nБуллет Трекинг / АИМ БОТ\r\nСпин Бот (жесть) \r\nЕСП - 4 вида, топ настройки\r\nОдин из мощнейших антибанов на данный момент \r\nЕще огромное множество функций которые вас удивят! \r\n\r\n Можно играть спокойно на основном аккаунте \r\n\r\n1   Day's 80 🇺🇦| 170  \r\n3   Day's 150🇺🇦 | 390 \r\n7   Day's 300 🇺🇦| 700 \r\n 14 Day's 400 🇺🇦 | 900\r\n30 Day's 550 🇺🇦 | 1200 \r\n 60 Day's 700 🇺🇦 | 1500 \r\n\r\n\r\nЗа покупкой:\r\n✍️@MANAGER_DEATH_GAMES🌎",
                    parseMode: Telegram.Bot.Types.Enums.ParseMode.Html,
                    replyMarkup: inlinereplyMarkup);
                        break;

                    case "VN":
                        await botClient.SendVideoAsync(chatId: command.Callback.Message.Chat.Id ,
                    video: Telegram.Bot.Types.InputFile.FromUri("https://t.me/Death_games_1234567890/21"),
                    caption: "••••••••••VN XAK•••••••••• \r\n•••••••На ANDROID•••••••  \r\n•••••УСИЛЕНЫЙ АНТИБАН•••••\r\n\r\n\r\n\r\n⚜️Вх паутина (идут линии к врагам)\r\n⚜️быстрые обновления\r\n⚜️ Ростояние к лут боксу\r\n⚜️ Булетрек \r\n⚜️указатель на игроков \r\n\r\n\r\n1 Day - 80🇺🇦  190🇷🇺 \r\n3 Day - 190🇺🇦  450🇷🇺                  \r\n7 Day - 381🇺🇦  900🇷🇺                     \r\n30Day-760🇺🇦1800🇷🇺                \r\n60Day-1100🇺🇦2600🇷🇺 \r\n\r\nЗа покупкой: \r\n✍️@MANAGER_DEATH_GAMES🌎",
                    parseMode: Telegram.Bot.Types.Enums.ParseMode.Html,
                    replyMarkup: inlinereplyMarkup);
                        break;

                    case "OWM MOD":
                        await botClient.SendVideoAsync(chatId: command.Callback.Message.Chat.Id,
                    video: Telegram.Bot.Types.InputFile.FromUri("https://t.me/Death_games_1234567890/19"),
                    caption: "••••••••••OWM MOD••••••••••\r\n••••••••••No Root••••••••••••• \r\n\r\n\r\nвидно людей на расстоянии 250м \r\nОдин из Лучших ! читов для Андроид , без рут прав!\r\nУСИЛЕНЫЙ АНТИБАН\r\n\r\n\r\nОсобенности: \r\nУмный  аим 200м+\r\nВх паутина (идут линии к врагам)\r\nбыстрые обновления\r\n Ростоянии к лут боксу\r\n скинхак персонажа\r\n указатель на играков\r\n\r\n\r\n\r\n🔑1  День    - 80🇺🇦 | 190  🇷🇺\r\n🔑3  Дня     -190🇺🇦 | 450  🇷🇺\r\n🔑7  Дней   -380🇺🇦 | 900  🇷🇺\r\n🔑14  Дней   -500🇺🇦 |1200 🇷🇺           \r\n🔑30  Дней   -760🇺🇦 | 1800🇷🇺                 \r\n🔑60  Дней -1100🇺🇦 | 2600🇷🇺\r\n   \r\n\r\nЗа покупкой:\r\n✍️@MANAGER_DEATH_GAMES🌎",
                    parseMode: Telegram.Bot.Types.Enums.ParseMode.Html,
                    replyMarkup: inlinereplyMarkup);
                        break;

                    case "Hassan": //Here is photo  
                        await botClient.SendPhotoAsync(chatId: command.Callback.Message.Chat.Id,
                    photo: Telegram.Bot.Types.InputFile.FromUri("https://t.me/Death_games_1234567890/31"),
                    caption: "•••••••••HASSAN VIP•••••••••\r\n \r\n\r\n         (Android)\r\n( для новичков : видно людей на расстоянии 250м \r\n⚠️⚠️⚠️⚠️\r\n⚠️⚠️⚠️⚠️\r\nдля Андроид , ROOT и NON ROOT \r\nУСИЛЕНЫЙ АНТИБАН❗️\r\n\r\n⚡️⚡️⚡️⚡️⚡️⚡️⚡️⚡️\r\n\r\n✨Вх паутина (идут линии к врагам)\r\n✨быстрые обновления\r\n✨ Ростоянии к лут боксу\r\n✨ Булетрек \r\n✨указатель на играков\r\n✨✨✨✨✨✨✨✨\r\nцена : ROOT\r\n1 Day - 80🇺🇦  190🇷🇺\r\n3 Day - 190🇺🇦  450🇷🇺                    \r\n7 Day - 381🇺🇦  900🇷🇺                     \r\n30Day-760🇺🇦1800🇷🇺\r\n✨✨✨✨✨✨✨✨\r\n Цена NON-ROOR\r\n1 Day - 60🇺🇦  130🇷🇺\r\n3 Day - 150🇺🇦  350🇷🇺                  \r\n7 Day - 290🇺🇦  700🇷🇺                  \r\n30Day-500🇺🇦1200🇷🇺          \r\n\r\n\r\nПо вопросам покупки обращайтесь\r\n@MANAGER_DEATH_GAMES 😀",
                    parseMode: Telegram.Bot.Types.Enums.ParseMode.Html,
                    replyMarkup: inlinereplyMarkup);
                        break;

                    case "Uki":
                        await botClient.SendVideoAsync(chatId: command.Callback.Message.Chat.Id,
                    video: Telegram.Bot.Types.InputFile.FromUri("https://t.me/Death_games_1234567890/22"),
                    caption: "••••••••••U K I••••••••••\r\n••••••• ANDROID NON ROOT••••••• \r\n•••••I advise you to buy•••••\r\n\r\n\r\n\r\n3 advantages \r\nStrengthen anti ban \r\n Smart aim \r\nBeautiful Vx \r\n Beautiful skin hack\r\nSkin hack works by skinning a character \r\n\r\n\r\n\r\n               \r\n🔑1 Day - 80🇺🇦  190🇷🇺  \r\n🔑3 Day - 190🇺🇦  450🇷🇺                      \r\n🔑7 Day - 381🇺🇦  900🇷🇺                      \r\n🔑30Day-760🇺🇦1800🇷🇺                  \r\n🔑60Day-1100🇺🇦2600🇷🇺\r\n\r\n\r\nЗа покупкой: \r\n✍️@MANAGER_DEATH_GAMES🌎",
                    parseMode: Telegram.Bot.Types.Enums.ParseMode.Html,
                    replyMarkup: inlinereplyMarkup);
                        break;

                    case "HarlyMod":
                        await botClient.SendVideoAsync(chatId: command.Callback.Message.Chat.Id,
                    video: Telegram.Bot.Types.InputFile.FromUri("https://t.me/Death_games_1234567890/25"),
                    caption: "••••••••HARLEY MOD New Pubg 3.2•••••••\r\n••••••••64Bit All Version Version•••••••••••\r\n\r\nFeatures:👀🔫\r\n==> X-ray Esp Player\r\n==> X-ray Esp World\r\n==> X-ray Esp Vehicle\r\n==> X-ray Esp 360° Alert\r\n==> X-ray Enemy Can See You\r\n\r\n==> Real-time Skin Hack\r\n==> Safe Aimbot\r\n==> Safe Silent Aim\r\n==> With Fov Based\r\n==> Wide View\r\n==> Auto Wall jump \r\n\r\nUninstall Old Pubg\r\nInstall New Pubg Mod\r\n\r\n\r\n🔑1 День - 80🇺🇦 | 190🇷🇺\r\n🔑3 Дня - 190🇺🇦 | 450🇷🇺\r\n🔑7 Дней - 380🇺🇦 | 900🇷🇺\r\n🔑14 Дней -500🇺🇦 | 1200🇷🇺\r\n🔑30 Дней -760🇺🇦 | 1800🇷🇺\r\n🔑60 дней -1100🇺🇦 | 2600🇷🇺\r\n\r\n\r\nЗа покупкой:\r\n✍️@MANAGER_DEATH_GAMES🌎",
                    parseMode: Telegram.Bot.Types.Enums.ParseMode.Html,
                    replyMarkup: inlinereplyMarkup);
                        break;

                    case "DESERTSTORM":
                        await botClient.SendVideoAsync(chatId: command.Callback.Message.Chat.Id,
                    video: Telegram.Bot.Types.InputFile.FromUri("https://t.me/Death_games_1234567890/28"),
                    caption: "•••••••••DESERT SHTORM•••••••••\r\n\r\n\r\nЛучший софт на андроид [Ios версия в обновлении] - [Без рут прав + Рут Zygisk] \r\n\r\n\r\nФункционал :\r\n Валхак  оптимизационный, можно отключить ботов и видеть игроков до 300 метров.\r\n\r\nАимбот- настраиваемый, можно настроить чтобы был беспалевным.\r\n\r\nСкинхак - показывает только у вас.\r\n\r\nМетро - вх на оружия на руке у врага, вх на коробки в радике.\r\n\r\n\r\n\r\n1 день - 90🇺🇦220🇷🇺\r\n3 дня - 250🇺🇦 500🇷🇺\r\n7 дней - 465🇺🇦1000🇷🇺\r\n30 дней - 1120🇺🇦2400🇷🇺\r\n\r\n\r\nЗа покупкой:\r\n✍️@MANAGER_DEATH_GAMES🌎",
                    parseMode: Telegram.Bot.Types.Enums.ParseMode.Html,
                    replyMarkup: inlinereplyMarkup);
                        break;
                    case "Fite Mod":
                        await botClient.SendVideoAsync(chatId: command.Callback.Message.Chat.Id,
                    video: Telegram.Bot.Types.InputFile.FromUri("https://t.me/Death_games_1234567890/29"),
                    caption: "FITE MOD - BEST HACK - NEW PROJECT 3.2\r\n\r\nБуллет Трекинг / АИМ БОТ\r\nСпин Бот (жесть) \r\nЕСП - 4 вида, топ настройки\r\nОдин из мощнейших антибанов на данный момент \r\nЕще огромное множество функций которые вас удивят! \r\n\r\n Можно играть спокойно на основном аккаунте \r\n\r\n1   Day's 80 🇺🇦| 170  \r\n3   Day's 150🇺🇦 | 390 \r\n7   Day's 300 🇺🇦| 700 \r\n 14 Day's 400 🇺🇦 | 900\r\n30 Day's 550 🇺🇦 | 1200 \r\n 60 Day's 700 🇺🇦 | 1500 \r\n\r\n\r\nЗа покупкой:\r\n✍️@MANAGER_DEATH_GAMES🌎",
                    parseMode: Telegram.Bot.Types.Enums.ParseMode.Html,
                    replyMarkup: inlinereplyMarkup);
                        break;

                    default:
                        break;
                }
            }
            if (Category == kb.Category.AndroidRoot)
            {
                switch (ProductName)
                {
                    case "root Star":
                        await botClient.SendVideoAsync(chatId: command.Callback.Message.Chat.Id,
                    video: Telegram.Bot.Types.InputFile.FromUri("https://t.me/Death_games_1234567890/23"),
                    caption: "•••••••••••••• STAR HACK ••••••••••••••\r\n\r\n\r\n\r\n(Android)\r\n( для новичков : видно людей на расстоянии 250м , автоприцеливание в голову или тело )\r\n\r\nОдин из Лучших ! читов для Андроид , без рут + РУТ + IOS \r\n\r\nОсобенности: \r\nотличный аим 200м\r\nВх паутина (идут линии к врагам)\r\nбыстрые обновления\r\n\r\n\r\n\r\nцена : НОН-РУТ\r\n1 день - 120🇺🇦 279🇷🇺\r\n7 дней - 500🇺🇦 1163🇷🇺\r\n30 дней - 1200🇺🇦 2792🇷🇺\r\nФайлы (https://t.me/filesDEATHgames/86)\r\n\r\nцена: РУТ -\r\n1 день - 130🇺🇦 300🇷🇺\r\n7 дней -500🇺🇦 1163🇷🇺\r\n30 дней - 1200🇺🇦 2790🇷🇺\r\n\r\n\r\n\r\nWinIOS STAR HAK \r\n1 день - 150🇺🇦 347🇷🇺\r\n7 дней 600🇺🇦 1400🇷🇺\r\n30 дней 1300🇺🇦 3000🇷🇺\r\n\r\nЗа покупкой: \r\n✍️@MANAGER_DEATH_GAMES🌎",
                    parseMode: Telegram.Bot.Types.Enums.ParseMode.Html,
                    replyMarkup: inlinereplyMarkup);
                        break;
                    case "root ZOLO":
                        await botClient.SendVideoAsync(chatId: command.Callback.Message.Chat.Id,
                    video: Telegram.Bot.Types.InputFile.FromUri("https://t.me/Death_games_1234567890/18"),
                    caption: "☠️ZOLO☠️\r\n(No-Root•••Root)\r\n\r\n\r\n\U0001f977Идеальный вариант для начинающих софтеров ! видно людей на расстоянии 250м , автоприцеливание в голову или тело )\U0001f977\r\n\r\nЦена:\r\n🔑1 день – 80₴🇺🇦 | 190₽ 🇷🇺\r\n🔑3 дня - 180₴ 🇺🇦| 430₽ 🇷🇺\r\n🔑7 дней - 325₴🇺🇦 | 800₽ 🇷🇺\r\n🔑14 дней - 400₴🇺🇦 | 1000₽ 🇷🇺\r\n🔑30 дней - 700₴🇺🇦 | 1400₽ 🇷🇺\r\n🔑60 дней - 900₴🇺🇦 | 1800₽ 🇷🇺\r\n\r\n\r\n\r\nЗа покупкой:\r\n✍️@MANAGER_DEATH_GAMES🌎",

                    parseMode: Telegram.Bot.Types.Enums.ParseMode.Html,
                    replyMarkup: inlinereplyMarkup);
                        break;
                    case "root X-Shooter":
                        await botClient.SendVideoAsync(chatId: command.Callback.Message.Chat.Id,
                    video: Telegram.Bot.Types.InputFile.FromUri("https://t.me/Death_games_1234567890/15"),
                    caption: "X Shooter(для рут девайсов) 🔥\r\n\r\n🗝️1 день -  180🇺🇦 | 360🇷🇺\r\n🗝️7 дней -  600 🇺🇦 | 1200 🇷🇺\r\n🗝️30 дней -  1100🇺🇦 | 2500🇷🇺\r\n💬💬💬💬💬💬💬💬💬💬\r\n\r\nКупить тут➡️ \r\n\r\n⚡️⚡️⚡️⚡️⚡️⚡️⚡️⚡️",
                    parseMode: Telegram.Bot.Types.Enums.ParseMode.Html,
                    replyMarkup: inlinereplyMarkup);
                        break;

                    default:
                        break;
                }
            }
            if (Category == kb.Category.IOS)
            {
                switch (ProductName)
                {
                    case "Vn":
                        await botClient.SendVideoAsync(chatId: command.Callback.Message.Chat.Id,
                    video: Telegram.Bot.Types.InputFile.FromUri("https://t.me/Death_games_1234567890/17"),
                    caption: "••••••••••••••VN   HACK••••••••••••••\r\n\r\n\r\n      \U0001f977Один из самых лучших на IOS \r\nОтличается от других своей безопасностью(очень хорошей)\r\nИмеется скин чеджер и много других крутых функций\U0001f977 \r\n\r\n\r\n🔑1 день - 200🇺🇦 | 400🇷🇺\r\n🔑7 дней - 700🇺🇦 | 1500🇷🇺\r\n🔑30 дней - 1400🇺🇦 | 2700🇷🇺\r\n\r\n\r\n💬купить: @MANAGER_DEATH_GAMES 📱",
                    parseMode: Telegram.Bot.Types.Enums.ParseMode.Html,
                    replyMarkup: inlinereplyMarkup);
                        break;
                    case "IOS Star":
                        await botClient.SendVideoAsync(chatId: command.Callback.Message.Chat.Id,
                    video: Telegram.Bot.Types.InputFile.FromUri("https://t.me/Death_games_1234567890/23"),
                    caption: "•••••••••••••• STAR HACK ••••••••••••••\r\n\r\n\r\n\r\n(Android)\r\n( для новичков : видно людей на расстоянии 250м , автоприцеливание в голову или тело )\r\n\r\nОдин из Лучших ! читов для Андроид , без рут + РУТ + IOS \r\n\r\nОсобенности: \r\nотличный аим 200м\r\nВх паутина (идут линии к врагам)\r\nбыстрые обновления\r\n\r\n\r\n\r\nцена : НОН-РУТ\r\n1 день - 120🇺🇦 279🇷🇺\r\n7 дней - 500🇺🇦 1163🇷🇺\r\n30 дней - 1200🇺🇦 2792🇷🇺\r\nФайлы (https://t.me/filesDEATHgames/86)\r\n\r\nцена: РУТ -\r\n1 день - 130🇺🇦 300🇷🇺\r\n7 дней -500🇺🇦 1163🇷🇺\r\n30 дней - 1200🇺🇦 2790🇷🇺\r\n\r\n\r\n\r\nWinIOS STAR HAK \r\n1 день - 150🇺🇦 347🇷🇺\r\n7 дней 600🇺🇦 1400🇷🇺\r\n30 дней 1300🇺🇦 3000🇷🇺\r\n\r\nЗа покупкой: \r\n✍️@MANAGER_DEATH_GAMES🌎",

                    parseMode: Telegram.Bot.Types.Enums.ParseMode.Html,
                    replyMarkup: inlinereplyMarkup);
                        break;
                    case "IOS SponsorStar":
                        await botClient.SendVideoAsync(chatId: command.Callback.Message.Chat.Id,
                    video: Telegram.Bot.Types.InputFile.FromUri("https://t.me/Death_games_1234567890/23"),
                    caption: "•••••••••••••• STAR HACK ••••••••••••••\r\n\r\n\r\n\r\n(Android)\r\n( для новичков : видно людей на расстоянии 250м , автоприцеливание в голову или тело )\r\n\r\nОдин из Лучших ! читов для Андроид , без рут + РУТ + IOS \r\n\r\nОсобенности: \r\nотличный аим 200м\r\nВх паутина (идут линии к врагам)\r\nбыстрые обновления\r\n\r\n\r\n\r\nцена : НОН-РУТ\r\n1 день - 120🇺🇦 279🇷🇺\r\n7 дней - 500🇺🇦 1163🇷🇺\r\n30 дней - 1200🇺🇦 2792🇷🇺\r\nФайлы (https://t.me/filesDEATHgames/86)\r\n\r\nцена: РУТ -\r\n1 день - 130🇺🇦 300🇷🇺\r\n7 дней -500🇺🇦 1163🇷🇺\r\n30 дней - 1200🇺🇦 2790🇷🇺\r\n\r\n\r\n\r\nWinIOS STAR HAK \r\n1 день - 150🇺🇦 347🇷🇺\r\n7 дней 600🇺🇦 1400🇷🇺\r\n30 дней 1300🇺🇦 3000🇷🇺\r\n\r\nЗа покупкой: \r\n✍️@MANAGER_DEATH_GAMES🌎",

                    parseMode: Telegram.Bot.Types.Enums.ParseMode.Html,
                    replyMarkup: inlinereplyMarkup);
                        break;

                    default:
                        break;
                }
            }
            //if (Category == kb.Category.PC)
            //{
            //    switch (ProductName)
            //    {
            //        case "ANUBIS":
            //            await botClient.SendVideoAsync(chatId: command.Callback.Message.Chat.Id,
            //        video: Telegram.Bot.Types.InputFile.FromUri(""),
            //        caption: "",
            //        parseMode: Telegram.Bot.Types.Enums.ParseMode.Html,
            //        replyMarkup: inlinereplyMarkup);
            //            break;
            //        default:
            //            break;
            //    }
            //}
        }
    }
}
