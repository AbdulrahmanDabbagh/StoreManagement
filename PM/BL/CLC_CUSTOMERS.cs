using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PM.BL
{
    class CLC_CUSTOMERS
    {
        public void ADD_CUSTOMERS(string First_Name, string Last_Name)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@FIRST_NAME", SqlDbType.VarChar, 25);
            param[0].Value = First_Name;
            param[1] = new SqlParameter("@LAST_NAME", SqlDbType.VarChar, 25);
            param[1].Value = Last_Name;
            DAL.ExecuteCommand("ADD_CUSTOMERS", param);
            DAL.Close();

        }
        public void EDIT_CUSTOMERS(string First_Name, string Last_Name, int ID)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@FIRST_NAME", SqlDbType.VarChar, 25);
            param[0].Value = First_Name;
            param[1] = new SqlParameter("@LAST_NAME", SqlDbType.VarChar, 25);
            param[1].Value = Last_Name;
            param[2] = new SqlParameter("@ID", SqlDbType.Int);
            param[2].Value = ID;
            DAL.ExecuteCommand("EDIT_CUSTOMERS", param);
            DAL.Close();

        }
        public void DElETE_CUSTOMER_CUSTOMERS(int ID)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = ID;
            DAL.ExecuteCommand("DElETE_CUSTOMER", param);
            DAL.Close();

        }
        public DataTable GET_ALL_CUSTOMERS()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            Dt = DAL.selectdata("GET_ALL_CUSTOMERS", null);
            DAL.Close();
            return Dt;

        }
        public DataTable Search_Customer(string Criterion)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1]; 
            param[0] =new SqlParameter("@Criterion", SqlDbType.VarChar, 50);
            param[0].Value = Criterion;
            Dt = DAL.selectdata("Search_Customer", param);
            DAL.Close();
            return Dt;

        }
    }
}
