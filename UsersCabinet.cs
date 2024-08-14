using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace TestForTutorial
{
    public class UsersCabinet
    {
        public string Id { get; } = "0";
        public Update UserUpdate { get; set; }
        public string UserName { get; set; }
        public int AmountOfBoughtPurchases { get; set; } // кол-во купленых покупок
        public string ChosenCurrency { get; set; }
        public string GetUserBalance()
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionOptions.connectionString))
            {
                string balance = "0";
                sqlConnection.Open();

                string queryString = $"select user_balance from ResellerInfo where resellerName = '{UserName}'";
                SqlCommand cmd = new(queryString, sqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        char separator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];

                        balance = reader.GetValue(0).ToString().Replace(',', separator);

                        if (balance.Length > 4)
                        {
                            using (SqlConnection newSqlConnection = new SqlConnection(ConnectionOptions.connectionString))
                            {
                                newSqlConnection.Open();
                                var roundBalance = Math.Round(Convert.ToDouble(balance));
                                queryString = $"update ResellerInfo set user_balance = '{Math.Round(Convert.ToDouble(balance))}' where resellerName = '{UserName}'";
                                SqlCommand command = new(queryString, newSqlConnection);
                                command.ExecuteNonQuery();

                                return roundBalance.ToString();
                            }
                        }

                    }
                }
                return balance;
            }
            //UserName
        }
        public string GenerateId(Update? update)
        {
            string userName = (update?.Message?.Chat?.FirstName).ToString();
            string userId = (update?.Message?.Chat.Id).ToString();


            string generatedId = "0";



            generatedId = generatedId + userName + userId;

            return generatedId;
        }

        public UsersCabinet(string userName, int amountOfBoughtPurchases, Update userUpdate)
        {
            UserName = userName;
            AmountOfBoughtPurchases = amountOfBoughtPurchases;
            Id = GenerateId(userUpdate);
        }

        public UsersCabinet(string userName)
        {
            UserName = userName;
        }


    }
}
