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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Query = new System.Windows.Forms.Button();
            this.tb_PrintNum = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btn_Print = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Label)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.dgv_Label.Location = new System.Drawing.Point(12, 93);
            this.dgv_Label.Name = "dgv_Label";
            this.dgv_Label.RowHeadersWidth = 10;
            this.dgv_Label.RowTemplate.Height = 23;
            this.dgv_Label.Size = new System.Drawing.Size(963, 568);
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
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lb_Count);
            this.panel2.Controls.Add(this.cb_All);
            this.panel2.Location = new System.Drawing.Point(12, 56);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(963, 31);
            this.panel2.TabIndex = 8;
            // 
            // btn_Query
            // 
            this.btn_Query.Location = new System.Drawing.Point(454, 3);
            this.btn_Query.Name = "btn_Query";
            this.btn_Query.Size = new System.Drawing.Size(75, 23);
            this.btn_Query.TabIndex = 1;
            this.btn_Query.Text = "刷新";
            this.btn_Query.UseVisualStyleBackColor = true;
            this.btn_Query.Click += new System.EventHandler(this.btn_Query_Click);
            // 
            // tb_PrintNum
            // 
            this.tb_PrintNum.Location = new System.Drawing.Point(78, 7);
            this.tb_PrintNum.Name = "tb_PrintNum";
            this.tb_PrintNum.Size = new System.Drawing.Size(176, 21);
            this.tb_PrintNum.TabIndex = 0;
            this.tb_PrintNum.Text = "2";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 12);
            this.label14.TabIndex = 2;
            this.label14.Text = "打印份数:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(260, 10);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(95, 12);
            this.label15.TabIndex = 2;
            this.label15.Text = "（默认值为2份）";
            // 
            // btn_Print
            // 
            this.btn_Print.Location = new System.Drawing.Point(373, 3);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(75, 23);
            this.btn_Print.TabIndex = 4;
            this.btn_Print.Text = "USB打印";
            this.btn_Print.UseVisualStyleBackColor = true;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Print);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.tb_PrintNum);
            this.panel1.Controls.Add(this.btn_Query);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(963, 38);
            this.panel1.TabIndex = 4;
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
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PrintDialog pd_Label;
        private System.Windows.Forms.PrintPreviewDialog ppd_Label;
        private System.Drawing.Printing.PrintDocument pd_LabelStyle;
        private System.Windows.Forms.PageSetupDialog psd_Label; 
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cb_All;
        private System.Windows.Forms.Label lb_Count;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_PrintState;
        private System.Windows.Forms.Label lb_PrintMessage;
        private System.Windows.Forms.TextBox tb_PrintProcess;
        private System.Windows.Forms.DataGridView dgv_Label;
        private System.Windows.Forms.Panel panel2;
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
        private System.Windows.Forms.Button btn_Query;
        private System.Windows.Forms.TextBox tb_PrintNum;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btn_Print;
        private System.Windows.Forms.Panel panel1;
    }
}

