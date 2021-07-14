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
    public partial class mony : Form
    {
        public mony()
        {
            InitializeComponent();
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

            try
            {
                BL.products bl = new BL.products();
                dataGridView1.DataSource = bl.select_products_for_mony();
                double sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    double x = 0, y = 0, p = 0;
                    if (dataGridView1.Rows[i].Cells[1].Value.ToString() != "")
                        x = double.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                    //if (dataGridView1.Rows[i].Cells[2].Value.ToString() != "")
                    //    y = double.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());

                    if (dataGridView1.Rows[i].Cells[2].Value.ToString() != "")
                        p = double.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                    sum += (x) * p;
                    dataGridView1.Rows[i].Cells[2].Value = ((x) * p).ToString();
                }
                total.Text = sum.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void mony_Load(object sender, EventArgs e)
        {

        }
    }
}
