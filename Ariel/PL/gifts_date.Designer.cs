namespace Ariel.PL
{
    partial class gifts_date
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
            this.date2 = new System.Windows.Forms.DateTimePicker();
            this.date1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.report = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // date2
            // 
            this.date2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date2.Location = new System.Drawing.Point(152, 212);
            this.date2.Name = "date2";
            this.date2.Size = new System.Drawing.Size(405, 38);
            this.date2.TabIndex = 123;
            // 
            // date1
            // 
            this.date1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date1.Location = new System.Drawing.Point(152, 100);
            this.date1.Name = "date1";
            this.date1.Size = new System.Drawing.Size(405, 38);
            this.date1.TabIndex = 122;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(52, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 29);
            this.label2.TabIndex = 121;
            this.label2.Text = "الي:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 29);
            this.label1.TabIndex = 120;
            this.label1.Text = "من :";
            // 
            // report
            // 
            this.report.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.report.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.report.ForeColor = System.Drawing.Color.LimeGreen;
            this.report.Location = new System.Drawing.Point(232, 337);
            this.report.Name = "report";
            this.report.Size = new System.Drawing.Size(157, 69);
            this.report.TabIndex = 124;
            this.report.Text = "تقرير فتره";
            this.report.UseVisualStyleBackColor = false;
            this.report.Click += new System.EventHandler(this.report_Click);
            // 
            // gifts_date
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 480);
            this.Controls.Add(this.report);
            this.Controls.Add(this.date2);
            this.Controls.Add(this.date1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "gifts_date";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DateTimePicker date2;
        public System.Windows.Forms.DateTimePicker date1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button report;
    }
}