using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

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
                MessageBox.Show(" Server is not responding please check your connections ");
                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert(' Server is not responding please check your connections ');", true);
                Response.Redirect("AdminFrame.html");

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
                deletePhoneNumber();
                deleteClient();
                MessageBox.Show("User deleted successfully");
                Response.Redirect("AdminFrame.html");
            }
            else
            {
                read.Close();
                MessageBox.Show("this client user name doesn’t exist on the system");
                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert(' this client user name doesn’t exist on the system ');", true);
                Response.Redirect("AdminFrame.html");

            }
        }
        public void deleteAccount() {
            MySqlCommand command;
            string sqlQuery = "select AccountNumber from accounts where ClientID = @clientid";
            command = new MySqlCommand(sqlQuery, connection);
            command.Parameters.Add("clientid", MySqlDbType.Int32);
            command.Parameters["@clientid"].Value = int.Parse(Client_ID);
            MySqlDataReader read = command.ExecuteReader();
            List<int> accountNumbers = new List<int>(); 
            while (read.Read())
            {
                accountNumbers.Add(read.GetInt32(0));
            }
            read.Close();
            foreach (int accountNumber in accountNumbers)
            {
                deleteTransfers(accountNumber);
            }
            

            sqlQuery ="DELETE from accounts where ClientID= @clientid ";
            command = new MySqlCommand(sqlQuery, connection);
            command.Parameters.Add("clientid", MySqlDbType.Int32);
            command.Parameters["@clientid"].Value = int.Parse(Client_ID);
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
        public void deleteTransfers(int AccountNumber) {
            MySqlCommand command;
            string sqlDeleteClient = "DELETE from transfer where SourceAccount = @AccountNumber or DestinationAccount = @AccountNumber ";
            command = new MySqlCommand(sqlDeleteClient, connection);
            command.Parameters.Add("@AccountNumber", MySqlDbType.Int32);
            command.Parameters["@AccountNumber"].Value = AccountNumber;
            command.ExecuteNonQuery();
        }
        public void deletePhoneNumber() {
            MySqlCommand command;
            string sqlDeletePhonenumber = "DELETE from clientphonenumber where ClientID= @clientID";
            command = new MySqlCommand(sqlDeletePhonenumber, connection);
            command.Parameters.Add("@clientID", MySqlDbType.Int32);
            command.Parameters["@clientID"].Value = int.Parse(Client_ID);
            command.ExecuteNonQuery();
        }
    }


    
}