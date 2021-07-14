using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
namespace Ariel.PL
{
    public partial class take_path : Form
    {
        SqlConnection cn;
        public take_path()
        {
            InitializeComponent();
            string mode = Properties.Settings.Default.mode;
            if (mode == "SQL")
            {
                cn = new SqlConnection(@"data source=" + Properties.Settings.Default.server +
                    ";initial catalog=" + Properties.Settings.Default.database +
                    ";integrated security=false;User ID=" + Properties.Settings.Default.id
                    + ";Password=" + Properties.Settings.Default.password + "");
            }
            else
            {
                cn = new SqlConnection(@"data source=" + Properties.Settings.Default.server +
                    ";initial catalog=" + Properties.Settings.Default.database +
                    ";integrated security=true");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string file_name = textBox1.Text + "\\" + Properties.Settings.Default.database + DateTime.Now.TimeOfDay.ToString().Replace(':', '-') + " - " +
                    DateTime.Now.ToShortDateString().Replace('/', '-') + " - " + DateTime.Now.ToLongDateString().Replace(':', '-');
                string query = "Backup Database " + Properties.Settings.Default.database + " to Disk='" + file_name + ".Bak'";
                SqlCommand com = new SqlCommand(query, cn);
                cn.Open();
                com.ExecuteNonQuery();
                MessageBox.Show("تم انشاء نسخه");
                this.Hide();
                textBox1.Text = "";
                //SaveFileDialog sf = new SaveFileDialog();
                //sf.Filter = "Backup Files (*.Bak)|*.bak";
                //if (sf.ShowDialog() == DialogResult.OK)
                //{
                //    SqlCommand cm = new SqlCommand("Backup Database tamwin to Disk='"+sf.FileName+"'", cn);
                //    cn.Open();
                //    cm.ExecuteNonQuery();
                //    cn.Close();
                //}
                //MessageBox.Show("تم بنجاح");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            DialogResult = f.ShowDialog();
            if (DialogResult == DialogResult.OK)
            {
                textBox1.Text = f.SelectedPath;
            }
        }

        private void take_path_Load(object sender, EventArgs e)
        {
        }
    }
}
