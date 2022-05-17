using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IBS_Website
{
    public partial class DeleteClient : System.Web.UI.Page
    {
        HttpContext req;
        string userName, Client_ID;
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
                Response.Redirect("ClienttFrame.html");

            }

        }

        protected void ClientUsernameDC_TextChanged(object sender, EventArgs e)
        {

        }

        protected void DeleteClientBtn_Click(object sender, EventArgs e)
        {
            userName = ClientUsernameDC.Text;

            string sqlSelect = "SELECT ClientID  from client where userName= @UserName ";
            MySqlCommand command = new MySqlCommand(sqlSelect, connection);

            command.Parameters.Add("@UserName", MySqlDbType.VarChar, 20);

            command.Parameters["@UserName"].Value = userName;
            MySqlDataReader read = command.ExecuteReader();
            if (read.Read())
            {
                Client_ID = read.GetString(0);
                read.Close();
                deleteAccount();
                deleteClient();
            }
            else
            {
                read.Close();
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert(' this client user name doesn’t exist on the system ');", true);
                Response.Redirect("ClienttFrame.html");

            }
        }
        public void deleteAccount() {
            MySqlCommand command;
            string sqlDeleteAccount = "DELETE from accounts where CLientID= @clientid ";
            command = new MySqlCommand(sqlDeleteAccount, connection);
            command.Parameters.Add("clientid", MySqlDbType.VarChar, 20);
            command.Parameters["@clientid"].Value = Client_ID;
            command.ExecuteNonQuery();
        }
        public void deleteClient() {
            MySqlCommand command;
            string sqlDeleteClient = "DELETE from client where userName= @UserName ";
            command = new MySqlCommand(sqlDeleteClient, connection);
            command.Parameters.Add("@UserName", MySqlDbType.VarChar, 20);
            command.Parameters["@UserName"].Value = userName;
            command.ExecuteNonQuery();
        }


    }
}