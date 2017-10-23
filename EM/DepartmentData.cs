using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EM
{
    public partial class DepartmentData : UserControl
    {
        public DepartmentData()
        {
            InitializeComponent();
        }

        private void Read_Click(object sender, EventArgs e)
        {

            //string sql = @"select * from (
            //            Department_E4
            //            inner join DepartmentGroup_E4_E5 
            //            on DepartmentGroup_E4_E5.Department_E4_ID=Department_E4.AutoID
            //            )
            //                    inner join Group_E5 
            //        on DepartmentGroup_E4_E5.Group_E5_ID=Group_E5.AutoID
            //        inner join E5_Team
            //        on E5_Team.Group_E5_ID=Group_E5.AutoID
            //        where Department_E4.Name= @pid
            //               ";
            //List<Department> DepList = new List<Department>();
            //string sql = @"select * from Department_E4  where Department_E4.Name= @pid";
            //SqlParameter p1 = new SqlParameter("@pid", SqlDbType.VarChar, 20) { Value = DepTextBox.Text.Trim() };

            //using (SqlDataReader rd = SqlHelper.ExcuteReader(sql, p1))
            //{
            //    if (rd.HasRows)
            //    {
            //        while (rd.Read())
            //        {
            //            Department dpt = new Department();
            //            dpt.Name = rd.GetString(1);
            //            dpt.ShortName = rd.GetString(2);
            //            dpt.Description = rd.GetString(3);
            //            dpt.CostCenter = rd.GetString(4);
            //            DepList.Add(dpt);
            //        }
            //    }

            //}
            //dataGridView1.DataSource = DepList;

        }

        private void treeview_Click(object sender, EventArgs e)
        {
          
        }

        private void DepartmentData_Load(object sender, EventArgs e)
        {
            List<Department> DepList = new List<Department>();
            string sql = @"select * from Department_E4 ";
            //   SqlParameter p1 = new SqlParameter("@pid", SqlDbType.VarChar, 20) { Value = DepTextBox.Text.Trim() };

            try
            {
                using (SqlDataReader rd = SqlHelper.ExcuteReader(sql))
                {
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            Department dpt = new Department();
                            dpt.Name = rd.GetString(1);
                            dpt.ShortName = rd.GetString(2);
                            dpt.Description = rd.GetString(3);
                            dpt.CostCenter = rd.GetString(4);
                            DepList.Add(dpt);


                        }
                    }

                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            foreach (var item in DepList)
            {
                // node0.Nodes.Contains()

              TreeNode node0= treeView1.Nodes.Add(item.Name);        //第一级，获取到Depatment
                node0.Tag = "Department";
                List<Group> grplist = GetGroup(node0.Text);
                foreach (var Gitem in grplist)
                {
                    TreeNode node1 = node0.Nodes.Add(Gitem.Name);   //第二级，获取到Group；
                    node1.Tag = "Group";
                    List<Team> TeamList = GetTeam(Gitem.Name);
                    foreach (var Titem in TeamList)
                    {
                        TreeNode node2 = node1.Nodes.Add(Titem.Name); //第三级，获取到Team
                        node2.Tag = "Team";
                    }
                   
                    
                }


                //  node0.Nodes.Add("123");
                //  node0.Tag = 0;


                treeView1.ExpandAll();
            }

           
        }
        /// <summary>
        /// 根据指定的Department获取到对应的group
        /// </summary>
        /// <param name="ParentString"></param>
        /// <returns></returns>
        public List<Group> GetGroup(String ParentString) 
        {
            List<Group> GroupList = new List<Group>();
            string sql = @"     select Group_E5.Name,Group_E5.ShortName,Group_E5.Descriptions from Department_E4
     inner join DepartmentGroup_E4_E5 
     on Department_E4.AutoID=DepartmentGroup_E4_E5.Department_E4_ID  
     inner join Group_E5
     on DepartmentGroup_E4_E5.Group_E5_ID=Group_E5.AutoID     
     where Department_E4.Name=@pid";
            SqlParameter p1 = new SqlParameter("@pid", SqlDbType.VarChar, 20) { Value = ParentString };

            using (SqlDataReader rd = SqlHelper.ExcuteReader(sql,p1))
            {
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        Group grp = new Group();
                        grp.Name = rd.GetString(0);
                        if (rd.GetValue(1).ToString()!="")
                        {
                            grp.ShortName = rd.GetString(1);
                        }
                        if (rd.GetValue(2).ToString()!="")
                        {
                            grp.Description = rd.GetString(2);
                        }
                      
                      
                        GroupList.Add(grp);


                    }
                }

                return GroupList;
            }

        }

        /// <summary>
        /// 根据制定的Group名称获取到对应的Team
        /// </summary>
        /// <param name="ParentString"></param>
        /// <returns></returns>
        public List<Team> GetTeam(String ParentString)
        {
            List<Team> TeamList = new List<Team>();
            string sql = @" select Team.Name,Team.Short_Name,Team.Descriptions from Group_E5 
     inner join E5_Team
     on Group_E5.AutoID=E5_Team.Group_E5_ID
     inner join Team
     on E5_Team.Team_ID=Team.AutoID 
     where Group_E5.Name=@pid";
            SqlParameter p1 = new SqlParameter("@pid", SqlDbType.VarChar, 20) { Value = ParentString };

            using (SqlDataReader rd = SqlHelper.ExcuteReader(sql, p1))
            {
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        Team team = new Team();
                        team.Name = rd.GetString(0);
                        if (rd.GetValue(1).ToString()!="")
                        {
                            team.ShortName = rd.GetString(1);
                        }
                        if (rd.GetValue(2).ToString()!="")
                        {
                            team.Description = rd.GetString(2);
                        }
                        

                        TeamList.Add(team);


                    }
                }

                return TeamList;
            }

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode!=null)
            {
                switch (treeView1.SelectedNode.Tag.ToString())
                {

                    case "Department":

                       
                        break;
                    case "Group":
                        break;
                    case "Team":
                        #region
                        //List<Person> PersonList = new List<Person>();
                        //string sql = @"   select Person_P.company_ID,Person_P.First_Name,Person_P.Family_Name,Person_P.Call_Name,Person_P.BBAC,Person_P.BAIC,Person_P.Daimler,Person_P.Supplier,Person_P.L_ID from Team
                        //                  inner join Team_P
                        //                  on Team.AutoID=Team_P.Team_ID
                        //                  inner join Person_P
                        //                  on Team_P.P_ID=Person_P.AutoID
                        //                  where Team.Name=@pid";
                        //SqlParameter p1 = new SqlParameter("@pid", SqlDbType.VarChar, 20) { Value = treeView1.SelectedNode.Text };

                        //using (SqlDataReader rd = SqlHelper.ExcuteReader(sql, p1))
                        //{
                        //    if (rd.HasRows)
                        //    {
                        //        while (rd.Read())
                        //        {                                    
                        //            Person person = new Person();
                        //            person.Company_ID = rd.GetString(0);
                        //            person.First_Name = rd.GetString(1);
                        //            person.Family_Name = rd.GetString(2);
                        //            person.Call_Name = rd.GetString(3);
                        //            person.BBAC = rd.GetBoolean(4);
                        //            person.BAIC = rd.GetBoolean(5);
                        //            person.Daimler = rd.GetBoolean(6);
                        //            person.Supplier = rd.GetBoolean(7);
                        //            person.L_ID = Convert.ToInt32(rd.GetValue(8));
                        //            PersonList.Add(person);
                        //        }
                        //    }
                        //}
                        //dataGridView1.DataSource = PersonList;

                        //string sql = @"   select Person_P.company_ID,Person_P.First_Name,Person_P.Family_Name,Person_P.Call_Name,Person_P.BBAC,Person_P.BAIC,Person_P.Daimler,Person_P.Supplier,Person_P.L_ID from Team
                        //                  inner join Team_P
                        //                  on Team.AutoID=Team_P.Team_ID
                        //                  inner join Person_P
                        //                  on Team_P.P_ID=Person_P.AutoID
                        //                  where Team.Name=@pid";
                        //select(sql);
                        #endregion
                        string sql = @"   select Person_P.company_ID,Person_P.First_Name,Person_P.Family_Name,Person_P.Call_Name,Person_P.BBAC,Person_P.BAIC,Person_P.Daimler,Person_P.Supplier,Person_P.L_ID from Team
                                          inner join Team_P
                                          on Team.AutoID=Team_P.Team_ID
                                          inner join Person_P
                                          on Team_P.Direct_Member_P_ID=Person_P.AutoID
                                          where Team.Name=@pid";
                        select(sql);

                        break;
                    default :
                        break;
                }
            }
        }

        private void select(string sql)
        {
            List<Person> PersonList = new List<Person>();
          
            SqlParameter p1 = new SqlParameter("@pid", SqlDbType.VarChar, 20) { Value = treeView1.SelectedNode.Text };

            try
            { using (SqlDataReader rd = SqlHelper.ExcuteReader(sql, p1))
                {
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            Person person = new Person();
                            if (rd.GetValue(0).ToString()!="")
                            {
                                person.Company_ID = rd.GetString(0);
                            }
                           
                            person.First_Name = rd.GetString(1);
                            person.Family_Name = rd.GetString(2);
                            person.Call_Name = rd.GetString(3);
                            person.BBAC = rd.GetBoolean(4);
                            person.BAIC = rd.GetBoolean(5);
                            person.Daimler = rd.GetBoolean(6);
                            person.Supplier = rd.GetBoolean(7);
                            person.L_ID = Convert.ToInt32(rd.GetValue(8));
                            PersonList.Add(person);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataGridView1.DataSource = PersonList;
        }

    }
}
