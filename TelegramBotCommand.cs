using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace TestForTutorial
{
    /// <summary>
    /// Contains command using in Telegram bot, which starts with '/'
    /// </summary>
    public class TelegramBotCommand
    {
        public string CommandName { get; set; }
        public string Description { get; set; }
        //public bool IsFutureMessageContainsUnderButton { get; set; }
        public CallbackQuery Callback { get; set; }

        public TelegramBotCommand(string commandName, string description)
        {
            CommandName = commandName;
            Description = description;

        }
        public TelegramBotCommand(CallbackQuery callbackName, string description)
        {
            Callback = callbackName;
            Description = description;

        }

        public async Task SendTextAnswerOnCallbackAsync(ITelegramBotClient botClient, string callbackTextAnswer, ParseMode parseMode, ReplyKeyboardMarkup replyKeyreplyMarkup)
        {
            if (Callback.Data != null)
            {
                await botClient.SendTextMessageAsync(Callback.Message.Chat.Id,
                    text: callbackTextAnswer,
                    parseMode: parseMode,
                    replyMarkup: replyKeyreplyMarkup);
            }
        }

        public async Task SendTextAnswerOnCallbackAsync(ITelegramBotClient botClient, string callbackTextAnswer, ParseMode parseMode, InlineKeyboardMarkup inlinereplyMarkup)
        {
            if (Callback.Data != null)
            {
                await botClient.SendTextMessageAsync(Callback.Message.Chat.Id,
                    text: callbackTextAnswer,
                    parseMode: parseMode,
                    replyMarkup: inlinereplyMarkup);
            }
        }
        public async Task SendTextAnswerOnCallbackAsync(ITelegramBotClient botClient, string callbackTextAnswer, ParseMode parseMode)
        {
            if (Callback.Data != null)
            {
                await botClient.SendTextMessageAsync(Callback.Message.Chat.Id, text: callbackTextAnswer, parseMode: parseMode);
            }
        }
        /// <summary>
        /// Is used to send text messages via commands
        /// </summary>
        /// <param name="botClient"></param>
        /// <param name="text">Text to send</param>
        /// <param name="update"></param>
        /// <param name="parseMode"></param>
        /// <param name="replyMarkup"></param>
        /// <returns></returns>
        public async Task SendTextAnswerAsync(ITelegramBotClient botClient, string text, Update update, ParseMode parseMode)
        {
            if (update?.Message?.Text != null)
            {
                if (update?.Message?.Text == CommandName)
                {
                    await botClient.SendTextMessageAsync(chatId: update.Message.Chat.Id,
                text: text,
                parseMode: parseMode);

                }
            }
        }
        /// <summary>
        /// Inline buttons added
        /// </summary>
        /// <param name="botClient"></param>
        /// <param name="text"></param>
        /// <param name="update"></param>
        /// <param name="parseMode"></param>
        /// <param name="inlinereplyMarkup">inline button</param>
        /// <returns></returns>
        public async Task SendTextAnswerAsync(ITelegramBotClient botClient, string text, Update update, ParseMode parseMode, InlineKeyboardMarkup inlinereplyMarkup)
        //CallbackQuery callbackQuery
        {
            if (update?.Message?.Text != null)
            {
                if (update?.Message?.Text == CommandName)
                {
                    await botClient.SendTextMessageAsync(chatId: update.Message.Chat.Id,
                        text: text,
                        parseMode: parseMode,
                        replyMarkup: inlinereplyMarkup);

                    
                }
            }
        }
        /// <summary>
        /// Key buttons added
        /// </summary>
        /// <param name="botClient"></param>
        /// <param name="text"></param>
        /// <param name="update"></param>
        /// <param name="parseMode"></param>
        /// <param name="inlinereplyMarkup">Key button</param>
        /// <returns></returns>
        public async Task SendTextAnswerAsync(ITelegramBotClient botClient, string text, Update update, ParseMode parseMode, ReplyKeyboardMarkup replyKeyreplyMarkup)
        {
            if (update?.Message?.Text != null)
            {
                if (update?.Message?.Text == CommandName)
                {
                    await botClient.SendTextMessageAsync(disableWebPagePreview: true, chatId: update.Message.Chat.Id,
                        text: text,
                        parseMode: parseMode,
                        replyMarkup: replyKeyreplyMarkup);
                }
            }
        }

    }
}
