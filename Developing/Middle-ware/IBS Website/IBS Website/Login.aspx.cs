using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using MySql.Data.MySqlClient;

namespace IBS_Website
{
    public partial class Login : System.Web.UI.Page
    {
        static string databaseName = "internet_banking_system";
        static string connstring = string.Format("Server=10.145.2.180; persistsecurityinfo=True ;database={0}; UID=user;password=123456; SslMode = none", databaseName);
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
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert(' Server is not responding please check your connections '); windows.loaction ='LoginFrame.html';", true);
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
            
            string sqlQuery ="select ClientID from client where UserName = @UserName and Password = @Pass ";
            MySqlCommand command = new MySqlCommand(sqlQuery,connection);
            command.Parameters.Add("@UserName", MySqlDbType.VarChar, 20);
            command.Parameters.Add("@Pass", MySqlDbType.VarChar, 50);

            command.Parameters["@UserName"].Value = userName;
            command.Parameters["@Pass"].Value = password;
            MySqlDataReader read = command.ExecuteReader();
            if (read.Read())
            {
                client_ID= read.GetString(0);
                read.Close();
                Response.Redirect("ClientFrame.html");

            }
            else {
                read.Close();
                sqlQuery = "select AdminUserName from admin where AdminUserName = @AdminUserName and Password = @Pass ";
                command = new MySqlCommand(sqlQuery, connection);
                command.Parameters.Add("@AdminUserName", MySqlDbType.VarChar,20);
                command.Parameters.Add("@Pass", MySqlDbType.VarChar, 50);

                command.Parameters["@AdminUserName"].Value = userName;
                command.Parameters["@Pass"].Value = password;
                read = command.ExecuteReader();
                if (read.Read())
                {
                    adminUserName = read.GetString(0);
                    read.Close();
                    Response.Redirect("AdminFrame.html");
                }
                else 
                {

                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert(' username or password is wrong '); windows.loaction ='LoginFrame.html';", true);
                    //MessageBox.Show("username or password is wrong","ERROR");
                }
            }
        }
    }
}