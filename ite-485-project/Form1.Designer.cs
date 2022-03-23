
namespace ite_485_project
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnNewCase = new System.Windows.Forms.Button();
            this.btnOpenCase = new System.Windows.Forms.Button();
            this.btnClosedCase = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btntest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNewCase
            // 
            this.btnNewCase.Location = new System.Drawing.Point(90, 84);
            this.btnNewCase.Name = "btnNewCase";
            this.btnNewCase.Size = new System.Drawing.Size(109, 39);
            this.btnNewCase.TabIndex = 0;
            this.btnNewCase.Text = "New Case";
            this.btnNewCase.UseVisualStyleBackColor = true;
            this.btnNewCase.Click += new System.EventHandler(this.btnNewCase_Click);
            // 
            // btnOpenCase
            // 
            this.btnOpenCase.Location = new System.Drawing.Point(90, 129);
            this.btnOpenCase.Name = "btnOpenCase";
            this.btnOpenCase.Size = new System.Drawing.Size(109, 42);
            this.btnOpenCase.TabIndex = 1;
            this.btnOpenCase.Text = "Open Cases";
            this.btnOpenCase.UseVisualStyleBackColor = true;
            this.btnOpenCase.Click += new System.EventHandler(this.btnOpenCase_Click);
            // 
            // btnClosedCase
            // 
            this.btnClosedCase.Location = new System.Drawing.Point(90, 177);
            this.btnClosedCase.Name = "btnClosedCase";
            this.btnClosedCase.Size = new System.Drawing.Size(109, 44);
            this.btnClosedCase.TabIndex = 2;
            this.btnClosedCase.Text = "Close Cases";
            this.btnClosedCase.UseVisualStyleBackColor = true;
            this.btnClosedCase.Click += new System.EventHandler(this.btnClosedCase_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(90, 227);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(109, 42);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bernard MT Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(119, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "CIISS";
            // 
            // btntest
            // 
            this.btntest.Location = new System.Drawing.Point(119, 288);
            this.btntest.Name = "btntest";
            this.btntest.Size = new System.Drawing.Size(75, 23);
            this.btntest.TabIndex = 6;
            this.btntest.Text = "Test";
            this.btntest.UseVisualStyleBackColor = true;
            this.btntest.Click += new System.EventHandler(this.btntest_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(283, 349);
            this.Controls.Add(this.btntest);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClosedCase);
            this.Controls.Add(this.btnOpenCase);
            this.Controls.Add(this.btnNewCase);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNewCase;
        private System.Windows.Forms.Button btnOpenCase;
        private System.Windows.Forms.Button btnClosedCase;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btntest;
    }
}

