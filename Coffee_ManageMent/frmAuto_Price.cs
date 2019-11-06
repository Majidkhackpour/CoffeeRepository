using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee_ManageMent
{
    public partial class frmAuto_Price : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string op;
        public void Form_Load()
        {
            rbtnAll.Checked = true;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Rounded_Number FROM tbl_Setting", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtRound.Text = dt.Rows[0].ItemArray[0].ToString();
            }
            catch
            {
                txtRound.Text = "0";
            }
        }
        public frmAuto_Price()
        {
            InitializeComponent();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAuto_Price_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            clsFunction.Timer_Dispaly(lblHour, lblMin, lblSec);
        }

        private void rbtnAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnAll.Checked)
                grpProduct2.Enabled = false;
            else if (rbtnSelect.Checked)
                grpProduct2.Enabled = true;
        }

        private void rbtnSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnAll.Checked)
                grpProduct2.Enabled = false;
            else if (rbtnSelect.Checked)
                grpProduct2.Enabled = true;
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (rbtnAll.Checked)
            {
                if (op == "Buy")
                {
                    if (rbtnPercent.Checked)
                    {
                        SqlDataAdapter da = new SqlDataAdapter("SELECT P_Code, Buy_Price FROM tbl_Price_List WHERE Pattern_Code='" + lblPattern_Code.Text + "'", dataconnection);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        int Percent = Convert.ToInt32(txtDigit.Text);
                        string query, query2;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            try
                            {
                                Int64 Cost = Convert.ToInt32(dt.Rows[i].ItemArray[1]) + ((Convert.ToInt32(dt.Rows[i].ItemArray[1]) * Percent) / 100);
                                if (Convert.ToInt32(txtRound.Text) == 0)
                                {
                                }
                                else if (Convert.ToInt32(txtRound.Text) == 1)
                                {
                                    Cost = Cost / 10;
                                    decimal Round = (decimal)Cost;
                                    Cost = Convert.ToInt64(System.Math.Round(Round));
                                    Cost = Cost * 10;
                                }
                                else if (Convert.ToInt32(txtRound.Text) == 2)
                                {
                                    Cost = Cost / 100;
                                    decimal Round = (decimal)Cost;
                                    Cost = Convert.ToInt64(System.Math.Round(Round));
                                    Cost = Cost * 100;
                                }
                                else if (Convert.ToInt32(txtRound.Text) == 3)
                                {
                                    Cost = Cost / 1000;
                                    decimal Round = (decimal)Cost;
                                    Cost = Convert.ToInt64(System.Math.Round(Round));
                                    Cost = Cost * 1000;
                                }
                                else if (Convert.ToInt32(txtRound.Text) == 4)
                                {
                                    Cost = Cost / 10000;
                                    decimal Round = (decimal)Cost;
                                    Cost = Convert.ToInt64(System.Math.Round(Round));
                                    Cost = Cost * 10000;
                                }
                                query = "UPDATE tbl_Price_List SET Buy_Price = '" + Cost + "' WHERE P_Code = '" + Convert.ToInt32(dt.Rows[i].ItemArray[0]) + "' AND Pattern_Code = '" + lblPattern_Code.Text + "'";
                                query2 = "UPDATE tbl_Product SET Buy_Price = '" + Cost + "' WHERE P_Code = '" + Convert.ToInt32(dt.Rows[i].ItemArray[0]) + "'";
                                if (clsFunction.Execute(dataconnection, query) == true && clsFunction.Execute(dataconnection, query2) == true)
                                {
                                }
                            }
                            catch
                            {
                            }
                        }
                    }
                    else if (rbtnPrice.Checked)
                    {
                        SqlDataAdapter da = new SqlDataAdapter("SELECT P_Code, Buy_Price FROM tbl_Price_List WHERE Pattern_Code='" + lblPattern_Code.Text + "'", dataconnection);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        int Percent = Convert.ToInt32(txtDigit.Text);
                        string query, query2;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            try
                            {
                                Int64 Cost = Convert.ToInt32(dt.Rows[i].ItemArray[1]) + Percent;
                                if (Convert.ToInt32(txtRound.Text) == 1)
                                {
                                    Cost = Cost / 10;
                                    decimal Round = (decimal)Cost;
                                    Cost = Convert.ToInt64(System.Math.Round(Round));
                                    Cost = Cost * 10;
                                }
                                else if (Convert.ToInt32(txtRound.Text) == 2)
                                {
                                    Cost = Cost / 100;
                                    decimal Round = (decimal)Cost;
                                    Cost = Convert.ToInt64(System.Math.Round(Round));
                                    Cost = Cost * 100;
                                }
                                else if (Convert.ToInt32(txtRound.Text) == 3)
                                {
                                    Cost = Cost / 1000;
                                    decimal Round = (decimal)Cost;
                                    Cost = Convert.ToInt64(System.Math.Round(Round));
                                    Cost = Cost * 1000;
                                }
                                else if (Convert.ToInt32(txtRound.Text) == 4)
                                {
                                    Cost = Cost / 10000;
                                    decimal Round = (decimal)Cost;
                                    Cost = Convert.ToInt64(System.Math.Round(Round));
                                    Cost = Cost * 10000;
                                }
                                query = "UPDATE tbl_Price_List SET Buy_Price = '" + Cost + "' WHERE P_Code = '" + Convert.ToInt32(dt.Rows[i].ItemArray[0]) + "' AND Pattern_Code = '" + lblPattern_Code.Text + "'";
                                query2 = "UPDATE tbl_Product SET Buy_Price = '" + Cost + "' WHERE P_Code = '" + Convert.ToInt32(dt.Rows[i].ItemArray[0]) + "'";
                                if (clsFunction.Execute(dataconnection, query) == true && clsFunction.Execute(dataconnection, query2) == true)
                                {
                                }
                            }
                            catch
                            {
                            }
                        }
                    }
                }
                else if (op == "Sell")
                {
                    if (rbtnPercent.Checked)
                    {
                        if (rbtnPrice_Now.Checked)
                        {
                            SqlDataAdapter da = new SqlDataAdapter("SELECT P_Code, Sell_Price FROM tbl_Price_List WHERE Pattern_Code='" + lblPattern_Code.Text + "'", dataconnection);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            int Percent = Convert.ToInt32(txtDigit.Text);
                            string query, query2;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                try
                                {
                                    Int64 Cost = Convert.ToInt32(dt.Rows[i].ItemArray[1]) + ((Convert.ToInt32(dt.Rows[i].ItemArray[1]) * Percent) / 100);
                                    if (Convert.ToInt32(txtRound.Text) == 0)
                                    {
                                    }
                                    else if (Convert.ToInt32(txtRound.Text) == 1)
                                    {
                                        Cost = Cost / 10;
                                        decimal Round = (decimal)Cost;
                                        Cost = Convert.ToInt64(System.Math.Round(Round));
                                        Cost = Cost * 10;
                                    }
                                    else if (Convert.ToInt32(txtRound.Text) == 2)
                                    {
                                        Cost = Cost / 100;
                                        decimal Round = (decimal)Cost;
                                        Cost = Convert.ToInt64(System.Math.Round(Round));
                                        Cost = Cost * 100;
                                    }
                                    else if (Convert.ToInt32(txtRound.Text) == 3)
                                    {
                                        Cost = Cost / 1000;
                                        decimal Round = (decimal)Cost;
                                        Cost = Convert.ToInt64(System.Math.Round(Round));
                                        Cost = Cost * 1000;
                                    }
                                    else if (Convert.ToInt32(txtRound.Text) == 4)
                                    {
                                        Cost = Cost / 10000;
                                        decimal Round = (decimal)Cost;
                                        Cost = Convert.ToInt64(System.Math.Round(Round));
                                        Cost = Cost * 10000;
                                    }
                                    query = "UPDATE tbl_Price_List SET Sell_Price = '" + Cost + "' WHERE P_Code = '" + Convert.ToInt32(dt.Rows[i].ItemArray[0]) + "' AND Pattern_Code = '" + lblPattern_Code.Text + "'";
                                    query2 = "UPDATE tbl_Product SET Sell_Price = '" + Cost + "' WHERE P_Code = '" + Convert.ToInt32(dt.Rows[i].ItemArray[0]) + "'";
                                    if (clsFunction.Execute(dataconnection, query) == true && clsFunction.Execute(dataconnection, query2) == true)
                                    {
                                    }
                                }
                                catch
                                {
                                }
                            }
                        }
                        else if (rbtnBuy_Price.Checked)
                        {
                            SqlDataAdapter da = new SqlDataAdapter("SELECT P_Code, Buy_Price FROM tbl_Product", dataconnection);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            int Percent = Convert.ToInt32(txtDigit.Text);
                            string query, query2;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                try
                                {
                                    Int64 Cost = Convert.ToInt32(dt.Rows[i].ItemArray[1]) + ((Convert.ToInt32(dt.Rows[i].ItemArray[1]) * Percent) / 100);
                                    if (Convert.ToInt32(txtRound.Text) == 0)
                                    {
                                    }
                                    else if (Convert.ToInt32(txtRound.Text) == 1)
                                    {
                                        Cost = Cost / 10;
                                        decimal Round = (decimal)Cost;
                                        Cost = Convert.ToInt64(System.Math.Round(Round));
                                        Cost = Cost * 10;
                                    }
                                    else if (Convert.ToInt32(txtRound.Text) == 2)
                                    {
                                        Cost = Cost / 100;
                                        decimal Round = (decimal)Cost;
                                        Cost = Convert.ToInt64(System.Math.Round(Round));
                                        Cost = Cost * 100;
                                    }
                                    else if (Convert.ToInt32(txtRound.Text) == 3)
                                    {
                                        Cost = Cost / 1000;
                                        decimal Round = (decimal)Cost;
                                        Cost = Convert.ToInt64(System.Math.Round(Round));
                                        Cost = Cost * 1000;
                                    }
                                    else if (Convert.ToInt32(txtRound.Text) == 4)
                                    {
                                        Cost = Cost / 10000;
                                        decimal Round = (decimal)Cost;
                                        Cost = Convert.ToInt64(System.Math.Round(Round));
                                        Cost = Cost * 10000;
                                    }
                                    query = "UPDATE tbl_Price_List SET Sell_Price = '" + Cost + "' WHERE P_Code = '" + Convert.ToInt32(dt.Rows[i].ItemArray[0]) + "' AND Pattern_Code = '" + lblPattern_Code.Text + "'";
                                    query2 = "UPDATE tbl_Product SET Sell_Price = '" + Cost + "' WHERE P_Code = '" + Convert.ToInt32(dt.Rows[i].ItemArray[0]) + "'";
                                    if (clsFunction.Execute(dataconnection, query) == true && clsFunction.Execute(dataconnection, query2) == true)
                                    {
                                    }
                                }
                                catch
                                {
                                }
                            }
                        }
                    }
                    else if (rbtnPrice.Checked)
                    {
                        if (rbtnPrice_Now.Checked)
                        {
                            SqlDataAdapter da = new SqlDataAdapter("SELECT P_Code, Sell_Price FROM tbl_Price_List WHERE Pattern_Code='" + lblPattern_Code.Text + "'", dataconnection);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            int Percent = Convert.ToInt32(txtDigit.Text);
                            string query, query2;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                try
                                {
                                    Int64 Cost = Convert.ToInt32(dt.Rows[i].ItemArray[1]) + Percent;
                                    if (Convert.ToInt32(txtRound.Text) == 1)
                                    {
                                        Cost = Cost / 10;
                                        decimal Round = (decimal)Cost;
                                        Cost = Convert.ToInt64(System.Math.Round(Round));
                                        Cost = Cost * 10;
                                    }
                                    else if (Convert.ToInt32(txtRound.Text) == 2)
                                    {
                                        Cost = Cost / 100;
                                        decimal Round = (decimal)Cost;
                                        Cost = Convert.ToInt64(System.Math.Round(Round));
                                        Cost = Cost * 100;
                                    }
                                    else if (Convert.ToInt32(txtRound.Text) == 3)
                                    {
                                        Cost = Cost / 1000;
                                        decimal Round = (decimal)Cost;
                                        Cost = Convert.ToInt64(System.Math.Round(Round));
                                        Cost = Cost * 1000;
                                    }
                                    else if (Convert.ToInt32(txtRound.Text) == 4)
                                    {
                                        Cost = Cost / 10000;
                                        decimal Round = (decimal)Cost;
                                        Cost = Convert.ToInt64(System.Math.Round(Round));
                                        Cost = Cost * 10000;
                                    }
                                    query = "UPDATE tbl_Price_List SET Sell_Price = '" + Cost + "' WHERE P_Code = '" + Convert.ToInt32(dt.Rows[i].ItemArray[0]) + "' AND Pattern_Code = '" + lblPattern_Code.Text + "'";
                                    query2 = "UPDATE tbl_Product SET Sell_Price = '" + Cost + "' WHERE P_Code = '" + Convert.ToInt32(dt.Rows[i].ItemArray[0]) + "'";
                                    if (clsFunction.Execute(dataconnection, query) == true && clsFunction.Execute(dataconnection, query2) == true)
                                    {
                                    }
                                }
                                catch
                                {
                                }
                            }
                        }
                        else if (rbtnBuy_Price.Checked)
                        {
                            SqlDataAdapter da = new SqlDataAdapter("SELECT P_Code, Buy_Price FROM tbl_Product", dataconnection);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            int Percent = Convert.ToInt32(txtDigit.Text);
                            string query, query2;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                try
                                {
                                    Int64 Cost = Convert.ToInt32(dt.Rows[i].ItemArray[1]) + Percent;
                                    if (Convert.ToInt32(txtRound.Text) == 0)
                                    {
                                    }
                                    else if (Convert.ToInt32(txtRound.Text) == 1)
                                    {
                                        Cost = Cost / 10;
                                        decimal Round = (decimal)Cost;
                                        Cost = Convert.ToInt64(System.Math.Round(Round));
                                        Cost = Cost * 10;
                                    }
                                    else if (Convert.ToInt32(txtRound.Text) == 2)
                                    {
                                        Cost = Cost / 100;
                                        decimal Round = (decimal)Cost;
                                        Cost = Convert.ToInt64(System.Math.Round(Round));
                                        Cost = Cost * 100;
                                    }
                                    else if (Convert.ToInt32(txtRound.Text) == 3)
                                    {
                                        Cost = Cost / 1000;
                                        decimal Round = (decimal)Cost;
                                        Cost = Convert.ToInt64(System.Math.Round(Round));
                                        Cost = Cost * 1000;
                                    }
                                    else if (Convert.ToInt32(txtRound.Text) == 4)
                                    {
                                        Cost = Cost / 10000;
                                        decimal Round = (decimal)Cost;
                                        Cost = Convert.ToInt64(System.Math.Round(Round));
                                        Cost = Cost * 10000;
                                    }
                                    query = "UPDATE tbl_Price_List SET Sell_Price = '" + Cost + "' WHERE P_Code = '" + Convert.ToInt32(dt.Rows[i].ItemArray[0]) + "' AND Pattern_Code = '" + lblPattern_Code.Text + "'";
                                    query2 = "UPDATE tbl_Product SET Sell_Price = '" + Cost + "' WHERE P_Code = '" + Convert.ToInt32(dt.Rows[i].ItemArray[0]) + "'";
                                    if (clsFunction.Execute(dataconnection, query) == true && clsFunction.Execute(dataconnection, query2) == true)
                                    {
                                    }
                                }
                                catch
                                {
                                }
                            }
                        }
                    }
                }
                string query3;
                SqlDataAdapter da2 = new SqlDataAdapter("SELECT Count (ID) FROM tbl_Setting", dataconnection);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                if (Convert.ToInt32(dt2.Rows[0].ItemArray[0]) <= 0)
                {
                    query3 = "INSERT INTO tbl_Setting (Rounded_Number) VALUES ('" + Convert.ToInt32(txtRound.Text) + "')";
                    clsFunction.Execute(dataconnection, query3);
                }
                else
                {
                    query3 = "UPDATE tbl_Setting SET Rounded_Number='" + Convert.ToInt32(txtRound.Text) + "' WHERE ID=1";
                    clsFunction.Execute(dataconnection, query3);
                }
                this.Close();
            }
            else if (rbtnSelect.Checked)
            {
                if (clsFunction.Error_Provider(txtName1, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtName2, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
                {
                }
                else
                {
                    if (op == "Buy")
                    {
                        if (rbtnPercent.Checked)
                        {
                            SqlDataAdapter da = new SqlDataAdapter("SELECT P_Code, Buy_Price FROM tbl_Price_List WHERE P_Code>='" + Convert.ToInt32(txtCode1.Text) + "' AND P_Code<='" + Convert.ToInt32(txtCode2.Text) + "' AND Pattern_Code='" + lblPattern_Code.Text + "'", dataconnection);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            int Percent = Convert.ToInt32(txtDigit.Text);
                            string query, query2;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                try
                                {
                                    Int64 Cost = Convert.ToInt32(dt.Rows[i].ItemArray[1]) + ((Convert.ToInt32(dt.Rows[i].ItemArray[1]) * Percent) / 100);
                                    if (Convert.ToInt32(txtRound.Text) == 0)
                                    {
                                    }
                                    else if (Convert.ToInt32(txtRound.Text) == 1)
                                    {
                                        Cost = Cost / 10;
                                        decimal Round = (decimal)Cost;
                                        Cost = Convert.ToInt64(System.Math.Round(Round));
                                        Cost = Cost * 10;
                                    }
                                    else if (Convert.ToInt32(txtRound.Text) == 2)
                                    {
                                        Cost = Cost / 100;
                                        decimal Round = (decimal)Cost;
                                        Cost = Convert.ToInt64(System.Math.Round(Round));
                                        Cost = Cost * 100;
                                    }
                                    else if (Convert.ToInt32(txtRound.Text) == 3)
                                    {
                                        Cost = Cost / 1000;
                                        decimal Round = (decimal)Cost;
                                        Cost = Convert.ToInt64(System.Math.Round(Round));
                                        Cost = Cost * 1000;
                                    }
                                    else if (Convert.ToInt32(txtRound.Text) == 4)
                                    {
                                        Cost = Cost / 10000;
                                        decimal Round = (decimal)Cost;
                                        Cost = Convert.ToInt64(System.Math.Round(Round));
                                        Cost = Cost * 10000;
                                    }
                                    query = "UPDATE tbl_Price_List SET Buy_Price = '" + Cost + "' WHERE P_Code = '" + Convert.ToInt32(dt.Rows[i].ItemArray[0]) + "' AND Pattern_Code = '" + lblPattern_Code.Text + "'";
                                    query2 = "UPDATE tbl_Product SET Buy_Price = '" + Cost + "' WHERE P_Code = '" + Convert.ToInt32(dt.Rows[i].ItemArray[0]) + "'";
                                    if (clsFunction.Execute(dataconnection, query) == true && clsFunction.Execute(dataconnection, query2) == true)
                                    {
                                    }
                                }
                                catch
                                {
                                }
                            }
                        }
                        else if (rbtnPrice.Checked)
                        {
                            SqlDataAdapter da = new SqlDataAdapter("SELECT P_Code, Buy_Price FROM tbl_Price_List WHERE P_Code>='" + Convert.ToInt32(txtCode1.Text) + "' AND P_Code<='" + Convert.ToInt32(txtCode2.Text) + "' AND Pattern_Code='" + lblPattern_Code.Text + "'", dataconnection);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            int Percent = Convert.ToInt32(txtDigit.Text);
                            string query, query2;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                try
                                {
                                    Int64 Cost = Convert.ToInt32(dt.Rows[i].ItemArray[1]) + Percent;
                                    if (Convert.ToInt32(txtRound.Text) == 1)
                                    {
                                        Cost = Cost / 10;
                                        decimal Round = (decimal)Cost;
                                        Cost = Convert.ToInt64(System.Math.Round(Round));
                                        Cost = Cost * 10;
                                    }
                                    else if (Convert.ToInt32(txtRound.Text) == 2)
                                    {
                                        Cost = Cost / 100;
                                        decimal Round = (decimal)Cost;
                                        Cost = Convert.ToInt64(System.Math.Round(Round));
                                        Cost = Cost * 100;
                                    }
                                    else if (Convert.ToInt32(txtRound.Text) == 3)
                                    {
                                        Cost = Cost / 1000;
                                        decimal Round = (decimal)Cost;
                                        Cost = Convert.ToInt64(System.Math.Round(Round));
                                        Cost = Cost * 1000;
                                    }
                                    else if (Convert.ToInt32(txtRound.Text) == 4)
                                    {
                                        Cost = Cost / 10000;
                                        decimal Round = (decimal)Cost;
                                        Cost = Convert.ToInt64(System.Math.Round(Round));
                                        Cost = Cost * 10000;
                                    }
                                    query = "UPDATE tbl_Price_List SET Buy_Price = '" + Cost + "' WHERE P_Code = '" + Convert.ToInt32(dt.Rows[i].ItemArray[0]) + "' AND Pattern_Code = '" + lblPattern_Code.Text + "'";
                                    query2 = "UPDATE tbl_Product SET Buy_Price = '" + Cost + "' WHERE P_Code = '" + Convert.ToInt32(dt.Rows[i].ItemArray[0]) + "'";
                                    if (clsFunction.Execute(dataconnection, query) == true && clsFunction.Execute(dataconnection, query2) == true)
                                    {
                                    }
                                }
                                catch
                                {
                                }
                            }
                        }
                    }
                    else if (op == "Sell")
                    {
                        if (rbtnPercent.Checked)
                        {
                            if (rbtnPrice_Now.Checked)
                            {
                                SqlDataAdapter da = new SqlDataAdapter("SELECT P_Code, Sell_Price FROM tbl_Price_List WHERE P_Code>='" + Convert.ToInt32(txtCode1.Text) + "' AND P_Code<='" + Convert.ToInt32(txtCode2.Text) + "' AND Pattern_Code='" + lblPattern_Code.Text + "'", dataconnection);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                int Percent = Convert.ToInt32(txtDigit.Text);
                                string query, query2;
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    try
                                    {
                                        Int64 Cost = Convert.ToInt32(dt.Rows[i].ItemArray[1]) + ((Convert.ToInt32(dt.Rows[i].ItemArray[1]) * Percent) / 100);
                                        if (Convert.ToInt32(txtRound.Text) == 0)
                                        {
                                        }
                                        else if (Convert.ToInt32(txtRound.Text) == 1)
                                        {
                                            Cost = Cost / 10;
                                            decimal Round = (decimal)Cost;
                                            Cost = Convert.ToInt64(System.Math.Round(Round));
                                            Cost = Cost * 10;
                                        }
                                        else if (Convert.ToInt32(txtRound.Text) == 2)
                                        {
                                            Cost = Cost / 100;
                                            decimal Round = (decimal)Cost;
                                            Cost = Convert.ToInt64(System.Math.Round(Round));
                                            Cost = Cost * 100;
                                        }
                                        else if (Convert.ToInt32(txtRound.Text) == 3)
                                        {
                                            Cost = Cost / 1000;
                                            decimal Round = (decimal)Cost;
                                            Cost = Convert.ToInt64(System.Math.Round(Round));
                                            Cost = Cost * 1000;
                                        }
                                        else if (Convert.ToInt32(txtRound.Text) == 4)
                                        {
                                            Cost = Cost / 10000;
                                            decimal Round = (decimal)Cost;
                                            Cost = Convert.ToInt64(System.Math.Round(Round));
                                            Cost = Cost * 10000;
                                        }
                                        query = "UPDATE tbl_Price_List SET Sell_Price = '" + Cost + "' WHERE P_Code = '" + Convert.ToInt32(dt.Rows[i].ItemArray[0]) + "' AND Pattern_Code = '" + lblPattern_Code.Text + "'";
                                        query2 = "UPDATE tbl_Product SET Sell_Price = '" + Cost + "' WHERE P_Code = '" + Convert.ToInt32(dt.Rows[i].ItemArray[0]) + "'";
                                        if (clsFunction.Execute(dataconnection, query) == true && clsFunction.Execute(dataconnection, query2) == true)
                                        {
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                            else if (rbtnBuy_Price.Checked)
                            {
                                SqlDataAdapter da = new SqlDataAdapter("SELECT P_Code, Buy_Price FROM tbl_Product WHERE P_Code>='" + Convert.ToInt32(txtCode1.Text) + "' AND P_Code<='" + Convert.ToInt32(txtCode2.Text) + "' AND Pattern_Code='" + lblPattern_Code.Text + "'", dataconnection);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                int Percent = Convert.ToInt32(txtDigit.Text);
                                string query, query2;
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    try
                                    {
                                        Int64 Cost = Convert.ToInt32(dt.Rows[i].ItemArray[1]) + ((Convert.ToInt32(dt.Rows[i].ItemArray[1]) * Percent) / 100);
                                        if (Convert.ToInt32(txtRound.Text) == 0)
                                        {
                                        }
                                        else if (Convert.ToInt32(txtRound.Text) == 1)
                                        {
                                            Cost = Cost / 10;
                                            decimal Round = (decimal)Cost;
                                            Cost = Convert.ToInt64(System.Math.Round(Round));
                                            Cost = Cost * 10;
                                        }
                                        else if (Convert.ToInt32(txtRound.Text) == 2)
                                        {
                                            Cost = Cost / 100;
                                            decimal Round = (decimal)Cost;
                                            Cost = Convert.ToInt64(System.Math.Round(Round));
                                            Cost = Cost * 100;
                                        }
                                        else if (Convert.ToInt32(txtRound.Text) == 3)
                                        {
                                            Cost = Cost / 1000;
                                            decimal Round = (decimal)Cost;
                                            Cost = Convert.ToInt64(System.Math.Round(Round));
                                            Cost = Cost * 1000;
                                        }
                                        else if (Convert.ToInt32(txtRound.Text) == 4)
                                        {
                                            Cost = Cost / 10000;
                                            decimal Round = (decimal)Cost;
                                            Cost = Convert.ToInt64(System.Math.Round(Round));
                                            Cost = Cost * 10000;
                                        }
                                        query = "UPDATE tbl_Price_List SET Sell_Price = '" + Cost + "' WHERE P_Code = '" + Convert.ToInt32(dt.Rows[i].ItemArray[0]) + "' AND Pattern_Code = '" + lblPattern_Code.Text + "'";
                                        query2 = "UPDATE tbl_Product SET Sell_Price = '" + Cost + "' WHERE P_Code = '" + Convert.ToInt32(dt.Rows[i].ItemArray[0]) + "'";
                                        if (clsFunction.Execute(dataconnection, query) == true && clsFunction.Execute(dataconnection, query2) == true)
                                        {
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                        }
                        else if (rbtnPrice.Checked)
                        {
                            if (rbtnPrice_Now.Checked)
                            {
                                SqlDataAdapter da = new SqlDataAdapter("SELECT P_Code, Sell_Price FROM tbl_Price_List WHERE P_Code>='" + Convert.ToInt32(txtCode1.Text) + "' AND P_Code<='" + Convert.ToInt32(txtCode2.Text) + "' AND Pattern_Code='" + lblPattern_Code.Text + "'", dataconnection);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                int Percent = Convert.ToInt32(txtDigit.Text);
                                string query, query2;
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    try
                                    {
                                        Int64 Cost = Convert.ToInt32(dt.Rows[i].ItemArray[1]) + Percent;
                                        if (Convert.ToInt32(txtRound.Text) == 0)
                                        {
                                        }
                                        else if (Convert.ToInt32(txtRound.Text) == 1)
                                        {
                                            Cost = Cost / 10;
                                            decimal Round = (decimal)Cost;
                                            Cost = Convert.ToInt64(System.Math.Round(Round));
                                            Cost = Cost * 10;
                                        }
                                        else if (Convert.ToInt32(txtRound.Text) == 2)
                                        {
                                            Cost = Cost / 100;
                                            decimal Round = (decimal)Cost;
                                            Cost = Convert.ToInt64(System.Math.Round(Round));
                                            Cost = Cost * 100;
                                        }
                                        else if (Convert.ToInt32(txtRound.Text) == 3)
                                        {
                                            Cost = Cost / 1000;
                                            decimal Round = (decimal)Cost;
                                            Cost = Convert.ToInt64(System.Math.Round(Round));
                                            Cost = Cost * 1000;
                                        }
                                        else if (Convert.ToInt32(txtRound.Text) == 4)
                                        {
                                            Cost = Cost / 10000;
                                            decimal Round = (decimal)Cost;
                                            Cost = Convert.ToInt64(System.Math.Round(Round));
                                            Cost = Cost * 10000;
                                        }
                                        query = "UPDATE tbl_Price_List SET Sell_Price = '" + Cost + "' WHERE P_Code = '" + Convert.ToInt32(dt.Rows[i].ItemArray[0]) + "' AND Pattern_Code = '" + lblPattern_Code.Text + "'";
                                        query2 = "UPDATE tbl_Product SET Sell_Price = '" + Cost + "' WHERE P_Code = '" + Convert.ToInt32(dt.Rows[i].ItemArray[0]) + "'";
                                        if (clsFunction.Execute(dataconnection, query) == true && clsFunction.Execute(dataconnection, query2) == true)
                                        {
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                            else if (rbtnBuy_Price.Checked)
                            {
                                SqlDataAdapter da = new SqlDataAdapter("SELECT P_Code, Buy_Price FROM tbl_Product WHERE P_Code>='" + Convert.ToInt32(txtCode1.Text) + "' AND P_Code<='" + Convert.ToInt32(txtCode2.Text) + "' AND Pattern_Code='" + lblPattern_Code.Text + "'", dataconnection);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                int Percent = Convert.ToInt32(txtDigit.Text);
                                string query, query2;
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    try
                                    {
                                        Int64 Cost = Convert.ToInt32(dt.Rows[i].ItemArray[1]) + Percent;
                                        if (Convert.ToInt32(txtRound.Text) == 0)
                                        {
                                        }
                                        else if (Convert.ToInt32(txtRound.Text) == 1)
                                        {
                                            Cost = Cost / 10;
                                            decimal Round = (decimal)Cost;
                                            Cost = Convert.ToInt64(System.Math.Round(Round));
                                            Cost = Cost * 10;
                                        }
                                        else if (Convert.ToInt32(txtRound.Text) == 2)
                                        {
                                            Cost = Cost / 100;
                                            decimal Round = (decimal)Cost;
                                            Cost = Convert.ToInt64(System.Math.Round(Round));
                                            Cost = Cost * 100;
                                        }
                                        else if (Convert.ToInt32(txtRound.Text) == 3)
                                        {
                                            Cost = Cost / 1000;
                                            decimal Round = (decimal)Cost;
                                            Cost = Convert.ToInt64(System.Math.Round(Round));
                                            Cost = Cost * 1000;
                                        }
                                        else if (Convert.ToInt32(txtRound.Text) == 4)
                                        {
                                            Cost = Cost / 10000;
                                            decimal Round = (decimal)Cost;
                                            Cost = Convert.ToInt64(System.Math.Round(Round));
                                            Cost = Cost * 10000;
                                        }
                                        query = "UPDATE tbl_Price_List SET Sell_Price = '" + Cost + "' WHERE P_Code = '" + Convert.ToInt32(dt.Rows[i].ItemArray[0]) + "' AND Pattern_Code = '" + lblPattern_Code.Text + "'";
                                        query2 = "UPDATE tbl_Product SET Sell_Price = '" + Cost + "' WHERE P_Code = '" + Convert.ToInt32(dt.Rows[i].ItemArray[0]) + "'";
                                        if (clsFunction.Execute(dataconnection, query) == true && clsFunction.Execute(dataconnection, query2) == true)
                                        {
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                        }
                    }
                    string query3;
                    SqlDataAdapter da2 = new SqlDataAdapter("SELECT Count (ID) FROM tbl_Setting", dataconnection);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    if (Convert.ToInt32(dt2.Rows[0].ItemArray[0]) <= 0)
                    {
                        query3 = "INSERT INTO tbl_Setting (Rounded_Number) VALUES ('" + Convert.ToInt32(txtRound.Text) + "')";
                        clsFunction.Execute(dataconnection, query3);
                    }
                    else
                    {
                        query3 = "UPDATE tbl_Setting SET Rounded_Number='" + Convert.ToInt32(txtRound.Text) + "' WHERE ID=1";
                        clsFunction.Execute(dataconnection, query3);
                    }
                    this.Close();
                }
            }
        }

        private void txtDigit_TextChanged(object sender, EventArgs e)
        {
            try
            {
                clsFunction.Three_Ziro(txtDigit);
                if (rbtnPercent.Checked)
                {
                    if (Convert.ToInt32(txtDigit.Text) > 100)
                    {
                        txtDigit.Text = "100";
                        txtDigit.SelectionStart = txtDigit.Text.Length;
                    }
                }
            }
            catch
            {
                txtDigit.Text = "0";
            }
        }

        private void txtCode1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT P_Show_Name FROM tbl_Product WHERE P_Code='" + Convert.ToInt32(txtCode1.Text) + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtName1.Text = dt.Rows[0].ItemArray[0].ToString();
            }
            catch
            {
                txtName1.Text = "";
            }
        }

        private void txtCode2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT P_Show_Name FROM tbl_Product WHERE P_Code='" + Convert.ToInt32(txtCode2.Text) + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtName2.Text = dt.Rows[0].ItemArray[0].ToString();
            }
            catch
            {
                txtName2.Text = "";
            }
        }

        private void btnSearchProduct1_Click(object sender, EventArgs e)
        {
            try
            {
                frmAllProduct f = new frmAllProduct();
                f.op = "All";
                f.Fill_All_Product();
                f.ShowDialog();
                txtCode1.Text = f.Product_Code;
            }
            catch
            {
                txtCode1.Text = "";
            }
        }

        private void btnSearchProduct2_Click(object sender, EventArgs e)
        {
            try
            {
                frmAllProduct f = new frmAllProduct();
                f.op = "All";
                f.Fill_All_Product();
                f.ShowDialog();
                txtCode2.Text = f.Product_Code;
            }
            catch
            {
                txtCode2.Text = "";
            }
        }

        private void txtCode1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 48 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtCode2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 48 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtDigit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtRound_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 48 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtCode1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtCode2.Focus();
        }

        private void txtCode2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtDigit.Focus();
        }

        private void txtDigit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtRound.Focus();
        }

        private void txtRound_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnFinish.Focus();
        }
    }
}
