using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Telegram.Bot;
using Telegram.Bots.Http;

namespace TestForTutorial
{
    public class OrdersListener
    {
        
        public int amountOfGoods { get; set; } = 1;
        public int amountOfOrders { get; set; } = 0;
        public string chosenProductName { get; set; }
        public string deviceType { get; set; }
        public string price { get; set; }
        public string duration { get; set; }
        public string country { get; set; }


        public bool isConfirmed { get; set; }

        public async Task<bool> CheckIfKeysExist()
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionOptions.connectionString))
            {
                sqlConnection.Open();
                string query = $"SELECT COUNT(*) FROM KeysInfo where key_duration_in_days = {duration} and device_type = '{deviceType}' and hack_type = '{chosenProductName}'";

                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                var count = await cmd.ExecuteScalarAsync();
                if (Convert.ToInt32(count) - amountOfGoods >= 0)
                    return true;
                else
                    return false;
            }
        }
        public async void WriteoffMoneyFromBalance(UsersCabinet userCabinet, string newBalance)
        {
            using (SqlConnection sqlConnectionWriteOff = new SqlConnection(ConnectionOptions.connectionString))
            {
                //{Convert.ToDouble(userCabinet.GetUserBalance() - Convert.ToDouble(price))}
                sqlConnectionWriteOff.Open();

                string queryString = $"update ResellerInfo set user_balance = '{newBalance}' where resellerName = '{userCabinet.UserName}'";
                SqlCommand cmd = new(queryString, sqlConnectionWriteOff);

                await cmd.ExecuteNonQueryAsync();
            }
        }
        private async Task<string> GiveKey(TelegramBotCommand telegramBotCommand, ITelegramBotClient botClient)
        {
            string key = "";
            using (SqlConnection sqlConnectionGive = new SqlConnection(ConnectionOptions.connectionString))
            {

                sqlConnectionGive.Open();
                string queryString = $"SELECT TOP 1 key_value FROM KeysInfo where key_duration_in_days = {duration} and device_type = '{deviceType}' and hack_type = '{chosenProductName}'";
                SqlCommand cmd = new(queryString, sqlConnectionGive);

                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    key = reader.GetValue(0).ToString();
                    await telegramBotCommand.SendTextAnswerOnCallbackAsync(botClient, key, Telegram.Bot.Types.Enums.ParseMode.Html);
                    
                }

            }
            return key;
        }
        private async Task RemoveKey(string key)
        {
            using (SqlConnection sqlConnectionRemove = new SqlConnection(ConnectionOptions.connectionString))
            {
                sqlConnectionRemove.Open();
                string queryString = $"delete from KeysInfo where key_value = '{key}'";

                SqlCommand cmd = new(queryString, sqlConnectionRemove);
                await cmd.ExecuteNonQueryAsync();

            }
        }

        public async Task GetKey(TelegramBotCommand telegramBotCommand, ITelegramBotClient botClient)
        {
            char separator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];


            UsersCabinet user = new(telegramBotCommand.Callback.From.Username);
            double balance = Convert.ToDouble(user.GetUserBalance());
            
            //int realAmountOfChosenGuts = 0;
            //SELECT COUNT(*) FROM KeysInfo where key_value = '{keyStringTextBox.Text}'
            //select top {amountOfGoods} key_value from KeysInfo where key_duration_in_days = {duration} and device_type = '{deviceType}' and hack_type = '{chosenProductName}'

            if (await CheckIfKeysExist())
            {
                if (balance - (Convert.ToDouble(price) * amountOfGoods) >= 0)
                {
                    //balance -= Convert.ToDouble(price);
                    
                    using (SqlConnection sqlConnection = new SqlConnection(ConnectionOptions.connectionString))
                    {
                        sqlConnection.Open();

                        await telegramBotCommand.SendTextAnswerOnCallbackAsync(botClient, "Вот список ключей:", Telegram.Bot.Types.Enums.ParseMode.Html);

                        //string selectKeyQueryString = $"SELECT TOP {amountOfGoods} key_value FROM KeysInfo where key_duration_in_days = {duration} and device_type = '{deviceType}' and hack_type = '{chosenProductName}'";
                        //SqlCommand cmd = new(selectKeyQueryString, sqlConnection);
                        //SqlDataReader reader = cmd.ExecuteReader();
                        for (int i = 0; i < amountOfGoods; i++)
                        {
                            string key = await GiveKey(telegramBotCommand, botClient);

                            await Task.Delay(1000);
                            await RemoveKey(key);

                        }
                        //string newBalance = ((Convert.ToDouble(price) * amountOfGoods)).ToString();
                        //string newBalance = user.GetUserBalance().ToString();
                        double newBalance = (balance - Convert.ToDouble(price.Replace(',', separator)) * amountOfGoods);
                        
                        WriteoffMoneyFromBalance(user, newBalance.ToString()); //To uncomment it

                        await telegramBotCommand.SendTextAnswerOnCallbackAsync(botClient, $"Ваш баланс: {Math.Round((balance - (Convert.ToDouble(price) * amountOfGoods)))}", Telegram.Bot.Types.Enums.ParseMode.MarkdownV2, replyKeyreplyMarkup: kb.StartMenu);
                        
                    }
                }
                else
                    await telegramBotCommand.SendTextAnswerOnCallbackAsync(botClient, $"Недостаточно денег на балансе!\nВаш баланс: {balance}\nСумма к оплате: {Convert.ToDouble(price) * amountOfGoods}", Telegram.Bot.Types.Enums.ParseMode.Html);
            }
            else
                await telegramBotCommand.SendTextAnswerOnCallbackAsync(botClient, "Столько ключей у нас нету", Telegram.Bot.Types.Enums.ParseMode.Html);

        }



        public int IncreaseAmountOfOrders()
        {

            return amountOfOrders++;
        }
        public int DecreaseAmountOfOrders()
        {
            if (amountOfOrders > 1)
            {
                return amountOfOrders -= 1;
            }

            else
            {
                //Console.WriteLine("Operation disabled");
                return 0;
            }
        }
        public int SetNullToAmountOfOrders()
        {
            return amountOfOrders = 0;
        }
        //////////FOR AMOUTN OF GOODS////////////////
        public int IncreaseAmountOfGoods()
        {
            return amountOfGoods++;
        }
        public int IncreaseAmountOfGoodsOn10()
        {

            return amountOfGoods += 10;
        }
        public int DecreaseAmountOfGoods()
        {
            if (amountOfGoods > 1)
            {
                return amountOfGoods -= 1;
            }
            else
            {
                //Console.WriteLine("Operation disabled");
                return 0;
            }
        }
        public int DecreaseAmountOfGoodsOn10()
        {
            if (amountOfGoods > 10)
            {
                return amountOfGoods -= 10;
            }
            else
            {
                //Console.WriteLine("Operation disabled");
                return 0;
            }
        }

        public int SetNullToAmountOfGoods()
        {
            return amountOfGoods = 0;
        }

        public string ChangePrice(double newPrice)
        {
            if (newPrice.ToString().Length > 4)
            {
                return Math.Round(newPrice).ToString();
            }
            else
                return newPrice.ToString();
        }

        

        public void DataDistributor(TelegramBotCommand telegramBotCommand)
        {
            if (Prices.IsCallbackPrice(telegramBotCommand.Callback))
            {
                string[] result = telegramBotCommand.Callback.Data.Split('_');

                deviceType = result[1]; // not result[0] bc result[0] == price
                chosenProductName = result[2]; //name of hack
                
                price = (Convert.ToDouble(result[3]) * amountOfGoods).ToString();
                duration = result[4]; // in days
                country = result[5]; //type of currency 
            }
        }

    }
}
