using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Data.SqlTypes;


namespace ite_485_project
{


    public partial class NewCase : Form
    {
        

        public static string SetValue2 = "";


        public NewCase()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string filepath = txtFilePath.Text;

            using (Stream stream = File.OpenRead(filepath))
            {

                string date = dtDate.Text;
                string time = timePicker.Text;
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                string FileName = new FileInfo(filepath).Name;
                string extn = new FileInfo(filepath).Extension;
                long size = new FileInfo(filepath).Length;
                string query = "INSERT INTO dbo.Documents(FileData,Extension,DisplayName,FileSize,UploadDate,Time)VALUES(@FileData,@Extension,@DisplayName,@FileSize,@UploadDate,@Time)";
                

                using (SqlConnection cn = GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.Add("@FileData", SqlDbType.VarBinary).Value = buffer;
                    cmd.Parameters.Add("@Extension", SqlDbType.VarChar).Value = extn;
                    cmd.Parameters.Add("@DisplayName", SqlDbType.VarChar).Value = FileName;
                    cmd.Parameters.Add("@FileSize", SqlDbType.BigInt).Value = size;
                    cmd.Parameters.Add("@UploadDate", SqlDbType.DateTime).Value = date;
                    cmd.Parameters.Add("@Time", SqlDbType.Char).Value = time;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

                string officerName = txtOfficer.Text;
                string offenderName = txtOffender.Text;
                string query2 = "INSERT INTO dbo.CaseInfo(OfficerName,OffenderName,CaseStatus,Date,Time)VALUES(@OfficerName,@OffenderName,@CaseStatus,@Date,@Time)";

                using (SqlConnection cn = GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(query2, cn);
                    cmd.Parameters.Add("@OfficerName", SqlDbType.VarChar).Value = officerName;
                    cmd.Parameters.Add("@OffenderName", SqlDbType.VarChar).Value = offenderName;
                    cmd.Parameters.Add("CaseStatus", SqlDbType.SmallInt).Value = 1;
                    cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = date;
                    cmd.Parameters.Add("@Time", SqlDbType.Char).Value = time;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    
                }
                
            }
            string query3 = "SELECT MAX(CaseNum) FROM dbo.CaseInfo";
            string test = txttest.Text;

            using (SqlConnection cn = GetConnection())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(query3, cn);
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    SetValue2 = da.GetValue(0).ToString();
                }
                cn.Close();
            }

            string query4 = "UPDATE dbo.Documents SET CaseNum='" + SetValue2 + "' WHERE SNo=(select max(SNo)From dbo.Documents)";
            using (SqlConnection cn = GetConnection())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(query4, cn);
                cmd.ExecuteNonQuery();

            }

            string officerName2 = txtOfficer.Text;
            string date2 = dtDate.Text;

            string query5 = "SELECT MAX(SNo) FROM dbo.Documents";
            using (SqlConnection cn = GetConnection())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(query5, cn);
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    txtsno.Text = da.GetValue(0).ToString();
                }
                cn.Close();
            }


            string query6 = "INSERT INTO dbo.ChainOfCustody(SNo,OfficerName,Date,Time,EvidenceName)VALUES(@SNo,@OfficerName,@Date,@Time,@EvidenceName)";
            using (SqlConnection cn = GetConnection())
            {
                string filepath2 = txtFilePath.Text;
                string FileName = new FileInfo(filepath).Name;



                SqlCommand cmd = new SqlCommand(query6, cn);
                cmd.Parameters.Add("@OfficerName", SqlDbType.VarChar).Value = officerName2;
                cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = date2;
                cmd.Parameters.Add("@SNo", SqlDbType.Int).Value = txtsno.Text;
                cmd.Parameters.Add("@EvidenceName", SqlDbType.VarChar).Value = FileName;
                cmd.Parameters.Add("@Time", SqlDbType.Char).Value = timePicker.Text;


                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

            }


        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Filter = "Pdf Files|*.pdf|Image Files|*.bmp;*.jpg;*.gif;*.png;*.tif|Word| *.docx",
                Title = "Browse Files",
                

            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                txtFilePath.Text = openFileDialog1.FileName;

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 home = new Form1();
            home.ShowDialog();
            this.Close();
        }

        private void NewCase_Load(object sender, EventArgs e)
        {
            timePicker = new DateTimePicker();
            timePicker.Format = DateTimePickerFormat.Time;
            timePicker.ShowUpDown = true;
            timePicker.Location = new Point(124, 169);
            timePicker.Width = 100;
            Controls.Add(timePicker);
            

        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(@"Server=tcp:ite-485-database-sever.database.windows.net,1433;Initial Catalog=ite-485-database;Persist Security Info=False;User ID=EcS;Password=Eric20000;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
