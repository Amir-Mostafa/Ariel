using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace Ariel.BL
{
    class emplyees
    {
        DAL.DataAccesLier DAL = new DAL.DataAccesLier();
        public void add_emp(string name)
        {
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@emp_name", SqlDbType.NVarChar, 50);
            param[0].Value = name;
            DAL.open();
            DAL.executenonquery("add_emp", param);
            DAL.close();

        }

        public DataTable all_emp()
        {
            return DAL.selectdata("all_emp", null);
        }

        public void add_outgoings(int emp_id,DateTime date,string total,string desc)
        {
            SqlParameter[] param = new SqlParameter[4];

            param[0] = new SqlParameter("@emp_id", SqlDbType.Int);
            param[0].Value = emp_id;
            param[1] = new SqlParameter("@date", SqlDbType.DateTime);
            param[1].Value = date;

            param[2] = new SqlParameter("@total", SqlDbType.NVarChar, 50);
            param[2].Value = total;

            param[3] = new SqlParameter("@desc", SqlDbType.NVarChar, 50);
            param[3].Value = desc;
            DAL.open();
            DAL.executenonquery("add_outgoings", param);
            DAL.close();

        }

        public DataTable emp_report(int emp_id, DateTime date1,DateTime date2)
        {
            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@emp_id", SqlDbType.Int);
            param[0].Value = emp_id;
            param[1] = new SqlParameter("@date1", SqlDbType.DateTime);
            param[1].Value = date1;

            param[2] = new SqlParameter("@date2", SqlDbType.DateTime);
            param[2].Value = date2;

            return DAL.selectdata("emp_report", param);

        }
        public DataTable all_outgoings(DateTime date1,DateTime date2)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@date1", SqlDbType.DateTime);
            param[0].Value = date1;

            param[1] = new SqlParameter("@date2", SqlDbType.DateTime);
            param[1].Value = date2;

            return DAL.selectdata("all_outgoings",param);
        }

        public DataTable outgoing_mony()
        {


            return DAL.selectdata("outgoing_mony", null);
        }

        public DataTable delete_outgoing(int id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
            return DAL.selectdata("delete_outgoing", param);
        }

    }
}
