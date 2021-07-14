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
    public partial class all_mony : Form
    {
        BL.buy_orders bl = new BL.buy_orders();
        BL.car b = new BL.car();
        BL.sell_order c = new BL.sell_order();
        public all_mony()
        {
            InitializeComponent();

            try
            {


                DataTable d = new DataTable();
                d = bl.all_buy_order();
                double take = 0;
                for (int i = 0; i < d.Rows.Count; i++)
                {
                    if (d.Rows[i]["الاجمالي"].ToString()!="")
                    take += double.Parse(d.Rows[i]["الاجمالي"].ToString());
                }


                //outgoings calculations
                BL.emplyees all_emp = new BL.emplyees();
                d = all_emp.outgoing_mony();

                for (int i = 0; i < d.Rows.Count;i++)
                {
                    if (d.Rows[i]["total"].ToString() != "")
                    take += double.Parse(d.Rows[i]["total"].ToString());
                }

                    d = b.all_car_orders();

                double add = 0;
                for (int i = 0; i < d.Rows.Count; i++)
                {
                    if (d.Rows[i]["total"].ToString() != "")
                    add += double.Parse(d.Rows[i]["total"].ToString());
                }
                d=c.sell_order_mony();
                double sell_mony = 0;
                for (int i = 0; i < d.Rows.Count;i++)
                {
                    if (d.Rows[i]["total"].ToString() != "")
                    sell_mony += double.Parse(d.Rows[i]["total"].ToString());
                }
                add += sell_mony;
                    total.Text = (add - take).ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void all_mony_Load(object sender, EventArgs e)
        {

        }
    }
}
