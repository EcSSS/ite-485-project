using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IronOcr;

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


            


            //var filepath = txtFilePath.Text;

            //var Ocr = new IronTesseract();

            //using (var Input = new OcrInput())
            //{
                
            //        Input.AddPdf(filepath);
            //        var Result = Ocr.Read(Input);
            //        System.IO.File.WriteAllText("C:\\Users\\erics\\Documents\\test.txt", Result.Text);
                         
            //}
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
    }
}
