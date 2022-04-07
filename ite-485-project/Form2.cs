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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(@"Server=tcp:ite-485-database-sever.database.windows.net,1433;Initial Catalog=ite-485-database;Persist Security Info=False;User ID=EcS;Password=Eric20000;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string SNo = ShowCase.SetValue2;

            using (SqlConnection cn = GetConnection())
            {

                string query = "SELECT SNo,EvidenceName,OfficerName,Date,Time FROM dbo.ChainOfCustody WHERE SNo='" + SNo + "'";
                SqlDataAdapter adp = new SqlDataAdapter(query, cn);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;


            }
        }
    }
}
