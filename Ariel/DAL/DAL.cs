using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Windows.Forms;
namespace Ariel.DAL
{
    class DataAccesLier
    {
        SqlConnection cn;
        public DataAccesLier()
        {
            string mode = Properties.Settings.Default.mode;
            if (mode == "SQL")
            {
                cn = new SqlConnection(@"data source=" + Properties.Settings.Default.server +
                    ";initial catalog=" + Properties.Settings.Default.database +
                    ";integrated security=false;User ID=" + Properties.Settings.Default.id
                    + ";Password=" + Properties.Settings.Default.password + "");
                //cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\mosta\OneDrive\Documents\Visual Studio 2013\Projects\amir mostafa\amir mostafa\db\Database1.mdf;Integrated Security=True");
            }
            else
            {
                //cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\mosta\OneDrive\Documents\Visual Studio 2013\Projects\amir mostafa\amir mostafa\db\Database1.mdf;Integrated Security=True");
                cn = new SqlConnection(@"data source=" + Properties.Settings.Default.server +
                   ";initial catalog=" + Properties.Settings.Default.database +
                   ";integrated security=true");
            }

            //if(!is_connect())
            //{
            //    string path = Path.GetFullPath(Environment.CurrentDirectory);
            //    MessageBox.Show(path);
            //    cn = new SqlConnection(@"data source=."+
            //      ";initial catalog=master"+
            //      ";integrated security=true");
            //    string q = "CREATE DATABASE Ariel_pro ON ( FILENAME =" + path + @"\Ariel_pro.mdf' ),( FILENAME = " + path + @"\Ariel_pro_log.ldf' )FOR ATTACH";
            //    if(is_connect())
            //    {
            //        SqlCommand com = new SqlCommand();
            //        com.CommandType = CommandType.Text;
            //        com.CommandText = q;
            //        com.Connection = cn;
            //        com.ExecuteNonQuery();

            //    }
            //}
            
        }
        //method for open connection
        public void open()
        {
            if (cn.State != ConnectionState.Open)
                cn.Open();
        }
        //method for close connection
        public void close()
        {
            if (cn.State != ConnectionState.Closed)
                cn.Close();
        }
        //method select data from database
        public DataTable selectdata(string stord_proc, SqlParameter[] param)
        {
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = stord_proc;
            com.Connection = cn;
            if (param != null)
            {
                for (int i = 0; i < param.Length; i++)
                    com.Parameters.Add(param[i]);
            }
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        //methid insert update delete 
        public void executenonquery(string stored_proc, SqlParameter[] param)
        {
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = stored_proc;
            com.Connection = cn;
            if (param != null)
                com.Parameters.AddRange(param);
            com.ExecuteNonQuery();
        }

        public bool is_connect()
        {
            try
            {
                cn.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }

}
