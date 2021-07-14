using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Ariel.BL
{
    class sell_order
    {
        DAL.DataAccesLier DAL=new DAL.DataAccesLier();
        public DataTable all_clints()
        {

            return DAL.selectdata("all_clints", null);

        }
        public DataTable get_all_order(string id)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.NVarChar,50);
            param[0].Value = id;
            return DAL.selectdata("get_all_order", param);

        }
        public DataTable max_sell_order()
        {

            return DAL.selectdata("max_sell_order", null);

        }
        public void sell_order_head(int id, int clint_id, DateTime time,string total)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = id;
            param[1] = new SqlParameter("@clint_id", SqlDbType.Int);
            param[1].Value = clint_id;
            param[2] = new SqlParameter("@time", SqlDbType.DateTime);
            param[2].Value = time;
            param[3] = new SqlParameter("@total", SqlDbType.NVarChar,50);
            param[3].Value = total;
            DAL.open();
            DAL.executenonquery("sell_order_head", param);
            DAL.close();
        }
        public void sell_operations(int id, int clint_id, int product_id, string amount, DateTime time)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = id;
            param[1] = new SqlParameter("@clint_id", SqlDbType.Int);
            param[1].Value = clint_id;
            param[2] = new SqlParameter("@product_id", SqlDbType.Int);
            param[2].Value = product_id;
            param[3] = new SqlParameter("@amount", SqlDbType.NVarChar,20);
            param[3].Value = amount;
            param[4] = new SqlParameter("@time", SqlDbType.DateTime);
            param[4].Value = time;
            DAL.open();
            DAL.executenonquery("add_sell_operations", param);
            DAL.close();
        }
        public void update_sell_order(int id, int clint_id, DateTime time ,string total)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = id;
            param[1] = new SqlParameter("@clint_id", SqlDbType.Int);
            param[1].Value = clint_id;
            param[2] = new SqlParameter("@time", SqlDbType.DateTime);
            param[2].Value = time;
            param[3] = new SqlParameter("@total", SqlDbType.NVarChar,50);
            param[3].Value = total;
            DAL.open();
            DAL.executenonquery("update_sell_order", param);
            DAL.close();
        }
        public DataTable get_sell_operations(int id)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = id;
            return DAL.selectdata("get_sell_operations", param);
            
        }
        public void delete_sell_operations(int id)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = id;
            DAL.open();
            DAL.executenonquery("delete_sell_operations", param);
            DAL.close();
        }
        public void delete_sell_order(int id)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = id;
            DAL.open();
            DAL.executenonquery("delete_sell_order", param);
            DAL.close();
        }
        public DataTable sell_operations_arabic(int id)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = id;
            return DAL.selectdata("sell_operations_arabic", param);

        }
        public DataTable sell_order_by_id(int id)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = id;
            return DAL.selectdata("sell_order_by_id", param);

        }
        public DataTable sell_order_mony()
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();

            return DAL.selectdata("sell_order_mony", null);

        }
 
        public DataTable print_order(int id)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = id;
            return DAL.selectdata("print_order", param);

        }

    }
}
