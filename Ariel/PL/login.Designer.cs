namespace Ariel.PL
{
    partial class login
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtserial4 = new System.Windows.Forms.TextBox();
            this.txtserial3 = new System.Windows.Forms.TextBox();
            this.txtserial2 = new System.Windows.Forms.TextBox();
            this.txtserial1 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(234, 111);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 56);
            this.button1.TabIndex = 4;
            this.button1.Text = "تسجيل";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtserial4
            // 
            this.txtserial4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtserial4.Location = new System.Drawing.Point(399, 139);
            this.txtserial4.MaxLength = 4;
            this.txtserial4.Name = "txtserial4";
            this.txtserial4.Size = new System.Drawing.Size(100, 38);
            this.txtserial4.TabIndex = 8;
            this.txtserial4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtserial4.Visible = false;
            this.txtserial4.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // txtserial3
            // 
            this.txtserial3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtserial3.Location = new System.Drawing.Point(293, 139);
            this.txtserial3.MaxLength = 4;
            this.txtserial3.Name = "txtserial3";
            this.txtserial3.Size = new System.Drawing.Size(100, 38);
            this.txtserial3.TabIndex = 7;
            this.txtserial3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtserial3.Visible = false;
            this.txtserial3.Leave += new System.EventHandler(this.textBox2_Leave);
            // 
            // txtserial2
            // 
            this.txtserial2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtserial2.Location = new System.Drawing.Point(187, 139);
            this.txtserial2.MaxLength = 4;
            this.txtserial2.Name = "txtserial2";
            this.txtserial2.Size = new System.Drawing.Size(100, 38);
            this.txtserial2.TabIndex = 6;
            this.txtserial2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtserial2.Visible = false;
            this.txtserial2.Leave += new System.EventHandler(this.textBox3_Leave);
            // 
            // txtserial1
            // 
            this.txtserial1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtserial1.Location = new System.Drawing.Point(81, 139);
            this.txtserial1.MaxLength = 4;
            this.txtserial1.Name = "txtserial1";
            this.txtserial1.Size = new System.Drawing.Size(100, 38);
            this.txtserial1.TabIndex = 5;
            this.txtserial1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtserial1.Visible = false;
            this.txtserial1.Leave += new System.EventHandler(this.textBox4_Leave);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(65, 57);
            this.textBox1.MaxLength = 100;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(453, 38);
            this.textBox1.TabIndex = 9;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(151, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 32);
            this.label1.TabIndex = 10;
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 189);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtserial4);
            this.Controls.Add(this.txtserial3);
            this.Controls.Add(this.txtserial2);
            this.Controls.Add(this.txtserial1);
            this.Controls.Add(this.button1);
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "login";
            this.Load += new System.EventHandler(this.login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtserial4;
        private System.Windows.Forms.TextBox txtserial3;
        private System.Windows.Forms.TextBox txtserial2;
        private System.Windows.Forms.TextBox txtserial1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}