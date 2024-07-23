using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.IO;
using ExcelDataReader;
using System.Data;
using DAO;

namespace QLNhaHang
{
	public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport
	{
		DataTableCollection data;
		public XtraReport1(string pathfile, string name)
		{
			InitializeComponent();
			QrEx.Text = name;
			using (var stream = File.Open(pathfile, FileMode.Open, FileAccess.Read))
			{
				using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
				{
					DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
					{
						ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
					});
					data = result.Tables;
					foreach (DataTable dataTable in data)
					{
						if (dataTable.TableName == "table")
						{
							this.DataSource = dataTable;
							colSTT.DataBindings.Add("Text",this.DataSource, "STT");
							colTenTP.DataBindings.Add("Text", this.DataSource, "TenThucPham");
							colDVT.DataBindings.Add("Text", this.DataSource, "DonViTinh");
							colSL.DataBindings.Add("Text", this.DataSource, "SoLuong");
							colGT.DataBindings.Add("Text", this.DataSource, "DonGia");
							colTT.DataBindings.Add("Text", this.DataSource, "ThanhTien");
							xrLabel1.Text = dataTable.Rows[0][6].ToString();
						}
					}
				}
			}
		}

		private void xrLabel1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			XRLabel label = sender as XRLabel;
			double value = Convert.ToDouble(label.Text);
			if (value == 0) label.Text = "0";
			else label.Text = string.Format("{0:N0}",value);
		}

		private void colGT_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			XRLabel label = sender as XRLabel;
			double value = Convert.ToDouble(label.Text);
			if (value == 0) label.Text = "0";
			else label.Text = string.Format("{0:N0}", value);
		}

		private void colTT_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			XRLabel label = sender as XRLabel;
			double value = Convert.ToDouble(label.Text);
			if (value == 0) label.Text = "0";
			else label.Text = string.Format("{0:N0}", value);
		}
	}
	 
}
