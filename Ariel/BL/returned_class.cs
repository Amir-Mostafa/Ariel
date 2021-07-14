using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Ariel.BL
{
    class returned_class
    {
        DAL.DataAccesLier DAL = new DAL.DataAccesLier();
        public DataTable max_returned_id()
        {

            return DAL.selectdata("max_returned_id", null);

        }

        public DataTable get_returned_order(int id)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
            return DAL.selectdata("get_returned_order", param);
        }

        public DataTable get_returned_operation(int id)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
            return DAL.selectdata("get_returned_operation", param);
        }

        public DataTable get_returned_operation_arabic(int id)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
            return DAL.selectdata("get_returned_operation_arabic", param);
        }

        public void add_returned_order(int id, int clint_id, DateTime time)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
            param[1] = new SqlParameter("@clint_id", SqlDbType.Int);
            param[1].Value = clint_id;
            param[2] = new SqlParameter("@time", SqlDbType.DateTime);
            param[2].Value = time;
            DAL.open();
            DAL.executenonquery("add_returned_order", param);
            DAL.close();
        }

        public void update_returned_order(int id, int clint_id, DateTime time)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
            param[1] = new SqlParameter("@clint_id", SqlDbType.Int);
            param[1].Value = clint_id;
            param[2] = new SqlParameter("@time", SqlDbType.DateTime);
            param[2].Value = time;
            DAL.open();
            DAL.executenonquery("update_returned_order", param);
            DAL.close();
        }

        public void delete_returned_order(int id)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
            DAL.open();
            DAL.executenonquery("delete_returned_order", param);
            DAL.close();
        }

        public void insert_returned_operation(int product_id, string amount, DateTime time,int clint_id,int order_id)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@product_id", SqlDbType.Int);
            param[0].Value = product_id;
            param[1] = new SqlParameter("@amount", SqlDbType.NVarChar,50);
            param[1].Value = amount;
            param[2] = new SqlParameter("@time", SqlDbType.DateTime);
            param[2].Value = time;
            param[3] = new SqlParameter("@clint_id", SqlDbType.Int);
            param[3].Value = clint_id;
            param[4] = new SqlParameter("@order_id", SqlDbType.Int);
            param[4].Value = order_id;
            DAL.open();
            DAL.executenonquery("insert_returned_operation", param);
            DAL.close();
        }

        public void update_returned_operation(int id,int product_id, string amount, DateTime time, int clint_id, int order_id)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
            param[1] = new SqlParameter("@product_id", SqlDbType.Int);
            param[1].Value = product_id;
            param[2] = new SqlParameter("@amount", SqlDbType.NVarChar, 50);
            param[2].Value = amount;
            param[3] = new SqlParameter("@time", SqlDbType.DateTime);
            param[3].Value = time;
            param[4] = new SqlParameter("@clint_id", SqlDbType.Int);
            param[4].Value = clint_id;
            param[5] = new SqlParameter("@order_id", SqlDbType.Int);
            param[5].Value = order_id;
            DAL.open();
            DAL.executenonquery("update_returned_operation", param);
            DAL.close();
        }

        public void delete_returned_operation(int id)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            DAL.open();
            DAL.executenonquery("delete_returned_operation", param);
            DAL.close();
        }


    }
}
