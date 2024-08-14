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
    public partial class CreateKeyForm : Form
    {
        
        
        public CreateKeyForm()
        {
            InitializeComponent();
        }
        
        private void keyStringTextBox_Click(object sender, EventArgs e)
        {
            if (keyStringTextBox.Text == "Ключ")
            {
                keyStringTextBox.Text = string.Empty;
            }
            
            keyStringTextBox.ForeColor = System.Drawing.Color.White;
        }

        private void keyDurationTextBox_Click(object sender, EventArgs e)
        {
            if (keyDurationTextBox.Text == "Длительность(кол-во дней)")
            {
                keyDurationTextBox.Text = string.Empty;
            }

            keyDurationTextBox.ForeColor = System.Drawing.Color.White;
        }

        private void deviceTypeComboBox_Click(object sender, EventArgs e)
        {
            if (deviceTypeComboBox.Text == "Тип девайса")
            {
                deviceTypeComboBox.Text = string.Empty;
            }

            deviceTypeComboBox.ForeColor = System.Drawing.Color.White;
        }
        private void priceTextBox_Click(object sender, EventArgs e)
        {
            if (priceTextBox.Text == "Цена")
            {
                priceTextBox.Text = string.Empty;
            }

            priceTextBox.ForeColor = System.Drawing.Color.White;
        }
        private string[] hacksForAndroidNoRoot = new string[]
        {
            "Zolo", "Nerohol", "Fite Mod", "VN", "KING MOD", "Hassan", "Uki", "DESERTSTORM", "OWM MOD", "HarlyMod"
        };

        private string[] hacksForAndroidRoot = new string[]
        {
            "root Star",
        };

        private string[] hacksForIOS = new string[]
        {
            "IOS SponsorStar",
        };
        private string[] hacksForPC = new string[]
        {
            "ANUBIS"
        };
        public string[] SelectHacks(string device) //Use when device is selected
        {
            string[] result = new string[] { };
            switch (device)
            {
                case "AndroidNoRoot":
                    result = hacksForAndroidNoRoot;
                    break;
                case "AndroidRoot":
                    result = hacksForAndroidRoot;
                    break;
                case "IOS":
                    result = hacksForIOS;
                    break;
                case "For PC":
                    result = hacksForPC;
                    break;
                default:
                    result = new string[1] { "Non found" };
                    break;
            }


            return result;
        }

        private void hackTypeComboBox_Click(object sender, EventArgs e)
        {
            if (hackTypeComboBox.Text == "Тип чита")
            {
                hackTypeComboBox.Text = string.Empty;
            }

            hackTypeComboBox.ForeColor = System.Drawing.Color.White;

            hackTypeComboBox.Items.Clear(); //Firstly, Items should be cleared

            hackTypeComboBox.Items.AddRange(SelectHacks(deviceTypeComboBox.Text));

        }

        private async void addKeyButton_Click(object sender, EventArgs e) //for key adding 
        {
            string key = keyStringTextBox.Text;
            string duraton = keyDurationTextBox.Text;
            string price =  priceTextBox.Text;
            string device = deviceTypeComboBox.Text;
            string hackType = hackTypeComboBox.Text;
            //DB logic
            if (key != null && duraton != null && price != null && device != null && hackType != null)
            {
                var array = keyStringTextBox.Text.Split(',');

                using (SqlConnection connection = new(ConnectionOptions.connectionString))
                {
                    connection.Open();

                    foreach (string item in array)
                    {
                        //string queryString = $"insert into KeysInfo(key_value, key_duration_in_days, price, device_type, hack_type) values('{item}', {keyDurationTextBox.Text}, {priceTextBox.Text}, '{deviceTypeComboBox.Text}', '{hackTypeComboBox.Text}')";
                        string queryStringCycle = $"insert into KeysInfo(key_value, key_duration_in_days, price, device_type, hack_type) values('{item}', {keyDurationTextBox.Text}, {priceTextBox.Text}, '{deviceTypeComboBox.Text}', '{hackTypeComboBox.Text}')";
                        SqlCommand cmd = new SqlCommand(queryStringCycle, connection);

                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                

                //string queryString = $"insert into KeysInfo(key_value, key_duration_in_days, price, device_type, hack_type) values('{key}', '{duraton}', '{price}', '{device}', '{hackType}')";
                //SqlCommand command = new SqlCommand(queryString, SqlConnectionstr);

                //adapter.SelectCommand = command;
                //adapter.Fill(table);

                

                //if (command.ExecuteNonQuery() == 1)
                //{
                //    MessageBox.Show("Seccessfuly!");
                //}
                //else MessageBox.Show("Error!");

                //SqlConnectionstr.Close();

            }
        }

        private void editKeyInfoButton_Click(object sender, EventArgs e)
        {
            EditKeyInfoForm form = new();
            form.Show();
        }

    }
}
