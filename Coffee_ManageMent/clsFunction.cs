using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using TMS.Class;
using System.Text.RegularExpressions;
using Microsoft.Office.Interop.Excel;
using System.IO;
namespace Coffee_ManageMent
{
    public class clsFunction
    {
        public static string DB_Address = System.IO.File.ReadAllText(System.Windows.Forms.Application.StartupPath + "\\info.txt");
        public static string Connection_string = "Data Source=.;Initial Catalog=" + DB_Address + ";Integrated Security=True;Connect Timeout=30";
        public static string User_Real_Name;
        public static void Black(System.Windows.Forms.Label lbl)
        {
            lbl.ForeColor = Color.Black;
        }
        public static void Red(System.Windows.Forms.Label lbl)
        {
            lbl.ForeColor = Color.Red;
        }
        public static void Display(string Query, SqlConnection dataconnection, DataGridView dgv, System.Windows.Forms.Label lbl)
        {
            SqlDataAdapter da = new SqlDataAdapter(Query, dataconnection);
            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            dgv.DataSource = dt;
            lbl.Text = dgv.Rows.Count.ToString();
        }
        public static void FillComboBox(SqlConnection dataconnection, string query, ComboBox cmb, string obj)
        {
            dataconnection.Open();
            SqlCommand cmd = new SqlCommand(query, dataconnection);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    cmb.Items.Add(dr[obj]);
                }
            }
            dr.Close();
            cmd.ExecuteNonQuery();
            dataconnection.Close();
        }
        public static void lbl_NewCode(SqlConnection dataconnection, string query, System.Windows.Forms.Label lbl, string Min_Value)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(query, dataconnection);
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);
                lbl.Text = (Convert.ToInt32(dt.Rows[0].ItemArray[0]) + 1).ToString();
            }
            catch
            {
                lbl.Text = Min_Value;
            }
        }
        public static void txt_NewCode(SqlConnection dataconnection, string query, System.Windows.Forms.TextBox txt, string Min_Value)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(query, dataconnection);
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);
                txt.Text = (Convert.ToInt32(dt.Rows[0].ItemArray[0]) + 1).ToString();
            }
            catch
            {
                txt.Text = Min_Value;
            }
        }
        public static void Numeric_Up_Down_NewCode(SqlConnection dataconnection, string query, NumericUpDown txt, string Min_Value)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(query, dataconnection);
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);
                txt.Text = (Convert.ToInt32(dt.Rows[0].ItemArray[0]) + 1).ToString();
            }
            catch
            {
                txt.Text = Min_Value;
            }
        }
        public static bool Execute(SqlConnection dataconection, string query)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = dataconection;
            cmd.CommandText = query;
            try
            {
                dataconection.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                dataconection.Close();
            }
        }
        public static bool Error_Provider(System.Windows.Forms.TextBox txt, ErrorProvider ep, string Error)
        {
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                ep.Clear();
                ep.RightToLeft = true;
                ep.SetError(txt, Error);
                return true;
            }
            else
                return false;
        }
        public static bool MSK_Error_Provider(MaskedTextBox txt, ErrorProvider ep, string Error)
        {
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                ep.Clear();
                ep.RightToLeft = true;
                ep.SetError(txt, Error);
                return true;
            }
            else
                return false;
        }
        public static void Show_OtherError(System.Windows.Forms.TextBox txt, ErrorProvider ep, string Error)
        {
            ep.Clear();
            ep.RightToLeft = true;
            ep.SetError(txt, Error);
        }
        public static string M2SH(DateTime d)
        {
            PersianCalendar pc = new PersianCalendar();
            StringBuilder sb = new StringBuilder();
            sb.Append(pc.GetYear(d).ToString("0000"));
            sb.Append("/");
            sb.Append(pc.GetMonth(d).ToString("00"));
            sb.Append("/");
            sb.Append(pc.GetDayOfMonth(d).ToString("00"));
            return sb.ToString();
        }
        public static void Three_Ziro(System.Windows.Forms.TextBox txt)
        {
            txt.Text = txt.Text.Replace(".", "000");
            txt.SelectionStart = txt.Text.Length;
        }
        public static void Display_Header(System.Windows.Forms.Label lblDay, System.Windows.Forms.Label lblNewDate)
        {
            MaftooxCalendar.MaftooxPersianCalendar.DateWork PRD = new MaftooxCalendar.MaftooxPersianCalendar.DateWork();
            lblDay.Text = PRD.GetNameDayInMonth();
            lblNewDate.Text = PRD.GetNumberDayInMonth() + " " + PRD.GetNameMonth() + " " + PRD.GetNumberYear();
        }
        public static void Timer_Dispaly(System.Windows.Forms.Label lblHour, System.Windows.Forms.Label lblMin, System.Windows.Forms.Label lblSec)
        {
            lblHour.Text = System.DateTime.Now.Hour.ToString();
            lblMin.Text = System.DateTime.Now.Minute.ToString();
            if (lblSec.Visible == true)
                lblSec.Visible = false;
            else if (lblSec.Visible == false)
                lblSec.Visible = true;
        }
        public static bool Check_Email(System.Windows.Forms.TextBox txt)
        {
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                return true;
            }
            else
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(txt.Text, @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"))
                    return true;
                else
                    return false;
            }
        }
        public static bool Check_Mobile(System.Windows.Forms.TextBox txt)
        {
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                return true;
            }
            else
            {
                string str1 = txt.Text.Substring(0, 2);
                if (str1 == "09")
                    return true;
                else
                    return false;
            }
        }
        public static bool Check_NationalCode(System.Windows.Forms.TextBox txt)
        {
            try
            {
                char[] chArray = txt.Text.ToCharArray();
                int[] numArray = new int[chArray.Length];
                for (int i = 0; i < chArray.Length; i++)
                {
                    numArray[i] = (int)char.GetNumericValue(chArray[i]);
                }
                int num2 = numArray[9];
                switch (txt.Text)
                {
                    case "0000000000":
                    case "1111111111":
                    case "22222222222":
                    case "33333333333":
                    case "4444444444":
                    case "5555555555":
                    case "6666666666":
                    case "7777777777":
                    case "8888888888":
                    case "9999999999":
                        return false;
                        break;
                }
                int num3 = ((((((((numArray[0] * 10) + (numArray[1] * 9)) + (numArray[2] * 8)) + (numArray[3] * 7)) + (numArray[4] * 6)) + (numArray[5] * 5)) + (numArray[6] * 4)) + (numArray[7] * 3)) + (numArray[8] * 2);
                int num4 = num3 - ((num3 / 11) * 11);
                if ((((num4 == 0) && (num2 == num4)) || ((num4 == 1) && (num2 == 1))) || ((num4 > 1) && (num2 == Math.Abs((int)(num4 - 11)))))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static void AutoComplete(string query, SqlConnection dataconnection, System.Windows.Forms.TextBox txt)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(query, dataconnection);
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    txt.AutoCompleteCustomSource.Add(dt.Rows[i].ItemArray[0].ToString());
                }
            }
            catch (Exception)
            {
            }
        }
        public static void Switch_Language_To_English()
        {
            CultureInfo LAN = new CultureInfo("en-us");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(LAN);
        }
        public static void Switch_Language_To_Persian()
        {
            CultureInfo LAN = new CultureInfo("fa-ir");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(LAN);
        }
        public static void Export_Data_To_Excel(DataGridView dgv)
        {
            object mis = System.Reflection.Missing.Value;
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook WorkBook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet Worksheet = null;
            app.Visible = false;
            Worksheet = (Worksheet)WorkBook.Sheets["Sheet1"];
            Worksheet = (Worksheet)WorkBook.ActiveSheet;
            Worksheet.Name = "Export";
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                Worksheet.Cells[1, i] = dgv.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    Worksheet.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j].Value.ToString();
                }
            }
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Document (*.xlsx)|*.xlsx";
            sfd.FileName = "Export";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                WorkBook.SaveAs(sfd.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            app.Quit();
        }
        public static bool CMB_Error_Provider(System.Windows.Forms.ComboBox cmb, ErrorProvider ep, string Error)
        {
            if (string.IsNullOrWhiteSpace(cmb.Text))
            {
                ep.Clear();
                ep.RightToLeft = true;
                ep.SetError(cmb, Error);
                return true;
            }
            else
                return false;
        }
        public static void ToCsv(DataGridView dgv, string fileName)
        {
            string stOutput = "";
            string sHeaders = "";
            for (int j = 0; j < dgv.Columns.Count; j++)
            {
                sHeaders = sHeaders.ToString() + Convert.ToString(dgv.Columns[j].HeaderText) + "\t";
            }
            stOutput += sHeaders + "\r\n";
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                string stLine = "";
                for (int j = 0; j < dgv.Rows[i].Cells.Count; j++)
                {
                    stLine = stLine.ToString() + Convert.ToString(dgv.Rows[i].Cells[j].Value) + "\t";
                }
                stOutput += stLine + "\r\n";
            }
            Encoding utf16 = new UTF8Encoding();
            byte[] output = utf16.GetBytes(stOutput);
            FileStream fs = new FileStream(fileName, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(output, 0, output.Length);
            bw.Flush();
            bw.Close();
            fs.Close();
        }
    }
}
