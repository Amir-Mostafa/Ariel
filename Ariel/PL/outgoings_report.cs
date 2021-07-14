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
    public partial class outgoings_report : Form
    {
        BL.emplyees bl = new BL.emplyees();
        public outgoings_report()
        {
            InitializeComponent();
            dataGridView2.BorderStyle = BorderStyle.None;
            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.Blue;
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView2.BackgroundColor = Color.Tan;

            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dataGridView2.DefaultCellStyle.Font = new Font("Tahoma", 16);
            dataGridView2.RowTemplate.Height = 30;





            try
            {

                DataTable d = new DataTable();
                d = bl.all_emp();
                comboBox3.DataSource = d;
                comboBox3.DisplayMember = "emp_name";
                comboBox3.ValueMember = "emp_id";


                int x = Convert.ToInt32(comboBox3.SelectedValue);
                dataGridView2.DataSource = bl.emp_report(x, date1.Value.Date, date2.Value.Date);

                double sum = 0;
                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    string val = dataGridView2.Rows[i].Cells[2].Value.ToString();
                    sum += double.Parse(val);
                }
                total.Text = sum.ToString();

                DataTable all = bl.all_outgoings(date1.Value.Date, date2.Value.Date);
                sum = 0;
                for (int i = 0; i < all.Rows.Count; i++)
                {
                    sum += double.Parse(all.Rows[i]["total"].ToString());
                }
                textBox1.Text = sum.ToString();


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void outgoings_report_Load(object sender, EventArgs e)
        {
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(comboBox3.SelectedValue);
                dataGridView2.DataSource = bl.emp_report(x,date1.Value.Date,date2.Value.Date);

                double sum = 0;
                for(int i=0;i<dataGridView2.Rows.Count-1;i++)
                {
                    string val=dataGridView2.Rows[i].Cells[2].Value.ToString();
                    sum += double.Parse(val);
                }
                total.Text = sum.ToString();

                DataTable all = bl.all_outgoings(date1.Value.Date, date2.Value.Date);
                 sum = 0;
                for (int i = 0; i < all.Rows.Count; i++)
                {
                    sum += double.Parse(all.Rows[i]["total"].ToString());
                }
                textBox1.Text = sum.ToString();

                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void date1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(comboBox3.SelectedValue);
                dataGridView2.DataSource = bl.emp_report(x, date1.Value.Date, date2.Value.Date);

                double sum = 0;
                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    string val = dataGridView2.Rows[i].Cells[2].Value.ToString();
                    sum += double.Parse(val);
                }
                total.Text = sum.ToString();

                DataTable all = bl.all_outgoings(date1.Value.Date, date2.Value.Date);
                sum = 0;
                for (int i = 0; i < all.Rows.Count; i++)
                {
                    sum += double.Parse(all.Rows[i]["total"].ToString());
                }
                textBox1.Text = sum.ToString();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void date2_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(comboBox3.SelectedValue);
                dataGridView2.DataSource = bl.emp_report(x, date1.Value.Date, date2.Value.Date);

                double sum = 0;
                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    string val = dataGridView2.Rows[i].Cells[2].Value.ToString();
                    sum += double.Parse(val);
                }
                total.Text = sum.ToString();

                DataTable all = bl.all_outgoings(date1.Value.Date, date2.Value.Date);
                sum = 0;
                for (int i = 0; i < all.Rows.Count; i++)
                {
                    sum += double.Parse(all.Rows[i]["total"].ToString());
                }
                textBox1.Text = sum.ToString();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("هل تريد الحذف", "fv", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
               
            try
            {
                bl.delete_outgoing(int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString()));
                int x = Convert.ToInt32(comboBox3.SelectedValue);
                dataGridView2.DataSource = bl.emp_report(x, date1.Value.Date, date2.Value.Date);

                double sum = 0;
                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    string val = dataGridView2.Rows[i].Cells[2].Value.ToString();
                    sum += double.Parse(val);
                }
                total.Text = sum.ToString();

                DataTable all = bl.all_outgoings(date1.Value.Date, date2.Value.Date);
                sum = 0;
                for (int i = 0; i < all.Rows.Count; i++)
                {
                    sum += double.Parse(all.Rows[i]["total"].ToString());
                }
                textBox1.Text = sum.ToString();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            }
        }
    }
}
