namespace WangNeedSearch
{
    partial class SubForm2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtOrderNumber = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.trvOrderDetail = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDetailCount = new System.Windows.Forms.TextBox();
            this.lstFactory = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnXiaDan = new System.Windows.Forms.Button();
            this.lblNotFound = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtZC = new System.Windows.Forms.TextBox();
            this.txtXQ = new System.Windows.Forms.TextBox();
            this.txtKC = new System.Windows.Forms.TextBox();
            this.lstDanBie = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblKongDanBie = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "订单号：";
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.Location = new System.Drawing.Point(144, 28);
            this.txtOrderNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.Size = new System.Drawing.Size(238, 35);
            this.txtOrderNumber.TabIndex = 1;
            this.txtOrderNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOrderNumber_KeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(394, 28);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 42);
            this.button1.TabIndex = 2;
            this.button1.Text = "查找订单";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // trvOrderDetail
            // 
            this.trvOrderDetail.Location = new System.Drawing.Point(36, 88);
            this.trvOrderDetail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trvOrderDetail.Name = "trvOrderDetail";
            this.trvOrderDetail.Size = new System.Drawing.Size(346, 536);
            this.trvOrderDetail.TabIndex = 3;
            this.trvOrderDetail.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvOrderDetail_AfterSelect);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(612, 514);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "下单数量：";
            // 
            // txtDetailCount
            // 
            this.txtDetailCount.Location = new System.Drawing.Point(728, 506);
            this.txtDetailCount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDetailCount.Name = "txtDetailCount";
            this.txtDetailCount.Size = new System.Drawing.Size(146, 35);
            this.txtDetailCount.TabIndex = 5;
            // 
            // lstFactory
            // 
            this.lstFactory.FormattingEnabled = true;
            this.lstFactory.ItemHeight = 24;
            this.lstFactory.Location = new System.Drawing.Point(404, 380);
            this.lstFactory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstFactory.Name = "lstFactory";
            this.lstFactory.Size = new System.Drawing.Size(198, 244);
            this.lstFactory.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(404, 348);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "分公司：";
            // 
            // btnXiaDan
            // 
            this.btnXiaDan.Location = new System.Drawing.Point(744, 588);
            this.btnXiaDan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnXiaDan.Name = "btnXiaDan";
            this.btnXiaDan.Size = new System.Drawing.Size(132, 40);
            this.btnXiaDan.TabIndex = 8;
            this.btnXiaDan.Text = "下单";
            this.btnXiaDan.UseVisualStyleBackColor = true;
            this.btnXiaDan.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblNotFound
            // 
            this.lblNotFound.AutoSize = true;
            this.lblNotFound.ForeColor = System.Drawing.Color.Red;
            this.lblNotFound.Location = new System.Drawing.Point(538, 36);
            this.lblNotFound.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblNotFound.Name = "lblNotFound";
            this.lblNotFound.Size = new System.Drawing.Size(130, 24);
            this.lblNotFound.TabIndex = 25;
            this.lblNotFound.Text = "没有找到！";
            this.lblNotFound.Visible = false;
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(404, 88);
            this.lbl2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(58, 24);
            this.lbl2.TabIndex = 26;
            this.lbl2.Text = "在产";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(404, 148);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 24);
            this.label7.TabIndex = 27;
            this.label7.Text = "需求";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(404, 206);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 24);
            this.label11.TabIndex = 28;
            this.label11.Text = "库存";
            // 
            // txtZC
            // 
            this.txtZC.Location = new System.Drawing.Point(470, 84);
            this.txtZC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtZC.Name = "txtZC";
            this.txtZC.Size = new System.Drawing.Size(146, 35);
            this.txtZC.TabIndex = 29;
            // 
            // txtXQ
            // 
            this.txtXQ.Location = new System.Drawing.Point(470, 142);
            this.txtXQ.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtXQ.Name = "txtXQ";
            this.txtXQ.Size = new System.Drawing.Size(146, 35);
            this.txtXQ.TabIndex = 30;
            // 
            // txtKC
            // 
            this.txtKC.Location = new System.Drawing.Point(470, 202);
            this.txtKC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtKC.Name = "txtKC";
            this.txtKC.Size = new System.Drawing.Size(146, 35);
            this.txtKC.TabIndex = 31;
            // 
            // lstDanBie
            // 
            this.lstDanBie.FormattingEnabled = true;
            this.lstDanBie.ItemHeight = 24;
            this.lstDanBie.Location = new System.Drawing.Point(678, 239);
            this.lstDanBie.Margin = new System.Windows.Forms.Padding(4);
            this.lstDanBie.Name = "lstDanBie";
            this.lstDanBie.Size = new System.Drawing.Size(198, 244);
            this.lstDanBie.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(674, 202);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 24);
            this.label4.TabIndex = 33;
            this.label4.Text = "工单单别：";
            // 
            // lblKongDanBie
            // 
            this.lblKongDanBie.AutoSize = true;
            this.lblKongDanBie.ForeColor = System.Drawing.Color.Red;
            this.lblKongDanBie.Location = new System.Drawing.Point(674, 163);
            this.lblKongDanBie.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblKongDanBie.Name = "lblKongDanBie";
            this.lblKongDanBie.Size = new System.Drawing.Size(82, 24);
            this.lblKongDanBie.TabIndex = 34;
            this.lblKongDanBie.Text = "空单别";
            this.lblKongDanBie.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(357, 698);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(217, 57);
            this.button2.TabIndex = 35;
            this.button2.Text = "GetMaxSerial";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // SubForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.ClientSize = new System.Drawing.Size(900, 780);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblKongDanBie);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lstDanBie);
            this.Controls.Add(this.txtKC);
            this.Controls.Add(this.txtXQ);
            this.Controls.Add(this.txtZC);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lblNotFound);
            this.Controls.Add(this.btnXiaDan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstFactory);
            this.Controls.Add(this.txtDetailCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trvOrderDetail);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtOrderNumber);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "SubForm2";
            this.ShowIcon = false;
            this.Text = "SubForm2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SubForm2_FormClosing);
            this.Load += new System.EventHandler(this.SubForm2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOrderNumber;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TreeView trvOrderDetail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDetailCount;
        private System.Windows.Forms.ListBox lstFactory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnXiaDan;
        private System.Windows.Forms.Label lblNotFound;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtZC;
        private System.Windows.Forms.TextBox txtXQ;
        private System.Windows.Forms.TextBox txtKC;
        private System.Windows.Forms.ListBox lstDanBie;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblKongDanBie;
        private System.Windows.Forms.Button button2;
    }
}