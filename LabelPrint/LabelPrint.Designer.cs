namespace LabelPrint
{
    partial class LabelPrint
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LabelPrint));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pd_Label = new System.Windows.Forms.PrintDialog();
            this.ppd_Label = new System.Windows.Forms.PrintPreviewDialog();
            this.pd_LabelStyle = new System.Drawing.Printing.PrintDocument();
            this.psd_Label = new System.Windows.Forms.PageSetupDialog();
            this.dgv_Label = new System.Windows.Forms.DataGridView();
            this.dgc_CheckNum = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.资产编号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.资产名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.账面原值 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.管理机构 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.责任人 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.会计凭证号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.品牌 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.规格型号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.入账日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_All = new System.Windows.Forms.CheckBox();
            this.lb_Count = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_PrintState = new System.Windows.Forms.TextBox();
            this.lb_PrintMessage = new System.Windows.Forms.Label();
            this.tb_PrintProcess = new System.Windows.Forms.TextBox();
            this.cb_ManageDept = new System.Windows.Forms.ComboBox();
            this.cb_BigClass = new System.Windows.Forms.ComboBox();
            this.tb_AssetName = new System.Windows.Forms.TextBox();
            this.tb_Price = new System.Windows.Forms.TextBox();
            this.btn_Query = new System.Windows.Forms.Button();
            this.tb_User = new System.Windows.Forms.TextBox();
            this.tb_Account = new System.Windows.Forms.TextBox();
            this.tb_AssetCode = new System.Windows.Forms.TextBox();
            this.tb_Judge = new System.Windows.Forms.TextBox();
            this.tb_Type = new System.Windows.Forms.TextBox();
            this.tb_GetDate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btn_Print = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tb_PrintNum = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Label)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pd_Label
            // 
            this.pd_Label.UseEXDialog = true;
            // 
            // ppd_Label
            // 
            this.ppd_Label.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.ppd_Label.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.ppd_Label.ClientSize = new System.Drawing.Size(400, 300);
            this.ppd_Label.Enabled = true;
            this.ppd_Label.Icon = ((System.Drawing.Icon)(resources.GetObject("ppd_Label.Icon")));
            this.ppd_Label.Name = "ppd_Label";
            this.ppd_Label.Visible = false;
            // 
            // pd_LabelStyle
            // 
            this.pd_LabelStyle.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pd_LabelStyle_PrintPage);
            // 
            // dgv_Label
            // 
            this.dgv_Label.AllowUserToAddRows = false;
            this.dgv_Label.AllowUserToDeleteRows = false;
            this.dgv_Label.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv_Label.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Label.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Label.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgc_CheckNum,
            this.资产编号,
            this.资产名称,
            this.账面原值,
            this.管理机构,
            this.责任人,
            this.会计凭证号,
            this.品牌,
            this.规格型号,
            this.入账日期});
            this.dgv_Label.Location = new System.Drawing.Point(12, 190);
            this.dgv_Label.Name = "dgv_Label";
            this.dgv_Label.RowHeadersWidth = 10;
            this.dgv_Label.RowTemplate.Height = 23;
            this.dgv_Label.Size = new System.Drawing.Size(963, 471);
            this.dgv_Label.TabIndex = 1;
            // 
            // dgc_CheckNum
            // 
            this.dgc_CheckNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgc_CheckNum.HeaderText = "选择";
            this.dgc_CheckNum.Name = "dgc_CheckNum";
            this.dgc_CheckNum.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgc_CheckNum.Width = 35;
            // 
            // 资产编号
            // 
            this.资产编号.DataPropertyName = "资产编号";
            this.资产编号.HeaderText = "资产编号";
            this.资产编号.Name = "资产编号";
            // 
            // 资产名称
            // 
            this.资产名称.DataPropertyName = "资产名称";
            this.资产名称.HeaderText = "资产名称";
            this.资产名称.Name = "资产名称";
            // 
            // 账面原值
            // 
            this.账面原值.DataPropertyName = "账面原值";
            this.账面原值.HeaderText = "账面原值";
            this.账面原值.Name = "账面原值";
            // 
            // 管理机构
            // 
            this.管理机构.DataPropertyName = "管理机构";
            this.管理机构.HeaderText = "管理机构";
            this.管理机构.Name = "管理机构";
            // 
            // 责任人
            // 
            this.责任人.DataPropertyName = "责任人";
            this.责任人.HeaderText = "责任人";
            this.责任人.Name = "责任人";
            // 
            // 会计凭证号
            // 
            this.会计凭证号.DataPropertyName = "会计凭证号";
            this.会计凭证号.HeaderText = "会计凭证号";
            this.会计凭证号.Name = "会计凭证号";
            // 
            // 品牌
            // 
            this.品牌.DataPropertyName = "品牌";
            this.品牌.HeaderText = "品牌";
            this.品牌.Name = "品牌";
            // 
            // 规格型号
            // 
            this.规格型号.DataPropertyName = "规格型号";
            this.规格型号.HeaderText = "规格型号";
            this.规格型号.Name = "规格型号";
            // 
            // 入账日期
            // 
            this.入账日期.DataPropertyName = "入账日期";
            this.入账日期.HeaderText = "入账日期";
            this.入账日期.Name = "入账日期";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(157, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "个设备";
            // 
            // cb_All
            // 
            this.cb_All.AutoSize = true;
            this.cb_All.Location = new System.Drawing.Point(6, 6);
            this.cb_All.Name = "cb_All";
            this.cb_All.Size = new System.Drawing.Size(48, 16);
            this.cb_All.TabIndex = 2;
            this.cb_All.Text = "全选";
            this.cb_All.UseVisualStyleBackColor = true;
            this.cb_All.CheckedChanged += new System.EventHandler(this.cb_All_CheckedChanged);
            // 
            // lb_Count
            // 
            this.lb_Count.AutoSize = true;
            this.lb_Count.Location = new System.Drawing.Point(126, 8);
            this.lb_Count.Name = "lb_Count";
            this.lb_Count.Size = new System.Drawing.Size(11, 12);
            this.lb_Count.TabIndex = 1;
            this.lb_Count.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "共计";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 671);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "打印机状态：";
            // 
            // tb_PrintState
            // 
            this.tb_PrintState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_PrintState.Location = new System.Drawing.Point(89, 667);
            this.tb_PrintState.Name = "tb_PrintState";
            this.tb_PrintState.Size = new System.Drawing.Size(249, 21);
            this.tb_PrintState.TabIndex = 6;
            // 
            // lb_PrintMessage
            // 
            this.lb_PrintMessage.AutoSize = true;
            this.lb_PrintMessage.Location = new System.Drawing.Point(344, 672);
            this.lb_PrintMessage.Name = "lb_PrintMessage";
            this.lb_PrintMessage.Size = new System.Drawing.Size(65, 12);
            this.lb_PrintMessage.TabIndex = 5;
            this.lb_PrintMessage.Text = "打印信息：";
            // 
            // tb_PrintProcess
            // 
            this.tb_PrintProcess.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_PrintProcess.Location = new System.Drawing.Point(427, 667);
            this.tb_PrintProcess.Name = "tb_PrintProcess";
            this.tb_PrintProcess.Size = new System.Drawing.Size(548, 21);
            this.tb_PrintProcess.TabIndex = 6;
            // 
            // cb_ManageDept
            // 
            this.cb_ManageDept.FormattingEnabled = true;
            this.cb_ManageDept.Location = new System.Drawing.Point(340, 2);
            this.cb_ManageDept.Name = "cb_ManageDept";
            this.cb_ManageDept.Size = new System.Drawing.Size(181, 20);
            this.cb_ManageDept.TabIndex = 1;
            this.cb_ManageDept.SelectedIndexChanged += new System.EventHandler(this.cb_ManageDept_SelectedIndexChanged);
            // 
            // cb_BigClass
            // 
            this.cb_BigClass.FormattingEnabled = true;
            this.cb_BigClass.Location = new System.Drawing.Point(70, 2);
            this.cb_BigClass.Name = "cb_BigClass";
            this.cb_BigClass.Size = new System.Drawing.Size(176, 20);
            this.cb_BigClass.TabIndex = 0;
            this.cb_BigClass.SelectedIndexChanged += new System.EventHandler(this.cb_BigClass_SelectedIndexChanged);
            // 
            // tb_AssetName
            // 
            this.tb_AssetName.Location = new System.Drawing.Point(608, 3);
            this.tb_AssetName.Name = "tb_AssetName";
            this.tb_AssetName.Size = new System.Drawing.Size(209, 21);
            this.tb_AssetName.TabIndex = 0;
            // 
            // tb_Price
            // 
            this.tb_Price.Location = new System.Drawing.Point(340, 27);
            this.tb_Price.Name = "tb_Price";
            this.tb_Price.Size = new System.Drawing.Size(181, 21);
            this.tb_Price.TabIndex = 0;
            // 
            // btn_Query
            // 
            this.btn_Query.Location = new System.Drawing.Point(3, 110);
            this.btn_Query.Name = "btn_Query";
            this.btn_Query.Size = new System.Drawing.Size(75, 23);
            this.btn_Query.TabIndex = 1;
            this.btn_Query.Text = "刷新";
            this.btn_Query.UseVisualStyleBackColor = true;
            this.btn_Query.Click += new System.EventHandler(this.btn_Query_Click);
            // 
            // tb_User
            // 
            this.tb_User.Location = new System.Drawing.Point(608, 30);
            this.tb_User.Name = "tb_User";
            this.tb_User.Size = new System.Drawing.Size(209, 21);
            this.tb_User.TabIndex = 0;
            // 
            // tb_Account
            // 
            this.tb_Account.Location = new System.Drawing.Point(340, 56);
            this.tb_Account.Name = "tb_Account";
            this.tb_Account.Size = new System.Drawing.Size(181, 21);
            this.tb_Account.TabIndex = 0;
            // 
            // tb_AssetCode
            // 
            this.tb_AssetCode.Location = new System.Drawing.Point(70, 28);
            this.tb_AssetCode.Name = "tb_AssetCode";
            this.tb_AssetCode.Size = new System.Drawing.Size(176, 21);
            this.tb_AssetCode.TabIndex = 0;
            // 
            // tb_Judge
            // 
            this.tb_Judge.Location = new System.Drawing.Point(70, 56);
            this.tb_Judge.Name = "tb_Judge";
            this.tb_Judge.Size = new System.Drawing.Size(176, 21);
            this.tb_Judge.TabIndex = 0;
            // 
            // tb_Type
            // 
            this.tb_Type.Location = new System.Drawing.Point(609, 56);
            this.tb_Type.Name = "tb_Type";
            this.tb_Type.Size = new System.Drawing.Size(208, 21);
            this.tb_Type.TabIndex = 0;
            // 
            // tb_GetDate
            // 
            this.tb_GetDate.Location = new System.Drawing.Point(70, 83);
            this.tb_GetDate.Name = "tb_GetDate";
            this.tb_GetDate.Size = new System.Drawing.Size(176, 21);
            this.tb_GetDate.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "资产大类:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(544, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "资产名称:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(269, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "账面原值:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(544, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 12);
            this.label9.TabIndex = 2;
            this.label9.Text = "使用人:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(269, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 12);
            this.label10.TabIndex = 2;
            this.label10.Text = "会计凭证号:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 12);
            this.label11.TabIndex = 2;
            this.label11.Text = "品牌:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(544, 59);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 12);
            this.label12.TabIndex = 2;
            this.label12.Text = "规格型号:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 84);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 12);
            this.label13.TabIndex = 2;
            this.label13.Text = "入账日期:";
            // 
            // btn_Print
            // 
            this.btn_Print.Location = new System.Drawing.Point(84, 110);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(75, 23);
            this.btn_Print.TabIndex = 4;
            this.btn_Print.Text = "USB打印";
            this.btn_Print.UseVisualStyleBackColor = true;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "资产编号:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(269, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "管理机构:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btn_Print);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.tb_PrintNum);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tb_GetDate);
            this.panel1.Controls.Add(this.tb_Type);
            this.panel1.Controls.Add(this.tb_Judge);
            this.panel1.Controls.Add(this.tb_AssetCode);
            this.panel1.Controls.Add(this.tb_Account);
            this.panel1.Controls.Add(this.tb_User);
            this.panel1.Controls.Add(this.btn_Query);
            this.panel1.Controls.Add(this.tb_Price);
            this.panel1.Controls.Add(this.tb_AssetName);
            this.panel1.Controls.Add(this.cb_BigClass);
            this.panel1.Controls.Add(this.cb_ManageDept);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(12, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(963, 139);
            this.panel1.TabIndex = 4;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(524, 90);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(95, 12);
            this.label15.TabIndex = 2;
            this.label15.Text = "（默认值为2份）";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(270, 86);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 12);
            this.label14.TabIndex = 2;
            this.label14.Text = "打印份数:";
            // 
            // tb_PrintNum
            // 
            this.tb_PrintNum.Location = new System.Drawing.Point(342, 85);
            this.tb_PrintNum.Name = "tb_PrintNum";
            this.tb_PrintNum.Size = new System.Drawing.Size(176, 21);
            this.tb_PrintNum.TabIndex = 0;
            this.tb_PrintNum.Text = "2";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lb_Count);
            this.panel2.Controls.Add(this.cb_All);
            this.panel2.Location = new System.Drawing.Point(12, 163);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(963, 27);
            this.panel2.TabIndex = 8;
            // 
            // LabelPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 700);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tb_PrintProcess);
            this.Controls.Add(this.tb_PrintState);
            this.Controls.Add(this.lb_PrintMessage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgv_Label);
            this.Name = "LabelPrint";
            this.Text = "标签打印管理";
            this.Load += new System.EventHandler(this.LabelPrint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Label)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PrintDialog pd_Label;
        private System.Windows.Forms.PrintPreviewDialog ppd_Label;
        private System.Drawing.Printing.PrintDocument pd_LabelStyle;
        private System.Windows.Forms.PageSetupDialog psd_Label;
        private whtb2008_V7DataSet whtb2008_V7DataSet;
        private whtb2008_V7DataSetTableAdapters.VBasAssetStockTableAdapter vBasAssetStockTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn 卡片编号DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 资产编号DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 资产名称DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 分类代码DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 分类名称DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 计量单位DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 财务分类DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 资产大类DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 数量DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 账面原值DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 使用状况DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 管理机构代码DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 管理机构DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 会计凭证号DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 入账日期DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 录入日期DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 折旧方法DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 录入人DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 备注DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 使用年限DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 净残值DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 净残值率DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 净值DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 已计提月份DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 月折旧额DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 累计折旧DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn custom01DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn custom02DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn custom03DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn custom04DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn custom05DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn custom06DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn custom07DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn custom08DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn custom09DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn custom10DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn custom11DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn custom12DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn custom13DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn custom14DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn custom15DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn custom16DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn custom17DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn custom18DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn custom19DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn custom20DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn custom21DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn custom22DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn custom23DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn custom24DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn custom25DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn custom26DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn custom27DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn custom28DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn custom29DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn custom30DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 盘盈标记DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 资金来源DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 增加方式DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn editDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn isEditDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 条码DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 责任人DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 使用人DataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cb_All;
        private System.Windows.Forms.Label lb_Count;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_PrintState;
        private System.Windows.Forms.Label lb_PrintMessage;
        private System.Windows.Forms.TextBox tb_PrintProcess;
        private System.Windows.Forms.DataGridView dgv_Label;
        private System.Windows.Forms.ComboBox cb_ManageDept;
        private System.Windows.Forms.ComboBox cb_BigClass;
        private System.Windows.Forms.TextBox tb_AssetName;
        private System.Windows.Forms.TextBox tb_Price;
        private System.Windows.Forms.Button btn_Query;
        private System.Windows.Forms.TextBox tb_User;
        private System.Windows.Forms.TextBox tb_Account;
        private System.Windows.Forms.TextBox tb_AssetCode;
        private System.Windows.Forms.TextBox tb_Judge;
        private System.Windows.Forms.TextBox tb_Type;
        private System.Windows.Forms.TextBox tb_GetDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btn_Print;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tb_PrintNum;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgc_CheckNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn 资产编号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 资产名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 账面原值;
        private System.Windows.Forms.DataGridViewTextBoxColumn 管理机构;
        private System.Windows.Forms.DataGridViewTextBoxColumn 责任人;
        private System.Windows.Forms.DataGridViewTextBoxColumn 会计凭证号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 品牌;
        private System.Windows.Forms.DataGridViewTextBoxColumn 规格型号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 入账日期;
    }
}

