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
    public partial class repors_sell : Form
    {
        BL.buy_orders bl = new BL.buy_orders();
        public repors_sell()
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
        }

        private void repors_sell_Load(object sender, EventArgs e)
        {
            try
            {
                double sum=0;
                DataTable d = bl.reort_buy_orders(report_sell.R_S.date1.Value.Date, report_sell.R_S.date2.Value.Date);
                dataGridView1.DataSource = d;
                for(int i=0 ;i<d.Rows.Count;i++)
                {
                    if ((d.Rows[i]["الاجمالي"].ToString())!="")
                    sum += double.Parse(d.Rows[i]["الاجمالي"].ToString());
                }
                bunifuMetroTextbox1.Text = sum.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
