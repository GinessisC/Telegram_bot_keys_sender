using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace TestForTutorial
{
    public partial class AddReselerForm : Form
    {
        public AddReselerForm()
        {
            InitializeComponent();
        }
        private void addResellerButton_Click(object sender, EventArgs e)
        {
            //UserInfo.isReseller = true;


            using (SqlConnection sqlConnection = new SqlConnection(ConnectionOptions.connectionString)) // Reseller to add
            {
                //string queryStringToPerformFirst = $"insert into UserInfo(isReseller, userName, users_id) values({1}, '{resellerNameTextBox.Text}', '{}')";
                string queryString = $"insert into ResellerInfo(isUnique, resellerName) values({1}, '{resellerNameTextBox.Text}')";
                sqlConnection.Open();
                

                //SqlCommand cmdToPerformFirstly = new SqlCommand(queryStringToPerformFirst, sqlConnection);


                SqlCommand cmdToPerformSecond = new SqlCommand(queryString, sqlConnection);

                var result = cmdToPerformSecond.ExecuteNonQuery();

                if (result == 1)
                {
                    MessageBox.Show("Ресселер добавлен!");
                }
            }
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionOptions.connectionString)) //To update user`s data in UserInfo
            {
                sqlConnection.Open();
                string queryString = $"update UserInfo set isUnique = 1  where userName = '{resellerNameTextBox.Text}'";
                SqlCommand cmd = new SqlCommand(queryString, sqlConnection);
                cmd.ExecuteNonQuery();
            }

        }

        private void resellerNameTextBox_TextChanged(object sender, EventArgs e)
        {
            //UserInfo.isReseller = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionOptions.connectionString))
            {
                sqlConnection.Open();
                string queryString = $"SELECT resellerName FROM ResellerInfo WHERE EXISTS(SELECT resellerName FROM ResellerInfo WHERE resellerName = '{resellerNameTextBox.Text}');";



                SqlCommand cmd = new SqlCommand(queryString, sqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();



                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        resellerFoundLabel.Visible = true;
                        resellerFoundLabel.Text = $"Пользователь {resellerNameTextBox.Text} - реселлер!";


                        //bool resellerExists = reader.GetBoolean(0);
                        //if (resellerExists == true)
                        //{
                        //    
                        //}

                    }

                }

                else
                {
                    resellerFoundLabel.Visible = false;
                    isResellerFoundLabel.Text = $"Ресселер {resellerNameTextBox.Text} не найден";
                    userIsNotFoundLabel.Visible = true;
                    userIsFoundLabel.Visible = false;
                }

            }
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionOptions.connectionString))
            {
                sqlConnection.Open();

                string queryStringForUserFinding = $"SELECT userName FROM UserInfo WHERE EXISTS(SELECT userName FROM UserInfo WHERE userName = '{resellerNameTextBox.Text}');";

                SqlCommand cmdForUserFinding = new SqlCommand(queryStringForUserFinding, sqlConnection);

                SqlDataReader readerForUserFinding = cmdForUserFinding.ExecuteReader();

                if (readerForUserFinding.HasRows)
                {
                    while (readerForUserFinding.Read())
                    {
                        userIsFoundLabel.Visible = true;
                        userIsNotFoundLabel.Visible = false;
                        userIsFoundLabel.Text = $"Пользователь {resellerNameTextBox.Text} найден в боте";
                    }
                }
                else
                {
                    userIsNotFoundLabel.Visible = true;
                    userIsNotFoundLabel.Text = $"Пользоветель {resellerNameTextBox.Text} не найден в боте";
                    userIsFoundLabel.Visible = false;
                }
            }
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionOptions.connectionString))
            {
                sqlConnection.Open();

                string queryStringForUserFinding = $"select user_balance from ResellerInfo where resellerName = '{resellerNameTextBox.Text}'";

                SqlCommand cmdForUserFinding = new SqlCommand(queryStringForUserFinding, sqlConnection);

                SqlDataReader readerForUserFinding = cmdForUserFinding.ExecuteReader();
                if (readerForUserFinding.HasRows)
                {
                    while (readerForUserFinding.Read())
                    {
                        resellerBalanceTextBox.Text = readerForUserFinding.GetValue(0).ToString();
                    }
                }
            }


        }

        private async  void removeResellerButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionOptions.connectionString)) //Delating reseller at all
                {
                    sqlConnection.Open();

                    string queryStringForResellerRemoving = $"delete from ResellerInfo where resellerName = '{resellerNameTextBox.Text}' AND isUnique = {1}";
                    SqlCommand cmdForResellerRemoving = new SqlCommand(queryStringForResellerRemoving, sqlConnection);



                    if (cmdForResellerRemoving.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Пользователь удалён из списков реселлеров!");
                    }
                }
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionOptions.connectionString)) // remove reseller ststus from UserInfo by changing IsUnique from 1 to 0
                {
                    sqlConnection.Open();
                    string queryStringForUserUpdating = $"update UserInfo set isUnique = {0} where UserName = '{resellerNameTextBox.Text}'";

                    SqlCommand cmdForUsingUpdating = new SqlCommand(queryStringForUserUpdating, sqlConnection);
                    cmdForUsingUpdating.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

            }

        }

        private void changeBalanceButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionOptions.connectionString))
                {
                    sqlConnection.Open();

                    string queryStringForChangingBalance = $"update ResellerInfo set user_balance = '{resellerBalanceTextBox.Text}' where resellerName = '{resellerNameTextBox.Text}'";
                    SqlCommand cmd = new(queryStringForChangingBalance, sqlConnection);

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Операция выполнена успешно!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }

        }

        private void MakeDiscountButton_Click(object sender, EventArgs e)
        {
            MakeDiscountForm form = new();
            form.Show();
        }
    }
}
