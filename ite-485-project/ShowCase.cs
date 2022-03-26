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
using System.Diagnostics;
using System.Threading;






namespace ite_485_project
{
    public partial class ShowCase : Form
    {
        
        public ShowCase()
        {
            InitializeComponent();
        }

        private void ShowCase_Load(object sender, EventArgs e)
        {


            using (SqlConnection cn = GetConnection())
            {
                
                string query = "SELECT SNo,DisplayName,Extension FROM dbo.tblDocuments";
                SqlDataAdapter adp = new SqlDataAdapter(query, cn);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                   dataGridView1.DataSource = dt;
                }
                
            }

        }

        private void button2_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView1.SelectedRows;
            foreach (var row in selectedRow)
            {
                int id = (int)((DataGridViewRow)row).Cells[0].Value;

                OpenFile(id);
            }
            

        }
        private void OpenFile(int id)
        {



            using (SqlConnection cn = GetConnection())
            {
                FileStream FS = null;
                
                string query = "SELECT FileData,DisplayName,Extension FROM dbo.tblDocuments WHERE SNo=@SNo";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.Add("@SNo", SqlDbType.Int).Value = id;
                cn.Open();

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var name = reader["DisplayName"].ToString();
                    var data = (byte[])reader["FileData"];
                    var extn = reader["Extension"].ToString();
                    var newFileName = name.Replace(extn, DateTime.Now.ToString("ddMMyyyyhhmmss")) + extn;
                    string filepath = @"C:\Users\erics\Downloads\" + name + ".pdf";

                    FS = new FileStream(filepath, System.IO.FileMode.Create);

                    FS.Write(data, 0, data.Length);
                    FS.Close();

                    string adobeReaderPath = @"C:\Program Files\Adobe\Acrobat DC\Acrobat\Acrobat.exe";

                    System.Diagnostics.Process.Start(adobeReaderPath, filepath);

                    
                    

                }

            }
        }
        private SqlConnection GetConnection()
        {
            return new SqlConnection(@"Server=tcp:ite-485-database-sever.database.windows.net,1433;Initial Catalog=ite-485-database;Persist Security Info=False;User ID=EcS;Password=Eric20000;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        private void btnSave_Click(object sender, EventArgs e)
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
                }
                

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 home = new Form1();
            home.ShowDialog();
            this.Close();
        }
    }
}
