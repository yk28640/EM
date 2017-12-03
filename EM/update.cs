using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EM
{
    public partial class update : Form
    {
        public update()
        {
            InitializeComponent();
        }
        public string PersonAutoID { get; set; }
        public string Level { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public static update updateFormSingle = null;
        public event EventHandler MyEvent;
        public static update GetSingle()
        {
            if (updateFormSingle == null || updateFormSingle.IsDisposed)
            {
                updateFormSingle = new update();
            }

            return updateFormSingle;
        }

        private void update_Load(object sender, EventArgs e)
        {
            //innitialize 
            new General().comboxGet<Department>(comboBoxDepartment, "Department_E4", 1);
            new General().comboxGet<Level>(comboBoxLevel, "L", 4);
            //  new General().comboxGet<Team>
            #region
            //List<Department> DepList = new List<Department>();
            //string sql = @"select * from Department_E4 ";
            ////   SqlParameter p1 = new SqlParameter("@pid", SqlDbType.VarChar, 20) { Value = DepTextBox.Text.Trim() };

            //using (SqlDataReader rd = SqlHelper.ExcuteReader(sql))
            //{
            //    if (rd.HasRows)
            //    {
            //        while (rd.Read())
            //        {
            //            Department dpt = new Department();
            //            dpt.Name = rd.GetString(1);
            //            //     dpt.ShortName = rd.GetString(2);
            //            //     dpt.Description = rd.GetString(3);
            //            //    dpt.CostCenter = rd.GetString(4);
            //            DepList.Add(dpt);


            //        }
            //    }

            //}
            //foreach (var item in DepList)
            //{
            //    comboBoxDepartment.Items.Add(item.Name);
            //}
            //DepList.Clear();
            #endregion
        }

        private void comboBoxDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxGroup.Items.Clear();
            foreach (var item in new DepartmentData().GetGroup(comboBoxDepartment.SelectedItem.ToString()))
            {
                comboBoxGroup.Items.Add(item.Name);
            }

            if (comboBoxGroup.Items.Count == 0)
            {
                comboBoxTeam.Items.Clear();
            }

        }

        private void comboBoxGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxTeam.Items.Clear();
            foreach (var item in new DepartmentData().GetTeam(comboBoxGroup.SelectedItem.ToString()))
            {
                comboBoxTeam.Items.Add(item.Name);
            }
        }

        private void comboBoxLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            //   new Operation().comboBox1_SelectedIndexChanged_1(sender, e);
            labelDepartment.Visible = false;
            labelGroup.Visible = false;
            labelTeam.Visible = false;
            comboBoxDepartment.Visible = false;
            comboBoxGroup.Visible = false;
            comboBoxTeam.Visible = false;


            switch (comboBoxLevel.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    break;


                case 2:
                    labelDepartment.Visible = true;
                    comboBoxDepartment.Visible = true;
                    break;
                case 7:
                    labelDepartment.Visible = true;
                    comboBoxDepartment.Visible = true;
                    break;

                case 3:
                    //labelDepartment.Visible = true;
                    //comboBoxDepartment.Visible = true;
                    //labelGroup.Visible = true;
                    //comboBoxGroup.Visible = true;
                    //break;
                    goto case 2;
                case 4:
                    //labelDepartment.Visible = true;
                    //comboBoxDepartment.Visible = true;
                    //labelGroup.Visible = true;
                    //comboBoxGroup.Visible = true;
                    //break;
                    goto case 2;
                case 6:
                    labelDepartment.Visible = true;
                    comboBoxDepartment.Visible = true;
                    labelGroup.Visible = true;
                    comboBoxGroup.Visible = true;
                    break;
                case 10:
                    //labelDepartment.Visible = true;
                    //comboBoxDepartment.Visible = true;
                    //labelGroup.Visible = true;
                    //comboBoxGroup.Visible = true;
                    //break;
                    goto case 2;
                case 11:
                    //labelDepartment.Visible = true;
                    //comboBoxDepartment.Visible = true;
                    //labelGroup.Visible = true;
                    //comboBoxGroup.Visible = true;
                    //break;
                    goto case 2;
                default:
                    labelDepartment.Visible = true;
                    labelGroup.Visible = true;
                    labelTeam.Visible = true;
                    comboBoxDepartment.Visible = true;
                    comboBoxGroup.Visible = true;
                    comboBoxTeam.Visible = true;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // MessageBox.Show(PersonAutoID);
            if (comboBoxCompany.SelectedIndex >= 0 && comboBoxLevel.SelectedIndex>=0)

            {
                if ((comboBoxDepartment.Visible == true && comboBoxDepartment.SelectedIndex < 0) || (comboBoxGroup.Visible == true && comboBoxGroup.SelectedIndex < 0) || (comboBoxTeam.Visible == true && comboBoxTeam.SelectedIndex < 0))
                {
                    MessageBox.Show("fill blank");
                }
                else
                {
                    // Fill infomation into Perosn_P
                    #region Fill_Peron
                    //try
                    //{

                    //    // find AutoID by the NameBBAC(string) in Level Table 
                    //    string sqlLevel = "select L.AutoID from L where L.NameBBAC=@LevelName";
                    //    SqlParameter para = new SqlParameter("@LevelName", SqlDbType.VarChar, 30) { Value = comboBoxLevel.SelectedItem.ToString() };


                    //    Person person = new Person();
                    //    person.Company_ID = textBoxCompanyID.Text.Trim();
                    //    person.Call_Name = textBoxCallName.Text.Trim();
                    //    person.Family_Name = textBoxFamilyName.Text.Trim();
                    //    person.First_Name = textBoxFirstName.Text.Trim();
                    //    person.L_ID = Convert.ToInt32(SqlHelper.ExcuteScalar(sqlLevel, para));
                    //    switch (comboBoxCompany.SelectedItem.ToString())
                    //    {
                    //        case "BBAC":
                    //            person.BBAC = true;
                    //            break;
                    //        case "BAIC":
                    //            person.BAIC = true;
                    //            break;
                    //        case "Daimler":
                    //            person.Daimler = true;
                    //            break;
                    //        case "Supplier":
                    //            person.Supplier = true;
                    //            break;
                    //        default:
                    //            break;
                    //    }


                    //    string sql = @"insert into Person_P(company_ID,First_Name,Family_Name,Call_Name,BBAC,BAIC,Daimler,Supplier,L_ID) 
                    //               Values(@compID,@Fname,@FamilyName,@Cname,@BBAC,@BAIC,@Daimler,@Supplier,@LID)";
                    //    SqlParameter[] pms = new SqlParameter[]
                    //    {
                    //    new SqlParameter( "@compID", SqlDbType.VarChar, 20) { Value= person.Company_ID =="" ? DBNull.Value:(object)person.Company_ID } ,
                    //    new SqlParameter("@Fname",SqlDbType.VarChar,20) {Value = person.First_Name },
                    //    new SqlParameter("@FamilyName",SqlDbType.VarChar,20) {Value = person.Family_Name },
                    //    new SqlParameter("@Cname",SqlDbType.VarChar,20) {Value=person.Call_Name },
                    //    new SqlParameter("@BBAC",SqlDbType.Bit) {Value=person.BBAC },
                    //    new SqlParameter("@BAIC",SqlDbType.Bit) {Value=person.BAIC },
                    //    new SqlParameter("@Daimler",SqlDbType.Bit) {Value=person.Daimler },
                    //    new SqlParameter("@Supplier",SqlDbType.Bit) {Value=person.Supplier },
                    //    new SqlParameter("@LID",SqlDbType.Int) {Value=person.L_ID },

                    //    };

                    //    SqlHelper.ExcuteNonQuery(sql, pms);
                    //}
                    //catch (Exception s)
                    //{
                    //    MessageBox.Show(s.Message);
                    //}
                    #endregion
                    //解除原有连接关系
                    #region
                    //1,SET LEVEL NULL
                    string sqlLevelNull = "update Person_P set L_ID = null where AutoID =" + PersonAutoID;
                    SqlHelper.ExcuteNonQuery(sqlLevelNull);
                    string sqlLinkDel = null;
                    //2,release link
                    switch (Level)
                    {
                        case "Supervisor":
                            goto case "Engineer";
                        case "expert":
                            goto case "Engineer";
                        case "Specialist":
                            goto case "Engineer";
                        case "Engineer":
                            sqlLinkDel = "  delete  DepartmentPerson_E4_P where Direct_Member_P_ID =" + PersonAutoID;
                            break;
                        case "Senior Manager":
                            sqlLinkDel = "  delete  DepartmentPerson_E4_P where Leader_P_ID =" + PersonAutoID;
                            break;
                        case "Assistant Manager":
                            sqlLinkDel = "  delete  DepartmentPerson_E4_P where Assistant_P_ID =" + PersonAutoID;
                            break;
                        case "Group Leader":
                            sqlLinkDel = " delete GroupPerson_E5_P where Leader_P_ID = " + PersonAutoID;
                            break;
                        case "Team Leader":
                            sqlLinkDel = "delete Team_P where Leader_P_ID = " + PersonAutoID;
                            break;
                        case "Team Leader Assistant":
                            goto case "Team Leader";
                        case "Blue Color":
                            sqlLinkDel = "delete Team_P where Direct_Member_P_ID = " + PersonAutoID;
                            break;
                        default:
                            break;
                    }
                    if (sqlLinkDel != null)
                    {
                        SqlHelper.ExcuteNonQuery(sqlLinkDel);
                    }
                    #endregion
                    // rebuild new level and connection
                    #region
                    //update level
                    SqlHelper.ExcuteNonQuery("update Person_P set L_ID = (select L.AutoID from L where L.NameBBAC = " + @"'" + comboBoxLevel.SelectedItem.ToString() + @"'" + ") where AutoID =" + PersonAutoID);
                    //update company
                    string companysql = null;
                    switch (comboBoxCompany.SelectedIndex)
                    {
                        case 0:
                            companysql = " update Person_P set BBAC = 1, BAIC = 0, Daimler = 0, Supplier = 0 where AutoID = " + PersonAutoID;
                            break;
                        case 1:
                            companysql = " update Person_P set BBAC = 0, BAIC = 1, Daimler = 0, Supplier = 0 where AutoID = " + PersonAutoID;
                            break;
                        case 2:
                            companysql = " update Person_P set BBAC = 0, BAIC = 0, Daimler = 1, Supplier = 0 where AutoID = " + PersonAutoID;
                            break;
                        case 3:
                            companysql = " update Person_P set BBAC = 0, BAIC = 0, Daimler = 0, Supplier = 1 where AutoID = " + PersonAutoID;
                            break;
                        default:
                            MessageBox.Show("please select company");
                            break;
                    }
                    SqlHelper.ExcuteNonQuery(companysql);
                    #endregion
                    //
                    #region fill E4_P,E5_P,Team_P
                    switch (comboBoxLevel.SelectedIndex)
                    {
                        case 0:
                            goto case 1;
                        case 1:
                            break;

                        // fill E4_P
                        case 2:                     //GM
                            #region           
                            string sqlGM = "select Department_E4.AutoID from Department_E4 where Department_E4.Name=@DepName";  //根据选择的部门名称在数据库中找到对应的ID
                            SqlParameter paraDep = new SqlParameter("@DepName", SqlDbType.VarChar, 20) { Value = comboBoxDepartment.SelectedItem.ToString() };
                            string InsertE4_P_sql = "insert into DepartmentPerson_E4_P(E4_ID,Leader_P_ID) values(@DepID,@LeaderPID)";
                            SqlParameter[] paraInsertE4P = new SqlParameter[]
                            {
                                new SqlParameter("@DepID",SqlDbType.Int) {Value=Convert.ToInt32( SqlHelper.ExcuteScalar(sqlGM,paraDep)) },// Get the department id by department name as the ID
                                new SqlParameter("@LeaderPID",SqlDbType.Int) {Value= Convert.ToInt32(PersonAutoID)} //get the last autoID as the ID

                            };
                            SqlHelper.ExcuteNonQuery(InsertE4_P_sql, paraInsertE4P);
                            #endregion



                            break;
                        case 7:                     //AM
                            string sqlAM = "select Department_E4.AutoID from Department_E4 where Department_E4.Name=@DepName";
                            SqlParameter paraDep7 = new SqlParameter("@DepName", SqlDbType.VarChar, 20) { Value = comboBoxDepartment.SelectedItem.ToString() };
                            string InsertE4_P_sql7 = "insert into DepartmentPerson_E4_P(E4_ID,Assistant_P_ID) values(@DepID,@PID)";
                            SqlParameter[] paraInsertE4P7 = new SqlParameter[]
                            {
                                new SqlParameter("@DepID",SqlDbType.Int) {Value=Convert.ToInt32( SqlHelper.ExcuteScalar(sqlAM,paraDep7)) },// Get the department id by department name as the ID
                                new SqlParameter("@PID",SqlDbType.Int) {Value= Convert.ToInt32(PersonAutoID)} //get the last autoID as the ID

                            };
                            SqlHelper.ExcuteNonQuery(InsertE4_P_sql7, paraInsertE4P7);
                            break;
                        //fill E4_P
                        case 3:
                            string sql3 = "select Department_E4.AutoID from Department_E4 where Department_E4.Name=@DepName";
                            SqlParameter paraDep3 = new SqlParameter("@DepName", SqlDbType.VarChar, 20) { Value = comboBoxDepartment.SelectedItem.ToString() };
                            string InsertE4_P_sql3 = "insert into DepartmentPerson_E4_P(E4_ID,Direct_Member_P_ID) values(@DepID,@PID)";
                            SqlParameter[] paraInsertE4P3 = new SqlParameter[]
                            {
                                new SqlParameter("@DepID",SqlDbType.Int) {Value=Convert.ToInt32( SqlHelper.ExcuteScalar(sql3,paraDep3)) },// Get the department id by department name as the ID
                                new SqlParameter("@PID",SqlDbType.Int) {Value= Convert.ToInt32(PersonAutoID)} //get the last autoID as the ID

                            };
                            SqlHelper.ExcuteNonQuery(InsertE4_P_sql3, paraInsertE4P3);
                            break;
                        case 4:
                            goto case 3;
                        //fill E5_P
                        case 6:

                            string sql6 = "select Group_E5.AutoID from Group_E5 where Group_E5.Name=@GroupName";
                            SqlParameter paraDep6 = new SqlParameter("@GroupName", SqlDbType.VarChar, 20) { Value = comboBoxGroup.SelectedItem.ToString() };
                            string InsertE4_P_sql6 = " insert into GroupPerson_E5_P(Group_E5_ID,Leader_P_ID) values(@GroupID,@PID)";
                            SqlParameter[] paraInsertE4P6 = new SqlParameter[]
                            {
                                new SqlParameter("@GroupID",SqlDbType.Int) {Value=Convert.ToInt32( SqlHelper.ExcuteScalar(sql6,paraDep6)) },// Get the department id by department name as the ID
                                new SqlParameter("@PID",SqlDbType.Int) {Value= Convert.ToInt32(PersonAutoID)} //get the last autoID as the ID

                            };
                            SqlHelper.ExcuteNonQuery(InsertE4_P_sql6, paraInsertE4P6);
                            break;
                        case 10:
                            goto case 3;
                        case 11:

                            goto case 3;
                        //Fill Team_P
                        case 5:
                            string sql0 = "select Team.AutoID from Team where Team.Name=@TeamName";
                            SqlParameter paraDep0 = new SqlParameter("@TeamName", SqlDbType.VarChar, 20) { Value = comboBoxTeam.SelectedItem.ToString() };
                            string InsertE4_P_sql0 = " insert into Team_P(Team_ID,Leader_P_ID) values(@TeamID,@PID)";
                            SqlParameter[] paraInsertE4P0 = new SqlParameter[]
                            {
                                new SqlParameter("@TeamID",SqlDbType.Int) {Value=Convert.ToInt32( SqlHelper.ExcuteScalar(sql0,paraDep0)) },// Get the department id by department name as the ID
                                new SqlParameter("@PID",SqlDbType.Int) {Value= Convert.ToInt32(PersonAutoID)} //get the last autoID as the ID

                            };
                            SqlHelper.ExcuteNonQuery(InsertE4_P_sql0, paraInsertE4P0);
                            break;

                        default:
                            string sqlD = "select Team.AutoID from Team where Team.Name=@TeamName";
                            SqlParameter paraDepD = new SqlParameter("@TeamName", SqlDbType.VarChar, 20) { Value = comboBoxTeam.SelectedItem.ToString() };
                            string InsertE4_P_sqlD = " insert into Team_P(Team_ID,Direct_Member_P_ID) values(@TeamID,@PID)";
                            SqlParameter[] paraInsertE4PD = new SqlParameter[]
                            {
                                new SqlParameter("@TeamID",SqlDbType.Int) {Value=Convert.ToInt32( SqlHelper.ExcuteScalar(sqlD,paraDepD)) },// Get the department id by department name as the ID
                                new SqlParameter("@PID",SqlDbType.Int) {Value= Convert.ToInt32(PersonAutoID)} //get the last autoID as the ID

                            };
                            SqlHelper.ExcuteNonQuery(InsertE4_P_sqlD, paraInsertE4PD);
                            break;

                    }
                    #endregion

                    //fill contacts
                    #region FillContacts
                    //if ( textBoxPhoneNumber.Text.Trim().Length + textBoxEmail.Text.Trim().Length  > 0)
                    //{
                    //    string sqlContact = "insert into Contacts_Co(Descriptions,MobilePhone,PhoneNumber,Email,Web_Address,Fax) values(@Descriptions,@MobilePhone,@PhoneNumber,@Email,@Web_Address,@Fax)";
                    //    SqlParameter[] paraContacts = new SqlParameter[]
                    //    {
                    //        new SqlParameter("@Descriptions",SqlDbType.VarChar,8000) {Value=textBoxDescription.Text.Trim()==""?DBNull.Value:(object)textBoxDescription.Text.Trim() },
                    //        new SqlParameter("@MobilePhone",SqlDbType.VarChar,20) {Value=textBoxMobilePhone.Text.Trim()==""?DBNull.Value:(object)textBoxMobilePhone.Text.Trim() },
                    //        new SqlParameter("@PhoneNumber",SqlDbType.VarChar,20) {Value=textBoxPhoneNumber.Text.Trim()==""?DBNull.Value:(object)textBoxPhoneNumber.Text.Trim() },
                    //        new SqlParameter("@Email",SqlDbType.VarChar,20) {Value=textBoxEmail.Text.Trim()==""?DBNull.Value:(object)textBoxEmail.Text.Trim() },
                    //        new SqlParameter("@Web_Address",SqlDbType.VarChar,20) {Value=textBoxWeb.Text.Trim()==""?DBNull.Value:(object)textBoxWeb.Text.Trim() },
                    //        new SqlParameter("@Fax",SqlDbType.VarChar,20) {Value=textBoxFax.Text.Trim()==""?DBNull.Value:(object)textBoxFax.Text.Trim() }
                    //    };
                    //    try
                    //    {
                    //        SqlHelper.ExcuteNonQuery(sqlContact, paraContacts);
                    //    }
                    //    catch (Exception exc)
                    //    {
                    //        MessageBox.Show(exc.Message);
                    //    }
                    //}
                    #endregion

                    // fill contacts_linking
                    #region Contacts_links
                    
                    // 如果update的时候发现person和contact的连接没有建立就建立一个，直接从operation里面拷贝的
                    if (SqlHelper.ExcuteScalar("  select Contacts_Linkin_Co_link.AutoID from Contacts_Linkin_Co_link where Contacts_Linkin_Co_link.Person_P_ID=" + PersonAutoID) == null)
                    {
                        #region FillContacts
                        if (textBoxPhoneNumber.Text.Trim().Length + textBoxEmail.Text.Trim().Length > 0)
                        {
                            string sqlContact = "insert into Contacts_Co(MobilePhone,PhoneNumber,Email) values(@MobilePhone,@PhoneNumber,@Email)";
                            SqlParameter[] paraContacts = new SqlParameter[]
                            {
                      //  new SqlParameter("@Descriptions",SqlDbType.VarChar,8000) {Value=textBoxDescription.Text.Trim()==""?DBNull.Value:(object)textBoxDescription.Text.Trim() },
                        new SqlParameter("@MobilePhone",SqlDbType.VarChar,20) {Value=textBoxMobilePhone.Text.Trim()==""?DBNull.Value:(object)textBoxMobilePhone.Text.Trim() },
                        new SqlParameter("@PhoneNumber",SqlDbType.VarChar,20) {Value=textBoxPhoneNumber.Text.Trim()==""?DBNull.Value:(object)textBoxPhoneNumber.Text.Trim() },
                        new SqlParameter("@Email",SqlDbType.VarChar,20) {Value=textBoxEmail.Text.Trim()==""?DBNull.Value:(object)textBoxEmail.Text.Trim() },
                      //  new SqlParameter("@Web_Address",SqlDbType.VarChar,20) {Value=textBoxWeb.Text.Trim()==""?DBNull.Value:(object)textBoxWeb.Text.Trim() },
                      //  new SqlParameter("@Fax",SqlDbType.VarChar,20) {Value=textBoxFax.Text.Trim()==""?DBNull.Value:(object)textBoxFax.Text.Trim() }
                            };
                            try
                            {
                                SqlHelper.ExcuteNonQuery(sqlContact, paraContacts);
                            }
                            catch (Exception exc)
                            {
                                MessageBox.Show(exc.Message);
                            }
                            // fill contacts_linking
                            #region Contacts_links
                            string sqlContactLink = "insert into Contacts_Linkin_Co_link(Co_ID,Person_P_ID) values(@Co_ID,@Person_P_ID)";
                            SqlParameter[] parasqlContactLink = new SqlParameter[]
                            {
                         new SqlParameter("@Co_ID",SqlDbType.Int) {Value=Convert.ToInt32(SqlHelper.ExcuteScalar("select IDENT_CURRENT('Contacts_Co')") )},
                         new SqlParameter("@Person_P_ID",SqlDbType.Int) {Value=Convert.ToInt32(PersonAutoID) }
                            };
                            SqlHelper.ExcuteNonQuery(sqlContactLink, parasqlContactLink);

                            #endregion
                        }
                        #endregion
                    }
                    else    //如果联系已经建立，则直接更新
                    {
                        string contactSql = @"  update Contacts_Co set MobilePhone=@Mobile,PhoneNumber=@PhoneNumber,Email=@Email where Contacts_Co.AutoID=
                                            (
                                            select Contacts_Linkin_Co_link.Co_ID from Contacts_Co
                                            inner join Contacts_Linkin_Co_link on Contacts_Co.AutoID= Contacts_Linkin_Co_link.Co_ID
                                            where Contacts_Linkin_Co_link.Person_P_ID= " + PersonAutoID + ")";


                        SqlParameter[] pmsCo = new SqlParameter[]
                        {
                        new SqlParameter("@Mobile",SqlDbType.VarChar,20) {Value=textBoxMobilePhone.Text.Trim()==""?(object)MobilePhone:(object)textBoxMobilePhone.Text.Trim() },
                        new SqlParameter("@PhoneNumber",SqlDbType.VarChar,20) {Value=textBoxPhoneNumber.Text.Trim()==""?(object)Phone:(object)textBoxPhoneNumber.Text.Trim() },
                        new SqlParameter("@Email",SqlDbType.VarChar,20) {Value=textBoxEmail.Text.Trim()==""?(object)Email:(object)textBoxEmail.Text.Trim() }
                        };
                        SqlHelper.ExcuteNonQuery(contactSql, pmsCo);
                        #endregion
                       

                    }
                    if (MyEvent != null)
                    {
                        this.Close();
                        MyEvent(this, null);
                    }
                }
            }
            else
            {
                MessageBox.Show("choose  company and level  ");
            }
        }
    }
}
