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
    public partial class OpenCases : Form
    {
        string connectionString = @"Server=tcp:ite-485-database-sever.database.windows.net,1433;Initial Catalog=ite-485-database;Persist Security Info=False;User ID=EcS;Password={Eric20000};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
      
        public OpenCases()
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 home = new Form1();
            home.ShowDialog();
            this.Close();
        }
    }
}
