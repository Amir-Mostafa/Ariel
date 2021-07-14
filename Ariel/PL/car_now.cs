using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ariel.PL
{
    
    public partial class car_now : Form
    {
        public int c = 0;
        BL.products bl = new BL.products();
        BL.buy_orders b = new BL.buy_orders();

        int mov, mx, my;
        public car_now()
        {
            InitializeComponent();
            try
            {
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
                

                
                
                //timer1.Start();

                




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            //label1.BackColor = Color.Black;
            //label1.ForeColor = Color.Red;
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            //label1.BackColor = Color.Red;
            //label1.ForeColor = Color.Black;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            mx = e.X;
            my = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            //    {
            //        string val = dataGridView1.Rows[i].Cells[2].Value.ToString();
            //        if (val != "")
            //        {
            //            double x = double.Parse(val);

            //            int v = 0;
            //            if (dataGridView1.CurrentRow.Cells[9].Value.ToString() != "")
            //                v = int.Parse(dataGridView1.CurrentRow.Cells[9].Value.ToString());

            //            if (x <= v)
            //                dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Red;

            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void car_now_Load(object sender, EventArgs e)
        {

                DataTable d = bl.all(name.Text);
                dataGridView1.DataSource = d;

            dataGridView1.Columns["السعر"].Visible = false;
            dataGridView1.Columns["min_amount"].Visible = false;

            dataGridView1.Columns["الكميه في سياره 3"].Visible = false;
            dataGridView1.Columns["مبيعات 3"].Visible = false;
            dataGridView1.Columns["جرد 3"].Visible = false;

            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    string val = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    if (val != "")
                    {
                        double x = double.Parse(val);

                        int v = 0;
                        if (dataGridView1.Rows[i].Cells[13].Value.ToString() != "")
                            v = int.Parse(dataGridView1.Rows[i].Cells[13].Value.ToString());

                        if (x <= v)
                            dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                        // MessageBox.Show(v.ToString() + "////" + x.ToString());

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //try
            //{
            //    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            //    {
            //        string val = dataGridView1.Rows[i].Cells[2].Value.ToString();
            //        if (val != "")
            //        {
            //            double x = double.Parse(val);

            //            int v = 0;
            //            if (dataGridView1.CurrentRow.Cells[9].Value.ToString() != "")
            //                v = int.Parse(dataGridView1.CurrentRow.Cells[9].Value.ToString());

            //            if (x <= v)
            //                dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Red;

            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            //c++;
            //if(c==10)
            //{
            //    timer1.Stop();
            //}
        }

        private void name_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable d = bl.all(name.Text);
                dataGridView1.DataSource = d;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    string val = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    if (val != "")
                    {
                        double x = double.Parse(val);

                        int v = 0;
                        if (dataGridView1.Rows[i].Cells[13].Value.ToString() != "")
                            v = int.Parse(dataGridView1.Rows[i].Cells[13].Value.ToString());

                        if (x <= v)
                            dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                       // MessageBox.Show(v.ToString() + "////" + x.ToString());

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                double num;
                if(double.TryParse(dataGridView1.CurrentCell.Value.ToString(),out num) )
                {
                    int num_in_packet;
                    DataTable d = b.select_product_by_id(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                    if (d.Rows[0]["num_in_packet"].ToString() != "")
                        num_in_packet = int.Parse(d.Rows[0]["num_in_packet"].ToString());
                    else
                        num_in_packet = 0;

                    int p = (int)double.Parse(dataGridView1.CurrentCell.Value.ToString());

                    double s = Math.Round((double.Parse(dataGridView1.CurrentCell.Value.ToString()) - p)*num_in_packet);

                    packet.Text = p.ToString();
                    small.Text = s.ToString();



                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private readonly Random _random = new Random();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // creating Excel Application  
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                // creating new WorkBook within Excel application  
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                // creating new Excelsheet in workbook  
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                // see the excel sheet behind the program  
                app.Visible = true;
                // get the reference of first sheet. By default its name is Sheet1.  
                // store its reference to worksheet  
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                // changing the name of active sheet  
                worksheet.Name = "Exported from gridview";
                // storing header part in Excel  
                for (int i = 1; i < dataGridView1.Columns.Count+1; i++)
                {
                    if (dataGridView1.Columns[i-1].Visible == true)
                    worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }
                // storing Each row and column value to excel sheet  
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        if(dataGridView1.Columns[j].Visible==true)
                        worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
                // save the application  
                string path="D:\\Ariel\\dayys";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
              //  MessageBox.Show(path + "\\" + _random.Next() + DateTime.Now.TimeOfDay.ToString().Replace(':', '-') + " - " +
                    //DateTime.Now.ToShortDateString().Replace('/', '-') + " - " + DateTime.Now.ToLongDateString().Replace(':', '-') + ".xls");
                workbook.SaveAs(path+"\\" +_random.Next()+"_"+ DateTime.Now.TimeOfDay.ToString().Replace(':', '-') + " - " +
                    DateTime.Now.ToShortDateString().Replace('/', '-') + " - " + DateTime.Now.ToLongDateString().Replace(':', '-') + ".xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                 //Exit from the application  
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
