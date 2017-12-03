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
    public partial class AreaOverview : UserControl
    {
        public AreaOverview()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlArea = @"  select * from A";
            List<AreaMachine4DataGridView> AreaMachineList = new List<AreaMachine4DataGridView>();

            //try
            //{
                using (SqlDataReader rd = SqlHelper.ExcuteReader(sqlArea))
                {
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            AreaMachine4DataGridView amObject = new AreaMachine4DataGridView();
                            amObject.FunctionLocation = rd.GetValue(1).ToString();
                            amObject.FunctionLocationName = rd.GetValue(2).ToString();
                            amObject.MainteananceWorkCenter = rd.GetValue(3).ToString();
                            amObject.PlannerGroup = rd.GetValue(4).ToString();
                            amObject.Descriptions = rd.GetValue(5).ToString();
                     
                            amObject.Supprior_Area_A_ID= rd.GetValue(6).ToString();
                        if ( rd.GetValue(7).ToString() == "true")
                        {
                            amObject.Property = "Machine";
                        }
                        else if (rd.GetValue(8).ToString() == "true")
                        {
                            amObject.Property = "zone";
                        }
                        else if (rd.GetValue(9).ToString() == "true")
                        {
                            amObject.Property = "Line";
                        }
                        else if (rd.GetValue(10).ToString() == "true")
                        {
                            amObject.Property = "Plant";
                        }
                        else
                        {
                            amObject.Property = "NULL";
                        }

                        amObject.sop_date = rd.GetValue(11).ToString();
                            amObject.BottleNeck = rd.GetValue(12).ToString();
                        amObject.BreakdownFactor = rd.GetValue(13).ToString();

                        if (rd.GetValue(14).ToString() == "true")
                        {
                            amObject.Responsible = "T3PartyResponsible";
                        }
                        else if (rd.GetValue(15).ToString() == "true")
                        {
                            amObject.Responsible = "SupportOnsite";
                        }
                        else if (rd.GetValue(16).ToString() == "true")
                        {
                            amObject.Responsible = "SupportItech";
                        }
                        else if (rd.GetValue(17).ToString() == "true")
                        {
                            amObject.Responsible = "SupportChina";
                        }
                        else if (rd.GetValue(18).ToString() == "true")
                        {
                            amObject.Responsible = "SupportInternational";
                        }
                       
                        else if (rd.GetValue(19).ToString() == "true")
                        {
                            amObject.Responsible = "NoSupport";
                        }
                        else
                        {
                            amObject.Responsible = "NULL";
                        }

                       
                        AreaMachineList.Add(amObject);
                        }
                        
                    }
                }
               
            //}
            //catch
            //{

            //}
            dataGridView1.DataSource = AreaMachineList;
        }


       
    }
}
