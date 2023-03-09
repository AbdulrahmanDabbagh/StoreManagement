using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//allow using sql server
using System.Data.SqlClient;
//allow using data container
using System.Data;

namespace PM.DAL
{
    class DataAccessLayer
    {
        SqlConnection sqlconnection;
        //this constructor int the connection object
        public DataAccessLayer()
        {
            try
            {
                string mode = Properties.Settings.Default.Mode;
                if (mode == "SQL")
                {
                    sqlconnection = new SqlConnection("server=" + Properties.Settings.Default.Server + "; Database=" + Properties.Settings.Default.Database +
                        "; Integrated Security = flase; User ID=" + Properties.Settings.Default.ID + ";Password=" + Properties.Settings.Default.Password + "");
                }
                else
                {
                    sqlconnection = new SqlConnection("server=" + Properties.Settings.Default.Server + "; Database=" + Properties.Settings.Default.Database + "; Integrated Security = true");
                }
            }
            catch
            {
                Environment.Exit(0);
            }
        }

        //method to open the connection

        public void Open()
        {
            if (sqlconnection.State != ConnectionState.Open)
            {
                sqlconnection.Open();
            }
        }

        //method to close the connection

        public void Close()
        {
            if (sqlconnection.State == ConnectionState.Open)
            {
                sqlconnection.Close();
            }
        }
        //method to read data from database

        public DataTable selectdata(string stored_procedure , SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_procedure;
            sqlcmd.Connection = sqlconnection;

            if (param != null)
            {
                for(int i = 0; i<param.Length;i++)
                {
                    sqlcmd.Parameters.Add(param[i]);
                }
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        //method to insert , update , delete data from database
        public void ExecuteCommand(string stored_procedure , SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_procedure;
            sqlcmd.Connection = sqlconnection;

            if(param != null)
            {
                sqlcmd.Parameters.AddRange(param);

            }
            sqlcmd.ExecuteNonQuery();
        }
    }
}
