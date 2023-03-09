using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace PM.BL
{
    class CLS_ORDERS
    {
        public DataTable GET_LAST_ORDER_ID()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            Dt = DAL.selectdata("GET_LAST_ORDER_ID", null);
            DAL.Close();
            return Dt;

        }
        public void ADD_ORDER(int ID_ORDER, DateTime DATE_ORDER, int CUSTUMER_ID
            , string DESCRIPTION_ORDER, string SALESMAN, string ORDER_TYPE)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@ID_ORDER", SqlDbType.Int);
            param[0].Value = ID_ORDER;

            param[1] = new SqlParameter("@DATE_ORDER", SqlDbType.DateTime);
            param[1].Value = DATE_ORDER;

            param[2] = new SqlParameter("@CUSTUMER_ID", SqlDbType.Int);
            param[2].Value = CUSTUMER_ID;

            param[3] = new SqlParameter("@DESCRIPTION_ORDER", SqlDbType.VarChar, 250);
            param[3].Value = DESCRIPTION_ORDER;

            param[4] = new SqlParameter("@SALESMAN", SqlDbType.VarChar, 75);
            param[4].Value = SALESMAN;

            param[5] = new SqlParameter("@ORDER_TYPE", SqlDbType.VarChar, 50);
            param[5].Value = ORDER_TYPE;

            DAL.ExecuteCommand("ADD_ORDER", param);
            DAL.Close();

        }
        public void ADD_ORDER_DETAILS(string ID_PRODUCT, int ID_ORDER, int QTE, string ORDER_TYPE)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@ID_PRODUCT", SqlDbType.VarChar,30);
            param[0].Value = ID_PRODUCT;

            param[1] = new SqlParameter("@ID_ORDER", SqlDbType.Int);
            param[1].Value = ID_ORDER;

            param[2] = new SqlParameter("@QTE", SqlDbType.Int);
            param[2].Value = QTE;

            param[3] = new SqlParameter("@ORDER_TYPE", SqlDbType.VarChar,50);
            param[3].Value = ORDER_TYPE;

            DAL.ExecuteCommand("ADD_ORDER_DETAILS", param);
            DAL.Close();

        }
        public DataTable VerifyQty(string ID_PRODUCT, int Qty_Entered)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ID_PRODUCT", SqlDbType.VarChar, 30);
            param[0].Value = ID_PRODUCT;

            param[1] = new SqlParameter("@Qty_Entered", SqlDbType.Int);
            param[1].Value = Qty_Entered;
            dt = DAL.selectdata("VerifyQty", param);
            DAL.Close();
            return dt;
        }
        public DataTable SearchOrders(string Criterion)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Criterion", SqlDbType.VarChar, 50);
            param[0].Value = Criterion;
            dt = DAL.selectdata("SearchOrders", param);
            DAL.Close();
            return dt;
        }
        public DataTable SearchOrdersR(string Criterion)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Criterion", SqlDbType.VarChar, 50);
            param[0].Value = Criterion;
            dt = DAL.selectdata("SearchOrdersR", param);
            DAL.Close();
            return dt;
        }
        public DataTable SearchOrdersD(string Criterion)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Criterion", SqlDbType.VarChar, 50);
            param[0].Value = Criterion;
            dt = DAL.selectdata("SearchOrdersD", param);
            DAL.Close();
            return dt;
        }
        public DataTable DestructionProcess(string Criterion)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Criterion", SqlDbType.VarChar, 50);
            param[0].Value = Criterion;
            dt = DAL.selectdata("DestructionProcess", param);
            DAL.Close();
            return dt;
        }
    }
}
