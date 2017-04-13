using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WangNeedSearch.Properties;

namespace WangNeedSearch
{
    public partial class SubForm2 : Form
    {
        private SqlConnection _sqlConnection;
        private const string ConnString = "UID=sa;Password=sa;Initial Catalog=RH;Data Source=192.168.1.6";

        private void ConnectDb()
        {
            _sqlConnection = new SqlConnection(ConnString);
            _sqlConnection.Open();
        }

        public SubForm2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void SubForm2_Load(object sender, EventArgs e)
        {
            lblNotFound.Visible = false;
            try
            {
                ConnectDb();
                GetFactory();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void Search()
        {
            lblNotFound.Visible = false;
            if (!string.IsNullOrEmpty(txtOrderNumber.Text))
            {
                string temp = txtOrderNumber.Text.Trim();
                string tc001 = temp.Substring(0, 4);
                string tc002 = temp.Substring(4, temp.Length - 4);
                GetDetailAndCountByOrderNumber(tc001, tc002);
            }
            else
            {
                ShowLabelWarnning();
                ClearUIContent();
            }
        }

        private void GetDetailAndCountByOrderNumber(string preOrder, string order)
        {
            try
            {
                string SQL = "select TD004, TD008, TD009 from RHLX.dbo.COPTC left join RHLX.dbo.COPTD on TC001 = TD001 and TC002 = TD002 where TC001 = '" + preOrder + "' and TC002 = '" + order + "'";
                SqlDataAdapter objDataAdpter = new SqlDataAdapter();
                objDataAdpter.SelectCommand = new SqlCommand(SQL, _sqlConnection);
                DataSet ds = new DataSet();
                objDataAdpter.Fill(ds, "temp");

                DataTable dataTable = ds.Tables[0];
                /*
                DataView dataView = dataTable.DefaultView;
                //dataView.Sort = "";
                lstFactory.DataSource = dataView;
                lstFactory.DisplayMember = "TD004";
                lstFactory.ValueMember = "TD004";
                */

                TreeNode[] treeNodes = new TreeNode[dataTable.Rows.Count];
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    treeNodes[i] = new TreeNode(dataTable.Rows[i][0].ToString());
                    treeNodes[i].Text = dataTable.Rows[i][0].ToString();
                    treeNodes[i].Name = dataTable.Rows[i][0].ToString();
                }
                foreach (TreeNode treeNode in treeNodes)
                {
                    /*
                    SQL = "select * from RHLX.dbo.BOMMC left join RHLX.dbo.BOMMD on MC001 = MD001 where MC001 = '102-1309-76'";
                    SqlDataAdapter objDataAdpter = new SqlDataAdapter();
                    objDataAdpter.SelectCommand = new SqlCommand(SQL, _sqlConnection);
                    DataSet ds = new DataSet();
                    objDataAdpter.Fill(ds, "temp");

                    DataTable dataTable = ds.Tables[0];
                    */
                    treeNode.Nodes.Add("Child");
                }
                trvOrderDetail.Nodes.AddRange(treeNodes);
            }
            catch (Exception ee)
            {
            }
        }

        private void GetFactory()
        {
            throw new NotImplementedException();
        }

        private void ClearUIContent()
        {
            txtOrderNumber.Text = "";
            txtDetailCount.Text = "";
            trvOrderDetail.Nodes.Clear();
            //lstFactory.Items.Clear();
        }

        private void ShowLabelWarnning()
        {
            lblNotFound.Text = Resources.SubForm2_ShowLabelWarnning_;
            lblNotFound.Visible = true;
        }

        private void SubForm2_FormClosing(object sender, FormClosingEventArgs e)
        {
            _sqlConnection.Close();
            _sqlConnection.Dispose();
        }

        private void txtOrderNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }
    }
}
