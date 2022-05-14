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
        string userName, accountType, Client_ID, AdminUserName;
        int accountNumber, counter = 0;
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
            Client_ID = "1";

            string sql ="SELECT ClientID , AdminUserName from client where userName= @UserName ";

            string queryString = "INSERT INTO accounts(AccountNumber, ClientID , AccountType , AdminUserName) VALUES (@AccNum,@ID,@Type,@AdminName)";

            MySqlCommand command = new MySqlCommand(sql, connection);

            command.Parameters.Add("@UserName", MySqlDbType.VarChar, 20);

            command.Parameters["@UserName"].Value = userName;

            MySqlDataReader read = command.ExecuteReader();
            if (read.Read())
            {
                //    if(read.)
                Client_ID = read.GetString(0);
                AdminUserName = read.GetString(1);
                read.Close();
                if (UserHasTwoAccounts(int.Parse(Client_ID)))
                {
                    return;
                }
                
                command = new MySqlCommand(queryString, connection);
                command.Parameters.Add("@AccNum", MySqlDbType.Int32);
                command.Parameters.Add("@ID", MySqlDbType.Int32);
                command.Parameters.Add("@Type", MySqlDbType.VarChar, 20);
                command.Parameters.Add("@AdminName", MySqlDbType.VarChar, 20);


                command.Parameters["@AccNum"].Value = accountNumber;
                command.Parameters["@ID"].Value = Client_ID;
                command.Parameters["@Type"].Value = accountType;
                command.Parameters["@AdminName"].Value = AdminUserName;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert(' another client already owns this account number ');", true);
                }
                connection.Close();
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert(' Account is successfully created ');", true);

            }
            else 
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert(' This Client User Name Doesn't Excit ');", true);

            }
            read.Close();
        }
        protected bool UserHasTwoAccounts(int clientid)
        {
            string sqlCount = "SELECT COUNT(*) from accounts where clientid= @ClientID ";
            MySqlCommand command = new MySqlCommand(sqlCount, connection);

            command.Parameters.Add("@ClientID", MySqlDbType.Int32);
            command.Parameters["@ClientID"].Value = clientid;

            MySqlDataReader read = command.ExecuteReader();
            if (read.Read())
            {
                counter = read.GetInt32(0);
                read.Close();
                if (counter >= 2)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert(' A Client can not have more than 2 Accounts ');", true);
                    return true;
                }
                else
                    return false;

            }
            return false;
        }

    }
}