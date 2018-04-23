#region #Reference
using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.Snap.Core.API;
using DevExpress.XtraRichEdit.API.Native;
// ...
#endregion #Reference

namespace SnapSeparatorExample {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        #region #Code
        private void Form1_Load(object sender, EventArgs e) {
            // Create a dataset and bind the Snap control to data.
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("Customers");
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Rows.Add(1, "Steven Buchanan");
            dt.Rows.Add(2, "Anne Dodsworth");
            dt.Rows.Add(3, "Janet Levering");
            ds.Tables.Add(dt);
            this.snapControl1.DataSources.Add("DS", ds);

            // Create a Snap list and populate it with the data.
            SnapList snList = this.snapControl1.Document.CreateSnList(
                this.snapControl1.Document.Range.Start, "List1");
            snList.BeginUpdate();
            snList.DataSourceName = "DS";
            snList.DataMember = "Customers";
            SnapDocument listRow = snList.RowTemplate;
            Table listRowTable = listRow.Tables.Create(listRow.Range.Start, 1, 2);
            TableCellCollection listRowCells = listRowTable.FirstRow.Cells;
            listRow.CreateSnText(listRowCells[0].ContentRange.End, @"Id");
            listRow.CreateSnText(listRowCells[1].ContentRange.End, @"Name");

            // Define a list separator and specify its format.
            snList.Separator.AppendText(new string('\f', 1));

            // Finalize the Snap list creation.
            snList.EndUpdate();
            snList.Field.Update();
        }
        #endregion #Code
    }
}
