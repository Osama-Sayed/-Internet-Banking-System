using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IBS_Website
{
    public partial class AddAccount : System.Web.UI.Page
    {
        HttpContext req;
        string userName, accountType;
        int accountNumber;
        static string databaseName = "internet_banking_system";
        static string connstring = string.Format("Server=10.145.2.180; persistsecurityinfo=True ;database={0}; UID=user;password=123456; SslMode = none", databaseName);
        MySqlConnection connection = new MySqlConnection(connstring);

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert(' Server is not responding please check your connections ');", true);

            }

        }

        protected void ClientUsernameAA_TextChanged(object sender, EventArgs e)
        {

        }

        protected void NewAccountNumAA_TextChanged(object sender, EventArgs e)
        {

        }

        protected void SaveCurrentAA_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void AddClientBtn_Click(object sender, EventArgs e)
        {
            userName = ClientUsernameAA.Text;
            accountType = SaveCurrentAA.Text;
            accountNumber = int.Parse(NewAccountNumAA.Text);

            string sql = string.Format("SELECT ClientID , AdminUserName from clients where userName={0}", userName);

            string queryString = "INSERT INTO accounts(AccountNumber, ClientID , AccountType , AdminUserName) VALUES (@AccNum,@ID,@Type,@AdminName)";

            MySqlCommand command = new MySqlCommand(queryString, connection);
            MySqlDataReader read = command.ExecuteReader();

            command = new MySqlCommand(queryString, connection);
            command.Parameters.Add("@AccNum", MySqlDbType.Int32);
            command.Parameters.Add("@ID", MySqlDbType.Int32);
            command.Parameters.Add("@Type", MySqlDbType.VarChar, 20);
            command.Parameters.Add("@AdminName", MySqlDbType.VarChar, 20);


            command.Parameters["@AccNum"].Value = accountNumber;
            command.Parameters["@ID"].Value = accountNumber;
            command.Parameters["@Type"].Value = accountType;
            command.Parameters["@AdminName"].Value = accountNumber;




        }
    }
}