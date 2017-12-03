using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM
{
    class General
    {
        //获取

        //Department_E4
        public void comboxGet<T>(System.Windows.Forms.ComboBox combobox, string table,int x) where T : Isome, new()
        {
            #region
            List<T> Tlist = new List<T>();
            string sql = @"select * from "+table;
            //   SqlParameter p1 = new SqlParameter("@pid", SqlDbType.VarChar, 20) { Value = DepTextBox.Text.Trim() };

            using (SqlDataReader rd = SqlHelper.ExcuteReader(sql))
            {
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        T dpt = new T();
                        dpt.Name = rd.GetString(x);
                        //     dpt.ShortName = rd.GetString(2);
                        //     dpt.Description = rd.GetString(3);
                        //    dpt.CostCenter = rd.GetString(4);
                        Tlist.Add(dpt);


                    }
                }

            }
            foreach (var item in Tlist)
            {
                combobox.Items.Add(item.Name);
            }
            Tlist.Clear();
            #endregion
        }
    }

    interface Isome
    {
         string Name { get; set; }

    }

    
}
