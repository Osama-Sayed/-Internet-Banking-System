using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace IBS_Website
{
    public partial class EditClientStepTwo : System.Web.UI.Page
    {
        string Username;
        string Client_ID;
        string email;
        string password;
        string phone_number;
        string Account_number;
        string oldAccountNumber;
        string confirm_pass;
        static string databaseName = "internet_banking_system";
        static string connstring = string.Format("Server=10.145.2.180; persistsecurityinfo=True ;database={0}; UID=user;password=123456; SslMode = none", databaseName);
        MySqlConnection connection = new MySqlConnection(connstring);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                Username = EditClientStepOne.Username;
                
                email = EditClientStepOne.Email;
                password = EditClientStepOne.Password;
                phone_number = EditClientStepOne.phoneNumber;
                Account_number = EditClientStepOne.AccountNumber;

                UsernameEC.Text = Username;
                EmailEC.Text = email;
                PasswordEC.Text = password;
                PasswordconEC.Text = password;
                PhoneNumEC.Text = phone_number;
                AccountNumEC.Text = Account_number;
            }
            Client_ID = EditClientStepOne.Client_ID;
            oldAccountNumber = EditClientStepOne.AccountNumber;





            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert(' Server is not responding please check your connections ');", true);
            }


        }

        protected void UsernameEC_TextChanged(object sender, EventArgs e)
        {
        }

        protected void PasswordEC_TextChanged(object sender, EventArgs e)
        {

        }

        protected void PasswordconEC_TextChanged(object sender, EventArgs e)
        {

        }

        protected void AccountNumEC_TextChanged(object sender, EventArgs e)
        {

        }

        protected void EmailEC_TextChanged(object sender, EventArgs e)
        {

        }

        protected void PhoneNumEC_TextChanged(object sender, EventArgs e)
        {

        }

        protected void EditClientBtn_Click(object sender, EventArgs e)
        {
            Username = UsernameEC.Text;
            password = PasswordEC.Text;
            confirm_pass = PasswordconEC.Text;
            Account_number = AccountNumEC.Text;
            email = EmailEC.Text;
            phone_number = PhoneNumEC.Text;



            if (UserNameisUnique())
            {
                if (ConfirmPasswordEqualsPassword())
                {

                    updateClient();
                    updateAccount();
                    updateClientPhoneNumber();
                    Response.Redirect("Home.aspx");

                }
            }
        }


        protected bool UserNameisUnique()
        {

            string sqlQuery = "select ClientID from client where UserName = @UserName";
            MySqlCommand command = new MySqlCommand(sqlQuery, connection);
            command.Parameters.Add("@UserName", MySqlDbType.VarChar, 20);
            command.Parameters["@UserName"].Value = Username;

            MySqlDataReader read = command.ExecuteReader();
            if (read.Read())
            {
                   
                if (read.GetString(0) != Client_ID)
                {
                    read.Close();
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert(' this username is already taken ');", true);
                    return false;
                }
            }
            read.Close();
            return true;
        }

        protected bool ConfirmPasswordEqualsPassword()
        {
            if (confirm_pass == password)
            {
                return true;
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert(' passwords don’t match ');", true);
                return false;
            }
        }
        protected void updateClientPhoneNumber()
        {
            string sqlQuery = "UPDATE clientphonenumber SET PhoneNumber = @PhoneNumber WHERE ClientID = @ClientID;";
            MySqlCommand command = new MySqlCommand(sqlQuery, connection);
            //command.Parameters.Add("@Phoneid", MySqlDbType.Int32);
            command.Parameters.Add("@ClientID", MySqlDbType.Int32);
            command.Parameters.Add("@PhoneNumber", MySqlDbType.Int32);

           // command.Parameters["@Phoneid"].Value = new Random().Next(9000);
            command.Parameters["@ClientID"].Value = Client_ID;
            command.Parameters["@PhoneNumber"].Value = int.Parse(phone_number);

            command.ExecuteNonQuery();
        }
        protected void updateAccount()
        {
            string sqlQuery = "update accounts set AccountNumber = @accountNumber where ClientID = @clientID and AccountNumber = @oldAccountNumber";
            MySqlCommand command = new MySqlCommand(sqlQuery, connection);
            command.Parameters.Add("@accountNumber", MySqlDbType.Int32);
            command.Parameters.Add("@clientID", MySqlDbType.Int32);
            command.Parameters.Add("@oldAccountNumber", MySqlDbType.Int32);

            command.Parameters["@accountNumber"].Value = int.Parse(Account_number);
            command.Parameters["@clientID"].Value = int.Parse(Client_ID);
            command.Parameters["@oldAccountNumber"].Value = int.Parse(oldAccountNumber);



            command.ExecuteNonQuery();

        }
        protected void updateClient()
        {

            string sqlQuery = "update client set UserName = @username, Email = @email, Password = @pass where ClientID =@clientID";
            MySqlCommand command = new MySqlCommand(sqlQuery, connection);
            command.Parameters.Add("@clientID", MySqlDbType.Int32);
            command.Parameters.Add("@username", MySqlDbType.VarChar, 20);
            command.Parameters.Add("@email", MySqlDbType.VarChar, 50);
            command.Parameters.Add("@pass", MySqlDbType.VarChar, 50);

            command.Parameters["@clientID"].Value = int.Parse(Client_ID);
            command.Parameters["@username"].Value = Username;
            command.Parameters["@email"].Value = email;
            command.Parameters["@pass"].Value = password;

            command.ExecuteNonQuery();

            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert(' User edited succesfully ');", true);


        }
    }
}