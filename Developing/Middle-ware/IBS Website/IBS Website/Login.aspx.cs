using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace IBS_Website
{
    public partial class Login : System.Web.UI.Page
    {
        static string databaseName = "internet_banking_system";
        static string connstring = string.Format("Server=10.145.1.6; persistsecurityinfo=True ;database={0}; UID=user;password=123456; SslMode = none", databaseName);
        public static string client_ID;
        public static string adminUserName;
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

        protected void UsernameL_TextChanged1(object sender, EventArgs e)
        {

        }

        protected void PasswordL_TextChanged(object sender, EventArgs e)
        {

        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            string userName = UsernameL.Text;
            string password = PasswordL.Text;
            
            string sqlQuery = string.Format("select ClientID from client where UserName = {0} and Password = {1} "
                                            , userName,password);
            MySqlCommand command = new MySqlCommand(sqlQuery,connection);
            MySqlDataReader read = command.ExecuteReader();
            if (read.Read())
            {
                client_ID= read.GetString(0);
                read.Close();
                Response.Redirect

            }
            else {
                sqlQuery = string.Format("select UserName from client where UserName = {0} and Password = {1} "
                                            , userName, password);
                command = new MySqlCommand(sqlQuery, connection);
                read = command.ExecuteReader();
                if (read.Read())
                {
                    adminUserName = read.GetString(0);
                    read.Close();
                }
                else 
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert(' username or password is wrong ');", true);

                }
            }
        }
    }
}