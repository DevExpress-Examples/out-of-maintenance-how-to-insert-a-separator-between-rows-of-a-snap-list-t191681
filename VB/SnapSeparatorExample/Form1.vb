'#Region "#Reference"
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports DevExpress.Snap.Core.API
Imports DevExpress.XtraRichEdit.API.Native

' ...
'#End Region  ' #Reference
Namespace SnapSeparatorExample

    Public Partial Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

'#Region "#Code"
        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            ' Create a dataset and bind the Snap control to data.
            Dim ds As DataSet = New DataSet()
            Dim dt As DataTable = New DataTable("Customers")
            dt.Columns.Add("Id", GetType(Integer))
            dt.Columns.Add("Name", GetType(String))
            dt.Rows.Add(1, "Steven Buchanan")
            dt.Rows.Add(2, "Anne Dodsworth")
            dt.Rows.Add(3, "Janet Levering")
            ds.Tables.Add(dt)
            snapControl1.DataSources.Add("DS", ds)
            ' Create a Snap list and populate it with the data.
            Dim snList As SnapList = snapControl1.Document.CreateSnList(snapControl1.Document.Range.Start, "List1")
            snList.BeginUpdate()
            snList.DataSourceName = "DS"
            snList.DataMember = "Customers"
            Dim listRow As SnapDocument = snList.RowTemplate
            Dim listRowTable As Table = listRow.Tables.Create(listRow.Range.Start, 1, 2)
            Dim listRowCells As TableCellCollection = listRowTable.FirstRow.Cells
            listRow.CreateSnText(listRowCells(0).ContentRange.End, "Id")
            listRow.CreateSnText(listRowCells(1).ContentRange.End, "Name")
            ' Define a list separator and specify its format.
            snList.Separator.AppendText(New String(Microsoft.VisualBasic.Strings.ChrW(12), 1))
            ' Finalize the Snap list creation.
            snList.EndUpdate()
            snList.Field.Update()
        End Sub
'#End Region  ' #Code
    End Class
End Namespace
