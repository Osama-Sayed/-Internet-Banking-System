using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace IBS_Website
{
    public partial class EditClientStepOne : System.Web.UI.Page
    {
        public static string Client_ID;
        public static string Email;
        public static string Password;
        public static string phoneNumber;
        public static string AccountNumber;

        public static string Username;

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

        protected void ClientUsernameEC_TextChanged(object sender, EventArgs e)
        {

        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            Username = ClientUsernameEC.Text;
            GetClientDetailsByUserName(Username);
            Response.Redirect("EditClientStepTwo.aspx");
            connection.Close();
        }

        protected bool GetClientDetailsByUserName(string clientUserName)
        {
            string queryString = "Select * from client where UserName = @UserName";
            MySqlCommand command = new MySqlCommand(queryString, connection);
            command.Parameters.Add("@UserName", MySqlDbType.VarChar, 20);
            command.Parameters["@UserName"].Value = clientUserName;
            MySqlDataReader read = command.ExecuteReader();
            if (read.Read())
            {
                clientUserName = read.GetString(1);
                Client_ID = read.GetString(0);
                Email = read.GetString(2);
                Password = read.GetString(3);
                read.Close();
                GetPhoneNumber();
                GetAccountNumber();
                return true;
            }

            else
            {
                read.Close();
                MessageBox.Show("this client username doesn’t exist on the system");
                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert(' this client user name doesn’t exist on the system ');", true);
                Response.Redirect("imgbackadmin.aspx");

                return false;
            }
        }
        public void GetPhoneNumber()
        {
            string sqlQuery = "select PhoneNumber from clientphonenumber where ClientID = @ClientID";
            MySqlCommand command = new MySqlCommand(sqlQuery, connection);
            command.Parameters.Add("@ClientID", MySqlDbType.Int32);
            command.Parameters["@ClientID"].Value = int.Parse(Client_ID);

            MySqlDataReader read = command.ExecuteReader();

            if (read.Read())
            {
                phoneNumber = read.GetString(0);
            }
            read.Close();

        }
        public void GetAccountNumber()
        {
            string sqlQuery = "select AccountNumber from accounts where ClientID = @ClientID";
            MySqlCommand command = new MySqlCommand(sqlQuery, connection);
            command.Parameters.Add("@ClientID", MySqlDbType.Int32);
            command.Parameters["@ClientID"].Value = int.Parse(Client_ID);

            MySqlDataReader read = command.ExecuteReader();

            if (read.Read())
            {
                AccountNumber = read.GetString(0);
            }

            read.Close();

        }
    }
}