using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TestForTutorial
{
    public partial class DeleteDiscountForm : Form
    {
        

        public DeleteDiscountForm()
        {
            InitializeComponent();
        }

        private int RowsCount(string userName)
        {
            int result = 0;
            using (SqlConnection connection = new(ConnectionOptions.connectionString))
            {
                connection.Open();

                string queryString = $"select count(*) from Discounts where reseller_name_for_discount = '{userName}'";
                SqlCommand cmd = new SqlCommand(queryString, connection);

                SqlDataReader readerToConnect = cmd.ExecuteReader();
                while (readerToConnect.Read())
                {
                    result = readerToConnect.GetInt32(0);
                }
                connection.Close();
                return result;
                
            }
        }

        private async Task DisplayUserDiscountAsync(string userName)
        {
            using (SqlConnection connectionToDisplay = new(ConnectionOptions.connectionString))
            {
                connectionToDisplay.Open();
                string query = $"select * from Discounts where reseller_name_for_discount = '{userName}'";
                SqlCommand command = new SqlCommand(query, connectionToDisplay);
                SqlDataReader reader = command.ExecuteReader();
                int startYPos = 235;

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Label label = new();
                        label.Text = $"{userName}:  ID: {reader.GetValue(0)}   discount_amount: {reader.GetValue(2)}   device_type: {reader.GetValue(3)}  hack_type: {reader.GetValue(4)} duration: {reader.GetValue(5)}";
                        label.Size = new Size(2000, 23);
                        label.Visible = true;
                        label.ForeColor = Color.White;
                        label.Location = new Point(230, startYPos);
                        startYPos += 40;

                        Controls.Add(label);
                    }
                    reader.NextResult();
                }
                connectionToDisplay.Close();
            }
            
        }

        
        //private async Task LabelDisplayer(string userName)
        //{
        //    int startYPos = 235;
        //    string[] discount =  DisplayUserDiscountAsync(userName);

        //    for (int i = 0; i < discount.Length; i++)
        //    {
        //        Label label = new();
        //        label.Text = $"{userName}:  ID: {discount[0]}   discount_amount: {discount[2]}   device_type: {discount[3]}  hack_type: {discount[4]}";
        //        label.Size = new Size(2000, 23);
        //        label.Visible = true;
        //        label.ForeColor = Color.White;
        //        label.Location = new Point(230, startYPos);
        //        startYPos += 40;

        //        Controls.Add(label);
        //    }
        //}
        private async void resellerNameTextBox_TextChanged(object sender, EventArgs e)
        {
            
            using (SqlConnection connection = new(ConnectionOptions.connectionString))
            {
                connection.Open();
                string query = $"SELECT reseller_name_for_discount FROM Discounts WHERE EXISTS(SELECT reseller_name_for_discount FROM Discounts WHERE reseller_name_for_discount = '{resellerNameTextBox.Text}')";

                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                
                if (reader.HasRows)
                {
                    isResellerLabel.Visible = true;
                    await DisplayUserDiscountAsync(resellerNameTextBox.Text);
                    connection.Close();
                }
                else
                {
                    isResellerLabel.Visible = false;

                }
            }
        }

        private async void removeResellerButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection connectionToDeleteDiscount = new(ConnectionOptions.connectionString))
            {
                try
                {
                    if (discountIdTextBox.Text != "Введите ID скидки")
                    {
                        connectionToDeleteDiscount.Open();
                        string queryToDeleteDiscount = $"delete from Discounts where id = {discountIdTextBox.Text}";
                        SqlCommand cmd = new SqlCommand(queryToDeleteDiscount, connectionToDeleteDiscount);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}\t Попробуйте заполнить поле 'Bведите ID скидки'");
                }
                finally
                {
                    connectionToDeleteDiscount.Close();

                }
            }
            
        }
    }
}
