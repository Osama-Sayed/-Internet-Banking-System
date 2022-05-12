using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
namespace IBS_Website
{
    public partial class TransferMoney : System.Web.UI.Page
    {
        HttpContext req;
        float amount, balance;
        static string databaseName = "internet_banking_system";
        static string connstring = string.Format("Server=10.145.1.6; persistsecurityinfo=True ;database={0}; UID=user;password=123456; SslMode = none", databaseName);
        MySqlConnection connection = new MySqlConnection(connstring);
        string client_ID = "1";
        string sourceAcoounrClientID;
        protected void Page_Load(object sender, EventArgs e)
        {
            try {
                connection.Open();
            }
            catch (Exception ex) {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert(' Server is not responding please check your connections ');", true);
                

            }

        }


        protected void TransferBtn_Click(object sender, EventArgs e)
        {
            req = HttpContext.Current;
            string sourceAccountNum = req.Request["SourceTM"];
            string destinationAccountNum = req.Request["DestinationTM"];
            if (sourceAccountNum == destinationAccountNum) {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Source Account number and destination account number are the same');", true);
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
                                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert(' The amount exceeds the allowed limit of 20,000 EGP ');", true);
                            }
                        }
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
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert(' The destination account is invalid ');", true);
                    return false;
                }

            }
            else
            {
                read.Close();
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert(' The source account is invalid ');", true);
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
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert(' please choose a valid currency ');", true);
                    return false;
                }
                else
                {

                    if (balance >= amount)
                    {
                        return true;
                    }
                    else {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert(' unsuffient balance ');", true);
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
            string alert = string.Format("alert(' {0}');", currency);
            switch (currency) {
                case "EGP":
                    return amount;
                    
                case "EUR":
                    return amount * 18.0f;
                    
                case "USD":
                    return amount * 20.0f;
                    
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
            balance = subAmountFromBalance();
            string queryString = string.Format("UPDATE accounts SET Balance = {0} WHERE AccountNumber = {1};", balance,sourceAccountNumber);
            MySqlCommand command = new MySqlCommand(queryString, connection);
            command.ExecuteNonQuery();
            queryString = string.Format("Select Balance from accounts where AccountNumber = {0}; ", destinationAccountNumber);
            command = new MySqlCommand(queryString, connection);
            MySqlDataReader read = command.ExecuteReader();
            if(read.Read())
            {
                balance = read.GetFloat(0);
                read.Close();
                queryString = string.Format("UPDATE accounts SET Balance = {0} WHERE AccountNumber = {1};", balance+amount, destinationAccountNumber);
                command = new MySqlCommand(queryString, connection);
                command.ExecuteNonQuery();
            }
            Random rand = new Random();
            string currency = req.Request["CurrencyTM"];
            queryString = "INSERT INTO transfer(TransferID, Currency, Amount, DestinationAccountNumber, SourceAccountNumber) VALUES (@ID,@CURRENCY,@AMOUNT,@DESTINATION,@SOURCE)";
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

            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Transfered successfully');", true);

            //command.ExecuteNonQuery();
            connection.Close();
        }
        protected float subAmountFromBalance() {
            return balance - amount;
        }


    }
}