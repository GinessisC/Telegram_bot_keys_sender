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

namespace TestForTutorial
{
    public partial class MakeDiscountForm : Form
    {


        
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


        public MakeDiscountForm()
        {
            InitializeComponent();
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

        private async void CreateDiscountButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection discountMakingSqlConnection = new SqlConnection(ConnectionOptions.connectionString))
            {
                discountMakingSqlConnection.Open();

                string query = $"insert into Discounts(reseller_name_for_discount, discount_amount, device_type, hack_type, days_to_use_hack) values ('{resellerNameTextBox.Text}', '{newPricetextBox.Text}', '{deviceTypeComboBox.Text}', '{hackTypeComboBox.Text}', '{durationOfDiscountHackTextBox.Text}')";
                SqlCommand cmd = new(query, discountMakingSqlConnection);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        private void deleteDiscountButton_Click(object sender, EventArgs e)
        {
            DeleteDiscountForm form = new DeleteDiscountForm();
            form.Show();
        }
    }
}
