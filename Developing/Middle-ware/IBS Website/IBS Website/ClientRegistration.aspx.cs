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
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try {
                connection.Open();
            }
            catch(Exception ex)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert(' Server is not responding please check your connections ');", true);
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
            UsernameCR;
            PasswordCR;
            PasswordConfCR;
            AccountNumCR;
            EmailCR;
            PhoneNumCR;
        }
    }
}