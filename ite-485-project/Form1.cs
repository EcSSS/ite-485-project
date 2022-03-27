using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace ite_485_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static object SelectedRow { get; internal set; }

        private void btnClosedCase_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClosedCases closed = new ClosedCases();
            closed.ShowDialog();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnNewCase_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewCase test = new NewCase();
            test.ShowDialog();
            this.Close();
        }

        private void btnOpenCase_Click(object sender, EventArgs e)
        {
            this.Hide();
            OpenCases opencase = new OpenCases();
            opencase.ShowDialog();
            this.Close();
        }

        private void btntest_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShowCase showCase3 = new ShowCase();
            showCase3.ShowDialog();
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

     
    }
}