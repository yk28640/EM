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
using EM.AreaMachineAdd;
namespace EM
{
    public partial class Main : Form
    {
      //  public Add AreaMachinePanel;
        public DepartmentData DepData;
        public Operation OperationPanel;
        public Search SearchPanel;
        public AreaOverview AreaOverviewPanel;

        public Main()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {
            DepData = new DepartmentData();
            OperationPanel = new Operation();
            SearchPanel = new Search();
            AreaOverviewPanel = new AreaOverview();
          //  AreaMachinePanel = new Add();

        }

        private void departmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DepData.Show();
            DataGB.Controls.Clear();
            DataGB.Controls.Add(DepData);
        }

        private void groupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //OperationPanel.Show();
            //DataGB.Controls.Clear();
            //DataGB.Controls.Add(OperationPanel);
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OperationPanel.Show();
            DataGB.Controls.Clear();
            DataGB.Controls.Add(OperationPanel);
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchPanel.Show();
            DataGB.Controls.Clear();
            DataGB.Controls.Add(SearchPanel);
        }

        //private void skillToolStripMenuItem_Click(object sender, EventArgs e)
        //{

        //}

        private void areaOverviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AreaOverviewPanel.Show();
            DataGB.Controls.Clear();
            DataGB.Controls.Add(AreaOverviewPanel);
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //   AreaMachinePanel.Show();
            
            Add AreaMachineAddPanel = new Add();
            AreaMachineAddPanel.Show();
            DataGB.Controls.Clear();
            DataGB.Controls.Add(AreaMachineAddPanel);
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    string sql = "select count(*) from Person_P where BBAC=1";
        //    //    SqlParameter[] pms = new SqlParameter[]
        //    //    {
        //    //        new 
        //    //    };

        // MessageBox.Show(  Convert.ToBoolean(SqlHelper.ExcuteScalar(sql)).ToString());
        //}
    }
}
