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
                
                
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                string FileName = new FileInfo(filepath).Name;
                string extn = new FileInfo(filepath).Extension;
                long size = new FileInfo(filepath).Length;
                string query = "INSERT INTO dbo.tblDocuments(DisplayName,Extension,FileData,FileSize)VALUES(@DisplayName,@Extension,@FileData,@FileSize)";
                

                using (SqlConnection cn = GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.Add("@FileData", SqlDbType.VarBinary).Value = buffer;
                    cmd.Parameters.Add("@Extension", SqlDbType.VarChar).Value = extn;
                    cmd.Parameters.Add("@DisplayName", SqlDbType.VarChar).Value = FileName;
                    cmd.Parameters.Add("@FileSize", SqlDbType.BigInt).Value = size;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

                string officerName = txtOfficer.Text;
                string offenderName = txtOffender.Text;
                string query2 = "INSERT INTO dbo.tblCaseInfo(OfficerName,OffenderName)VALUES(@OfficerName,@OffenderName)";

                using (SqlConnection cn = GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(query2, cn);
                    cmd.Parameters.Add("@OfficerName", SqlDbType.VarChar).Value = officerName;
                    cmd.Parameters.Add("@OffenderName", SqlDbType.VarChar).Value = offenderName;
                    cmd.Parameters.Add("CaseStatus", SqlDbType.SmallInt).Value = 1;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    
                }



            }
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
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
