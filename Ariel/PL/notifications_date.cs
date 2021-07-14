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
    public partial class notifications_date : Form
    {
        BL.products bl = new BL.products();
        public notifications_date()
        {
            InitializeComponent();
        }

        private void report_Click(object sender, EventArgs e)
        {
            try
            {
                Form f = new form_notifications();
                DataTable d=bl.report_notifications(date1.Value.Date, date2.Value.Date);
                form_notifications.notifications.dataGridView1.DataSource = d;
                form_notifications.notifications.dataGridView1.Columns["id"].Visible = false;

                double t = 0;
                for (int i = 0; i <d.Rows.Count; i++)
                {
                    t += double.Parse(d.Rows[i]["المبلغ"].ToString());
                }
                form_notifications.notifications.total.Text = t.ToString();
                this.Hide();
                f.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
