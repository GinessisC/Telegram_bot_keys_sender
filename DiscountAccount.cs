using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static TestForTutorial.kb;

namespace TestForTutorial
{
    class DiscountAccount
    {


        public string userName { get; set; } 
        public DiscountAccount(string UserName)
        {
            userName = UserName;
        }
        public async Task<List<string>> GetAllUserDiscountsAsync()
        {
            var result = new List<string> { };

            using (SqlConnection connectionToDeleteDiscount = new(ConnectionOptions.connectionString))
            {
                connectionToDeleteDiscount.Open();
                string query = $"select * from Discounts where reseller_name_for_discount = '{userName}'";
                SqlCommand cmd = new(query, connectionToDeleteDiscount);
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        
                        for (int i = 0; i < 6; i++)
                        {
                            //2 - price
                            //3 -device
                            //4 - hack
                            //5 - duration+

                            result.Add($"Цена:  {reader.GetValue(2)}\nДивайс:  {reader.GetValue(3)}\nНазвание чита:  {reader.GetValue(4)}\nЧит длится:  {reader.GetValue(5)}");
                        }
                    }
                    reader.NextResult();
                }


            }
            return result;
        }
        public async Task<InlineKeyboardMarkup> CreateInlineKeyboardMarkupForDiscount()
        {
            

            IEnumerable<IEnumerable<InlineKeyboardButton>> inlineKeyboardButtons = null;

            List<IEnumerable<InlineKeyboardButton>> inlineKeyboardList = inlineKeyboardButtons?.ToList() ?? new List<IEnumerable<InlineKeyboardButton>>();


            using (SqlConnection connectionToDeleteDiscount = new(ConnectionOptions.connectionString))
            {
                connectionToDeleteDiscount.Open();
                string query = $"select * from Discounts where reseller_name_for_discount = '{userName}'";
                SqlCommand cmd = new(query, connectionToDeleteDiscount);
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Dictionary<string, string> DaysPricesPair = new Dictionary<string, string>() { { reader.GetValue(5).ToString(), reader.GetValue(2).ToString() } };
                        InlineKeyboardButton[] newKeyboardRow = new[]
                        {
                            InlineKeyboardButton.WithCallbackData(text: $"{reader.GetValue(4)} • {reader.GetValue(2)}$ • {reader.GetValue(5)} дней",
                            callbackData: $"price_{reader.GetValue(3)}_{reader.GetValue(4)}_{reader.GetValue(2)}_{reader.GetValue(5)}_dol")

                        };
                        inlineKeyboardList.Add(newKeyboardRow);
                        //inlineKeyboardList. = kb.GeneratePrices(DaysPricesPair, productName: reader.GetValue(4).ToString(), reader.GetValue(3).ToString(), "dol");

                    }
                    reader.NextResult();
                }
                InlineKeyboardButton[] deleteButtonAndChangeCurrency = new[]
                {
                    InlineKeyboardButton.WithCallbackData(text: "Назад🔙", callbackData: "Back_to_Cotegories"),
                    InlineKeyboardButton.WithCallbackData(text: "Сменить валюту💱", callbackData: "Change_Currency")
                };
                inlineKeyboardList.Add(deleteButtonAndChangeCurrency);
                // Convert the list back to an array if necessary
                inlineKeyboardButtons = inlineKeyboardList.ToArray();
                InlineKeyboardMarkup inlineKeyboardMarkup = new(inlineKeyboardButtons.ToArray());
                return inlineKeyboardMarkup;

            }
            
        }
    }
}
