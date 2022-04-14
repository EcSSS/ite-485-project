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
        public static string SetValue2 = "";
        public ShowCase()
        {
            InitializeComponent();
        }


        private void ShowCase_Load(object sender, EventArgs e)
        {

            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;

            timePicker = new DateTimePicker();
            timePicker.Format = DateTimePickerFormat.Time;
            timePicker.ShowUpDown = true;
            timePicker.Location = new Point(1487, 856);
            timePicker.Width = 1;
            Controls.Add(timePicker);


            txtCaseNo.Text = ViewCases.SetValue;
            txtOffenderName.Text = ViewCases.OffenderName;
            txtCaseStatus.Text = ViewCases.CaseStatus;

            

            using (SqlConnection cn = GetConnection())
            {

                string query = "SELECT SNo,DisplayName,Extension,FileSize,UploadDate,Time FROM dbo.Documents WHERE CaseNum='" + txtCaseNo.Text + "'";
                SqlDataAdapter adp = new SqlDataAdapter(query, cn);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;

               
            }



        }   
            

        

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Filter = "Pdf Files|*.pdf|Image Files|*.bmp;*.jpg;*.png;|Word Files|*.docx",
                Title = "Browse Files",

            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                txtFilePath.Text = openFileDialog1.FileName;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                var selectedRow = dataGridView1.SelectedRows;
                foreach (var row in selectedRow)
                {
                    int id = (int)((DataGridViewRow)row).Cells[0].Value;

                    OpenFile(id);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error during open file sequence");
                return;
            }

        }
        private void OpenFile(int id)
        {

            try
            {

                using (SqlConnection cn = GetConnection())
                {
                    FileStream FS = null;

                    string query = "SELECT FileData,DisplayName,Extension FROM dbo.Documents WHERE SNo=@SNo";
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


                        if (extn == ".pdf")
                        {
                            string filepath = @"C:\Users\erics\Downloads\" + name + ".pdf";
                            FS = new FileStream(filepath, System.IO.FileMode.Create);

                            FS.Write(data, 0, data.Length);
                            FS.Close();

                            string adobeReaderPath = @"C:\Program Files\Adobe\Acrobat DC\Acrobat\Acrobat.exe";

                            System.Diagnostics.Process.Start(adobeReaderPath, filepath);
                        }
                        if (extn == ".docx")
                        {
                            string filepath = @"C:\Users\erics\Downloads\" + name + ".docx";
                            FS = new FileStream(filepath, System.IO.FileMode.Create);

                            FS.Write(data, 0, data.Length);
                            FS.Close();

                            string wordReaderPath = @"C:\Program Files\Microsoft Office\root\Office16\WINWORD.EXE";

                            System.Diagnostics.Process.Start(wordReaderPath, filepath);
                        }
                        if (extn == ".jpg")
                        {
                            string filepath = @"C:\Users\erics\Downloads\" + name + ".jpg";
                            FS = new FileStream(filepath, System.IO.FileMode.Create);

                            FS.Write(data, 0, data.Length);
                            FS.Close();

                            string imageReaderPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";

                            System.Diagnostics.Process.Start(imageReaderPath, filepath);
                        }

                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error during open file sequence");
                return;
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
                    string time = timePicker.Text;
                    string date = dtDate.Text;
                    byte[] buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, buffer.Length);
                    string FileName = new FileInfo(filepath).Name;
                    string extn = new FileInfo(filepath).Extension;
                    long size = new FileInfo(filepath).Length;
                    string query = "IF EXISTS(SELECT CaseNum FROM dbo.Documents WHERE CaseNum='" + txtCaseNo.Text + "')INSERT INTO dbo.Documents(DisplayName,Extension,FileData,FileSize,CaseNum,UploadDate,Time)VALUES(@DisplayName,@Extension,@FileData,@FileSize,@CaseNum,@UploadDate,@Time)";



                    using (SqlConnection cn = GetConnection())
                    {
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.Parameters.Add("@FileData", SqlDbType.VarBinary).Value = buffer;
                        cmd.Parameters.Add("@Extension", SqlDbType.VarChar).Value = extn;
                        cmd.Parameters.Add("@DisplayName", SqlDbType.VarChar).Value = FileName;
                        cmd.Parameters.Add("@FileSize", SqlDbType.BigInt).Value = size;
                        cmd.Parameters.Add("@CaseNum", SqlDbType.Int).Value = txtCaseNo.Text;
                        cmd.Parameters.Add("@UploadDate", SqlDbType.DateTime).Value = date;
                        cmd.Parameters.Add("@Time", SqlDbType.VarChar).Value = time;

                        cn.Open();
                        cmd.ExecuteNonQuery();
                    }



                }

            string officerName2 = txtOfficerNameCheckout.Text;
            string date2 = dtDate.Text;

            string query5 = "SELECT MAX(SNo) FROM dbo.Documents";
            using (SqlConnection cn = GetConnection())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(query5, cn);
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    txtControlSNo.Text = da.GetValue(0).ToString();
                }
                cn.Close();
            }


            string query6 = "INSERT INTO dbo.ChainOfCustody(SNo,Date,Time,EvidenceName)VALUES(@SNo,@Date,@Time,@EvidenceName)";
            using (SqlConnection cn = GetConnection())
            {
                string filepath2 = txtFilePath.Text;
                string FileName = new FileInfo(filepath).Name;

                SqlCommand cmd = new SqlCommand(query6, cn);
                //cmd.Parameters.Add("@OfficerName", SqlDbType.VarChar).Value = officerName2;
                cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = date2;
                cmd.Parameters.Add("@SNo", SqlDbType.Int).Value = txtControlSNo.Text;
                cmd.Parameters.Add("@EvidenceName", SqlDbType.VarChar).Value = FileName;
                cmd.Parameters.Add("@Time", SqlDbType.Char).Value = timePicker.Text;


                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

            }


        }

       

        private void btnClose_Click(object sender, EventArgs e)
        {
            string query = "UPDATE dbo.CaseInfo SET CaseStatus='"+0+"' WHERE CaseNum='"+txtCaseNo.Text+"'"; 
            using (SqlConnection cn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, cn);
                //cmd.Parameters.Add("@CaseStatus", SqlDbType.Bit).Value = 0;
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            ViewCases openCases = new ViewCases();
            openCases.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "IF EXISTS(SELECT SNo FROM dbo.ChainOfCustody WHERE SNo='" + txtEvidenceNo.Text + "')INSERT INTO dbo.ChainOfCustody(SNo,OfficerName,Date,Time,EvidenceName)VALUES(@SNo,@OfficerName,@Date,@Time,@EvidenceName)";

            string time = timePicker.Text;


            using (SqlConnection cn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.Add("@SNo", SqlDbType.Int).Value = txtEvidenceNo.Text;
                cmd.Parameters.Add("@OfficerName", SqlDbType.VarChar).Value = txtOfficerNameCheckout.Text;
                cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = dateTimePicker1.Text;
                cmd.Parameters.Add("@Time", SqlDbType.VarChar).Value = time;

                if (dataGridView1.SelectedRows.Count > 0)
                {
                    string EvidenceName = dataGridView1.SelectedRows[0].Cells[1].Value + string.Empty;
                    cmd.Parameters.Add("@EvidenceName", SqlDbType.VarChar).Value = EvidenceName;
                }


                cn.Open();
                cmd.ExecuteNonQuery();
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string EvidenceNo = dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty;
                txtEvidenceNo.Text = EvidenceNo;

                string EvidenceName = dataGridView1.SelectedRows[0].Cells[1].Value + string.Empty;
                txtEvidenceName.Text = EvidenceName;



            }



        }

        private void button5_Click(object sender, EventArgs e)
        {
            SetValue2 = txtEvidenceNo.Text;

            Form2 home2 = new Form2();
            home2.ShowDialog();

        }

        
    }
}
