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
    public partial class products_report : Form
    {
        BL.products bl = new BL.products();
        public DataTable g = new DataTable();
        public products_report()
        {
            InitializeComponent();
            g.Columns.Add("رقم الصنف");
            g.Columns.Add("اسم الصنف");
            g.Columns.Add("المشتريات");
            g.Columns.Add("المبيعات");
            g.Columns.Add("سحب سياره 1");
            g.Columns.Add("سحب سياره 2");
            g.Columns.Add("سحب سياره 3");
            g.Columns.Add("سحب المحل");
            dataGridView1.DataSource = g;


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

        private void products_report_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable d = bl.all("");
                for(int i=0;i<d.Rows.Count;i++)
                {
                    DataRow r = g.NewRow();
                    r[0] = d.Rows[i]["رقم الصنف"].ToString();
                    r[1] = d.Rows[i]["اسم الصنف"].ToString();
                    int product_id = int.Parse(d.Rows[i]["رقم الصنف"].ToString());
                    DataTable buy= bl.buy_operations_by_product_id(product_id, products_repor_date.p_r.date1.Value.Date, products_repor_date.p_r.date2.Value.Date);
                    double buy_amount = 0;
                    for(int j=0;j<buy.Rows.Count;j++)
                    {
                        buy_amount += double.Parse(buy.Rows[j]["amount"].ToString());
                    }
                    r[2] = buy_amount.ToString();
                    DataTable sell = bl.sell_operations_by_product_id(product_id, products_repor_date.p_r.date1.Value.Date, products_repor_date.p_r.date2.Value.Date);
                    double sell_amount = 0;
                    for (int j = 0; j < sell.Rows.Count; j++)
                    {
                        sell_amount += double.Parse(sell.Rows[j]["amount"].ToString());
                    }
                    r[3] = sell_amount.ToString();

                    DataTable sell_carr = bl.sell_operations_by_product_id_in_car(product_id, 1,products_repor_date.p_r.date1.Value.Date, products_repor_date.p_r.date2.Value.Date);
                    double sell_amount_in_car = 0;
                    for (int j = 0; j < sell_carr.Rows.Count; j++)
                    {
                        sell_amount_in_car += double.Parse(sell_carr.Rows[j]["amount"].ToString());
                    }
                    r[4] = sell_amount_in_car.ToString();

                    sell_carr = bl.sell_operations_by_product_id_in_car(product_id, 3, products_repor_date.p_r.date1.Value.Date, products_repor_date.p_r.date2.Value.Date);
                     sell_amount_in_car = 0;
                    for (int j = 0; j < sell_carr.Rows.Count; j++)
                    {
                        sell_amount_in_car += double.Parse(sell_carr.Rows[j]["amount"].ToString());
                    }
                    r[5] = sell_amount_in_car.ToString();


                    sell_carr = bl.sell_operations_by_product_id_in_car(product_id, 4, products_repor_date.p_r.date1.Value.Date, products_repor_date.p_r.date2.Value.Date);
                    sell_amount_in_car = 0;
                    for (int j = 0; j < sell_carr.Rows.Count; j++)
                    {
                        sell_amount_in_car += double.Parse(sell_carr.Rows[j]["amount"].ToString());
                    }
                    r[6] = sell_amount_in_car.ToString();


                    sell_carr = bl.sell_operations_by_product_id_in_car( product_id,2, products_repor_date.p_r.date1.Value.Date, products_repor_date.p_r.date2.Value.Date);
                     sell_amount_in_car = 0;
                    for (int j = 0; j < sell_carr.Rows.Count; j++)
                    {
                        sell_amount_in_car += double.Parse(sell_carr.Rows[j]["amount"].ToString());
                    }
                    r[7] = sell_amount_in_car.ToString();

                    g.Rows.Add(r);

                }
                dataGridView1.DataSource = g;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
