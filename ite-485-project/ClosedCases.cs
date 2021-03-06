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
    public partial class ClosedCases : Form
    {
        string connectionString = @"Server=tcp:ite-485-database-sever.database.windows.net,1433;Initial Catalog=ite-485-database;Persist Security Info=False;User ID=EcS;Password=;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public ClosedCases()
        {
            InitializeComponent();
        }

        public static string SetValue = "";
       

        private void ClosedCases_Load(object sender, EventArgs e)
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


        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 home = new Form1();
            home.ShowDialog();
            this.Close();


            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string caseId = dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty;
                string officerName = dataGridView1.SelectedRows[0].Cells[1].Value + string.Empty;
                string offenderName = dataGridView1.SelectedRows[0].Cells[2].Value + string.Empty;
                string caseStatus = dataGridView1.SelectedRows[0].Cells[3].Value + string.Empty;
                txtCaseNum.Text = caseId;
                txtOfficerName.Text = officerName;
                txtOffenderName.Text = offenderName;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {       
            SetValue = txtCaseNum.Text;

            ShowCase showcase = new ShowCase();
            showcase.Show();
        }
    }
}
