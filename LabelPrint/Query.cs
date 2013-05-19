using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabelPrint
{
    class Query
    {
    }
}

namespace whtb2008_V7DataSetTableAdapters
{
    public partial class VBasAssetStockTableAdapter : System.ComponentModel.Component
    {

        public virtual LabelPrint.whtb2008_V7DataSet.VBasAssetStockDataTable GetDataBySearch(string searchSql)
        {
            this.SelectCommand = new System.Data.OleDb.OleDbCommand(searchSql, this.DbCommandCollection);
            Fernando.OutRegisterDataTable dataTable = new Fernando.OutRegisterDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
