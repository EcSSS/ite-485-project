
namespace ite_485_project
{
    partial class ViewCases
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewCases));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.txtCaseNum = new System.Windows.Forms.TextBox();
            this.txtOfficerName = new System.Windows.Forms.TextBox();
            this.txtOffenderName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.rdAll = new System.Windows.Forms.RadioButton();
            this.rdClosed = new System.Windows.Forms.RadioButton();
            this.rdOpen = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(22, 252);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(1534, 1007);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1385, 158);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(171, 81);
            this.button1.TabIndex = 6;
            this.button1.Text = "Show Case";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtCaseNum
            // 
            this.txtCaseNum.Location = new System.Drawing.Point(344, 17);
            this.txtCaseNum.Margin = new System.Windows.Forms.Padding(6);
            this.txtCaseNum.Name = "txtCaseNum";
            this.txtCaseNum.Size = new System.Drawing.Size(80, 39);
            this.txtCaseNum.TabIndex = 10;
            // 
            // txtOfficerName
            // 
            this.txtOfficerName.Location = new System.Drawing.Point(669, 17);
            this.txtOfficerName.Margin = new System.Windows.Forms.Padding(6);
            this.txtOfficerName.Name = "txtOfficerName";
            this.txtOfficerName.Size = new System.Drawing.Size(262, 39);
            this.txtOfficerName.TabIndex = 11;
            // 
            // txtOffenderName
            // 
            this.txtOffenderName.Location = new System.Drawing.Point(1181, 17);
            this.txtOffenderName.Margin = new System.Windows.Forms.Padding(6);
            this.txtOffenderName.Name = "txtOffenderName";
            this.txtOffenderName.Size = new System.Drawing.Size(255, 39);
            this.txtOffenderName.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(173, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 32);
            this.label1.TabIndex = 14;
            this.label1.Text = "Case Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(500, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 32);
            this.label2.TabIndex = 15;
            this.label2.Text = "Officer Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(997, 23);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 32);
            this.label3.TabIndex = 16;
            this.label3.Text = "Offender Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bernard MT Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(22, 23);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 49);
            this.label5.TabIndex = 18;
            this.label5.Text = "CIISS";
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button2.Location = new System.Drawing.Point(1518, 0);
            this.button2.Margin = new System.Windows.Forms.Padding(6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(63, 79);
            this.button2.TabIndex = 19;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // rdAll
            // 
            this.rdAll.AutoSize = true;
            this.rdAll.Checked = true;
            this.rdAll.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.rdAll.Location = new System.Drawing.Point(481, 28);
            this.rdAll.Margin = new System.Windows.Forms.Padding(6);
            this.rdAll.Name = "rdAll";
            this.rdAll.Size = new System.Drawing.Size(139, 36);
            this.rdAll.TabIndex = 56;
            this.rdAll.TabStop = true;
            this.rdAll.Text = "All Cases";
            this.rdAll.UseVisualStyleBackColor = true;
            this.rdAll.CheckedChanged += new System.EventHandler(this.rdAll_CheckedChanged);
            // 
            // rdClosed
            // 
            this.rdClosed.AutoSize = true;
            this.rdClosed.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.rdClosed.Location = new System.Drawing.Point(227, 28);
            this.rdClosed.Margin = new System.Windows.Forms.Padding(6);
            this.rdClosed.Name = "rdClosed";
            this.rdClosed.Size = new System.Drawing.Size(184, 36);
            this.rdClosed.TabIndex = 55;
            this.rdClosed.Text = "Closed Cases";
            this.rdClosed.UseVisualStyleBackColor = true;
            this.rdClosed.CheckedChanged += new System.EventHandler(this.rdClosed_CheckedChanged);
            // 
            // rdOpen
            // 
            this.rdOpen.AutoSize = true;
            this.rdOpen.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.rdOpen.Location = new System.Drawing.Point(6, 28);
            this.rdOpen.Margin = new System.Windows.Forms.Padding(6);
            this.rdOpen.Name = "rdOpen";
            this.rdOpen.Size = new System.Drawing.Size(171, 36);
            this.rdOpen.TabIndex = 54;
            this.rdOpen.Text = "Open Cases";
            this.rdOpen.UseVisualStyleBackColor = true;
            this.rdOpen.CheckedChanged += new System.EventHandler(this.rdOpen_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdAll);
            this.panel1.Controls.Add(this.rdOpen);
            this.panel1.Controls.Add(this.rdClosed);
            this.panel1.Location = new System.Drawing.Point(462, 100);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(624, 96);
            this.panel1.TabIndex = 58;
            // 
            // ViewCases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1579, 1284);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOffenderName);
            this.Controls.Add(this.txtOfficerName);
            this.Controls.Add(this.txtCaseNum);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ViewCases";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OpenCases";
            this.Load += new System.EventHandler(this.OpenCases_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtCaseNum;
        private System.Windows.Forms.TextBox txtOfficerName;
        private System.Windows.Forms.TextBox txtOffenderName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton rdAll;
        private System.Windows.Forms.RadioButton rdClosed;
        private System.Windows.Forms.RadioButton rdOpen;
        private System.Windows.Forms.Panel panel1;
    }
}