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
    public partial class costs : Form
    {
        BL.emplyees bl = new BL.emplyees();
        public costs()
        {
            InitializeComponent();
        }

        private void costs_Load(object sender, EventArgs e)
        {
            try
            {

                DataTable d = bl.all_emp();
                comboBox3.DataSource=d;
                comboBox3.DisplayMember = "emp_name";
                comboBox3.ValueMember = "emp_id";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                int parsedValue;
                if (comboBox3.SelectedIndex == -1 || !int.TryParse(total.Text, out parsedValue))
                    MessageBox.Show("ادخل بيانات صحيحه");
                else
                {
                    if (desc.Text == "")
                        desc.Text = "دفعه من الحساب";
                    bl.add_outgoings(Convert.ToInt32(comboBox3.SelectedValue), date.Value.Date, total.Text, desc.Text);

                    comboBox3.SelectedIndex = -1;
                    total.Text = "";
                    desc.Text = "";
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
