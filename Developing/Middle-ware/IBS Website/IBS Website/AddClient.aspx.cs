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
    public partial class AddClient : System.Web.UI.Page
    {
        string adminUsername = Login.adminUserName;
        static string databaseName = "internet_banking_system";
        static string connstring = string.Format("Server=10.145.2.180; persistsecurityinfo=True ;database={0}; UID=user;password=123456; SslMode = none", databaseName);
        MySqlConnection connection = new MySqlConnection(connstring);
        string clientUsername;
        string password,confirmedPassword;
        int accountNum;
        string email;
        string phoneNumber;
        int client_ID = new Random().Next(9000);
        int phone_ID = new Random().Next(9000);
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Server is not responding please check your connections");
                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert(' Server is not responding please check your connections ');", true);
                //Response.Redirect("AdminFrame.html");

            }
        }

        protected void UsernameAC_TextChanged(object sender, EventArgs e)
        {

        }

        protected void passwordAC_TextChanged(object sender, EventArgs e)
        {

        }

        protected void passwordconfAC_TextChanged(object sender, EventArgs e)
        {

        }

        protected void AccountNumAC_TextChanged(object sender, EventArgs e)
        {

        }

        protected void EmailAC_TextChanged(object sender, EventArgs e)
        {

        }

        protected void PhoneNumAC_TextChanged(object sender, EventArgs e)
        {

        }

        protected bool ConfirmPasswordEqualsPassword()
        {
            if (confirmedPassword == password)
            {
                return true;
            }
            else
            {
                MessageBox.Show("passwords don’t match");
                Response.Write("<script>window.close(); </script>");

                return false;
            }
        }
        protected void addClient()
        {
            string sqlQuery = "insert into client (ClientID, UserName, Email , Password , AdminUserName  ) values (@ClientID , @UserName, @Email, @Password ,@AdminUserName)";
            MySqlCommand command = new MySqlCommand(sqlQuery, connection);
            command.Parameters.Add("@ClientID", MySqlDbType.Int32);
            command.Parameters.Add("@UserName", MySqlDbType.VarChar, 20);
            command.Parameters.Add("@Email", MySqlDbType.VarChar, 50 );
            command.Parameters.Add("@Password", MySqlDbType.VarChar, 50);
            command.Parameters.Add("@AdminUserName", MySqlDbType.VarChar, 20);
            command.Parameters["@ClientID"].Value = client_ID;
            command.Parameters["@UserName"].Value = clientUsername;
            command.Parameters["@Email"].Value = email;
            command.Parameters["@Password"].Value = password;
            command.Parameters["@adminUsername"].Value = adminUsername;
            command.ExecuteNonQuery();
        }
        protected void addAccount()
        {
            string sqlQuery = "insert into accounts (AccountNumber, ClientID) values(@accountNumber, @clientID)";
            MySqlCommand command = new MySqlCommand(sqlQuery, connection);
            command.Parameters.Add("@accountNumber", MySqlDbType.Int32);
            command.Parameters.Add("@clientID", MySqlDbType.Int32);

            command.Parameters["@accountNumber"].Value = accountNum;
            command.Parameters["@clientID"].Value = client_ID;


            command.ExecuteNonQuery();

        }
        protected void addPhoneNumber()
        {
            string sqlQuery = "insert into clientphonenumber (PhoneID, ClientID, PhoneNumber) values (@Phoneid, @ClientID, @PhoneNumber)";
            MySqlCommand command = new MySqlCommand(sqlQuery, connection);
            command.Parameters.Add("@PhoneID", MySqlDbType.Int32);
            command.Parameters.Add("@ClientID", MySqlDbType.Int32);
            command.Parameters.Add("@PhoneNumber", MySqlDbType.Int32);
            command.Parameters["@PhoneID"].Value = phone_ID;
            command.Parameters["@ClientID"].Value = client_ID;
            command.Parameters["@PhoneNumber"].Value = int.Parse(phoneNumber);
            command.ExecuteNonQuery();

        }
        protected bool clientAlreadyExists(string clientUsername)
        {
            string sqlQuery = "select ClientID from client where UserName = @UserName";
            MySqlCommand command = new MySqlCommand(sqlQuery, connection);
            command.Parameters.Add("@UserName", MySqlDbType.VarChar, 20);
            command.Parameters["@UserName"].Value = clientUsername;
            MySqlDataReader read = command.ExecuteReader();
            if (read.Read())
            {
                MessageBox.Show("this username is already taken");
                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert(' this username is already taken ');", true);
                //Response.Redirect("AdminFrame.html");

                return false;
            }
            read.Close();
            return true;
        }

        protected void AddClientBtn_Click(object sender, EventArgs e)
        {
            clientUsername = UsernameAC.Text;
            password = passwordAC.Text;
            confirmedPassword = passwordconfAC.Text;
            accountNum = int.Parse(AccountNumAC.Text);
            email = EmailAC.Text;
            phoneNumber = PhoneNumAC.Text;
            if (clientAlreadyExists(clientUsername))
            {
                if (ConfirmPasswordEqualsPassword())
                {
                    if (isAccountNumberUnique(accountNum))
                    {
                        addClient();
                        addPhoneNumber();
                        addAccount();
                        MessageBox.Show("Client Added Successfully");
                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert(' Client Added Successfully ');", true);
                        //Response.Redirect("AdminFrame.html");
                    }
                }
            }
        }

        public bool isAccountNumberUnique(int AccountNumber)
        {
            string sqlQuery = "select AccountNumber from accounts where AccountNumber = @AccountNO";
            MySqlCommand command = new MySqlCommand(sqlQuery, connection);
            command.Parameters.Add("@AccountNO", MySqlDbType.Int32);
            command.Parameters["@AccountNO"].Value = AccountNumber;
            MySqlDataReader read = command.ExecuteReader();
            if (read.Read())
            {
                MessageBox.Show("This account number is already taken");
                Response.Write("<script>window.close(); </script>");
                read.Close();
                return false;
            }
            else
            {
                read.Close();
                return true;
            }

        }
    }
}