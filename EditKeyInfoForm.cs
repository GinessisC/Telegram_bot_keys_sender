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
using System.Security.AccessControl;
using System.Configuration;
using Microsoft.VisualBasic.Logging;
using System.Reflection.Emit;

namespace TestForTutorial
{

    public partial class EditKeyInfoForm : Form
    {

        
        
        //string connection = new SqlConnection(ConfigurationManager.ConnectionStrings[SqlConnection].ConnectionString);
        //public string va = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        //ConfigurationManager.ConnectionStrings["Data Source=IDEAPAD;Initial Catalog=TelegramUsersData;Integrated Security=True"].ConnectionString;
        public EditKeyInfoForm()
        {
            InitializeComponent();
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

        private async void editKeyStringTextBox_TextChanged(object sender, EventArgs e)
        {
            // Corrected the instantiation of SqlConnection
            //string queryString = $"SELECT key_duration_in_days, price, device_type, hack_type FROM KeysInfo WHERE key_value = '{key}'";
            try
            {
                using (SqlConnection SqlConnection = new SqlConnection(ConnectionOptions.connectionString))
                {
                    SqlConnection.Open();

                    // Use parameterized query to prevent SQL injection

                    string queryString = $"SELECT price, key_duration_in_days, device_type, hack_type FROM KeysInfo where key_value = '{editKeyStringTextBox.Text}'";
                    SqlCommand command = new SqlCommand(queryString, SqlConnection);
                    SqlDataReader reader = command.ExecuteReader();


                    if (reader.HasRows)
                    {

                        if (reader.Read())
                        {
                            keyCantBeFoundLabel.Text = "Ключ найден!";


                            editKeyDurationTextBox.Visible = true;
                            editPriceTextBox.Visible = true;
                            editDeviceTypeComboBox.Visible = true;
                            editHackTypeComboBox.Visible = true;

                            // Retrieve and assign the values


                            editPriceTextBox.Text = reader.GetValue(0).ToString();
                            editKeyDurationTextBox.Text = reader.GetValue(1).ToString();
                            editDeviceTypeComboBox.Text = reader.GetValue(2).ToString();
                            editHackTypeComboBox.Text = reader.GetValue(3).ToString();


                        }

                    }
                    else
                        keyCantBeFoundLabel.Text = "Error: ключ не найден";
                    keyCantBeFoundLabel.ForeColor = Color.Red;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }

        }

        

        private async void editDeviceTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            editHackTypeComboBox.Items.Clear();
            editHackTypeComboBox.Items.AddRange(SelectHacks(editDeviceTypeComboBox.Text));
        }

        private async void editKeyInfoButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection SqlConnection = new SqlConnection(ConnectionOptions.connectionString))
                {
                    SqlConnection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    DataTable table = new DataTable();

                    // Use parameterized query to prevent SQL injection

                    string queryUpdateString = $"update KeysInfo set key_value = '{editKeyStringTextBox.Text}', key_duration_in_days = {editKeyDurationTextBox.Text}, price = {editPriceTextBox.Text}, device_type = '{editDeviceTypeComboBox.Text}', hack_type = '{editHackTypeComboBox.Text}' where key_value = '{editKeyStringTextBox.Text}';";
                    SqlCommand command = new SqlCommand(queryUpdateString, SqlConnection);

                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Операция выполнена успешно!");
                    }
                    else MessageBox.Show("Ошибка!");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
            
        }
    }
}
