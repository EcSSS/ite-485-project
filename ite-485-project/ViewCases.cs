using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace ite_485_project
{
    public partial class ViewCases : Form
    {
        string connectionString = @"Server=tcp:ite-485-database-sever.database.windows.net,1433;Initial Catalog=ite-485-database;Persist Security Info=False;User ID=EcS;Password=Eric20000;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public static string SetValue = "";
        public static string OffenderName = "";
        public static string CaseStatus = "";

        public ViewCases()
        {
            InitializeComponent();
        }

        private void OpenCases_Load(object sender, EventArgs e)
        {
            
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM dbo.CaseInfo", sqlCon);
                DataTable dtbl1 = new DataTable();
                sqlDa.Fill(dtbl1);

                dataGridView1.DataSource = dtbl1;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetValue = txtCaseNum.Text;
           
            ShowCase showcase = new ShowCase();
            showcase.Show();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string caseId = dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty;
                string officerName = dataGridView1.SelectedRows[0].Cells[1].Value + string.Empty;
                string offenderName = dataGridView1.SelectedRows[0].Cells[2].Value + string.Empty;
                string caseStatus1 = dataGridView1.SelectedRows[0].Cells[3].Value + string.Empty;
                txtCaseNum.Text = caseId;
                txtOfficerName.Text = officerName;
                txtOffenderName.Text = offenderName;
                OffenderName = txtOffenderName.Text;
                if (caseStatus1 == "True")
                {
                    CaseStatus = "Open";
                }
                if(caseStatus1 == "False")
                {
                    CaseStatus = "Closed";
                }
                
            }
            

            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            SetValue = "";
            Form1 home = new Form1();
            home.ShowDialog();
            this.Close();
            
            
        }

        private void rdAll_CheckedChanged(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM dbo.CaseInfo", sqlCon);
                DataTable dtbl1 = new DataTable();
                sqlDa.Fill(dtbl1);

                dataGridView1.DataSource = dtbl1;
            }
        }

        private void rdClosed_CheckedChanged(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM dbo.CaseInfo WHERE CaseStatus=0", sqlCon);
                DataTable dtbl1 = new DataTable();
                sqlDa.Fill(dtbl1);

                dataGridView1.DataSource = dtbl1;
            }
        }

        private void rdOpen_CheckedChanged(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM dbo.CaseInfo WHERE CaseStatus=1", sqlCon);
                DataTable dtbl1 = new DataTable();
                sqlDa.Fill(dtbl1);

                dataGridView1.DataSource = dtbl1;
            }
        }
    }
}
