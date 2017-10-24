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
    public partial class Operation : UserControl
    {
       
        public Operation()
        {
            InitializeComponent();
        }

       
        private void AddButton_Click(object sender, EventArgs e)

        {
            if ( textBoxFirstName.Text.Trim().Length>0 && textBoxFamilyName.Text.Trim().Length>0 &&
                textBoxCallName.Text.Length>0 )
            {
                
                   

               

                if (comboBoxCompany.SelectedIndex >= 0)

                {
                    // Fill infomation into Perosn_P
                    #region Fill_Peron
                    try
                    {

                        // find AutoID by the NameBBAC(string) in Level Table 
                        string sqlLevel = "select L.AutoID from L where L.NameBBAC=@LevelName";
                        SqlParameter para = new SqlParameter("@LevelName", SqlDbType.VarChar, 30) { Value = comboBoxLevel.SelectedItem.ToString() };


                        Person person = new Person();
                        person.Company_ID = textBoxCompanyID.Text.Trim();
                        person.Call_Name = textBoxCallName.Text.Trim();
                        person.Family_Name = textBoxFamilyName.Text.Trim();
                        person.First_Name = textBoxFirstName.Text.Trim();
                        person.L_ID = Convert.ToInt32(SqlHelper.ExcuteScalar(sqlLevel, para));
                        switch (comboBoxCompany.SelectedItem.ToString())
                        {
                            case "BBAC":
                                person.BBAC = true;
                                break;
                            case "BAIC":
                                person.BAIC = true;
                                break;
                            case "Daimler":
                                person.Daimler = true;
                                break;
                            case "Supplier":
                                person.Supplier = true;
                                break;
                            default:
                                break;
                        }


                        string sql = @"insert into Person_P(company_ID,First_Name,Family_Name,Call_Name,BBAC,BAIC,Daimler,Supplier,L_ID) 
                               Values(@compID,@Fname,@FamilyName,@Cname,@BBAC,@BAIC,@Daimler,@Supplier,@LID)";
                        SqlParameter[] pms = new SqlParameter[]
                        {
                    new SqlParameter( "@compID", SqlDbType.VarChar, 20) { Value= person.Company_ID =="" ? DBNull.Value:(object)person.Company_ID } ,
                    new SqlParameter("@Fname",SqlDbType.VarChar,20) {Value = person.First_Name },
                    new SqlParameter("@FamilyName",SqlDbType.VarChar,20) {Value = person.Family_Name },
                    new SqlParameter("@Cname",SqlDbType.VarChar,20) {Value=person.Call_Name },
                    new SqlParameter("@BBAC",SqlDbType.Bit) {Value=person.BBAC },
                    new SqlParameter("@BAIC",SqlDbType.Bit) {Value=person.BAIC },
                    new SqlParameter("@Daimler",SqlDbType.Bit) {Value=person.Daimler },
                    new SqlParameter("@Supplier",SqlDbType.Bit) {Value=person.Supplier },
                    new SqlParameter("@LID",SqlDbType.Int) {Value=person.L_ID },

                        };

                        SqlHelper.ExcuteNonQuery(sql, pms);
                    }
                    catch (Exception s)
                    {
                        MessageBox.Show(s.Message);
                    }
                    #endregion 

                    // fill E4_P,E5_P,Team_P
                    #region fill E4_P,E5_P,Team_P
                    switch (comboBoxLevel.SelectedIndex)
                    {
                        case 0:
                            goto case 1;
                        case 1:
                            break;

                        // fill E4_P
                        case 2:                     //GM
                            string sqlGM = "select Department_E4.AutoID from Department_E4 where Department_E4.Name=@DepName";  //根据选择的部门名称在数据库中找到对应的ID
                            SqlParameter paraDep = new SqlParameter("@DepName", SqlDbType.VarChar, 20) { Value = comboBoxDepartment.SelectedItem.ToString() };
                            string InsertE4_P_sql = "insert into DepartmentPerson_E4_P(E4_ID,Leader_P_ID) values(@DepID,@LeaderPID)";
                            SqlParameter[] paraInsertE4P = new SqlParameter[]
                            {
                                new SqlParameter("@DepID",SqlDbType.Int) {Value=Convert.ToInt32( SqlHelper.ExcuteScalar(sqlGM,paraDep)) },// Get the department id by department name as the ID
                                new SqlParameter("@LeaderPID",SqlDbType.Int) {Value=Convert.ToInt32(SqlHelper.ExcuteScalar("select IDENT_CURRENT('Person_P')") )} //get the last autoID as the ID

                            };
                            SqlHelper.ExcuteNonQuery(InsertE4_P_sql, paraInsertE4P);
                           
                            break;
                        case 7:                     //AM
                            string sqlAM = "select Department_E4.AutoID from Department_E4 where Department_E4.Name=@DepName"; 
                            SqlParameter paraDep7 = new SqlParameter("@DepName", SqlDbType.VarChar, 20) { Value = comboBoxDepartment.SelectedItem.ToString() };
                            string InsertE4_P_sql7 = "insert into DepartmentPerson_E4_P(E4_ID,Assistant_P_ID) values(@DepID,@PID)";
                            SqlParameter[] paraInsertE4P7 = new SqlParameter[]
                            {
                                new SqlParameter("@DepID",SqlDbType.Int) {Value=Convert.ToInt32( SqlHelper.ExcuteScalar(sqlAM,paraDep7)) },// Get the department id by department name as the ID
                                new SqlParameter("@PID",SqlDbType.Int) {Value=Convert.ToInt32(SqlHelper.ExcuteScalar("select IDENT_CURRENT('Person_P')") )} //get the last autoID as the ID

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
                                new SqlParameter("@PID",SqlDbType.Int) {Value=Convert.ToInt32(SqlHelper.ExcuteScalar("select IDENT_CURRENT('Person_P')") )} //get the last autoID as the ID

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
                                new SqlParameter("@PID",SqlDbType.Int) {Value=Convert.ToInt32(SqlHelper.ExcuteScalar("select IDENT_CURRENT('Person_P')") )} //get the last autoID as the ID

                            };
                            SqlHelper.ExcuteNonQuery(InsertE4_P_sql6, paraInsertE4P6);
                            break;
                        case 10:
                            goto case 3;
                        case 11:

                            goto case 3;
                        //Fill Team_P
                        case 5 :
                            string sql0 = "select Team.AutoID from Team where Team.Name=@TeamName";
                            SqlParameter paraDep0 = new SqlParameter("@TeamName", SqlDbType.VarChar, 20) { Value = comboBoxTeam.SelectedItem.ToString() };
                            string InsertE4_P_sql0 = " insert into Team_P(Team_ID,Leader_P_ID) values(@TeamID,@PID)";
                            SqlParameter[] paraInsertE4P0 = new SqlParameter[]
                            {
                                new SqlParameter("@TeamID",SqlDbType.Int) {Value=Convert.ToInt32( SqlHelper.ExcuteScalar(sql0,paraDep0)) },// Get the department id by department name as the ID
                                new SqlParameter("@PID",SqlDbType.Int) {Value=Convert.ToInt32(SqlHelper.ExcuteScalar("select IDENT_CURRENT('Person_P')") )} //get the last autoID as the ID

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
                                new SqlParameter("@PID",SqlDbType.Int) {Value=Convert.ToInt32(SqlHelper.ExcuteScalar("select IDENT_CURRENT('Person_P')") )} //get the last autoID as the ID

                            };
                            SqlHelper.ExcuteNonQuery(InsertE4_P_sqlD, paraInsertE4PD);
                            break;

                    }
                    #endregion

                    //fill contacts
                    #region FillContacts
                    if (textBoxDescription.Text.Trim().Length+ textBoxPhoneNumber.Text.Trim().Length+textBoxEmail.Text.Trim().Length+ textBoxWeb.Text.Trim().Length+ textBoxFax.Text.Trim().Length>0)
                    {
                        string sqlContact = "insert into Contacts_Co(Descriptions,MobilePhone,PhoneNumber,Email,Web_Address,Fax) values(@Descriptions,@MobilePhone,@PhoneNumber,@Email,@Web_Address,@Fax)";
                        SqlParameter[] paraContacts = new SqlParameter[]
                        {
                        new SqlParameter("@Descriptions",SqlDbType.VarChar,8000) {Value=textBoxDescription.Text.Trim()==""?DBNull.Value:(object)textBoxDescription.Text.Trim() },
                        new SqlParameter("@MobilePhone",SqlDbType.VarChar,20) {Value=textBoxMobilePhone.Text.Trim()==""?DBNull.Value:(object)textBoxMobilePhone.Text.Trim() },
                        new SqlParameter("@PhoneNumber",SqlDbType.VarChar,20) {Value=textBoxPhoneNumber.Text.Trim()==""?DBNull.Value:(object)textBoxPhoneNumber.Text.Trim() },
                        new SqlParameter("@Email",SqlDbType.VarChar,20) {Value=textBoxEmail.Text.Trim()==""?DBNull.Value:(object)textBoxEmail.Text.Trim() },
                        new SqlParameter("@Web_Address",SqlDbType.VarChar,20) {Value=textBoxWeb.Text.Trim()==""?DBNull.Value:(object)textBoxWeb.Text.Trim() },
                        new SqlParameter("@Fax",SqlDbType.VarChar,20) {Value=textBoxFax.Text.Trim()==""?DBNull.Value:(object)textBoxFax.Text.Trim() }
                        };
                        try
                        {
                            SqlHelper.ExcuteNonQuery(sqlContact, paraContacts);
                        }
                        catch(Exception exc)
                        {
                            MessageBox.Show(exc.Message);
                        }
                    }
                    #endregion

                    // fill contacts_linking
                    #region Contacts_links
                    string sqlContactLink = "insert into Contacts_Linkin_Co_link(Co_ID,Person_P_ID) values(@Co_ID,@Person_P_ID)";
                    SqlParameter[] parasqlContactLink = new SqlParameter[]
                    {
                    new SqlParameter("@Co_ID",SqlDbType.Int) {Value=Convert.ToInt32(SqlHelper.ExcuteScalar("select IDENT_CURRENT('Contacts_Co')") )},
                    new SqlParameter("@Person_P_ID",SqlDbType.Int) {Value=Convert.ToInt32(SqlHelper.ExcuteScalar("select IDENT_CURRENT('Person_P')") )}
                    };
                    SqlHelper.ExcuteNonQuery(sqlContactLink, parasqlContactLink);

                    #endregion



                }
                else
                {
                    MessageBox.Show("choose one company  ");
                }
                //    Convert.ToInt16(textBoxCallName.Text.Trim())

            }
            else
            {
                MessageBox.Show("please fill all blanks");
            }
        }

   
        /// <summary>
        /// 选择部门后自动出Group
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxGroup.Items.Clear();
            foreach (var item in new DepartmentData().GetGroup(comboBoxDepartment.SelectedItem.ToString()))
            {
                comboBoxGroup.Items.Add(item.Name);
            }

            if (comboBoxGroup.Items.Count==0)
            {
                comboBoxTeam.Items.Clear();
            }

            
         
        }
    

        private void Operation_Load(object sender, EventArgs e)
        {
            //innitial department
            #region
            List<Department> DepList = new List<Department>();
            string sql = @"select * from Department_E4 ";
            //   SqlParameter p1 = new SqlParameter("@pid", SqlDbType.VarChar, 20) { Value = DepTextBox.Text.Trim() };

            using (SqlDataReader rd = SqlHelper.ExcuteReader(sql))
            {
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        Department dpt = new Department();
                        dpt.Name = rd.GetString(1);
                        //     dpt.ShortName = rd.GetString(2);
                        //     dpt.Description = rd.GetString(3);
                        //    dpt.CostCenter = rd.GetString(4);
                        DepList.Add(dpt);


                    }
                }

            }
            foreach (var item in DepList)
            {
                comboBoxDepartment.Items.Add(item.Name);
            }
            DepList.Clear();
            #endregion
            //innitial level
            #region
            List<Level> LevelList = new List<Level>();
            string LevelSql = @"select * from L ";
            //   SqlParameter p1 = new SqlParameter("@pid", SqlDbType.VarChar, 20) { Value = DepTextBox.Text.Trim() };

            using (SqlDataReader rd = SqlHelper.ExcuteReader(LevelSql))
            {
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        Level level = new Level();
                        level.NameBBAC = rd.GetString(4);

                        LevelList.Add(level);


                    }
                }

            }
            foreach (var item in LevelList)
            {
                comboBoxLevel.Items.Add(item.NameBBAC);
            }
            LevelList.Clear();
            #endregion              



        }
        /// <summary>
        /// 选择group后自动出team
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxTeam.Items.Clear();
            foreach (var item in new DepartmentData().GetTeam(comboBoxGroup.SelectedItem.ToString()))
            {
                comboBoxTeam.Items.Add(item.Name);
            }

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
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

      
    }
    
}
