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
    public partial class notifications : Form
    {
        BL.products bl = new BL.products();
        public notifications()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                double t=0;
                if(desc.Text==""||total.Text==""||order_id.Text==""||!double.TryParse(total.Text,out t))
                    MessageBox.Show("ادخل البيانات كامله ");
                bl.new_notification(desc.Text, total.Text, order_id.Text, dateTimePicker1.Value.Date);
                MessageBox.Show("تم");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
