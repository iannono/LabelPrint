using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Threading;
using System.Data.OleDb;


namespace LabelPrint
{
    public partial class LabelPrint : Form
    {
        public Int32 _page = 0;
        public Boolean _check_Flag = false;
        public int m_PortIndex = 0;
        public LabelPrint()
        {
            InitializeComponent();
            
            Link_Access();
            Data_Init();
            check_State();

        }

        private void initPrinter()
        {
            this.pd_Label.Document = this.pd_LabelStyle;
            this.ppd_Label.Document = this.pd_LabelStyle;
            this.psd_Label.Document = this.pd_LabelStyle;
        }

        private void Link_Access()
        {
            string strDSN = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"../whtb2008_V7.mdb\"";
            string strSQL = Generate_Query();
            OleDbConnection myConn = new OleDbConnection(strDSN);
            
            try
            {
                myConn.Open();
                OleDbDataAdapter myAdapter = new OleDbDataAdapter(strSQL,strDSN);
                DataSet ds = new DataSet();
                myAdapter.Fill(ds);
                this.dgv_Label.DataSource = ds.Tables[0];
                init_Item_Count(ds.Tables[0].Rows.Count.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show("数据读取错误：\n错误信息--:" + e.Message.ToString(), "系统提示！", MessageBoxButtons.OK);
            }
            finally
            {
                myConn.Close();
            } 
        }
        /// <summary>
        /// 数据绑定初始化
        /// </summary>
        private void Data_Init()
        {
            try
            {
                whtb2008_V7DataSetTableAdapters.VBasAssetStockTableAdapter _BasAssetStockTA = new whtb2008_V7DataSetTableAdapters.VBasAssetStockTableAdapter();

                //绑定资产大类
                whtb2008_V7DataSetTableAdapters.BasClassCodeTableAdapter _BasClassCodeTA = new whtb2008_V7DataSetTableAdapters.BasClassCodeTableAdapter();
                whtb2008_V7DataSet.BasClassCodeDataTable _BasClassCodeDT = _BasClassCodeTA.GetBigClass();
                DataRow _row_Class = _BasClassCodeDT.NewRow();
                _row_Class["vcBigClass"] = "请选择资产大类";
                _row_Class["vcBigClassCode"] = 0;
                _BasClassCodeDT.Rows.InsertAt(_row_Class, 0);
                this.cb_BigClass.DisplayMember = "vcBigClass";
                this.cb_BigClass.ValueMember = "vcBigClassCode";
                
                //绑定管理机构
                whtb2008_V7DataSet.VBasAssetStockDataTable _BasAssetStockDT_Dept = _BasAssetStockTA.GetManageDept();
                DataRow _row_Dept = _BasAssetStockDT_Dept.NewRow();
                _row_Dept["管理机构"] = "请选择管理机构";
                _row_Dept["管理机构代码"] = 0;
                _BasAssetStockDT_Dept.Rows.InsertAt(_row_Dept, 0);
                this.cb_ManageDept.DisplayMember = "管理机构";
                this.cb_ManageDept.ValueMember = "管理机构代码";

                //下拉菜单绑定
                this.cb_BigClass.DataSource = _BasClassCodeDT;
                this.cb_ManageDept.DataSource = _BasAssetStockDT_Dept;

                //绑定数据集              
                //whtb2008_V7DataSet.VBasAssetStockDataTable _BasAssetStockDT = _BasAssetStockTA.GetData();
                
                //this.dgv_Label.DataSource = _BasAssetStockDT;
                //initPrinter();
                
            }
            catch (Exception e)
            {
                MessageBox.Show("请确认设置了正确数据源：\n错误信息--:" + e.Message.ToString(), "系统提示！", MessageBoxButtons.OK);
            }

        }

        /// <summary>
        /// 根据查询条件生成查询字符串
        /// </summary>
        private string  Generate_Query()
        {
            string _query = "SELECT 卡片编号, 资产编号, 资产名称, 分类名称, 计量单位, 财务分类, 资产大类,数量, 账面原值, 使用状况, 管理机构, 会计凭证号, custom06 AS 规格型号, custom01 AS 品牌, 入账日期, 责任人 FROM VBasAssetStock where 1=1";
            try
            {
                string _big_class = this.cb_BigClass.Text.ToString();//资产大类
                string _manage_dept = this.cb_ManageDept.Text.ToString();//管理机构
                string _asset_name = this.tb_AssetName.Text.ToString();//资产名称
                string _asset_price = this.tb_Price.Text.ToString();//账面原值
                string _asset_code = this.tb_AssetCode.Text.ToString();//资产编号
                string _asset_user = this.tb_User.Text.ToString();//使用人
                string _asset_account = this.tb_Account.Text.ToString();//会计凭证号
                string _asset_judge = this.tb_Judge.Text.ToString();//品牌
                string _asset_type = this.tb_Type.Text.ToString();//规格型号
                string _asset_get_date = this.tb_GetDate.Text.ToString();//入账日期

                if (this.cb_BigClass.SelectedValue.ToString() != "0")
                {
                    _query += " and 资产大类 like '%" + _big_class + "%'";
                }

                if (this.cb_ManageDept.SelectedValue.ToString() != "0")
                {
                    _query += " and 管理机构 like '%" + _manage_dept + "%'";
                }

                if (_asset_name != "")
                {
                    _query += " and 资产名称 like '%" + _asset_name + "%'";
                }
                if (_asset_price != "")
                {
                    _query += " and 账面原值 like '%" + _asset_price + "%'";
                }
                if (_asset_code != "")
                {
                    _query += " and 资产编号 like '%" + _asset_code + "%'";
                }
                if (_asset_user != "")
                {
                    _query += " and 使用人 like '%" + _asset_user + "%'";
                }
                if (_asset_account != "")
                {
                    _query += " and 会计凭证号 like '%" + _asset_account + "%'";
                }
                if (_asset_judge != "")
                {
                    _query += " and custom01 like '%" + _asset_judge + "%'";
                }
                if (_asset_type != "")
                {
                    _query += " and custom06 like '%" + _asset_type + "%'";
                }
                if (_asset_get_date != "")
                {
                    _query += " and 入账日期 like '%" + _asset_get_date + "%'";
                }
                return _query;
            }
            catch
            {
                return _query;
            }
        }
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBound()
        {
            try
            {
                string _big_class = (this.cb_BigClass.SelectedValue.ToString() == "0") ? "%" : this.cb_BigClass.Text;//资产大类
                string _manage_dept = (this.cb_ManageDept.SelectedValue.ToString() == "0") ? "%" : this.cb_ManageDept.Text;//管理机构
                string _asset_name = (this.tb_AssetName.Text.ToString() == "") ? "%" : this.tb_AssetName.Text;//资产名称
                string _asset_price = (this.tb_Price.Text.ToString() == "") ? "#" : this.tb_Price.Text;//账面原值
                string _asset_code = (this.tb_AssetCode.Text.ToString() == "") ? "%" : this.tb_AssetCode.Text;//资产编号
                string _asset_user = (this.tb_User.Text.ToString() == "") ? "%" : this.tb_User.Text;//使用人
                string _asset_account = (this.tb_Account.Text.ToString() == "") ? "%" : this.tb_Account.Text;//会计凭证号
                string _asset_judge = (this.tb_Judge.Text.ToString() == "") ? "%" : this.tb_Judge.Text;//品牌
                string _asset_type = (this.tb_Type.Text.ToString() == "") ? "%" : this.tb_Type.Text;//规格型号
                string _asset_get_date = (this.tb_GetDate.Text.ToString() == "") ? "%" : this.tb_GetDate.Text;//规格型号

                whtb2008_V7DataSetTableAdapters.VBasAssetStockTableAdapter _BasAssetStockTA = new whtb2008_V7DataSetTableAdapters.VBasAssetStockTableAdapter();
                whtb2008_V7DataSet.VBasAssetStockDataTable _BasAssetStockDT = _BasAssetStockTA.GetDataByQuery(_big_class, _manage_dept,_asset_code,_asset_name,Convert.ToDecimal(_asset_price),_asset_account,_asset_type,_asset_judge,Convert.ToDateTime(_asset_get_date));
                this.dgv_Label.DataSource = _BasAssetStockDT;
                init_Item_Count(_BasAssetStockDT.Rows.Count.ToString());
            }
            catch
            { }
        }


        private void btn_PrintSetup_Click(object sender, EventArgs e)
        {
            this.psd_Label.ShowDialog();
        }

        private void btn_Preview_Click(object sender, EventArgs e)
        {
            this.ppd_Label.ShowDialog();
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            //使用普通打印方式进行打印；
            //if (this.pd_Label.ShowDialog() == DialogResult.OK)
            //{
            //    this.pd_LabelStyle.Print();
            //}
            //调用标签打印机进行打印；
            print_ReadData_Double();
        }


        /// <summary>
        /// 调用驱动进行打印；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pd_LabelStyle_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Tahoma", 5, FontStyle.Underline);
            Brush bru = Brushes.Black;
            Pen pen = new Pen(bru);
            pen.Width = 1;

            //设置各边距 
            int nLeft = this.psd_Label.PageSettings.Margins.Left;
            int nTop = this.psd_Label.PageSettings.Margins.Top;
            int nRight = this.psd_Label.PageSettings.Margins.Right;
            int nBottom = this.psd_Label.PageSettings.Margins.Bottom;
            int nWidth = this.psd_Label.PageSettings.PaperSize.Width - nRight - nLeft;
            int nHeight = this.psd_Label.PageSettings.PaperSize.Height - nTop - nBottom;

            //打印各边距 
            e.Graphics.DrawLine(pen, nLeft, nTop, nLeft, nTop + nHeight);
            e.Graphics.DrawLine(pen, nLeft + nWidth, nTop, nLeft + nWidth, nTop + nHeight);
            e.Graphics.DrawLine(pen, nLeft, nTop, nLeft + nWidth, nTop);
            e.Graphics.DrawLine(pen, nLeft, nTop + nHeight, nLeft + nWidth, nTop + nHeight);

            Int32 _Index = 0;
            Boolean _Flag = false;
            Int32 _rowCount = this.dgv_Label.Rows.Count;
            string text1, text2, text3, text4, text5, text6, text7, text8, text9;
            for (Int32 i = _page; i < _rowCount; i++)
            {
                if (Convert.ToBoolean(dgv_Label.Rows[i].Cells[0].Value) != true)
                {
                    if (i == _rowCount - 1)
                    {
                        e.HasMorePages = false;
                        _Flag = true;//代表循环到最后一条；
                        break;
                    }
                    continue;
                }
                else
                {
                    ++_Index;
                }

                text1 = "资产编号--" + this.dgv_Label.Rows[i].Cells[1].Value;//资产编号
                text2 = "资产名称--" + this.dgv_Label.Rows[i].Cells[2].Value;//资产名称
                text3 = "账面原值--" + this.dgv_Label.Rows[i].Cells[3].Value;//账面原值
                text4 = "管理机构--" + this.dgv_Label.Rows[i].Cells[4].Value;//管理机构
                text5 = "使用人--" + this.dgv_Label.Rows[i].Cells[5].Value;//使用人
                text6 = "会计凭证号--" + this.dgv_Label.Rows[i].Cells[6].Value;//会计凭证号
                text7 = "品牌--" + this.dgv_Label.Rows[i].Cells[7].Value;//品牌
                text8 = "规格型号--" + this.dgv_Label.Rows[i].Cells[8].Value;//规格型号
                text9 = "取得日期--" + this.dgv_Label.Rows[i].Cells[9].Value;//取得日期

                e.Graphics.DrawString("武汉市结核防治所", font, bru, nLeft + 20, nTop + 10);
                e.Graphics.DrawString(text1, font, bru, nLeft + 20, nTop + 20);
                e.Graphics.DrawString(text2, font, bru, nLeft + 20, nTop + 30);
                e.Graphics.DrawString(text3, font, bru, nLeft + 20, nTop + 40);
                e.Graphics.DrawString(text4, font, bru, nLeft + 20, nTop + 50);
                e.Graphics.DrawString(text5, font, bru, nLeft + 20, nTop + 60);
                e.Graphics.DrawString(text6, font, bru, nLeft + 20, nTop + 70);
                e.Graphics.DrawString(text7, font, bru, nLeft + 20, nTop + 80);
                e.Graphics.DrawString(text8, font, bru, nLeft + 20, nTop + 90);
                e.Graphics.DrawString(text9, font, bru, nLeft + 20, nTop + 100);

                if (Convert.ToBoolean(_Index % 2))
                {
                    nLeft = nLeft + 150;
                }
                else
                {
                    nLeft = nLeft - 150;
                }
                if (!Convert.ToBoolean(_Index % 2))
                {
                    _page = i + 1;
                    break;
                }
                if (i == _rowCount - 1)
                {
                    e.HasMorePages = false;
                    _Flag = true;//代表循环到最后一条；
                    break;
                }

            }
            if (_Flag == false && _page != _rowCount)
            {
                e.HasMorePages = true;
            }
            else
            {
                _page = 0;
            }
            //在离左边距20,右边距20的位置打印haha xixi 
            //e.Graphics.DrawString("haha xixi", font, bru, nLeft + 20, nTop + 20);//如果要打印datagridView在这里遍历便可
        }



        private void LabelPrint_Load(object sender, EventArgs e)
        {


        }

        /// <summary>
        /// 资产大类选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_BigClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            //绑定数据集
            //whtb2008_V7DataSetTableAdapters.VBasAssetStockTableAdapter _BasAssetStockTA = new whtb2008_V7DataSetTableAdapters.VBasAssetStockTableAdapter();
            //whtb2008_V7DataSet.VBasAssetStockDataTable _BasAssetStockDT = _BasAssetStockTA.GetDataByBigClass(this.cb_BigClass.Text);
            //this.dgv_Label.AutoGenerateColumns = false;
            //this.dgv_Label.DataSource = _BasAssetStockDT;
            //DataBound();
        }

        /// <summary>
        /// 管理机构选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_ManageDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            //绑定数据集
            //whtb2008_V7DataSetTableAdapters.VBasAssetStockTableAdapter _BasAssetStockTA = new whtb2008_V7DataSetTableAdapters.VBasAssetStockTableAdapter();
            //whtb2008_V7DataSet.VBasAssetStockDataTable _BasAssetStockDT = _BasAssetStockTA.GetDataByManageDept(this.cb_ManageDept.Text);
            //this.dgv_Label.AutoGenerateColumns = false;
            //this.dgv_Label.DataSource = _BasAssetStockDT;
           //DataBound();         
        }

        /// <summary>
        /// 根据筛选条件进行查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Query_Click(object sender, EventArgs e)
        {
            Link_Access();
            //string _queryString = this.tb_AssetName.Text.Trim();
            //whtb2008_V7DataSetTableAdapters.VBasAssetStockTableAdapter _BasAssetStockTA = new whtb2008_V7DataSetTableAdapters.VBasAssetStockTableAdapter();
            //whtb2008_V7DataSet.VBasAssetStockDataTable _BasAssetStockDT = _BasAssetStockTA.GetDataByAssetName(_queryString);
            //this.dgv_Label.AutoGenerateColumns = false;
            //this.dgv_Label.DataSource = _BasAssetStockDT;
            //init_Item_Count(_BasAssetStockDT.Rows.Count.ToString());
           // DataBound();
        }

        /// <summary>
        /// 初始化筛选条目数量
        /// </summary>
        private void init_Item_Count(string _num)
        {
            this.lb_Count.Text = _num;
            this.cb_All.Checked = false;
        }

        private void grid_Bound(whtb2008_V7DataSet.VBasAssetStockDataTable _BasAssetStockDT)
        {
            this.dgv_Label.AutoGenerateColumns = false;
            this.dgv_Label.DataSource = _BasAssetStockDT;
        }

        /// <summary>
        /// 全选设备
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_All_CheckedChanged(object sender, EventArgs e)
        {
            Int32 _rowCount = this.dgv_Label.Rows.Count;

            if (this.cb_All.Checked)
            {
                for (Int32 i = 0; i < _rowCount; i++)
                {
                    dgv_Label.Rows[i].Cells[0].Value = true;
                }
            }
            else
            {
                for (Int32 i = 0; i < _rowCount; i++)
                {
                    dgv_Label.Rows[i].Cells[0].Value = false;
                }
            }
        }

        /// <summary>
        /// 检查USB端口的状态，判断打印机是否连接
        /// </summary>
        private void check_State()
        {
            int m_Result = 0;
            int m_Timeout = 0;
            string errorcode;
            m_PortIndex = 0;
            m_Result = PrinterDll.BPLA_OpenUsb();
            if (m_Result != PrinterDll.BPLA_OK)
            {

                //btn_Print.Enabled = false;
                errorcode = "端口打开错误，错误值--";
                errorcode += m_Result.ToString();
                tb_PrintState.Text = errorcode;
                return;
            }
            tb_PrintState.Text = "打印机读取状态正常";
            //m_Result = PrinterDll.BPLA_SetTimeOut(m_Timeout);
            //if (m_Result != PrinterDll.BPLA_OK)//USB口时设置端口超时
            //{

            //    btn_Print.Enabled = false;
            //    errorcode = "设置端口超时错误，错误值--";
            //    errorcode += m_Result.ToString();
            //    tb_PrintState.Text = errorcode;
            //    return;
            //}
        }

        /// <summary>
        /// 启动打印程序
        /// </summary>
        private void print_Start()
        {
            //bool bstate;
            //int starttime, endtime, time;
            //string info = "";

            //starttime = System.Environment.TickCount;
            //bstate = print_Process();
            //endtime = System.Environment.TickCount;
            //time = endtime - starttime;

            //if (bstate)
            //{
            //    info += " 打印成功-";
            //    info += time.ToString();
            //    info += "ms";
            //    tb_PrintProcess.Text = info;
            //    btn_Print.Enabled = true;
            //}
            //else
            //{

            //    info = "打印失败";
            //    tb_PrintProcess.Text = info;
            //    btn_Print.Enabled = false;
            //}
        }

        /// <summary>
        /// 打印过程（双列打印）
        /// _is_Single:判断是打印一边，还是打印两边的数据；
        /// </summary>
        private bool print_Process_Double(Dictionary<string,string> _printData,bool _is_Single)
        {
            #region
            //byte[] m_papershort = new byte[3], m_ribbionshort = new byte[3], m_busy = new byte[3], m_pause = new byte[3], m_com = new byte[3], m_headheat = new byte[3], m_headover = new byte[3], m_cut = new byte[3];
            //string m_info = "";
            //int state1;

            ////if (m_PortIndex == 3)//*********驱动启动打印
            ////{
            ////    state1 = PrinterDll.BPLA_StartDoc();
            ////    if (state1 != PrinterDll.BPLA_OK)
            ////    {
            ////        m_info = "驱动启动打印失败，错误值 --  ";
            ////        m_info += state1.ToString();
            ////        tb_PrintProcess.Text = m_info;
            ////        return false;
            ////    }
            ////}
            ////为了准确判断数据发送成功与否，建议对于每个调用的函数均检查其返回值。
            ////具体函数的返回值请参考DLL的说明文档。

            //try
            //{
            //    int state = PrinterDll.BPLA_SetPaperLength(580, 0);//对于标签纸，则不需要这个函数
            //    if (state != PrinterDll.BPLA_OK)
            //    {
            //        throw new Exception("端口没有打开");
            //    }
            //    state = PrinterDll.BPLA_SetAllRotate(1);
            //    if (state != PrinterDll.BPLA_OK)
            //    {
            //        throw new Exception("端口没有打开");
            //    }
            //    state = PrinterDll.BPLA_StartArea(0, 800, 0, 0, 0, 0, 0, 0);
            //    if (state != PrinterDll.BPLA_OK)
            //    {
            //        throw new Exception("端口没有打开");
            //    }
            //    state = PrinterDll.BPLA_PrintTruetype("A1234567", 30, 480, "黑体", 24, 0);
            //    if (state != PrinterDll.BPLA_OK)
            //    {
            //        throw new Exception("端口没有打开");
            //    }
            //    state = PrinterDll.BPLA_PrintTruetype("烟港售", 570, 480, "黑体", 24, 0);
            //    if (state != PrinterDll.BPLA_OK)
            //    {
            //        throw new Exception("端口没有打开");
            //    }
            //    state = PrinterDll.BPLA_PrintTruetype("中海客轮有限公司", 220, 410, "黑体", 28, 0);
            //    if (state != PrinterDll.BPLA_OK)
            //    {
            //        throw new Exception("端口没有打开");
            //    }
            //    state = PrinterDll.BPLA_PrintTruetype("客票", 60, 350, "黑体", 28, 0);
            //    if (state != PrinterDll.BPLA_OK)
            //    {
            //        throw new Exception("端口没有打开");
            //    }
            //    state = PrinterDll.BPLA_PrintTruetype("航次739", 60, 310, "黑体", 24, 0);
            //    if (state != PrinterDll.BPLA_OK)
            //    {
            //        throw new Exception("端口没有打开");
            //    }
            //    state = PrinterDll.BPLA_PrintTruetype("三等B", 60, 250, "黑体", 28, 0);
            //    if (state != PrinterDll.BPLA_OK)
            //    {
            //        throw new Exception("端口没有打开");
            //    }
            //    state = PrinterDll.BPLA_PrintTruetype("铺号:", 60, 140, "黑体", 24, 0);
            //    if (state != PrinterDll.BPLA_OK)
            //    {
            //        throw new Exception("端口没有打开");
            //    }
            //    state = PrinterDll.BPLA_PrintTruetype("123", 60, 85, "黑体", 24, 0);
            //    if (state != PrinterDll.BPLA_OK)
            //    {
            //        throw new Exception("端口没有打开");
            //    }
            //    state = PrinterDll.BPLA_PrintTruetype("烟台", 250, 355, "黑体", 36, 0);
            //    if (state != PrinterDll.BPLA_OK)
            //    {
            //        throw new Exception("端口没有打开");
            //    }
            //    state = PrinterDll.BPLA_PrintImage("arrow.bmp", 380, 365, 0);
            //    if (state != PrinterDll.BPLA_OK)
            //    {
            //        throw new Exception("端口没有打开");
            //    }
            //    state = PrinterDll.BPLA_PrintTruetype("大连", 540, 355, "黑体", 36, 0);
            //    if (state != PrinterDll.BPLA_OK)
            //    {
            //        throw new Exception("端口没有打开");
            //    }
            //    state = PrinterDll.BPLA_PrintTruetype("棒棰岛轮", 250, 300, "黑体", 28, 0);
            //    if (state != PrinterDll.BPLA_OK)
            //    {
            //        throw new Exception("端口没有打开");
            //    }
            //    state = PrinterDll.BPLA_PrintTruetype("烟港新站", 500, 300, "黑体", 28, 0);
            //    if (state != PrinterDll.BPLA_OK)
            //    {
            //        throw new Exception("端口没有打开");
            //    }
            //    state = PrinterDll.BPLA_PrintTruetype("2002年度05月20日21:30开", 250, 250, "黑体", 28, 0);
            //    if (state != PrinterDll.BPLA_OK)
            //    {
            //        throw new Exception("端口没有打开");
            //    }
            //    state = PrinterDll.BPLA_PrintTruetype("票价:109.00元", 250, 190, "黑体", 28, 0);
            //    if (state != PrinterDll.BPLA_OK)
            //    {
            //        throw new Exception("端口没有打开");
            //    }
            //    state = PrinterDll.BPLA_PrintTruetype("须知：当日当次船有效", 250, 150, "黑体", 24, 0);
            //    if (state != PrinterDll.BPLA_OK)
            //    {
            //        throw new Exception("端口没有打开");
            //    }
            //    state = PrinterDll.BPLA_PrintBarcode("345268724325578", 220, 30, 1, 4, 70, 4, 2, "000");
            //    if (state != PrinterDll.BPLA_OK)
            //    {
            //        throw new Exception("端口没有打开");
            //    }
            //    state = PrinterDll.BPLA_Print(1, 1, 1);
            //    if (state != PrinterDll.BPLA_OK)
            //    {
            //        throw new Exception("端口没有打开");
            //    }
            //}
            //catch (Exception error)
            //{
            //    MessageBox.Show(error.Message);
            //    return false;
            //}
            //if (m_PortIndex == 3)//驱动结束打印
            //{
            //    state1 = PrinterDll.BPLA_EndDoc();
            //    if (state1 != PrinterDll.BPLA_OK)
            //    {
            //        m_info = "驱动关闭打印失败，错误值 --  ";
            //        m_info += state1.ToString();
            //        textBoxStatus.Text = m_info;
            //        return false;
            //    }
            //}

            //if (m_PortIndex == 1 || m_PortIndex == 3) //并口,驱动不查询状态
            //{
            //    return true;
            //}

            //System.Threading.Thread.Sleep(1800);
            //int m_Result = PrinterDll.BPLA_CheckStatus(m_papershort, m_ribbionshort, m_busy, m_pause, m_com, m_headheat, m_headover, m_cut);
            //if (m_Result != PrinterDll.BPLA_OK)
            //{
            //    m_info = "查询状态失败";
            //    return false;
            //}
            //else
            //{
            //    m_info = "";
            //    if (m_papershort[0] != 'N') m_info += "缺纸 ";
            //    if (m_ribbionshort[0] != 'N') m_info += "缺色带 ";
            //    if (m_busy[0] != 'N') m_info += "解释器忙 ";
            //    if (m_pause[0] != 'N') m_info += "暂停 ";
            //    if (m_com[0] != 'N') m_info += "通讯错误 ";
            //    if (m_headover[0] != 'N') m_info += "打印头抬起 ";
            //    if (m_headheat[0] != 'N') m_info += "打印头过热 ";
            //    if (m_cut[0] != 'N') m_info += "切刀响应超时";
            //    if (m_info == "")
            //    {
            //        m_info = "状态正常";
            //    }
            //    textBoxStatus.Text = m_info;
            //}

            //if (textBoxStatus.Text == "状态正常")
            //    return true;
            //else return false;
            #endregion
            Int32 _font_size = 23;//设置字体高度
            Int32 _height = 210;//设置第一排文字的位置
            Int32 _left = 20;//设置第一行文字离左边的位置
            Int32 _add_sec = 200;//设置第二列的偏移位置
            Int32 _right = 440;//设置右侧文字第一行的位置
            try
             {
                int state;
                #region==========打开USB==========
                 ///int BPLA_OpenUsbPrn(int iDevID)
                 /*iDevID：[in] USB类模式设备编号，取值范围：> 0。
                  */
                 state = PrinterDll.BPLA_OpenUsb();//
                 if (state != PrinterDll.BPLA_OK)
                     throw new Exception();
                #endregion                 
                #region==========设置出纸方式==========
                ///int BPLA_Set(int iOutMode, int iPaperMode, int iPrintMode)
                 ///
                /*iOutMode   ：[in] 取值范围：0 --- 3，分别表示：切刀，剥离，撕离，回卷。
                    iPaperMode ：[in] 取值范围：0：非连续纸，1：连续纸。
                    iPrintMode ：[in] 取值范围：0：热敏打印，1：热转印打印。
                  */
                 state = PrinterDll.BPLA_Set(3, 0, 1);//
                if (state != PrinterDll.BPLA_OK)
                     throw new Exception();
                 #endregion
                #region==========设置标签纸的大小设置==========
                ///int BPLA_SetPaperLength(int iContinueLength, int iLabelLength)
                  /*
                  * iContinueLength ：[in] 连续纸长度，取值范围：0 --- 9999，如果为0，则不进行设置，单位：点，毫米/10，英寸/100。
                    iLabelLength    ：[in] 寻找标签的最大长度，取值范围：0 --- 9999，如果为0，则不进行设置，单位：点，毫米/10，英寸/100。
                  */
                 //state = PrinterDll.BPLA_SetPaperLength(100, 30);//
                 //if (state != PrinterDll.BPLA_OK)
                     //throw new Exception();
                 #endregion
                #region==========设置停止位==========
                ///int BPLA_SetEnd(int iPosition)
                 ///iPosition ：[in] 取值范围：0 --- 999， 0：存在传感器和按键起作用，非0：打印机不判别是否撕掉或剥掉，直接出纸到停止位。
                PrinterDll.BPLA_SetEnd(0);
                 #endregion
                #region==========进入标签模式，设置打印区域及打印参数==========
                ///int BPLA_StartArea(int iUnitMode, int iPrintWidth, int iColumn, int iRow, int iDarkness, int iSpeedPrint, int iSpeedFor, int iSpeedBac)                
                  /*  iUnitMode   ：[in] 单位模式，取值范围：0 --- 3 分别表示：0：默认单位，1：米制，2：点，3：英制。
                      iPrintWidth ：[in] 打印宽度设置。取值范围：单位由参数iUnitMode决定， 0 --- 9999。
                      iColumn     ：[in] 列偏移数，取值范围：0 --- 9999。
                      iRow        ：[in] 行偏移数，取值范围：0 --- 9999。
                      iDarkness   ：[in] 打印浓度，取值范围：0 --- 30。
                      iSpeedPrint ：[in] 打印速度，取值范围：0 --- 20。
                      iSpeedFor   ：[in] 进纸速度，取值范围：0 --- 20。
                      iSpeedBac   ：[in] 退纸速度，取值范围：0 --- 20。
                  */
                 state = PrinterDll.BPLA_StartArea(2, 1000, 0, 0, 20, 0, 0, 0);//进入标签模式，设置打印区域及打印参数
                  if (state != PrinterDll.BPLA_OK)
                     throw new Exception();
                 #endregion
                #region==========标签内容设置==========
                ///int BPLA_PrintTruetype(char *cText, int iStartX, int iStartY, char *cFontName, int iFontHeight, int iFontWidth)
                 /*
                  * cText        ：[in] 需要打印的文字。
                     iStartX      ：[in] 起点位置横坐标，取值范围：0 --- 9999。
                     iStartY      ：[in] 起点位置纵坐标，取值范围：0 --- 9999。
                     cFontName    ：[in] TRUETYPE字体名称，字符集依照系统默认字符集。
                     iFontHeight  ：[in] 字体高度，取值范围：>= 0
                     iFontWidth   ：[in] 字体宽度，取值范围：如果为0，则根据高度自动匹配宽度；如果不为0，则宽度为设定值，允许设置不规则字体。
                  */
                    
                  if (_is_Single)
                  {
                      //单位头信息
                      state = PrinterDll.BPLA_PrintTruetype("武汉市结核病防治所", _left + 20, _height, "Tahoma", 40, 0);//
                      if (state != PrinterDll.BPLA_OK)
                          throw new Exception();
                      _height = _height - 40;
                      //资产编号
                      state = PrinterDll.BPLA_PrintTruetype(_printData["AssetCodeA"], _left, _height, "Tahoma", 30, 0);//
                      if (state != PrinterDll.BPLA_OK)
                          throw new Exception();
                      _height = _height - 40;

                      //资产名称
                      state = PrinterDll.BPLA_PrintTruetype(_printData["AssetNameA"], _left, _height, "Tahoma", _font_size, 0);//
                      if (state != PrinterDll.BPLA_OK)
                          throw new Exception();
                      //账面原值
                      state = PrinterDll.BPLA_PrintTruetype(_printData["PriceA"], _left + _add_sec, _height, "Tahoma", _font_size, 0);//
                      if (state != PrinterDll.BPLA_OK)
                          throw new Exception();
                      _height = _height - _font_size;

                      //使用部门
                      state = PrinterDll.BPLA_PrintTruetype(_printData["DeptA"], _left, _height, "Tahoma", _font_size, 0);//
                      if (state != PrinterDll.BPLA_OK)
                          throw new Exception();
                      //使用人
                      state = PrinterDll.BPLA_PrintTruetype(_printData["UserA"], _left + _add_sec, _height, "Tahoma", _font_size, 0);//
                      if (state != PrinterDll.BPLA_OK)
                          throw new Exception();
                      _height = _height - _font_size;

                      //会计凭证号
                      state = PrinterDll.BPLA_PrintTruetype(_printData["AccountA"], _left, _height, "Tahoma", _font_size, 0);//
                      if (state != PrinterDll.BPLA_OK)
                          throw new Exception();
                      //品牌
                      state = PrinterDll.BPLA_PrintTruetype(_printData["JudgeA"], _left + _add_sec, _height, "Tahoma", _font_size, 0);//
                      if (state != PrinterDll.BPLA_OK)
                          throw new Exception();
                      _height = _height - _font_size;

                      //规格型号
                      state = PrinterDll.BPLA_PrintTruetype(_printData["TypeA"], _left, _height, "Tahoma", _font_size, 0);//
                      if (state != PrinterDll.BPLA_OK)
                          throw new Exception();
                      //取得日期
                      state = PrinterDll.BPLA_PrintTruetype(_printData["GetDateA"], _left + _add_sec, _height, "Tahoma", _font_size, 0);//
                      if (state != PrinterDll.BPLA_OK)
                          throw new Exception();
                  }
                  else
                  {
                      //左侧
                      //单位头信息
                      state = PrinterDll.BPLA_PrintTruetype("武汉市结核病防治所", _left + 20, _height, "Tahoma", 40, 0);//
                      if (state != PrinterDll.BPLA_OK)
                          throw new Exception();
                      _height = _height - 40;
                      //资产编号
                      state = PrinterDll.BPLA_PrintTruetype(_printData["AssetCodeA"], _left, _height, "Tahoma", 30, 0);//
                      if (state != PrinterDll.BPLA_OK)
                          throw new Exception();
                      _height = _height - 40;

                      //资产名称
                      state = PrinterDll.BPLA_PrintTruetype(_printData["AssetNameA"], _left, _height, "Tahoma", _font_size, 0);//
                      if (state != PrinterDll.BPLA_OK)
                          throw new Exception();
                      //账面原值
                      state = PrinterDll.BPLA_PrintTruetype(_printData["PriceA"], _left + _add_sec, _height, "Tahoma", _font_size, 0);//
                      if (state != PrinterDll.BPLA_OK)
                          throw new Exception();
                      _height = _height - _font_size;

                      //使用部门
                      state = PrinterDll.BPLA_PrintTruetype(_printData["DeptA"], _left, _height, "Tahoma", _font_size, 0);//
                      if (state != PrinterDll.BPLA_OK)
                          throw new Exception();
                      //使用人
                      state = PrinterDll.BPLA_PrintTruetype(_printData["UserA"], _left + _add_sec, _height, "Tahoma", _font_size, 0);//
                      if (state != PrinterDll.BPLA_OK)
                          throw new Exception();
                      _height = _height - _font_size;

                      //会计凭证号
                      state = PrinterDll.BPLA_PrintTruetype(_printData["AccountA"], _left, _height, "Tahoma", _font_size, 0);//
                      if (state != PrinterDll.BPLA_OK)
                          throw new Exception();
                      //品牌
                      state = PrinterDll.BPLA_PrintTruetype(_printData["JudgeA"], _left + _add_sec, _height, "Tahoma", _font_size, 0);//
                      if (state != PrinterDll.BPLA_OK)
                          throw new Exception();
                      _height = _height - _font_size;

                      //规格型号
                      state = PrinterDll.BPLA_PrintTruetype(_printData["TypeA"], _left, _height, "Tahoma", _font_size, 0);//
                      if (state != PrinterDll.BPLA_OK)
                          throw new Exception();
                      //取得日期
                      state = PrinterDll.BPLA_PrintTruetype(_printData["GetDateA"], _left + _add_sec, _height, "Tahoma", _font_size, 0);//
                      if (state != PrinterDll.BPLA_OK)
                          throw new Exception();

                      _height = 210;
                      //右侧
                      //单位头信息
                      state = PrinterDll.BPLA_PrintTruetype("武汉市结核病防治所", _right, _height, "Tahoma", 40, 0);//
                      if (state != PrinterDll.BPLA_OK)
                          throw new Exception();
                      _height = _height - 40;
                      //资产编号
                      state = PrinterDll.BPLA_PrintTruetype(_printData["AssetCodeB"], _right, _height, "Tahoma", 30, 0);//
                      if (state != PrinterDll.BPLA_OK)
                          throw new Exception();
                      _height = _height - 40;

                      //资产名称
                      state = PrinterDll.BPLA_PrintTruetype(_printData["AssetNameB"], _right, _height, "Tahoma", _font_size, 0);//
                      if (state != PrinterDll.BPLA_OK)
                          throw new Exception();
                      //账面原值
                      state = PrinterDll.BPLA_PrintTruetype(_printData["PriceB"], _right + _add_sec, _height, "Tahoma", _font_size, 0);//
                      if (state != PrinterDll.BPLA_OK)
                          throw new Exception();
                      _height = _height - _font_size;

                      //使用部门
                      state = PrinterDll.BPLA_PrintTruetype(_printData["DeptB"], _right, _height, "Tahoma", _font_size, 0);//
                      if (state != PrinterDll.BPLA_OK)
                          throw new Exception();
                      //使用人
                      state = PrinterDll.BPLA_PrintTruetype(_printData["UserB"], _right + _add_sec, _height, "Tahoma", _font_size, 0);//
                      if (state != PrinterDll.BPLA_OK)
                          throw new Exception();
                      _height = _height - _font_size;

                      //会计凭证号
                      state = PrinterDll.BPLA_PrintTruetype(_printData["AccountB"], _right, _height, "Tahoma", _font_size, 0);//
                      if (state != PrinterDll.BPLA_OK)
                          throw new Exception();
                      //品牌
                      state = PrinterDll.BPLA_PrintTruetype(_printData["JudgeB"], _right + _add_sec, _height, "Tahoma", _font_size, 0);//
                      if (state != PrinterDll.BPLA_OK)
                          throw new Exception();
                      _height = _height - _font_size;

                      //规格型号
                      state = PrinterDll.BPLA_PrintTruetype(_printData["TypeB"], _right, _height, "Tahoma", _font_size, 0);//
                      if (state != PrinterDll.BPLA_OK)
                          throw new Exception();
                      //取得日期
                      state = PrinterDll.BPLA_PrintTruetype(_printData["GetDateB"], _right + _add_sec, _height, "Tahoma", _font_size, 0);//
                      if (state != PrinterDll.BPLA_OK)
                          throw new Exception();
                  }
                 #endregion

                //#region==========标签条形码设置==========
                // /// int BPLA_PrintBarcode(char *cCodeData, int iStartX, int iStartY, int iRotate, int iBarType, int iHeight, int iNumber, int iNumberBase, char *cAddvalue)
                //  /*
                //  * cCodeData    ：[in] 条码数据。
                //   iStartX      ：[in] 起点位置横坐标，取值范围：0 --- 9999。
                //   iStartY      ：[in] 起点位置纵坐标，取值范围：0 --- 9999。
                //   iRotate      ：[in] 旋转方向，取值范围：1 --- 4分别代表逆时针旋转0、90、180、270度。
                //   iBarType     ：[in] 条码类型，取值范围：0 --- 19（有标记文字）， 20-39（无标记文字）。参见“附录/条码说明”。
                //   iHeight      ：[in] 条码高度，取值范围：0 --- 999。
                //   iNumber      ：[in] 比例分子，取值范围：1 --- 24。
                //   iNumberBase  ：[in] 比例分母，取值范围：1 --- 24。比例分子与分母的设置见参见“附录/条码说明”。
                //   cAddvalue    ：[in] 连续域递变值，可以为字母或数字设定递变值，如果为字母，递增使用符号“>”，递减使用符号“<”，比如从“m”开始递增，每次跳一个，则可以使用“>01”，递减，每次跳一个，则使用“<01”；如果为数字，递增使用符号“+”，递减使用符号“-”，比如从“10”开始递增，每次加1，则可以使用“+01”，递减，每次减1，则使用“-01”，此项值必须是长度为3个字节的字符串，如“+10”、“-08”、“>20”、“<10”等等。如果不准备使用递变值，则必须将此项设置为“000”。
                // */
                // state = PrinterDll.BPLA_PrintBarcode(bianhao, 150, 70, 1, 4, 100, 4, 2, "000");// 
                // if (state != PrinterDll.BPLA_OK)
                //     throw new Exception();
                // #endregion
                //Thread.Sleep(200);
                #region==========打印==========
                ///int BPLA_Print(int iPieces, intiSamePieces, int iOutUnit)
                 /*
                  *  iPieces     ：[in] 打印数量,取值范围：1 --- 9999。
                     iSamePieces ：[in] 相同标签的打印数量，取值范围：0 --- 99。
                     iOutUnit    ：[in] 出纸单位，取值范围：1 --- 9999。
                  */
                 PrinterDll.BPLA_Print(1, 0, 1);//
                 if (state != PrinterDll.BPLA_OK)
                     throw new Exception();
                 #endregion
                #region==========错误信息==========
                 //string m_info;
                //byte[] m_papershort = new byte[3],
                 //    m_ribbionshort = new byte[3],
                 //    m_busy = new byte[3],
                 //    m_pause = new byte[3],
                 //    m_com = new byte[3],
                 //    m_headheat = new byte[3],
                 //    m_headover = new byte[3],
                 //    m_cut = new byte[3];
                 //int iState = PrinterDll.BPLA_CheckStatus(m_papershort, m_ribbionshort, m_busy, m_pause, m_com, m_headheat, m_headover, m_cut);
                 //if (iState != PrinterDll.BPLA_OK)
                 //{
                 //    m_info = "查询状态失败，错误值 --- " + iState.ToString();
                 //}
                 //else
                 //{
                 //    m_info = "";
                 //    if (m_papershort[0] != 'N')
                 //    {
                 //        m_info += "缺纸";
                 //    }
                //    if (m_ribbionshort[0] != 'N')
                //    {
                 //        m_info += "缺色带";
                 //    }
                //    if (m_busy[0] != 'N')
                 //    {
                 //        m_info += "解释器忙";
                 //    }
                //    if (m_pause[0] != 'N')
                //    {
                 //        m_info += "暂停";
                 //    }
                //    if (m_com[0] != 'N')
                 //    {                 //        m_info += "通讯错误";                 //    }
                //    if (m_headover[0] != 'N')
                 //    {
                 //        m_info += "打印头抬起";
                 //    }
                //    if (m_headheat[0] != 'N')
                 //    {
                 //        m_info += " 打印头过热";
                 //    }
                //    if (m_cut[0] != 'N')
                 //    {
                 //        m_info += "切刀响应超时";
                 //    }
                //    if (m_info == "")
                 //    {
                 //        m_info = "状态正常";
                 //    }
                //}
                #endregion
                #region==========复位打印机==========
                /// int BPLA_Reset()
                // PrinterDll.BPLA_Reset();
                 #endregion
                #region==========关闭USB==========
                ///int BPLA_CloseUsbPrn()
                 ///
                // PrinterDll.BPLA_CloseUsb();//
                 #endregion
                 return true;
            }
             catch (Exception e)
             {
                 this.tb_PrintProcess.Text = "系统提示:" + e.Message.ToString();
                 PrinterDll.BPLA_Reset();
                 PrinterDll.BPLA_CloseUsb();
                 return false;
             }
        }

        #region//单列打印
        /// <summary>
        /// 打印过程（双列打印）
        /// </summary>
        private bool print_Process_Single(Dictionary<string, string> _printData)
        {
            try
            {
                int state;
                #region==========打开USB==========
                ///int BPLA_OpenUsbPrn(int iDevID)
                /*iDevID：[in] USB类模式设备编号，取值范围：> 0。
                 */
                state = PrinterDll.BPLA_OpenUsb();//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                #endregion
                #region==========设置出纸方式==========
                ///int BPLA_Set(int iOutMode, int iPaperMode, int iPrintMode)
                ///
                /*iOutMode   ：[in] 取值范围：0 --- 3，分别表示：切刀，剥离，撕离，回卷。
                    iPaperMode ：[in] 取值范围：0：非连续纸，1：连续纸。
                    iPrintMode ：[in] 取值范围：0：热敏打印，1：热转印打印。
                  */
                state = PrinterDll.BPLA_Set(1, 0, 1);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                #endregion
                #region==========设置标签纸的大小设置==========
                ///int BPLA_SetPaperLength(int iContinueLength, int iLabelLength)
                /*
                * iContinueLength ：[in] 连续纸长度，取值范围：0 --- 9999，如果为0，则不进行设置，单位：点，毫米/10，英寸/100。
                  iLabelLength    ：[in] 寻找标签的最大长度，取值范围：0 --- 9999，如果为0，则不进行设置，单位：点，毫米/10，英寸/100。
                */
                //state = PrinterDll.BPLA_SetPaperLength(100, 30);//
                //if (state != PrinterDll.BPLA_OK)
                //throw new Exception();
                #endregion
                #region==========设置停止位==========
                ///int BPLA_SetEnd(int iPosition)
                ///iPosition ：[in] 取值范围：0 --- 999， 0：存在传感器和按键起作用，非0：打印机不判别是否撕掉或剥掉，直接出纸到停止位。
                //PrinterDll.BPLA_SetEnd(0);
                #endregion
                #region==========进入标签模式，设置打印区域及打印参数==========
                ///int BPLA_StartArea(int iUnitMode, int iPrintWidth, int iColumn, int iRow, int iDarkness, int iSpeedPrint, int iSpeedFor, int iSpeedBac)                
                /*  iUnitMode   ：[in] 单位模式，取值范围：0 --- 3 分别表示：0：默认单位，1：米制，2：点，3：英制。
                    iPrintWidth ：[in] 打印宽度设置。取值范围：单位由参数iUnitMode决定， 0 --- 9999。
                    iColumn     ：[in] 列偏移数，取值范围：0 --- 9999。
                    iRow        ：[in] 行偏移数，取值范围：0 --- 9999。
                    iDarkness   ：[in] 打印浓度，取值范围：0 --- 30。
                    iSpeedPrint ：[in] 打印速度，取值范围：0 --- 20。
                    iSpeedFor   ：[in] 进纸速度，取值范围：0 --- 20。
                    iSpeedBac   ：[in] 退纸速度，取值范围：0 --- 20。
                */
                state = PrinterDll.BPLA_StartArea(1, 100, 11, 10, 0, 0, 0, 0);//进入标签模式，设置打印区域及打印参数
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                #endregion
                #region==========标签内容设置==========
                ///int BPLA_PrintTruetype(char *cText, int iStartX, int iStartY, char *cFontName, int iFontHeight, int iFontWidth)
                /*
                 * cText        ：[in] 需要打印的文字。
                    iStartX      ：[in] 起点位置横坐标，取值范围：0 --- 9999。
                    iStartY      ：[in] 起点位置纵坐标，取值范围：0 --- 9999。
                    cFontName    ：[in] TRUETYPE字体名称，字符集依照系统默认字符集。
                    iFontHeight  ：[in] 字体高度，取值范围：>= 0
                    iFontWidth   ：[in] 字体宽度，取值范围：如果为0，则根据高度自动匹配宽度；如果不为0，则宽度为设定值，允许设置不规则字体。
                 */

                //单位头信息
                state = PrinterDll.BPLA_PrintTruetype("武汉市结核防治所", 100, 320, "Arial", 20, 0);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                //资产编号
                state = PrinterDll.BPLA_PrintTruetype(_printData["AssetCode"], 100, 300, "Arial", 20, 0);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                //资产名称
                state = PrinterDll.BPLA_PrintTruetype(_printData["AssetName"], 100, 280, "Arial", 20, 0);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                //账面原值
                state = PrinterDll.BPLA_PrintTruetype(_printData["Price"], 100, 260, "Arial", 20, 0);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                //使用部门
                state = PrinterDll.BPLA_PrintTruetype(_printData["Dept"], 100, 240, "Arial", 20, 0);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                //使用人
                state = PrinterDll.BPLA_PrintTruetype(_printData["User"], 100, 220, "Arial", 20, 0);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                //会计凭证号
                state = PrinterDll.BPLA_PrintTruetype(_printData["Account"], 100, 200, "Arial", 20, 0);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                //品牌
                state = PrinterDll.BPLA_PrintTruetype(_printData["Judge"], 100, 180, "Arial", 20, 0);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                //规格型号
                state = PrinterDll.BPLA_PrintTruetype(_printData["Type"], 100, 160, "Arial", 20, 0);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                //取得日期
                state = PrinterDll.BPLA_PrintTruetype(_printData["GetDate"], 100, 140, "Arial", 20, 0);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                #endregion

                //#region==========标签条形码设置==========
                // /// int BPLA_PrintBarcode(char *cCodeData, int iStartX, int iStartY, int iRotate, int iBarType, int iHeight, int iNumber, int iNumberBase, char *cAddvalue)
                //  /*
                //  * cCodeData    ：[in] 条码数据。
                //   iStartX      ：[in] 起点位置横坐标，取值范围：0 --- 9999。
                //   iStartY      ：[in] 起点位置纵坐标，取值范围：0 --- 9999。
                //   iRotate      ：[in] 旋转方向，取值范围：1 --- 4分别代表逆时针旋转0、90、180、270度。
                //   iBarType     ：[in] 条码类型，取值范围：0 --- 19（有标记文字）， 20-39（无标记文字）。参见“附录/条码说明”。
                //   iHeight      ：[in] 条码高度，取值范围：0 --- 999。
                //   iNumber      ：[in] 比例分子，取值范围：1 --- 24。
                //   iNumberBase  ：[in] 比例分母，取值范围：1 --- 24。比例分子与分母的设置见参见“附录/条码说明”。
                //   cAddvalue    ：[in] 连续域递变值，可以为字母或数字设定递变值，如果为字母，递增使用符号“>”，递减使用符号“<”，比如从“m”开始递增，每次跳一个，则可以使用“>01”，递减，每次跳一个，则使用“<01”；如果为数字，递增使用符号“+”，递减使用符号“-”，比如从“10”开始递增，每次加1，则可以使用“+01”，递减，每次减1，则使用“-01”，此项值必须是长度为3个字节的字符串，如“+10”、“-08”、“>20”、“<10”等等。如果不准备使用递变值，则必须将此项设置为“000”。
                // */
                // state = PrinterDll.BPLA_PrintBarcode(bianhao, 150, 70, 1, 4, 100, 4, 2, "000");// 
                // if (state != PrinterDll.BPLA_OK)
                //     throw new Exception();
                // #endregion
                //Thread.Sleep(200);
                #region==========打印==========
                ///int BPLA_Print(int iPieces, intiSamePieces, int iOutUnit)
                /*
                 *  iPieces     ：[in] 打印数量,取值范围：1 --- 9999。
                    iSamePieces ：[in] 相同标签的打印数量，取值范围：0 --- 99。
                    iOutUnit    ：[in] 出纸单位，取值范围：1 --- 9999。
                 */
                PrinterDll.BPLA_Print(1, 1, 1);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                #endregion
                #region==========错误信息==========
                //string m_info;
                //byte[] m_papershort = new byte[3],
                //    m_ribbionshort = new byte[3],
                //    m_busy = new byte[3],
                //    m_pause = new byte[3],
                //    m_com = new byte[3],
                //    m_headheat = new byte[3],
                //    m_headover = new byte[3],
                //    m_cut = new byte[3];
                //int iState = PrinterDll.BPLA_CheckStatus(m_papershort, m_ribbionshort, m_busy, m_pause, m_com, m_headheat, m_headover, m_cut);
                //if (iState != PrinterDll.BPLA_OK)
                //{
                //    m_info = "查询状态失败，错误值 --- " + iState.ToString();
                //}
                //else
                //{
                //    m_info = "";
                //    if (m_papershort[0] != 'N')
                //    {
                //        m_info += "缺纸";
                //    }
                //    if (m_ribbionshort[0] != 'N')
                //    {
                //        m_info += "缺色带";
                //    }
                //    if (m_busy[0] != 'N')
                //    {
                //        m_info += "解释器忙";
                //    }
                //    if (m_pause[0] != 'N')
                //    {
                //        m_info += "暂停";
                //    }
                //    if (m_com[0] != 'N')
                //    {                 //        m_info += "通讯错误";                 //    }
                //    if (m_headover[0] != 'N')
                //    {
                //        m_info += "打印头抬起";
                //    }
                //    if (m_headheat[0] != 'N')
                //    {
                //        m_info += " 打印头过热";
                //    }
                //    if (m_cut[0] != 'N')
                //    {
                //        m_info += "切刀响应超时";
                //    }
                //    if (m_info == "")
                //    {
                //        m_info = "状态正常";
                //    }
                //}
                #endregion
                #region==========复位打印机==========
                /// int BPLA_Reset()
                //PrinterDll.BPLA_Reset();
                #endregion
                #region==========关闭USB==========
                ///int BPLA_CloseUsbPrn()
                ///
                //PrinterDll.BPLA_CloseUsb();//
                #endregion
                return true;
            }
            catch (Exception)
            {
                PrinterDll.BPLA_Reset();
                PrinterDll.BPLA_CloseUsb();
                return false;
            }
        }
        #endregion

        #region//读取打印数据(单列)
        /// <summary>
        /// 读取打印数据；
        /// 循环打印
        /// </summary>
        private void print_ReadData_Single()
        {
            Int32 _rowCount = this.dgv_Label.Rows.Count;
            string text1, text2, text3, text4, text5, text6, text7, text8, text9;
            for (Int32 i = 0; i < _rowCount; i++)
            {
                if (Convert.ToBoolean(dgv_Label.Rows[i].Cells[0].Value) == true)
                {
                    text1 = "编号-" + this.dgv_Label.Rows[i].Cells[1].Value;//资产编号
                    text2 = "名称-" + this.dgv_Label.Rows[i].Cells[2].Value;//资产名称
                    text3 = "原值-" + this.dgv_Label.Rows[i].Cells[3].Value;//账面原值
                    text4 = "机构-" + this.dgv_Label.Rows[i].Cells[4].Value;//管理机构
                    text5 = "使用人-" + this.dgv_Label.Rows[i].Cells[5].Value;//使用人
                    text6 = "凭证号-" + this.dgv_Label.Rows[i].Cells[6].Value;//会计凭证号
                    text7 = "品牌-" + this.dgv_Label.Rows[i].Cells[7].Value;//品牌
                    text8 = "型号-" + this.dgv_Label.Rows[i].Cells[8].Value;//规格型号
                    text9 = "日期-" + this.dgv_Label.Rows[i].Cells[9].Value;//取得日期

                    Dictionary<String, String> _printData = new Dictionary<string, string>();
                    _printData.Add("AssetCode", text1);
                    _printData.Add("AssetName", text2);
                    _printData.Add("Price", text3);
                    _printData.Add("Dept", text4);
                    _printData.Add("User", text5);
                    _printData.Add("Account", text6);
                    _printData.Add("Judge", text7);
                    _printData.Add("Type", text8);
                    _printData.Add("GetDate", text9);

                    print_Process_Single(_printData);
                }
            }
        }
        #endregion

        #region//读取打印数据(双列)
        /// <summary>
        /// 读取打印数据；
        /// 循环打印
        /// </summary>
        private void print_ReadData_Double()
        {
            Int32 _rowCount = this.dgv_Label.Rows.Count;
            Int32 _nIndex = 0;
            Int32 _printNum = Convert.ToInt32(this.tb_PrintNum.Text.Trim());
            bool _Flag = false;//是否最后一条
            bool _IsOdd = true;//是否是单数列
            string text1, text2, text3, text4, text5, text6, text7, text8, text9;
            Dictionary<String, String> _printData = new Dictionary<string, string>();

            if (_printNum == 1)
            {

                for (Int32 i = 0; i < _rowCount; i++)
                {
                    if (Convert.ToBoolean(dgv_Label.Rows[i].Cells[0].Value) != true)
                    {
                        if (i == _rowCount - 1)
                        {
                            _Flag = true;//代表循环到最后一条；
                            break;
                        }
                        continue;
                    }
                    else
                    {
                        if (i == _rowCount - 1)
                        {
                            _Flag = true;//代表循环到最后一条；
                        }
                        ++_nIndex;
                        _IsOdd = true;//代表目前是单列数据；
                    }
                    //单数列                
                    if (Convert.ToBoolean(_nIndex % 2))
                    {
                        _printData.Clear();

                        text1 = "编号:" + this.dgv_Label.Rows[i].Cells[1].Value;//资产编号
                        text2 = "名称:" + this.dgv_Label.Rows[i].Cells[2].Value;//资产名称
                        
                        text3 = "原值:" + this.dgv_Label.Rows[i].Cells[3].Value;//账面原值
                        text3 = text3.Substring(0, text3.Length - 3);
                        text4 = "二级管理:" + this.dgv_Label.Rows[i].Cells[4].Value;//管理机构
                        text5 = "使用:" + this.dgv_Label.Rows[i].Cells[5].Value;//使用人
                        text6 = "凭证号:" + this.dgv_Label.Rows[i].Cells[6].Value;//会计凭证号
                        text7 = "品牌:" + this.dgv_Label.Rows[i].Cells[7].Value;//品牌
                        text8 = "型号:" + this.dgv_Label.Rows[i].Cells[8].Value;//规格型号
                        text9 = "日期:" + this.dgv_Label.Rows[i].Cells[9].Value;//取得日期
                        if (text9.IndexOf("0:00:00") > 0)
                        {
                            text9 = text9.Replace("0:00:00", "");
                        }
                        _printData.Add("AssetCodeA", text1);
                        _printData.Add("AssetNameA", text2);
                        _printData.Add("PriceA", text3);
                        _printData.Add("DeptA", text4);
                        _printData.Add("UserA", text5);
                        _printData.Add("AccountA", text6);
                        _printData.Add("JudgeA", text7);
                        _printData.Add("TypeA", text8);
                        _printData.Add("GetDateA", text9);

                    }
                    else
                    {
                        text1 = "编号:" + this.dgv_Label.Rows[i].Cells[1].Value;//资产编号
                        text2 = "名称:" + this.dgv_Label.Rows[i].Cells[2].Value;//资产名称
                        text3 = "原值:" + this.dgv_Label.Rows[i].Cells[3].Value;//账面原值
                        text3 = text3.Substring(0, text3.Length - 3);
                        text4 = "二级管理:" + this.dgv_Label.Rows[i].Cells[4].Value;//管理机构
                        text5 = "使用:" + this.dgv_Label.Rows[i].Cells[5].Value;//使用人
                        text6 = "凭证号:" + this.dgv_Label.Rows[i].Cells[6].Value;//会计凭证号
                        text7 = "品牌:" + this.dgv_Label.Rows[i].Cells[7].Value;//品牌
                        text8 = "型号:" + this.dgv_Label.Rows[i].Cells[8].Value;//规格型号
                        text9 = "日期:" + this.dgv_Label.Rows[i].Cells[9].Value;//取得日期
                        if (text9.IndexOf("0:00:00") > 0)
                        {
                            text9 = text9.Replace("0:00:00", "");
                        }

                        _printData.Add("AssetCodeB", text1);
                        _printData.Add("AssetNameB", text2);
                        _printData.Add("PriceB", text3);
                        _printData.Add("DeptB", text4);
                        _printData.Add("UserB", text5);
                        _printData.Add("AccountB", text6);
                        _printData.Add("JudgeB", text7);
                        _printData.Add("TypeB", text8);
                        _printData.Add("GetDateB", text9);

                        //如果是双数列，则直接打印，并通知打印函数打印两列（true）；
                        _IsOdd = false;//代表目前是双列数据；
                        print_Process_Double(_printData, false);
                    }
                }

                //如果所有数据遍历完，只剩一条数据，则打印单列
                if (_Flag == true && _IsOdd == true)
                {
                    print_Process_Double(_printData, true);
                }
            }
            //如果打印份数为双数，则遍历所有数据，直接打印
            else if (!Convert.ToBoolean(_printNum % 2))
            {
                Int32 _n = _printNum/2;
                for (Int32 i = 0; i < _rowCount; i++)
                {
                    if (Convert.ToBoolean(dgv_Label.Rows[i].Cells[0].Value) != true)
                    {
                        continue;
                    }
                    _printData.Clear();
                    text1 = "编号:" + this.dgv_Label.Rows[i].Cells[1].Value;//资产编号
                    text2 = "名称:" + this.dgv_Label.Rows[i].Cells[2].Value;//资产名称
                    text3 = "原值:" + this.dgv_Label.Rows[i].Cells[3].Value;//账面原值
                    text3 = text3.Substring(0, text3.Length - 3);
                    text4 = "二级管理:" + this.dgv_Label.Rows[i].Cells[4].Value;//管理机构
                    text5 = "使用:" + this.dgv_Label.Rows[i].Cells[5].Value;//使用人
                    text6 = "凭证号:" + this.dgv_Label.Rows[i].Cells[6].Value;//会计凭证号
                    text7 = "品牌:" + this.dgv_Label.Rows[i].Cells[7].Value;//品牌
                    text8 = "型号:" + this.dgv_Label.Rows[i].Cells[8].Value;//规格型号                 
                    text9 = "日期:" + this.dgv_Label.Rows[i].Cells[9].Value;//取得日期
                    if (text9.IndexOf("0:00:00") > 0)
                    {
                        text9 = text9.Replace("0:00:00", "");
                    }
                    _printData.Add("AssetCode", text1);
                    _printData.Add("AssetName", text2);
                    _printData.Add("Price", text3);
                    _printData.Add("Dept", text4);
                    _printData.Add("User", text5);
                    _printData.Add("Account", text6);
                    _printData.Add("Judge", text7);
                    _printData.Add("Type", text8);
                    _printData.Add("GetDate", text9);
                    for (Int32 j = 0; j < _n; j++)
                    {
                        print_Process_More(_printData);
                    }
                }
            }
            //如果是奇数的份数，则打印完双数后，再单独打印一份
            else if(Convert.ToBoolean(_printNum % 2))
            {
                Int32 _n = _printNum / 2;
                for (Int32 i = 0; i < _rowCount; i++)
                {
                    if (Convert.ToBoolean(dgv_Label.Rows[i].Cells[0].Value) != true)
                    {
                        continue;
                    }
                    _printData.Clear();
                    text1 = "编号:" + this.dgv_Label.Rows[i].Cells[1].Value;//资产编号
                    text2 = "名称:" + this.dgv_Label.Rows[i].Cells[2].Value;//资产名称
                    text3 = "原值:" + this.dgv_Label.Rows[i].Cells[3].Value;//账面原值
                    text3 = text3.Substring(0, text3.Length - 3);
                    text4 = "二级管理:" + this.dgv_Label.Rows[i].Cells[4].Value;//管理机构
                    text5 = "使用:" + this.dgv_Label.Rows[i].Cells[5].Value;//使用人
                    text6 = "凭证号:" + this.dgv_Label.Rows[i].Cells[6].Value;//会计凭证号
                    text7 = "品牌:" + this.dgv_Label.Rows[i].Cells[7].Value;//品牌
                    text8 = "型号:" + this.dgv_Label.Rows[i].Cells[8].Value;//规格型号
                    text9 = "日期:" + this.dgv_Label.Rows[i].Cells[9].Value;//取得日期
                    if (text9.IndexOf("0:00:00") > 0)
                    {
                        text9 = text9.Replace("0:00:00", "");
                    }
                    _printData.Add("AssetCode", text1);
                    _printData.Add("AssetName", text2);
                    _printData.Add("Price", text3);
                    _printData.Add("Dept", text4);
                    _printData.Add("User", text5);
                    _printData.Add("Account", text6);
                    _printData.Add("Judge", text7);
                    _printData.Add("Type", text8);
                    _printData.Add("GetDate", text9);
                    for (Int32 j = 0; j < _n; j++)
                    {
                        print_Process_More(_printData);
                    }
                    print_Process_One(_printData);

                }
            }

        }
        #endregion

        /// <summary>
        /// 打印过程每个标签打印双份
        /// </summary>
        private bool print_Process_More(Dictionary<string, string> _printData)
        {
           
            Int32 _font_size = 23;//设置字体高度
            Int32 _height = 210;//设置第一排文字的位置
            Int32 _left = 20;//设置第一行文字离左边的位置
            Int32 _add_sec = 200;//设置第二列的偏移位置
            Int32 _right = 440;//设置右侧文字第一行的位置
            try
            {
                int state;
                #region==========打开USB==========
                ///int BPLA_OpenUsbPrn(int iDevID)
                /*iDevID：[in] USB类模式设备编号，取值范围：> 0。
                 */
                state = PrinterDll.BPLA_OpenUsb();//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                #endregion
                #region==========设置出纸方式==========
                ///int BPLA_Set(int iOutMode, int iPaperMode, int iPrintMode)
                ///
                /*iOutMode   ：[in] 取值范围：0 --- 3，分别表示：切刀，剥离，撕离，回卷。
                    iPaperMode ：[in] 取值范围：0：非连续纸，1：连续纸。
                    iPrintMode ：[in] 取值范围：0：热敏打印，1：热转印打印。
                  */
                state = PrinterDll.BPLA_Set(3, 0, 1);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                #endregion
                #region==========设置标签纸的大小设置==========
                ///int BPLA_SetPaperLength(int iContinueLength, int iLabelLength)
                /*
                * iContinueLength ：[in] 连续纸长度，取值范围：0 --- 9999，如果为0，则不进行设置，单位：点，毫米/10，英寸/100。
                  iLabelLength    ：[in] 寻找标签的最大长度，取值范围：0 --- 9999，如果为0，则不进行设置，单位：点，毫米/10，英寸/100。
                */
                //state = PrinterDll.BPLA_SetPaperLength(100, 30);//
                //if (state != PrinterDll.BPLA_OK)
                //throw new Exception();
                #endregion
                #region==========设置停止位==========
                ///int BPLA_SetEnd(int iPosition)
                ///iPosition ：[in] 取值范围：0 --- 999， 0：存在传感器和按键起作用，非0：打印机不判别是否撕掉或剥掉，直接出纸到停止位。
                PrinterDll.BPLA_SetEnd(0);
                #endregion
                #region==========进入标签模式，设置打印区域及打印参数==========
                ///int BPLA_StartArea(int iUnitMode, int iPrintWidth, int iColumn, int iRow, int iDarkness, int iSpeedPrint, int iSpeedFor, int iSpeedBac)                
                /*  iUnitMode   ：[in] 单位模式，取值范围：0 --- 3 分别表示：0：默认单位，1：米制，2：点，3：英制。
                    iPrintWidth ：[in] 打印宽度设置。取值范围：单位由参数iUnitMode决定， 0 --- 9999。
                    iColumn     ：[in] 列偏移数，取值范围：0 --- 9999。
                    iRow        ：[in] 行偏移数，取值范围：0 --- 9999。
                    iDarkness   ：[in] 打印浓度，取值范围：0 --- 30。
                    iSpeedPrint ：[in] 打印速度，取值范围：0 --- 20。
                    iSpeedFor   ：[in] 进纸速度，取值范围：0 --- 20。
                    iSpeedBac   ：[in] 退纸速度，取值范围：0 --- 20。
                */
                state = PrinterDll.BPLA_StartArea(2, 1000, 0, 0, 20, 0, 0, 0);//进入标签模式，设置打印区域及打印参数
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                #endregion
                #region==========标签内容设置==========
                ///int BPLA_PrintTruetype(char *cText, int iStartX, int iStartY, char *cFontName, int iFontHeight, int iFontWidth)
                /*
                 * cText        ：[in] 需要打印的文字。
                    iStartX      ：[in] 起点位置横坐标，取值范围：0 --- 9999。
                    iStartY      ：[in] 起点位置纵坐标，取值范围：0 --- 9999。
                    cFontName    ：[in] TRUETYPE字体名称，字符集依照系统默认字符集。
                    iFontHeight  ：[in] 字体高度，取值范围：>= 0
                    iFontWidth   ：[in] 字体宽度，取值范围：如果为0，则根据高度自动匹配宽度；如果不为0，则宽度为设定值，允许设置不规则字体。
                 */

                //既然是每条数据打印双份，那么只需要在左右各输出一遍即可
                //左侧
                //单位头信息
                state = PrinterDll.BPLA_PrintTruetype("武汉市结核病防治所", _left + 20, _height, "Tahoma", 40, 0);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                _height = _height - 40;
                //资产编号
                state = PrinterDll.BPLA_PrintTruetype(_printData["AssetCode"], _left, _height, "Tahoma", 30, 0);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                _height = _height - 40;

                //资产名称
                state = PrinterDll.BPLA_PrintTruetype(_printData["AssetName"], _left, _height, "Tahoma", _font_size, 0);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                //账面原值
                state = PrinterDll.BPLA_PrintTruetype(_printData["Price"], _left + _add_sec, _height, "Tahoma", _font_size, 0);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                _height = _height - _font_size;

                //使用部门
                state = PrinterDll.BPLA_PrintTruetype(_printData["Dept"], _left, _height, "Tahoma", _font_size, 0);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                //使用人
                state = PrinterDll.BPLA_PrintTruetype(_printData["User"], _left + _add_sec, _height, "Tahoma", _font_size, 0);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                _height = _height - _font_size;

                //会计凭证号
                state = PrinterDll.BPLA_PrintTruetype(_printData["Account"], _left, _height, "Tahoma", _font_size, 0);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                //品牌
                state = PrinterDll.BPLA_PrintTruetype(_printData["Judge"], _left + _add_sec, _height, "Tahoma", _font_size, 0);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                _height = _height - _font_size;

                //规格型号
                state = PrinterDll.BPLA_PrintTruetype(_printData["Type"], _left, _height, "Tahoma", _font_size, 0);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                //取得日期
                state = PrinterDll.BPLA_PrintTruetype(_printData["GetDate"], _left + _add_sec, _height, "Tahoma", _font_size, 0);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();

                _height = 210;
                //右侧
                //单位头信息
                state = PrinterDll.BPLA_PrintTruetype("武汉市结核病防治所", _right, _height, "Tahoma", 40, 0);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                _height = _height - 40;
                //资产编号
                state = PrinterDll.BPLA_PrintTruetype(_printData["AssetCode"], _right, _height, "Tahoma", 30, 0);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                _height = _height - 40;

                //资产名称
                state = PrinterDll.BPLA_PrintTruetype(_printData["AssetName"], _right, _height, "Tahoma", _font_size, 0);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                //账面原值
                state = PrinterDll.BPLA_PrintTruetype(_printData["Price"], _right + _add_sec, _height, "Tahoma", _font_size, 0);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                _height = _height - _font_size;

                //使用部门
                state = PrinterDll.BPLA_PrintTruetype(_printData["Dept"], _right, _height, "Tahoma", _font_size, 0);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                //使用人
                state = PrinterDll.BPLA_PrintTruetype(_printData["User"], _right + _add_sec, _height, "Tahoma", _font_size, 0);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                _height = _height - _font_size;

                //会计凭证号
                state = PrinterDll.BPLA_PrintTruetype(_printData["Account"], _right, _height, "Tahoma", _font_size, 0);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                //品牌
                state = PrinterDll.BPLA_PrintTruetype(_printData["Judge"], _right + _add_sec, _height, "Tahoma", _font_size, 0);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                _height = _height - _font_size;

                //规格型号
                state = PrinterDll.BPLA_PrintTruetype(_printData["Type"], _right, _height, "Tahoma", _font_size, 0);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                //取得日期
                state = PrinterDll.BPLA_PrintTruetype(_printData["GetDate"], _right + _add_sec, _height, "Tahoma", _font_size, 0);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                #endregion

                #region==========打印==========
                ///int BPLA_Print(int iPieces, intiSamePieces, int iOutUnit)
                /*
                 *  iPieces     ：[in] 打印数量,取值范围：1 --- 9999。
                    iSamePieces ：[in] 相同标签的打印数量，取值范围：0 --- 99。
                    iOutUnit    ：[in] 出纸单位，取值范围：1 --- 9999。
                 */
                PrinterDll.BPLA_Print(1, 0, 1);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                #endregion
               
                #region==========复位打印机==========
                /// int BPLA_Reset()
                // PrinterDll.BPLA_Reset();
                #endregion
                #region==========关闭USB==========
                ///int BPLA_CloseUsbPrn()
                ///
                // PrinterDll.BPLA_CloseUsb();//
                #endregion
                return true;
            }
            catch (Exception e)
            {
                this.tb_PrintProcess.Text = "系统提示:" + e.Message.ToString();
                PrinterDll.BPLA_Reset();
                PrinterDll.BPLA_CloseUsb();
                return false;
            }
        }

        /// <summary>
        /// 对传入的数据打印单独的一份
        /// </summary>
        private bool print_Process_One(Dictionary<string, string> _printData)
        {

            Int32 _font_size = 23;//设置字体高度
            Int32 _height = 210;//设置第一排文字的位置
            Int32 _left = 20;//设置第一行文字离左边的位置
            Int32 _add_sec = 200;//设置第二列的偏移位置
            Int32 _right = 440;//设置右侧文字第一行的位置
            try
            {
                int state;
                #region==========打开USB==========
                ///int BPLA_OpenUsbPrn(int iDevID)
                /*iDevID：[in] USB类模式设备编号，取值范围：> 0。
                 */
                state = PrinterDll.BPLA_OpenUsb();//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                #endregion
                #region==========设置出纸方式==========
                ///int BPLA_Set(int iOutMode, int iPaperMode, int iPrintMode)
                ///
                /*iOutMode   ：[in] 取值范围：0 --- 3，分别表示：切刀，剥离，撕离，回卷。
                    iPaperMode ：[in] 取值范围：0：非连续纸，1：连续纸。
                    iPrintMode ：[in] 取值范围：0：热敏打印，1：热转印打印。
                  */
                state = PrinterDll.BPLA_Set(3, 0, 1);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                #endregion
                #region==========设置标签纸的大小设置==========
                ///int BPLA_SetPaperLength(int iContinueLength, int iLabelLength)
                /*
                * iContinueLength ：[in] 连续纸长度，取值范围：0 --- 9999，如果为0，则不进行设置，单位：点，毫米/10，英寸/100。
                  iLabelLength    ：[in] 寻找标签的最大长度，取值范围：0 --- 9999，如果为0，则不进行设置，单位：点，毫米/10，英寸/100。
                */
                //state = PrinterDll.BPLA_SetPaperLength(100, 30);//
                //if (state != PrinterDll.BPLA_OK)
                //throw new Exception();
                #endregion
                #region==========设置停止位==========
                ///int BPLA_SetEnd(int iPosition)
                ///iPosition ：[in] 取值范围：0 --- 999， 0：存在传感器和按键起作用，非0：打印机不判别是否撕掉或剥掉，直接出纸到停止位。
                PrinterDll.BPLA_SetEnd(0);
                #endregion
                #region==========进入标签模式，设置打印区域及打印参数==========
                ///int BPLA_StartArea(int iUnitMode, int iPrintWidth, int iColumn, int iRow, int iDarkness, int iSpeedPrint, int iSpeedFor, int iSpeedBac)                
                /*  iUnitMode   ：[in] 单位模式，取值范围：0 --- 3 分别表示：0：默认单位，1：米制，2：点，3：英制。
                    iPrintWidth ：[in] 打印宽度设置。取值范围：单位由参数iUnitMode决定， 0 --- 9999。
                    iColumn     ：[in] 列偏移数，取值范围：0 --- 9999。
                    iRow        ：[in] 行偏移数，取值范围：0 --- 9999。
                    iDarkness   ：[in] 打印浓度，取值范围：0 --- 30。
                    iSpeedPrint ：[in] 打印速度，取值范围：0 --- 20。
                    iSpeedFor   ：[in] 进纸速度，取值范围：0 --- 20。
                    iSpeedBac   ：[in] 退纸速度，取值范围：0 --- 20。
                */
                state = PrinterDll.BPLA_StartArea(2, 1000, 0, 0, 20, 0, 0, 0);//进入标签模式，设置打印区域及打印参数
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                #endregion
                #region==========标签内容设置==========
                ///int BPLA_PrintTruetype(char *cText, int iStartX, int iStartY, char *cFontName, int iFontHeight, int iFontWidth)
                /*
                 * cText        ：[in] 需要打印的文字。
                    iStartX      ：[in] 起点位置横坐标，取值范围：0 --- 9999。
                    iStartY      ：[in] 起点位置纵坐标，取值范围：0 --- 9999。
                    cFontName    ：[in] TRUETYPE字体名称，字符集依照系统默认字符集。
                    iFontHeight  ：[in] 字体高度，取值范围：>= 0
                    iFontWidth   ：[in] 字体宽度，取值范围：如果为0，则根据高度自动匹配宽度；如果不为0，则宽度为设定值，允许设置不规则字体。
                 */

                //既然是每条数据打印双份，那么只需要在左右各输出一遍即可
                //左侧
                //单位头信息
                state = PrinterDll.BPLA_PrintTruetype("武汉市结核病防治所", _left + 20, _height, "Tahoma", 40, 0);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                _height = _height - 40;
                //资产编号
                state = PrinterDll.BPLA_PrintTruetype(_printData["AssetCode"], _left, _height, "Tahoma", 30, 0);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                _height = _height - 40;

                //资产名称
                state = PrinterDll.BPLA_PrintTruetype(_printData["AssetName"], _left, _height, "Tahoma", _font_size, 0);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                //账面原值
                state = PrinterDll.BPLA_PrintTruetype(_printData["Price"], _left + _add_sec, _height, "Tahoma", _font_size, 0);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                _height = _height - _font_size;

                //使用部门
                state = PrinterDll.BPLA_PrintTruetype(_printData["Dept"], _left, _height, "Tahoma", _font_size, 0);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                //使用人
                state = PrinterDll.BPLA_PrintTruetype(_printData["User"], _left + _add_sec, _height, "Tahoma", _font_size, 0);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                _height = _height - _font_size;

                //会计凭证号
                state = PrinterDll.BPLA_PrintTruetype(_printData["Account"], _left, _height, "Tahoma", _font_size, 0);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                //品牌
                state = PrinterDll.BPLA_PrintTruetype(_printData["Judge"], _left + _add_sec, _height, "Tahoma", _font_size, 0);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                _height = _height - _font_size;

                //规格型号
                state = PrinterDll.BPLA_PrintTruetype(_printData["Type"], _left, _height, "Tahoma", _font_size, 0);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                //取得日期
                state = PrinterDll.BPLA_PrintTruetype(_printData["GetDate"], _left + _add_sec, _height, "Tahoma", _font_size, 0);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();

                #endregion

                #region==========打印==========
                ///int BPLA_Print(int iPieces, intiSamePieces, int iOutUnit)
                /*
                 *  iPieces     ：[in] 打印数量,取值范围：1 --- 9999。
                    iSamePieces ：[in] 相同标签的打印数量，取值范围：0 --- 99。
                    iOutUnit    ：[in] 出纸单位，取值范围：1 --- 9999。
                 */
                PrinterDll.BPLA_Print(1, 0, 1);//
                if (state != PrinterDll.BPLA_OK)
                    throw new Exception();
                #endregion

                #region==========复位打印机==========
                /// int BPLA_Reset()
                // PrinterDll.BPLA_Reset();
                #endregion
                #region==========关闭USB==========
                ///int BPLA_CloseUsbPrn()
                ///
                // PrinterDll.BPLA_CloseUsb();//
                #endregion
                return true;
            }
            catch (Exception e)
            {
                this.tb_PrintProcess.Text = "系统提示:" + e.Message.ToString();
                PrinterDll.BPLA_Reset();
                PrinterDll.BPLA_CloseUsb();
                return false;
            }
        }

    }
}
