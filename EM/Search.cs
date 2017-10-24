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
    public partial class Search : UserControl
    {
        public Search()
        {
            InitializeComponent();
        }

        private void Search_Load(object sender, EventArgs e)
        {
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<PersonInfo> PersonInfoList = new List<PersonInfo>();
            string sqlLevel = @"select Person_P.AutoID,L.NameBBAC,Person_P.BAIC,Person_P.BBAC,Person_P.Daimler,Person_P.Supplier from Person_P 
                                inner join L on L.AutoID= Person_P.L_ID
                                where Person_P.First_Name=@FirstName and Person_P.Family_Name=@FamilyName";

            SqlParameter[] levelpms = new SqlParameter[]
            {
                new SqlParameter("@FirstName",SqlDbType.VarChar,20) {Value = textBoxFirstName.Text.Trim() },
                new SqlParameter("@FamilyName",SqlDbType.VarChar,20) {Value = textBoxFamilyName.Text.Trim() }
            };
            try
            {
                using (SqlDataReader rd = SqlHelper.ExcuteReader(sqlLevel, levelpms))
                {
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            PersonInfo oPersonInfo = new PersonInfo();
                            oPersonInfo.level = rd.GetString(1);
                            oPersonInfo.PersonAutoID = rd.GetInt32(0);
                            if (rd.GetBoolean(2))
                            {
                                oPersonInfo.Company = "BAIC";
                            }
                            else if (rd.GetBoolean(3))
                            {
                                oPersonInfo.Company = "BBAC";
                            }
                            else if (rd.GetBoolean(4))
                            {
                                oPersonInfo.Company = "Daimler";
                            }
                            else if(rd.GetBoolean(5))
                            {
                                oPersonInfo.Company = "Supplier";
                            }
                            else
                            {
                                oPersonInfo.Company = "DATA WRONG";
                            }
                            switch (rd.GetString(1))
                            {
                                
                                case "Blue Color" :
                                    #region BlueColor
                                    string sqlSearchTeam = @"select Team.Name from Person_P
                                                            inner join Team_P on Person_P.AutoID=Team_P.Direct_Member_P_ID or Person_P.AutoID=Team_P.Leader_P_ID 
                                                            inner join Team on Team_P.Team_ID=Team.AutoID
                                                            Where Person_P.AutoID= " + rd.GetInt32(0).ToString(); 
                                    oPersonInfo.Team = SqlHelper.ExcuteScalar(sqlSearchTeam).ToString();

                                    string sqlSearchGroup = @"select Group_E5.Name from Person_P
                                                            inner join Team_P on Person_P.AutoID=Team_P.Direct_Member_P_ID or Person_P.AutoID=Team_P.Leader_P_ID 
                                                            inner join Team on Team_P.Team_ID=Team.AutoID
                                                            inner join E5_Team on E5_Team.Team_ID=Team.AutoID
                                                            inner join Group_E5 on Group_E5.AutoID=E5_Team.Group_E5_ID
                                                            Where Person_P.AutoID= " + rd.GetInt32(0).ToString();
                                    oPersonInfo.Group = SqlHelper.ExcuteScalar(sqlSearchGroup).ToString();

                                    string sqlSearchDep = @"select Department_E4.Name from Person_P
                                                            inner join Team_P on  Person_P.AutoID=Team_P.Direct_Member_P_ID or Person_P.AutoID=Team_P.Leader_P_ID 
                                                            inner join Team on Team_P.Team_ID=Team.AutoID
                                                            inner join E5_Team on E5_Team.Team_ID=Team.AutoID
                                                            inner join Group_E5 on Group_E5.AutoID=E5_Team.Group_E5_ID
                                                            inner join DepartmentGroup_E4_E5 on DepartmentGroup_E4_E5.Group_E5_ID=Group_E5.AutoID
                                                            inner join Department_E4 on DepartmentGroup_E4_E5.Department_E4_ID=Department_E4.AutoID
                                                            Where Person_P.AutoID= " + rd.GetInt32(0).ToString();
                                    oPersonInfo.Department = SqlHelper.ExcuteScalar(sqlSearchDep).ToString();

                                    string sqlSearchPhone = @"  select  Contacts_Co.PhoneNumber,Contacts_Co.MobilePhone,Contacts_Co.Email from Contacts_Co
                                                                inner join Contacts_Linkin_Co_link on Contacts_Co.AutoID=Contacts_Linkin_Co_link.Co_ID
                                                                inner join Person_P on Contacts_Linkin_Co_link.Person_P_ID =Person_P.AutoID
                                                                where Person_P.AutoID=" + rd.GetInt32(0).ToString();

                                    using (SqlDataReader rdCo = SqlHelper.ExcuteReader(sqlSearchPhone))
                                    {
                                        if (rdCo.HasRows)
                                        {
                                            while (rdCo.Read())
                                            {
                                                oPersonInfo.PhoneNumber =rdCo.GetValue(0).ToString()==""?"": rdCo.GetString(0);
                                                oPersonInfo.MobilePhoneNumber = rdCo.GetValue(1).ToString() == "" ? "" : rdCo.GetString(1);
                                                oPersonInfo.Email = rdCo.GetValue(2).ToString() == "" ? "" : rdCo.GetString(2);
                                            }
                                        }
                                    }

                                    PersonInfoList.Add(oPersonInfo);
                                    #endregion
                                    break;

                                case "Team Leader Assistant":
                                    goto case "Blue Color";
                                case "Team Leader":
                                    goto case "Blue Color";

                                case "Group Leader":
                                    #region    
                                    string sqlSearchGroup2 = @"select Group_E5.Name from Person_P
                                                                inner join GroupPerson_E5_P on GroupPerson_E5_P.Direct_Member_P_ID=Person_P.AutoID or GroupPerson_E5_P.Leader_P_ID=Person_P.AutoID
                                                                inner join Group_E5 on Group_E5.AutoID=GroupPerson_E5_P.Group_E5_ID
                                                            Where Person_P.AutoID= " + rd.GetInt32(0).ToString();
                                    oPersonInfo.Group = SqlHelper.ExcuteScalar(sqlSearchGroup2).ToString();

                                    string sqlSearchDep2 = @"Select Department_E4.Name from Person_P
                                                             inner join  GroupPerson_E5_P on GroupPerson_E5_P.Direct_Member_P_ID=Person_P.AutoID or GroupPerson_E5_P.Leader_P_ID=Person_P.AutoID
                                                             inner join Group_E5 on Group_E5.AutoID=GroupPerson_E5_P.Group_E5_ID
                                                             inner join DepartmentGroup_E4_E5 on DepartmentGroup_E4_E5.Group_E5_ID=Group_E5.AutoID
                                                             inner join Department_E4 on DepartmentGroup_E4_E5.Department_E4_ID=Department_E4.AutoID
                                                            Where Person_P.AutoID= " + rd.GetInt32(0).ToString();
                                    oPersonInfo.Department = SqlHelper.ExcuteScalar(sqlSearchDep2).ToString();

                                    string sqlSearchPhone2 = @"  select  Contacts_Co.PhoneNumber,Contacts_Co.MobilePhone,Contacts_Co.Email from Contacts_Co
                                                                inner join Contacts_Linkin_Co_link on Contacts_Co.AutoID=Contacts_Linkin_Co_link.Co_ID
                                                                inner join Person_P on Contacts_Linkin_Co_link.Person_P_ID =Person_P.AutoID
                                                                where Person_P.AutoID=" + rd.GetInt32(0).ToString();

                                    using (SqlDataReader rdCo = SqlHelper.ExcuteReader(sqlSearchPhone2))
                                    {
                                        if (rdCo.HasRows)
                                        {
                                            while (rdCo.Read())
                                            {
                                                oPersonInfo.PhoneNumber = rdCo.GetValue(0).ToString() == "" ? "" : rdCo.GetString(0);
                                                oPersonInfo.MobilePhoneNumber = rdCo.GetValue(1).ToString() == "" ? "" : rdCo.GetString(1);
                                                oPersonInfo.Email = rdCo.GetValue(2).ToString() == "" ? "" : rdCo.GetString(2);
                                            }
                                        }
                                    }

                                    PersonInfoList.Add(oPersonInfo);
                                    #endregion
                                    break;

                                case "Senior Manager":
                                    #region 

                                    string sqlSearchDep3 = @"select Department_E4.Name from Person_P
                                                             inner join DepartmentPerson_E4_P on DepartmentPerson_E4_P.Leader_P_ID=Person_P.AutoID or DepartmentPerson_E4_P.Assistant_P_ID=Person_P.AutoID or DepartmentPerson_E4_P.Direct_Member_P_ID=Person_P.AutoID
                                                             inner join Department_E4 on Department_E4.AutoID= DepartmentPerson_E4_P.E4_ID
                                                            Where Person_P.AutoID= " + rd.GetInt32(0).ToString();
                                    oPersonInfo.Department = SqlHelper.ExcuteScalar(sqlSearchDep3).ToString();

                                    string sqlSearchPhone3 = @"  select  Contacts_Co.PhoneNumber,Contacts_Co.MobilePhone,Contacts_Co.Email from Contacts_Co
                                                                inner join Contacts_Linkin_Co_link on Contacts_Co.AutoID=Contacts_Linkin_Co_link.Co_ID
                                                                inner join Person_P on Contacts_Linkin_Co_link.Person_P_ID =Person_P.AutoID
                                                                where Person_P.AutoID=" + rd.GetInt32(0).ToString();

                                    using (SqlDataReader rdCo = SqlHelper.ExcuteReader(sqlSearchPhone3))
                                    {
                                        if (rdCo.HasRows)
                                        {
                                            while (rdCo.Read())
                                            {
                                                oPersonInfo.PhoneNumber = rdCo.GetValue(0).ToString() == "" ? "" : rdCo.GetString(0);
                                                oPersonInfo.MobilePhoneNumber = rdCo.GetValue(1).ToString() == "" ? "" : rdCo.GetString(1);
                                                oPersonInfo.Email = rdCo.GetValue(2).ToString() == "" ? "" : rdCo.GetString(2);
                                            }
                                        }
                                    }

                                    PersonInfoList.Add(oPersonInfo);
                                    break;

                                #endregion
                                case "Supervisor":
                                    goto case "Senior Manager";
                                case "Engineer":
                                    goto case "Senior Manager";
                                case "Assistant Manager":
                                    goto case "Senior Manager";
                                case "expert":
                                    goto case "Senior Manager";
                                case "Specialist":
                                    goto case "Senior Manager";
                                case "Vice President":
                                    #region
                                    string sqlSearchPhone4 = @"  select  Contacts_Co.PhoneNumber,Contacts_Co.MobilePhone,Contacts_Co.Email from Contacts_Co
                                                                inner join Contacts_Linkin_Co_link on Contacts_Co.AutoID=Contacts_Linkin_Co_link.Co_ID
                                                                inner join Person_P on Contacts_Linkin_Co_link.Person_P_ID =Person_P.AutoID
                                                                where Person_P.AutoID=" + rd.GetInt32(0).ToString();

                                    using (SqlDataReader rdCo = SqlHelper.ExcuteReader(sqlSearchPhone4))
                                    {
                                        if (rdCo.HasRows)
                                        {
                                            while (rdCo.Read())
                                            {
                                                oPersonInfo.PhoneNumber = rdCo.GetValue(0).ToString() == "" ? "" : rdCo.GetString(0);
                                                oPersonInfo.MobilePhoneNumber = rdCo.GetValue(1).ToString() == "" ? "" : rdCo.GetString(1);
                                                oPersonInfo.Email = rdCo.GetValue(2).ToString() == "" ? "" : rdCo.GetString(2);
                                            }
                                        }
                                    }

                                    PersonInfoList.Add(oPersonInfo);
                                    break;
                                #endregion
                                case "General Manager":
                                    goto case "Vice President";

                                default:
                                
                                    break;
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            dataGridView1.DataSource = PersonInfoList;
        }

        
    }
}
