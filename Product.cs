using System;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace TestForTutorial
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Description { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        public int Duration { get; set; }
        InlineKeyboardMarkup InlineKeyboardAnswereKeyBoard { get; set; }
        public Product(int id, string name, string description, string category, int price, int duration)
        {
            Id = id;
            Name = name;
            Description = description;
            Category = category;
            Price = price;
            Duration = duration;
        }
        public Product(int id, string name, string description, string category, int price, int duration, InlineKeyboardMarkup inlineKeyboardAnswereKeyBoard)
        {
            Id = id;
            Name = name;
            Description = description;
            Category = category;
            Price = price;
            Duration = duration;
            InlineKeyboardAnswereKeyBoard = inlineKeyboardAnswereKeyBoard;
        }
        
    }
}
