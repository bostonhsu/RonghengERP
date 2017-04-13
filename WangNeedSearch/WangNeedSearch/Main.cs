using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WangNeedSearch
{
    public partial class main : Form
    {
        private List<Form> childForms;

        public main()
        {
            InitializeComponent();
            childForms = new List<Form>();
        }

        private void main_Load(object sender, EventArgs e)
        {
            RefreshLblCount();
        }

        private void RefreshLblCount()
        {
            lblCount.Text = childForms.Count.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isExistFlag = false;
            if (childForms.Count > 0)
            {
                foreach (var childForm in childForms)
                {
                    if (childForm is SubForm1)
                    {
                        isExistFlag = true;
                        childForm.Visible = true;
                    }
                    else
                    {
                        childForm.Visible = false;
                    }
                }
                if (!isExistFlag)
                {
                    AddSubForm1ToList();
                }
            }
            else
            {
                AddSubForm1ToList();
            }
            RefreshLblCount();
        }

        private void AddSubForm1ToList()
        {
            SubForm1 subForm1 = new SubForm1();
            subForm1.TopLevel = false;
            panel1.Controls.Add(subForm1);
            subForm1.Show();
            childForms.Add(subForm1);
        }

        private void AddSubForm2ToList()
        {
            SubForm2 subForm2 = new SubForm2();
            subForm2.TopLevel = false;
            panel1.Controls.Add(subForm2);
            subForm2.Show();
            childForms.Add(subForm2);
        }

        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var childForm in childForms)
            {
                childForm.Close();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            bool isExistFlag = false;
            if (childForms.Count > 0)
            {
                foreach (var childForm in childForms)
                {
                    if (childForm is SubForm2)
                    {
                        isExistFlag = true;
                        childForm.Visible = true;
                    }
                    else
                    {
                        childForm.Visible = false;
                    }
                }
                if (!isExistFlag)
                {
                    AddSubForm2ToList();
                }
            }
            else
            {
                AddSubForm2ToList();
            }
            RefreshLblCount();
        }
    }
}
