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

                if (dataTable.Rows.Count < 1)
                {
                    ShowLabelWarnning();
                    ClearUIContent();
                    goto TiaoChu;
                }
                TreeNode[] treeNodes = new TreeNode[dataTable.Rows.Count];
                
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    treeNodes[i] = new TreeNode(dataTable.Rows[i][0].ToString().Trim());
                    treeNodes[i].Text = dataTable.Rows[i][0].ToString().Trim();
                    treeNodes[i].Name = dataTable.Rows[i][0].ToString().Trim();
                }
                foreach (TreeNode treeNode in treeNodes)
                {
                    SQL = "select MD003 from RHLX.dbo.BOMMC left join RHLX.dbo.BOMMD on MC001 = MD001 where MC001 = '" + treeNode.Text + "'";
                    objDataAdpter.SelectCommand = new SqlCommand(SQL, _sqlConnection);
                    DataSet dsTmp = new DataSet();
                    objDataAdpter.Fill(dsTmp, "temp");
                    if (dsTmp.Tables[0].Rows.Count > 0)
                    {
                        TreeNode[] treeNodes1 = new TreeNode[dsTmp.Tables[0].Rows.Count];
                        for (int i = 0; i < dsTmp.Tables[0].Rows.Count; i++)
                        {
                            treeNodes1[i] = new TreeNode(dsTmp.Tables[0].Rows[i][0].ToString().Trim());
                            treeNodes1[i].Text = dsTmp.Tables[0].Rows[i][0].ToString().Trim();
                            treeNodes1[i].Name = dsTmp.Tables[0].Rows[i][0].ToString().Trim();
                        }
                        foreach (TreeNode treeNode1 in treeNodes1)
                        {
                            SQL = "select MD003 from RHLX.dbo.BOMMC left join RHLX.dbo.BOMMD on MC001 = MD001 where MC001 = '" + treeNode1.Text.Trim() + "'";
                            objDataAdpter.SelectCommand = new SqlCommand(SQL, _sqlConnection);
                            DataSet dsTmp1 = new DataSet();
                            objDataAdpter.Fill(dsTmp1, "temp");
                            if (dsTmp1.Tables[0].Rows.Count > 0)
                            {
                                TreeNode[] treeNodes2 = new TreeNode[dsTmp1.Tables[0].Rows.Count];
                                for (int i = 0; i < dsTmp1.Tables[0].Rows.Count; i++)
                                {
                                    treeNodes2[i] = new TreeNode(dsTmp1.Tables[0].Rows[i][0].ToString().Trim());
                                    treeNodes2[i].Text = dsTmp1.Tables[0].Rows[i][0].ToString().Trim();
                                    treeNodes2[i].Name = dsTmp1.Tables[0].Rows[i][0].ToString().Trim();
                                }
                                foreach (TreeNode treeNode2 in treeNodes2)
                                {
                                    SQL = "select MD003 from RHLX.dbo.BOMMC left join RHLX.dbo.BOMMD on MC001 = MD001 where MC001 = '" + treeNode2.Text.Trim() + "'";
                                    objDataAdpter.SelectCommand = new SqlCommand(SQL, _sqlConnection);
                                    DataSet dsTmp2 = new DataSet();
                                    objDataAdpter.Fill(dsTmp2, "temp");
                                    if (dsTmp2.Tables[0].Rows.Count > 0)
                                    {
                                        TreeNode[] treeNodes3 = new TreeNode[dsTmp2.Tables[0].Rows.Count];
                                        for (int i = 0; i < dsTmp2.Tables[0].Rows.Count; i++)
                                        {
                                            treeNodes3[i] = new TreeNode(dsTmp2.Tables[0].Rows[i][0].ToString().Trim());
                                            treeNodes3[i].Text = dsTmp2.Tables[0].Rows[i][0].ToString().Trim();
                                            treeNodes3[i].Name = dsTmp2.Tables[0].Rows[i][0].ToString().Trim();
                                        }
                                        foreach (TreeNode treeNode3 in treeNodes3)
                                        {
                                            SQL = "select MD003 from RHLX.dbo.BOMMC left join RHLX.dbo.BOMMD on MC001 = MD001 where MC001 = '" + treeNode3.Text.Trim() + "'";
                                            objDataAdpter.SelectCommand = new SqlCommand(SQL, _sqlConnection);
                                            DataSet dsTmp3 = new DataSet();
                                            objDataAdpter.Fill(dsTmp3, "temp");
                                            if (dsTmp3.Tables[0].Rows.Count > 0)
                                            {
                                                TreeNode[] treeNodes4 = new TreeNode[dsTmp3.Tables[0].Rows.Count];
                                                for (int i = 0; i < dsTmp3.Tables[0].Rows.Count; i++)
                                                {
                                                    treeNodes4[i] = new TreeNode(dsTmp3.Tables[0].Rows[i][0].ToString().Trim());
                                                    treeNodes4[i].Text = dsTmp3.Tables[0].Rows[i][0].ToString().Trim();
                                                    treeNodes4[i].Name = dsTmp3.Tables[0].Rows[i][0].ToString().Trim();
                                                }
                                                foreach (TreeNode treeNode4 in treeNodes4)
                                                {
                                                    SQL = "select MD003 from RHLX.dbo.BOMMC left join RHLX.dbo.BOMMD on MC001 = MD001 where MC001 = '" + treeNode4.Text.Trim() + "'";
                                                    objDataAdpter.SelectCommand = new SqlCommand(SQL, _sqlConnection);
                                                    DataSet dsTmp4 = new DataSet();
                                                    objDataAdpter.Fill(dsTmp4, "temp");
                                                    if (dsTmp4.Tables[0].Rows.Count > 0)
                                                    {
                                                        TreeNode[] treeNodes5 = new TreeNode[dsTmp4.Tables[0].Rows.Count];
                                                        for (int i = 0; i < dsTmp4.Tables[0].Rows.Count; i++)
                                                        {
                                                            treeNodes5[i] = new TreeNode(dsTmp4.Tables[0].Rows[i][0].ToString().Trim());
                                                            treeNodes5[i].Text = dsTmp4.Tables[0].Rows[i][0].ToString().Trim();
                                                            treeNodes5[i].Name = dsTmp4.Tables[0].Rows[i][0].ToString().Trim();
                                                        }
                                                        foreach (TreeNode treeNode5 in treeNodes5)
                                                        {
                                                            SQL = "select MD003 from RHLX.dbo.BOMMC left join RHLX.dbo.BOMMD on MC001 = MD001 where MC001 = '" + treeNode5.Text.Trim() + "'";
                                                            objDataAdpter.SelectCommand = new SqlCommand(SQL, _sqlConnection);
                                                            DataSet dsTmp5 = new DataSet();
                                                            objDataAdpter.Fill(dsTmp5, "temp");
                                                            if (dsTmp5.Tables[0].Rows.Count > 0)
                                                            {
                                                                TreeNode[] treeNodes6 = new TreeNode[dsTmp5.Tables[0].Rows.Count];
                                                                for (int i = 0; i < dsTmp5.Tables[0].Rows.Count; i++)
                                                                {
                                                                    treeNodes6[i] = new TreeNode(dsTmp5.Tables[0].Rows[i][0].ToString().Trim());
                                                                    treeNodes6[i].Text = dsTmp5.Tables[0].Rows[i][0].ToString().Trim();
                                                                    treeNodes6[i].Name = dsTmp5.Tables[0].Rows[i][0].ToString().Trim();
                                                                }
                                                                foreach (TreeNode treeNode6 in treeNodes6)
                                                                {
                                                                    SQL = "select MD003 from RHLX.dbo.BOMMC left join RHLX.dbo.BOMMD on MC001 = MD001 where MC001 = '" + treeNode6.Text.Trim() + "'";
                                                                    objDataAdpter.SelectCommand = new SqlCommand(SQL, _sqlConnection);
                                                                    DataSet dsTmp6 = new DataSet();
                                                                    objDataAdpter.Fill(dsTmp6, "temp");
                                                                    if (dsTmp6.Tables[0].Rows.Count > 0)
                                                                    {
                                                                        TreeNode[] treeNodes7 = new TreeNode[dsTmp6.Tables[0].Rows.Count];
                                                                        for (int i = 0; i < dsTmp6.Tables[0].Rows.Count; i++)
                                                                        {
                                                                            treeNodes7[i] = new TreeNode(dsTmp6.Tables[0].Rows[i][0].ToString().Trim());
                                                                            treeNodes7[i].Text = dsTmp6.Tables[0].Rows[i][0].ToString().Trim();
                                                                            treeNodes7[i].Name = dsTmp6.Tables[0].Rows[i][0].ToString().Trim();
                                                                        }
                                                                        foreach (TreeNode treeNode7 in treeNodes7)
                                                                        {
                                                                            SQL = "select MD003 from RHLX.dbo.BOMMC left join RHLX.dbo.BOMMD on MC001 = MD001 where MC001 = '" + treeNode7.Text.Trim() + "'";
                                                                            objDataAdpter.SelectCommand = new SqlCommand(SQL, _sqlConnection);
                                                                            DataSet dsTmp7 = new DataSet();
                                                                            objDataAdpter.Fill(dsTmp7, "temp");
                                                                            if (dsTmp7.Tables[0].Rows.Count > 0)
                                                                            {
                                                                                TreeNode[] treeNodes8 = new TreeNode[dsTmp7.Tables[0].Rows.Count];
                                                                                for (int i = 0; i < dsTmp7.Tables[0].Rows.Count; i++)
                                                                                {
                                                                                    treeNodes8[i] = new TreeNode(dsTmp7.Tables[0].Rows[i][0].ToString().Trim());
                                                                                    treeNodes8[i].Text = dsTmp7.Tables[0].Rows[i][0].ToString().Trim();
                                                                                    treeNodes8[i].Name = dsTmp7.Tables[0].Rows[i][0].ToString().Trim();
                                                                                }
                                                                                foreach (TreeNode treeNode8 in treeNodes8)
                                                                                {
                                                                                    SQL = "select MD003 from RHLX.dbo.BOMMC left join RHLX.dbo.BOMMD on MC001 = MD001 where MC001 = '" + treeNode8.Text.Trim() + "'";
                                                                                    objDataAdpter.SelectCommand = new SqlCommand(SQL, _sqlConnection);
                                                                                    DataSet dsTmp8 = new DataSet();
                                                                                    objDataAdpter.Fill(dsTmp8, "temp");
                                                                                    if (dsTmp8.Tables[0].Rows.Count > 0)
                                                                                    {
                                                                                        TreeNode[] treeNodes9 = new TreeNode[dsTmp8.Tables[0].Rows.Count];
                                                                                        for (int i = 0; i < dsTmp8.Tables[0].Rows.Count; i++)
                                                                                        {
                                                                                            treeNodes9[i] = new TreeNode(dsTmp8.Tables[0].Rows[i][0].ToString().Trim());
                                                                                            treeNodes9[i].Text = dsTmp8.Tables[0].Rows[i][0].ToString().Trim();
                                                                                            treeNodes9[i].Name = dsTmp8.Tables[0].Rows[i][0].ToString().Trim();
                                                                                        }
                                                                                        foreach (TreeNode treeNode9 in treeNodes9)
                                                                                        {
                                                                                            SQL = "select MD003 from RHLX.dbo.BOMMC left join RHLX.dbo.BOMMD on MC001 = MD001 where MC001 = '" + treeNode9.Text.Trim() + "'";
                                                                                            objDataAdpter.SelectCommand = new SqlCommand(SQL, _sqlConnection);
                                                                                            DataSet dsTmp9 = new DataSet();
                                                                                            objDataAdpter.Fill(dsTmp9, "temp");
                                                                                            if (dsTmp9.Tables[0].Rows.Count > 0)
                                                                                            {
                                                                                                TreeNode[] treeNodes10 = new TreeNode[dsTmp9.Tables[0].Rows.Count];
                                                                                                for (int i = 0; i < dsTmp9.Tables[0].Rows.Count; i++)
                                                                                                {
                                                                                                    treeNodes10[i] = new TreeNode(dsTmp9.Tables[0].Rows[i][0].ToString().Trim());
                                                                                                    treeNodes10[i].Text = dsTmp9.Tables[0].Rows[i][0].ToString().Trim();
                                                                                                    treeNodes10[i].Name = dsTmp9.Tables[0].Rows[i][0].ToString().Trim();
                                                                                                }
                                                                                                foreach (TreeNode treeNode10 in treeNodes10)
                                                                                                {
                                                                                                    SQL = "select MD003 from RHLX.dbo.BOMMC left join RHLX.dbo.BOMMD on MC001 = MD001 where MC001 = '" + treeNode10.Text.Trim() + "'";
                                                                                                    objDataAdpter.SelectCommand = new SqlCommand(SQL, _sqlConnection);
                                                                                                    DataSet dsTmp10 = new DataSet();
                                                                                                    objDataAdpter.Fill(dsTmp10, "temp");
                                                                                                    if (dsTmp10.Tables[0].Rows.Count > 0)
                                                                                                    {
                                                                                                        TreeNode[] treeNodes11 = new TreeNode[dsTmp10.Tables[0].Rows.Count];
                                                                                                        for (int i = 0; i < dsTmp10.Tables[0].Rows.Count; i++)
                                                                                                        {
                                                                                                            treeNodes11[i] = new TreeNode(dsTmp10.Tables[0].Rows[i][0].ToString().Trim());
                                                                                                            treeNodes11[i].Text = dsTmp10.Tables[0].Rows[i][0].ToString().Trim();
                                                                                                            treeNodes11[i].Name = dsTmp10.Tables[0].Rows[i][0].ToString().Trim();
                                                                                                        }
                                                                                                        foreach (TreeNode treeNode11 in treeNodes11)
                                                                                                        {
                                                                                                            SQL = "select MD003 from RHLX.dbo.BOMMC left join RHLX.dbo.BOMMD on MC001 = MD001 where MC001 = '" + treeNode11.Text.Trim() + "'";
                                                                                                            objDataAdpter.SelectCommand = new SqlCommand(SQL, _sqlConnection);
                                                                                                            DataSet dsTmp11 = new DataSet();
                                                                                                            objDataAdpter.Fill(dsTmp11, "temp");
                                                                                                            if (dsTmp11.Tables[0].Rows.Count > 0)
                                                                                                            {
                                                                                                                TreeNode[] treeNodes12 = new TreeNode[dsTmp11.Tables[0].Rows.Count];
                                                                                                                for (int i = 0; i < dsTmp11.Tables[0].Rows.Count; i++)
                                                                                                                {
                                                                                                                    treeNodes12[i] = new TreeNode(dsTmp11.Tables[0].Rows[i][0].ToString().Trim());
                                                                                                                    treeNodes12[i].Text = dsTmp11.Tables[0].Rows[i][0].ToString().Trim();
                                                                                                                    treeNodes12[i].Name = dsTmp11.Tables[0].Rows[i][0].ToString().Trim();
                                                                                                                }
                                                                                                                foreach (TreeNode treeNode12 in treeNodes12)
                                                                                                                {
                                                                                                                    SQL = "select MD003 from RHLX.dbo.BOMMC left join RHLX.dbo.BOMMD on MC001 = MD001 where MC001 = '" + treeNode12.Text.Trim() + "'";
                                                                                                                    objDataAdpter.SelectCommand = new SqlCommand(SQL, _sqlConnection);
                                                                                                                    DataSet dsTmp12 = new DataSet();
                                                                                                                    objDataAdpter.Fill(dsTmp12, "temp");
                                                                                                                    if (dsTmp12.Tables[0].Rows.Count > 0)
                                                                                                                    {
                                                                                                                        TreeNode[] treeNodes13 = new TreeNode[dsTmp12.Tables[0].Rows.Count];
                                                                                                                        for (int i = 0; i < dsTmp12.Tables[0].Rows.Count; i++)
                                                                                                                        {
                                                                                                                            treeNodes13[i] = new TreeNode(dsTmp12.Tables[0].Rows[i][0].ToString().Trim());
                                                                                                                            treeNodes13[i].Text = dsTmp12.Tables[0].Rows[i][0].ToString().Trim();
                                                                                                                            treeNodes13[i].Name = dsTmp12.Tables[0].Rows[i][0].ToString().Trim();
                                                                                                                        }
                                                                                                                        foreach (TreeNode treeNode13 in treeNodes13)
                                                                                                                        {
                                                                                                                            SQL = "select MD003 from RHLX.dbo.BOMMC left join RHLX.dbo.BOMMD on MC001 = MD001 where MC001 = '" + treeNode13.Text.Trim() + "'";
                                                                                                                            objDataAdpter.SelectCommand = new SqlCommand(SQL, _sqlConnection);
                                                                                                                            DataSet dsTmp13 = new DataSet();
                                                                                                                            objDataAdpter.Fill(dsTmp13, "temp");
                                                                                                                            if (dsTmp13.Tables[0].Rows.Count > 0)
                                                                                                                            {
                                                                                                                                TreeNode[] treeNodes14 = new TreeNode[dsTmp13.Tables[0].Rows.Count];
                                                                                                                                for (int i = 0; i < dsTmp13.Tables[0].Rows.Count; i++)
                                                                                                                                {
                                                                                                                                    treeNodes14[i] = new TreeNode(dsTmp13.Tables[0].Rows[i][0].ToString().Trim());
                                                                                                                                    treeNodes14[i].Text = dsTmp13.Tables[0].Rows[i][0].ToString().Trim();
                                                                                                                                    treeNodes14[i].Name = dsTmp13.Tables[0].Rows[i][0].ToString().Trim();
                                                                                                                                }
                                                                                                                                foreach (TreeNode treeNode14 in treeNodes14)
                                                                                                                                {
                                                                                                                                    SQL = "select MD003 from RHLX.dbo.BOMMC left join RHLX.dbo.BOMMD on MC001 = MD001 where MC001 = '" + treeNode14.Text.Trim() + "'";
                                                                                                                                    objDataAdpter.SelectCommand = new SqlCommand(SQL, _sqlConnection);
                                                                                                                                    DataSet dsTmp14 = new DataSet();
                                                                                                                                    objDataAdpter.Fill(dsTmp14, "temp");
                                                                                                                                    if (dsTmp14.Tables[0].Rows.Count > 0)
                                                                                                                                    {
                                                                                                                                        TreeNode[] treeNodes15 = new TreeNode[dsTmp14.Tables[0].Rows.Count];
                                                                                                                                        for (int i = 0; i < dsTmp14.Tables[0].Rows.Count; i++)
                                                                                                                                        {
                                                                                                                                            treeNodes15[i] = new TreeNode(dsTmp14.Tables[0].Rows[i][0].ToString().Trim());
                                                                                                                                            treeNodes15[i].Text = dsTmp14.Tables[0].Rows[i][0].ToString().Trim();
                                                                                                                                            treeNodes15[i].Name = dsTmp14.Tables[0].Rows[i][0].ToString().Trim();
                                                                                                                                        }
                                                                                                                                        foreach (TreeNode treeNode15 in treeNodes15)
                                                                                                                                        {
                                                                                                                                            SQL = "select MD003 from RHLX.dbo.BOMMC left join RHLX.dbo.BOMMD on MC001 = MD001 where MC001 = '" + treeNode15.Text.Trim() + "'";
                                                                                                                                            objDataAdpter.SelectCommand = new SqlCommand(SQL, _sqlConnection);
                                                                                                                                            DataSet dsTmp15 = new DataSet();
                                                                                                                                            objDataAdpter.Fill(dsTmp15, "temp");
                                                                                                                                            if (dsTmp15.Tables[0].Rows.Count > 0)
                                                                                                                                            {
                                                                                                                                                TreeNode[] treeNodes16 = new TreeNode[dsTmp15.Tables[0].Rows.Count];
                                                                                                                                                for (int i = 0; i < dsTmp15.Tables[0].Rows.Count; i++)
                                                                                                                                                {
                                                                                                                                                    treeNodes16[i] = new TreeNode(dsTmp15.Tables[0].Rows[i][0].ToString().Trim());
                                                                                                                                                    treeNodes16[i].Text = dsTmp15.Tables[0].Rows[i][0].ToString().Trim();
                                                                                                                                                    treeNodes16[i].Name = dsTmp15.Tables[0].Rows[i][0].ToString().Trim();
                                                                                                                                                }
                                                                                                                                                foreach (TreeNode treeNode16 in treeNodes16)
                                                                                                                                                {
                                                                                                                                                    SQL = "select MD003 from RHLX.dbo.BOMMC left join RHLX.dbo.BOMMD on MC001 = MD001 where MC001 = '" + treeNode16.Text.Trim() + "'";
                                                                                                                                                    objDataAdpter.SelectCommand = new SqlCommand(SQL, _sqlConnection);
                                                                                                                                                    DataSet dsTmp16 = new DataSet();
                                                                                                                                                    objDataAdpter.Fill(dsTmp16, "temp");
                                                                                                                                                    if (dsTmp16.Tables[0].Rows.Count > 0)
                                                                                                                                                    {
                                                                                                                                                        TreeNode[] treeNodes17 = new TreeNode[dsTmp16.Tables[0].Rows.Count];
                                                                                                                                                        for (int i = 0; i < dsTmp16.Tables[0].Rows.Count; i++)
                                                                                                                                                        {
                                                                                                                                                            treeNodes17[i] = new TreeNode(dsTmp16.Tables[0].Rows[i][0].ToString().Trim());
                                                                                                                                                            treeNodes17[i].Text = dsTmp16.Tables[0].Rows[i][0].ToString().Trim();
                                                                                                                                                            treeNodes17[i].Name = dsTmp16.Tables[0].Rows[i][0].ToString().Trim();
                                                                                                                                                        }
                                                                                                                                                        foreach (TreeNode treeNode17 in treeNodes17)
                                                                                                                                                        {
                                                                                                                                                            SQL = "select MD003 from RHLX.dbo.BOMMC left join RHLX.dbo.BOMMD on MC001 = MD001 where MC001 = '" + treeNode17.Text.Trim() + "'";
                                                                                                                                                            objDataAdpter.SelectCommand = new SqlCommand(SQL, _sqlConnection);
                                                                                                                                                            DataSet dsTmp17 = new DataSet();
                                                                                                                                                            objDataAdpter.Fill(dsTmp17, "temp");
                                                                                                                                                            if (dsTmp17.Tables[0].Rows.Count > 0)
                                                                                                                                                            {
                                                                                                                                                                TreeNode[] treeNodes18 = new TreeNode[dsTmp17.Tables[0].Rows.Count];
                                                                                                                                                                for (int i = 0; i < dsTmp17.Tables[0].Rows.Count; i++)
                                                                                                                                                                {
                                                                                                                                                                    treeNodes18[i] = new TreeNode(dsTmp17.Tables[0].Rows[i][0].ToString().Trim());
                                                                                                                                                                    treeNodes18[i].Text = dsTmp17.Tables[0].Rows[i][0].ToString().Trim();
                                                                                                                                                                    treeNodes18[i].Name = dsTmp17.Tables[0].Rows[i][0].ToString().Trim();
                                                                                                                                                                }
                                                                                                                                                                foreach (TreeNode treeNode18 in treeNodes18)
                                                                                                                                                                {
                                                                                                                                                                    SQL = "select MD003 from RHLX.dbo.BOMMC left join RHLX.dbo.BOMMD on MC001 = MD001 where MC001 = '" + treeNode18.Text.Trim() + "'";
                                                                                                                                                                    objDataAdpter.SelectCommand = new SqlCommand(SQL, _sqlConnection);
                                                                                                                                                                    DataSet dsTmp18 = new DataSet();
                                                                                                                                                                    objDataAdpter.Fill(dsTmp18, "temp");
                                                                                                                                                                    if (dsTmp18.Tables[0].Rows.Count > 0)
                                                                                                                                                                    {
                                                                                                                                                                        TreeNode[] treeNodes19 = new TreeNode[dsTmp18.Tables[0].Rows.Count];
                                                                                                                                                                        for (int i = 0; i < dsTmp18.Tables[0].Rows.Count; i++)
                                                                                                                                                                        {
                                                                                                                                                                            treeNodes19[i] = new TreeNode(dsTmp18.Tables[0].Rows[i][0].ToString().Trim());
                                                                                                                                                                            treeNodes19[i].Text = dsTmp18.Tables[0].Rows[i][0].ToString().Trim();
                                                                                                                                                                            treeNodes19[i].Name = dsTmp18.Tables[0].Rows[i][0].ToString().Trim();
                                                                                                                                                                        }
                                                                                                                                                                        foreach (TreeNode treeNode19 in treeNodes19)
                                                                                                                                                                        {
                                                                                                                                                                            SQL = "select MD003 from RHLX.dbo.BOMMC left join RHLX.dbo.BOMMD on MC001 = MD001 where MC001 = '" + treeNode19.Text.Trim() + "'";
                                                                                                                                                                            objDataAdpter.SelectCommand = new SqlCommand(SQL, _sqlConnection);
                                                                                                                                                                            DataSet dsTmp19 = new DataSet();
                                                                                                                                                                            objDataAdpter.Fill(dsTmp19, "temp");
                                                                                                                                                                            if (dsTmp19.Tables[0].Rows.Count > 0)
                                                                                                                                                                            {
                                                                                                                                                                                TreeNode[] treeNodes20 = new TreeNode[dsTmp19.Tables[0].Rows.Count];
                                                                                                                                                                                for (int i = 0; i < dsTmp19.Tables[0].Rows.Count; i++)
                                                                                                                                                                                {
                                                                                                                                                                                    treeNodes20[i] = new TreeNode(dsTmp19.Tables[0].Rows[i][0].ToString().Trim());
                                                                                                                                                                                    treeNodes20[i].Text = dsTmp19.Tables[0].Rows[i][0].ToString().Trim();
                                                                                                                                                                                    treeNodes20[i].Name = dsTmp19.Tables[0].Rows[i][0].ToString().Trim();
                                                                                                                                                                                }
                                                                                                                                                                                foreach (TreeNode treeNode20 in treeNodes20)
                                                                                                                                                                                {
                                                                                                                                                                                    SQL = "select MD003 from RHLX.dbo.BOMMC left join RHLX.dbo.BOMMD on MC001 = MD001 where MC001 = '" + treeNode20.Text.Trim() + "'";
                                                                                                                                                                                    objDataAdpter.SelectCommand = new SqlCommand(SQL, _sqlConnection);
                                                                                                                                                                                    DataSet dsTmp20 = new DataSet();
                                                                                                                                                                                    objDataAdpter.Fill(dsTmp20, "temp");
                                                                                                                                                                                    if (dsTmp20.Tables[0].Rows.Count > 0)
                                                                                                                                                                                    {
                                                                                                                                                                                        TreeNode[] treeNodes21 = new TreeNode[dsTmp20.Tables[0].Rows.Count];
                                                                                                                                                                                        for (int i = 0; i < dsTmp20.Tables[0].Rows.Count; i++)
                                                                                                                                                                                        {
                                                                                                                                                                                            treeNodes21[i] = new TreeNode(dsTmp20.Tables[0].Rows[i][0].ToString().Trim());
                                                                                                                                                                                            treeNodes21[i].Text = dsTmp20.Tables[0].Rows[i][0].ToString().Trim();
                                                                                                                                                                                            treeNodes21[i].Name = dsTmp20.Tables[0].Rows[i][0].ToString().Trim();
                                                                                                                                                                                        }
                                                                                                                                                                                        // Kernel
                                                                                                                                                                                        treeNode20.Nodes.AddRange(treeNodes21);
                                                                                                                                                                                    }
                                                                                                                                                                                }
                                                                                                                                                                                treeNode19.Nodes.AddRange(treeNodes20);
                                                                                                                                                                            }
                                                                                                                                                                        }
                                                                                                                                                                        treeNode18.Nodes.AddRange(treeNodes19);
                                                                                                                                                                    }
                                                                                                                                                                }
                                                                                                                                                                treeNode17.Nodes.AddRange(treeNodes18);
                                                                                                                                                            }
                                                                                                                                                        }
                                                                                                                                                        treeNode16.Nodes.AddRange(treeNodes17);
                                                                                                                                                    }
                                                                                                                                                }
                                                                                                                                                treeNode15.Nodes.AddRange(treeNodes16);
                                                                                                                                            }
                                                                                                                                        }
                                                                                                                                        treeNode14.Nodes.AddRange(treeNodes15);
                                                                                                                                    }
                                                                                                                                }
                                                                                                                                treeNode13.Nodes.AddRange(treeNodes14);
                                                                                                                            }
                                                                                                                        }
                                                                                                                        treeNode12.Nodes.AddRange(treeNodes13);
                                                                                                                    }
                                                                                                                }
                                                                                                                treeNode11.Nodes.AddRange(treeNodes12);
                                                                                                            }
                                                                                                        }
                                                                                                        treeNode10.Nodes.AddRange(treeNodes11);
                                                                                                    }
                                                                                                }
                                                                                                treeNode9.Nodes.AddRange(treeNodes10);
                                                                                            }
                                                                                        }
                                                                                        treeNode8.Nodes.AddRange(treeNodes9);
                                                                                    }
                                                                                }
                                                                                treeNode7.Nodes.AddRange(treeNodes8);
                                                                            }
                                                                        }
                                                                        treeNode6.Nodes.AddRange(treeNodes7);
                                                                    }
                                                                }
                                                                treeNode5.Nodes.AddRange(treeNodes6);
                                                            }
                                                        }
                                                        treeNode4.Nodes.AddRange(treeNodes5);
                                                    }
                                                }
                                                treeNode3.Nodes.AddRange(treeNodes4);
                                            }
                                        }
                                        treeNode2.Nodes.AddRange(treeNodes3);
                                    }
                                }
                                treeNode1.Nodes.AddRange(treeNodes2);
                            }
                        }
                        treeNode.Nodes.AddRange(treeNodes1);
                    }
                }
                trvOrderDetail.Nodes.AddRange(treeNodes);
                TiaoChu:
                ;
            }
            catch (Exception ee)
            {
            }
        }

        private void GetFactory()
        {
            //throw new NotImplementedException();
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
