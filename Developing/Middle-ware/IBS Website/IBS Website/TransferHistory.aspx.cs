using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;


namespace IBS_Website
{
    public partial class TransferHistory : System.Web.UI.Page
    {
        static string databaseName = "internet_banking_system";
        static string connstring = string.Format("Server=10.145.2.180; persistsecurityinfo=True ;database={0}; UID=user;password=123456; SslMode = none", databaseName);
        MySqlConnection connection = new MySqlConnection(connstring);
        protected void Page_Load(object sender, EventArgs e)
        {   
            string client_ID = Login.client_ID;
            string sqlQuery = string.Format("select AccountNumber from accounts where ClientID = {0}", client_ID);
            connection.Open();
            MySqlCommand command = new MySqlCommand(sqlQuery, connection);
            MySqlDataReader read = command.ExecuteReader();
            List<string> accountNumberList = new List<string>() ;
            while (read.Read())
            {
                accountNumberList.Add(read.GetString(0));
 
            }
            read.Close();
            foreach (string accountNumber in accountNumberList)
            {
                addToTable(accountNumber);
            }



        }

        protected void addToTable(string AccountNumber) {
            string sqlQuery = string.Format("select * from transfer where SourceAccount = {0}", AccountNumber);
            MySqlCommand command = new MySqlCommand(sqlQuery, connection);
            MySqlDataReader read = command.ExecuteReader();
            string currency, destinationAccountNumber, amount, date ;
            Label sourceLbl, destinationLbl, amountLbl, currencyLbl, dateLbl;
            
            TableCell tableCell;
            TableRow tableRow;
            while (read.Read()) {
                currency = read.GetString(1);
                amount = read.GetString(2);
                destinationAccountNumber = read.GetString(4);
                date = read.GetString(5);
                sourceLbl = new Label();
                sourceLbl.Text = AccountNumber;
                destinationLbl = new Label();
                destinationLbl.Text = destinationAccountNumber;
                amountLbl = new Label();
                amountLbl.Text = amount;
                currencyLbl = new Label();
                currencyLbl.Text = currency;
                dateLbl = new Label();
                dateLbl.Text = date;


                tableCell = new TableCell();
                tableRow = new TableRow();
                tableCell.Controls.Add(sourceLbl);
                tableRow.Cells.Add(tableCell);


                tableCell = new TableCell();
                tableCell.Controls.Add(destinationLbl);
                tableRow.Cells.Add(tableCell);

                tableCell = new TableCell();
                tableCell.Controls.Add(amountLbl);
                tableRow.Cells.Add(tableCell);

                tableCell = new TableCell();
                tableCell.Controls.Add(currencyLbl);
                tableRow.Cells.Add(tableCell);

                tableCell = new TableCell();
                tableCell.Controls.Add(dateLbl);
                tableRow.Cells.Add(tableCell);


                TransferTable.Rows.Add(tableRow);
                
            }
            read.Close();
        }
    }
}