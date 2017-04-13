using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using WangNeedSearch.Properties;
using static System.Windows.Forms.MessageBox;

namespace WangNeedSearch
{
    public partial class SubForm1 : Form
    {
        private SqlConnection _sqlConnection;
        private const string ConnString = "UID=sa;Password=sa;Initial Catalog=RH;Data Source=192.168.1.6";

        public SubForm1()
        {
            InitializeComponent();
        }

        private void ConnectDb()
        {
            _sqlConnection = new SqlConnection(ConnString);
            _sqlConnection.Open();
        }

        private void SubForm1_Load(object sender, EventArgs e)
        {
            try
            {
                ConnectDb();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private string GetKCRH(string tuHao)
        {
            string ret = null;
            try
            {
                string SQL = "SELECT SUM(MC007) AS sumsss FROM  (SELECT MC001, MC002, MC007 FROM INVMC WHERE (MC001 = '" + tuHao + "') AND (MC002 LIKE '%C%')) AS tempttt";
                SqlDataAdapter objDataAdpter = new SqlDataAdapter();
                objDataAdpter.SelectCommand = new SqlCommand(SQL, _sqlConnection);
                DataSet ds = new DataSet();
                objDataAdpter.Fill(ds, "temp");
                ret = ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ee)
            {
            }
            return ret;
        }

        private string GetKCJZ(string tuHao)
        {
            string ret = null;
            try
            {
                string SQL = "SELECT SUM(MC007) AS sumsss FROM  (SELECT MC001, MC002, MC007 FROM INVMC WHERE (MC001 = '" + tuHao + "') AND (MC002 LIKE '%A%')) AS tempttt";
                SqlDataAdapter objDataAdpter = new SqlDataAdapter();
                objDataAdpter.SelectCommand = new SqlCommand(SQL, _sqlConnection);
                DataSet ds = new DataSet();
                objDataAdpter.Fill(ds, "temp");
                ret = ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ee)
            {
            }
            return ret;
        }

        private string GetKCSY(string tuHao)
        {
            string ret = null;
            try
            {
                string SQL = "SELECT SUM(MC007) AS sumsss FROM  (SELECT MC001, MC002, MC007 FROM INVMC WHERE (MC001 = '" + tuHao + "') AND (MC002 LIKE '%D%')) AS tempttt";
                SqlDataAdapter objDataAdpter = new SqlDataAdapter();
                objDataAdpter.SelectCommand = new SqlCommand(SQL, _sqlConnection);
                DataSet ds = new DataSet();
                objDataAdpter.Fill(ds, "temp");
                ret = ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ee)
            {
            }
            return ret;
        }

        private string GetKCXC(string tuHao)
        {
            string ret = null;
            try
            {
                string SQL = "SELECT MB064 FROM XC.dbo.INVMB where MB001='" + tuHao + "'";
                SqlDataAdapter objDataAdpter = new SqlDataAdapter();
                objDataAdpter.SelectCommand = new SqlCommand(SQL, _sqlConnection);
                DataSet ds = new DataSet();
                objDataAdpter.Fill(ds, "temp");
                ret = ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ee)
            {
            }
            return ret;
        }

        private string GetKCGH(string tuHao)
        {
            string ret = null;
            try
            {
                string SQL = "SELECT MB064 FROM GH.dbo.INVMB where MB001='" + tuHao + "'";
                SqlDataAdapter objDataAdpter = new SqlDataAdapter();
                objDataAdpter.SelectCommand = new SqlCommand(SQL, _sqlConnection);
                DataSet ds = new DataSet();
                objDataAdpter.Fill(ds, "temp");
                ret = ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ee)
            {
            }
            return ret;
        }

        private string GetZCRH(string tuHao)
        {
            string ret = null;
            try
            {
                string SQL = "SELECT MOCTA.TA001, MOCTA.TA002, MOCTA.TA015, MOCTA.TA017, MOCTA.TA021, MOCTA.TA026, MOCTA.TA027, COPMA.MA002 FROM MOCTA LEFT OUTER JOIN COPTC ON MOCTA.TA026 = COPTC.TC001 AND MOCTA.TA027 = COPTC.TC002 LEFT OUTER JOIN COPMA ON COPTC.TC004 = COPMA.MA001 WHERE (MOCTA.TA011 <> 'Y') AND (MOCTA.TA011 <> 'y') AND (MOCTA.TA006 = '" + tuHao + "')";
                //SQL = "SELECT SUM(MOCTA.TA015) AS SUMTA, SUM(MOCTA.TA017) AS SUMTB FROM MOCTA LEFT OUTER JOIN COPTC ON MOCTA.TA026 = COPTC.TC001 AND MOCTA.TA027 = COPTC.TC002 LEFT OUTER JOIN COPMA ON COPTC.TC004 = COPMA.MA001 WHERE (MOCTA.TA011 <> 'Y') AND (MOCTA.TA011 <> 'y') AND (MOCTA.TA006 = '" + tuHao + "')";
                SQL = "SELECT SUM(MOCTA.TA015) AS SUMTA, SUM(MOCTA.TA017) AS SUMTB FROM RH.dbo.MOCTA LEFT OUTER JOIN RH.dbo.COPTC ON (MOCTA.TA026 = COPTC.TC001 AND MOCTA.TA027 = COPTC.TC002) LEFT OUTER JOIN RH.dbo.COPMA ON COPTC.TC004 = COPMA.MA001 WHERE (MOCTA.TA011 <> 'Y') AND (MOCTA.TA011 <> 'y') AND (MOCTA.TA006 = '" + tuHao + "')";
                SqlDataAdapter objDataAdpter = new SqlDataAdapter();
                objDataAdpter.SelectCommand = new SqlCommand(SQL, _sqlConnection);
                DataSet ds = new DataSet();
                objDataAdpter.Fill(ds, "temp");
                double sums;
                double factor;
                sums = Double.Parse(ds.Tables[0].Rows[0][0].ToString());
                factor = Double.Parse(ds.Tables[0].Rows[0][1].ToString());
                sums = sums - factor;
                ret = sums.ToString();
            }
            catch (Exception ee)
            {
            }
            return ret;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            lblNotFound.Visible = false;
            if (txtSearch.Text.Trim() != "")
            {
                string temp = txtSearch.Text.Trim();
                if (string.IsNullOrEmpty(txtKCRH.Text = GetKCRH(temp)))
                {
                    lblNotFound.Text = "没有找到！";
                    lblNotFound.Visible = true;
                    ClearUIContent();
                }
                else
                {
                    txtKCJZ.Text = GetKCJZ(temp);
                    txtKCSY.Text = GetKCSY(temp);
                    txtKCXC.Text = GetKCXC(temp);
                    txtKCGH.Text = GetKCGH(temp);
                    txtZCRH.Text = GetZCRH(temp);
                }
            }
            else
            {
                lblNotFound.Text = "不能为空！";
                lblNotFound.Visible = true;
                ClearUIContent();
            }
        }

        private void ClearUIContent()
        {
            txtKCRH.Text = "";
            txtKCXC.Text = "";
            txtKCGH.Text = "";
            txtXQRH.Text = "";
            txtXQXC.Text = "";
            txtXQGH.Text = "";
            txtZCRH.Text = "";
            txtZCXC.Text = "";
            txtZCGH.Text = "";
        }

        private void SubForm1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _sqlConnection.Close();
            _sqlConnection.Dispose();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }
    }
}
