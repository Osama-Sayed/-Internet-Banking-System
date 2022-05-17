using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace IBS_Website
{
    public partial class ClientRegistration : System.Web.UI.Page
    {
        static string databaseName = "internet_banking_system";
        static string connstring = string.Format("Server=10.145.2.180; persistsecurityinfo=True ;database={0}; UID=user;password=123456; SslMode = none", databaseName);
        MySqlConnection connection = new MySqlConnection(connstring);
        string userName;
        string password;
        string confirmPassword;
        int accountNumber = new Random().Next(9000);
        string email;
        string phoneNumber;
        int client_ID = new Random().Next(9000);
        //int accountNumber = new Random().Next(9000);
       
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try {
                connection.Open();
            }
            catch(Exception ex)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert(' Server is not responding please check your connections ');", true);
                Response.Redirect("ClienttFrame.html");

            }
        }

        protected void UsernameCR_TextChanged(object sender, EventArgs e)
        {

        }

        protected void PasswordCR_TextChanged(object sender, EventArgs e)
        {

        }

        protected void PasswordConfCR_TextChanged(object sender, EventArgs e)
        {

        }

        protected void AccountNumCR_TextChanged(object sender, EventArgs e)
        {

        }

        protected void EmailCR_TextChanged(object sender, EventArgs e)
        {

        }

        protected void PhoneNumCR_TextChanged(object sender, EventArgs e)
        {

        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            userName= UsernameCR.Text;
            password= PasswordCR.Text;
            confirmPassword= PasswordConfCR.Text;
            accountNumber =int.Parse(AccountNumCR.Text);
            email= EmailCR.Text;
            phoneNumber= PhoneNumCR.Text;

            if (UserNameisUnique())
            {
                if (ConfirmPasswordEqualsPassword())
                {
                  
                    addClient();
                    addAccount();
                    addClientPhoneNumber();
                    Response.Redirect("ClienttFrame.html");


                }
            }
        }

        protected bool UserNameisUnique() {

            string sqlQuery = "select ClientID from client where UserName = @UserName";
            MySqlCommand command = new MySqlCommand(sqlQuery, connection);
            command.Parameters.Add("@UserName", MySqlDbType.VarChar, 20);
            command.Parameters["@UserName"].Value = userName;

            MySqlDataReader read = command.ExecuteReader();
            if (read.Read())
            {
                read.Close();
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert(' this username is already taken ');", true);
                Response.Redirect("ClienttFrame.html");
                return false;
            }
            read.Close();
            return true;
        }

        protected bool ConfirmPasswordEqualsPassword() {
            if (confirmPassword == password)
            {
                return true;
            }
            else 
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert(' passwords don’t match ');", true);
                Response.Redirect("ClienttFrame.html");

                return false;
            }
        }
        protected void addClientPhoneNumber()
        {
            string sqlQuery = "insert into clientphonenumber (PhoneID, ClientID, PhoneNumber) values (@Phoneid, @ClientID, @PhoneNumber)";
            MySqlCommand command = new MySqlCommand(sqlQuery, connection);
            command.Parameters.Add("@Phoneid", MySqlDbType.Int32);
            command.Parameters.Add("@ClientID", MySqlDbType.Int32);
            command.Parameters.Add("@PhoneNumber", MySqlDbType.Int32);

            command.Parameters["@Phoneid"].Value = new Random().Next(9000);
            command.Parameters["@ClientID"].Value = client_ID;
            command.Parameters["@PhoneNumber"].Value = int.Parse(phoneNumber);

            command.ExecuteNonQuery();
        }
        protected void addAccount()
        {
            string sqlQuery = "insert into accounts (AccountNumber, ClientID) values(@accountNumber, @clientID)";
            MySqlCommand command = new MySqlCommand(sqlQuery, connection);
            command.Parameters.Add("@accountNumber",MySqlDbType.Int32);
            command.Parameters.Add("@clientID", MySqlDbType.Int32);

            command.Parameters["@accountNumber"].Value = accountNumber;
            command.Parameters["@clientID"].Value = client_ID;
            

            command.ExecuteNonQuery();

        }
        protected void addClient() {
            
            string sqlQuery = "insert into client (ClientID, UserName, Email, Password) values (@clientID, @username, @email, @pass)";
            MySqlCommand command = new MySqlCommand(sqlQuery, connection);
            command.Parameters.Add("@clientID", MySqlDbType.Int32);
            command.Parameters.Add("@username", MySqlDbType.VarChar,20);
            command.Parameters.Add("@email",MySqlDbType.VarChar,50);
            command.Parameters.Add("@pass",MySqlDbType.VarChar,50);

            command.Parameters["@clientID"].Value = client_ID;
            command.Parameters["@username"].Value = userName;
            command.Parameters["@email"].Value = email;
            command.Parameters["@pass"].Value = password;

            command.ExecuteNonQuery();

            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert(' User registered succesfully ');", true);
            Response.Redirect("ClienttFrame.html");


        }
    }
}