using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace EM
{
    public static class SqlHelper
    {
        public static readonly string Constr = ConfigurationManager.ConnectionStrings["mssqlserver"].ConnectionString;
       // public static readonly string Constr = ConfigurationManager.ConnectionStrings["connection2"].ConnectionString;

        public static int ExcuteNonQuery(string sql, params SqlParameter[] pms)  //for insert delete update
        {
            using (SqlConnection con = new SqlConnection(Constr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }

        }

        public static object ExcuteScalar(string sql, params SqlParameter[] pms)  //for insert delete update
        {
            using (SqlConnection con = new SqlConnection(Constr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteScalar();
                }
            }

        }


        public static SqlDataReader ExcuteReader(string sql, params SqlParameter[] pms)
        {

            SqlConnection con = new SqlConnection(Constr);

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                if (pms != null)
                {
                    cmd.Parameters.AddRange(pms);
                }
                try
                {
                    con.Open();
                    return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
                catch
                {

                    con.Close();
                    con.Dispose();
                    throw;
                    
                }

            }
        }
    }
}

