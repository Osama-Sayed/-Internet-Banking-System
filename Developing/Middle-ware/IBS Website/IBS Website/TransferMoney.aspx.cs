using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IBS_Website
{
    public partial class TransferMoney : System.Web.UI.Page
    {
        HttpContext req;
        float amount, balance;
        static string databaseName = "internet_banking_system";
        static string connstring = string.Format("Server=10.145.2.180; persistsecurityinfo=True ;database={0}; UID=user;password=123456; SslMode = none", databaseName);
        MySqlConnection connection = new MySqlConnection(connstring);
        string client_ID = Login.client_ID;
        string sourceAcoounrClientID;
        protected void Page_Load(object sender, EventArgs e)
        {
            try {
                connection.Open();
            }
            catch (Exception ex) {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert(' Server is not responding please check your connections ');", true);
                Response.Redirect("ClientFrame.html");

            }

        }


        protected void TransferBtn_Click(object sender, EventArgs e)
        {
            req = HttpContext.Current;
            string sourceAccountNum = req.Request["SourceTM"];
            string destinationAccountNum = req.Request["DestinationTM"];
            if (sourceAccountNum == destinationAccountNum) {
                System.Windows.MessageBox.Show("Source Account number and destination account number are the same");
                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Source Account number and destination account number are the same');", true);
                Response.Redirect("ClientFrame.html");

            }
            else
            {
                if (checkIfAccountsnumberValid(sourceAccountNum, destinationAccountNum))
                {
                    if (isSourceAccountNumbreIsOwnedByClient())
                    {
                        if (sourceAccountHasSufficentBalance(sourceAccountNum))
                        {
                            if (amountShouldOnlyBeUnderTwentyThousand(amount))
                            {
                                addTransfer(sourceAccountNum, destinationAccountNum);
                                
                            }
                            else
                            {
                                System.Windows.MessageBox.Show("Amount exceeds the allowed limit of 20,000 EGP");
                                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert(' The amount exceeds the allowed limit of 20,000 EGP ');", true);
                                Response.Redirect("ClientFrame.html");

                            }
                        }
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("You do not own this source account number");
                        Response.Redirect("ClientFrame.html");
                    }

                }
                
            }
        }
        protected bool checkIfAccountsnumberValid(string sourceAccountNumber, string destinationAccountNumber) {
            string queryString = string.Format("Select ClientID from accounts where AccountNumber = {0};", sourceAccountNumber);
            MySqlCommand command = new MySqlCommand(queryString, connection);
            MySqlDataReader read = command.ExecuteReader();
            if (read.Read())
            {
                sourceAcoounrClientID = read.GetString(0);
                read.Close();
                queryString = string.Format("Select ClientID from accounts where AccountNumber = {0};", destinationAccountNumber);
                command = new MySqlCommand(queryString, connection);
                read = command.ExecuteReader();
                if (read.Read())
                {
                    read.Close();
                    return true;
                }
                else
                {
                    read.Close();
                    System.Windows.MessageBox.Show("Destination account number is invalid");
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert(' The destination account is invalid ');", true);
                    Response.Redirect("ClientFrame.html");
                    return false;
                }

            }
            else
            {
                read.Close();
                System.Windows.MessageBox.Show("Source account number is invalid");
                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert(' The source account is invalid ');", true);
                Response.Redirect("ClientFrame.html");

                return false;
            }
        }

        protected bool isSourceAccountNumbreIsOwnedByClient() {
            return sourceAcoounrClientID == client_ID;
        }

        protected bool sourceAccountHasSufficentBalance(string sourceAccountNumber)
        {
            string queryString = string.Format("Select Balance from accounts where AccountNumber = {0};", sourceAccountNumber);
            MySqlCommand command = new MySqlCommand(queryString, connection);
            MySqlDataReader read = command.ExecuteReader();
            if(read.Read())
            {
                balance = read.GetFloat(0);
                read.Close();
                amount =float.Parse(req.Request["AmountTM"]);
                amount= convertToEGP(amount);
                if (float.IsNaN(amount))
                {
                    System.Windows.MessageBox.Show("Please choose a valid currency");
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert(' please choose a valid currency ');", true);
                    //MessageBox.Show();
                    Response.Redirect("ClientFrame.html");

                    return false;
                }
                else
                {

                    if (balance >= amount)
                    {
                        return true;
                    }
                    else {
                        System.Windows.MessageBox.Show("Source account number doesn't have the necessary balance");
                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert(' unsuffient balance ');", true);
                        Response.Redirect("ClientFrame.html");
                        return false;

                    }
                }
               
            }
            read.Close();
            return false;
        }
        protected float convertToEGP(float amount)
        {
            string currency = req.Request["CurrencyTM"];
            //string alert = string.Format("alert(' {0}');", currency);
            switch (currency) {
                case "EGP":
                    return amount;
                    
                /*case "EUR":
                    return amount * 18.0f;*/
                    
                case "USD":
                    return amount * 15.0f;
                    
                case "":
                    return float.NaN;
            }
            return 0.0f;
        }
        protected bool amountShouldOnlyBeUnderTwentyThousand(float amount) 
        {
            //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert(' The amount exceeds the allowed limit of 20,000 EGP ');", true);
            return amount < 20000.0f;
        }
        protected void addTransfer(string sourceAccountNumber, string destinationAccountNumber) {
            
            string queryString;
            MySqlCommand command;
            
            Random rand = new Random();
            string currency = req.Request["CurrencyTM"];
            queryString = "INSERT INTO transfer(TransferID, Currency, Amount, DestinationAccount, SourceAccount) VALUES (@ID,@CURRENCY,@AMOUNT,@DESTINATION,@SOURCE)";
            command = new MySqlCommand(queryString, connection);
            command.Parameters.Add("@ID", MySqlDbType.Int32);
            command.Parameters.Add("@CURRENCY", MySqlDbType.VarChar,10);
            command.Parameters.Add("@AMOUNT", MySqlDbType.Float);
            command.Parameters.Add("@DESTINATION", MySqlDbType.Int32);
            command.Parameters.Add("@SOURCE", MySqlDbType.Int32);
            
            command.Parameters["@ID"].Value = rand.Next(9000);
            command.Parameters["@CURRENCY"].Value = currency;
            command.Parameters["@AMOUNT"].Value = int.Parse(AmountTM.Text);
            command.Parameters["@SOURCE"].Value = sourceAccountNumber;
            command.Parameters["@DESTINATION"].Value = destinationAccountNumber;

            command.ExecuteNonQuery();

            updateSourceAccount(sourceAccountNumber);
            updateDestinationAccount(destinationAccountNumber);
            
            //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Money is transfered successfully');window.location='ClientFrame.html';", true);
            System.Windows.MessageBox.Show("Money is successfully transferred");
            //Response.Redirect("ClientFrame.html");
            Response.Redirect("ClientFrame.html");



            //command.ExecuteNonQuery();

        }
        protected void updateSourceAccount (string sourceAccountNumber)
        {
            balance = subAmountFromBalance();
            string queryString = string.Format("UPDATE accounts SET Balance = {0} WHERE AccountNumber = {1};", balance, sourceAccountNumber);
            MySqlCommand command = new MySqlCommand(queryString, connection);
            command.ExecuteNonQuery();
        }
        protected void updateDestinationAccount(string destinationAccountNumber)
        {
            string queryString = string.Format("Select Balance from accounts where AccountNumber = {0}; ", destinationAccountNumber);
            MySqlCommand command = new MySqlCommand(queryString, connection);
            MySqlDataReader read = command.ExecuteReader();
            if (read.Read())
            {
                balance = read.GetFloat(0);
                read.Close();
                queryString = string.Format("UPDATE accounts SET Balance = {0} WHERE AccountNumber = {1};", balance + amount, destinationAccountNumber);
                command = new MySqlCommand(queryString, connection);
                command.ExecuteNonQuery();
            }
        }
        protected float subAmountFromBalance() {
            return balance - amount;
        }


    }
}