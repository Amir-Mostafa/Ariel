using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ariel.PL
{
    public partial class form_notifications : Form
    {
        public static  form_notifications notifications;
        public form_notifications()
        {
            InitializeComponent();
            notifications = this;

             dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Blue;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.Tan;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 16);
            dataGridView1.RowTemplate.Height = 30;

           
        }


        private void form_notifications_Load(object sender, EventArgs e)
        {
            
        }

        private void report_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد حذف الاشعار", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    BL.products bl = new BL.products();
                    bl.delete_notification(int.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString()));
                    dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
