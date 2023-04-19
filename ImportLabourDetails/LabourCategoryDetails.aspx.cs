using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestApp.ImportLabourDetails
{
    public partial class LabourCategoryDetails : System.Web.UI.Page
    {
        public SqlConnection con = new SqlConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            getconnection();
        }
        public void getconnection()
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["TempConnectionString"].ConnectionString;
        }
        protected void btnSampleExcel_Click(object sender, EventArgs e)
        {
            StringBuilder str = new StringBuilder();
            str.Append("window.open('../ImportFormats/labourCategoryexcel.xlsx','newwindow','height=350,width=830,left=200,top=100,scrollbars=no,location=no',replace=true);");
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "dialog", str.ToString(), true);
        }
        protected void BtnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                //lblmsg.Text = "";

                if (FileUpload1.HasFile)
                {

                    string FileName = Server.MapPath("~/Import/Account/" + FileUpload1.FileName + "");
                    string Path1 = Server.MapPath("~/Import/Account/");

                    if (!(Directory.Exists(Path1)))
                        Directory.CreateDirectory(Path1);

                    if (File.Exists(FileName) == true)
                        File.Delete(FileName);


                    FileUpload1.SaveAs(Server.MapPath("~/Import/Account/" + FileUpload1.FileName + ""));

                    string Path = Server.MapPath("~/Import/Account/" + FileUpload1.FileName + "");

                    if (Path.ToUpper().EndsWith("XLSX"))
                    {
                        String excelConnString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0\"", Path);

                        using (OleDbConnection excelConnection = new OleDbConnection(excelConnString))
                        {
                            //Create OleDbCommand to fetch data from Excel 
                            using (OleDbCommand cmd = new OleDbCommand("Select * from [Sheet1$]", excelConnection))
                            {
                                excelConnection.Open();
                                using (OleDbDataReader dReader = cmd.ExecuteReader())
                                {
                                    using (SqlBulkCopy sqlBulk = new SqlBulkCopy(con))
                                    {
                                        //Give your Destination table name 
                                        sqlBulk.DestinationTableName = "importdata";
                                        sqlBulk.ColumnMappings.Add("Contractname", "Contractname");
                                        sqlBulk.ColumnMappings.Add("CommonlabourCategory", "CommonlabourCategory");
                                        sqlBulk.ColumnMappings.Add("DisplayName", "DisplayName");
                                        sqlBulk.ColumnMappings.Add("Shortname", "Shortname");
                                        sqlBulk.ColumnMappings.Add("EEO", "EEO");
                                        sqlBulk.WriteToServer(dReader);
                                        lbsmsg.Text = "Imported Successsfully";
                                        con.Close();
                                    }
                                }
                            }
                        }

                    }
                    else
                    {
                        lbsmsg.Text = "Please browse .xlsx file";

                    }
                }
                else
                {
                    lbsmsg.Text = "Browse the File";

                }
            }
            catch (Exception ex)
            {
                if (ex.Message.EndsWith("because it is being used by another process."))
                    lbsmsg.Text = "Can't Upload, You trid it before....Pleae Try with another file";
            }
        }
    }

}
