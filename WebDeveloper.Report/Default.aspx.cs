using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
//using WebDeveloper.DataAccess;
using WebDeveloper.Model;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            PopulateReport();
        }
    }

    protected void PopulateReport()
    {
        string cadenaCnx = ConfigurationManager.ConnectionStrings["WebDeveloperConnectionString"].ToString();
        SqlConnection sqlCnx = new SqlConnection(cadenaCnx);
        DataTable dt = new DataTable();

        string queryString = "Select * From [Person].[vStateProvinceCountryRegion]";
        SqlCommand cmd = new SqlCommand(queryString, sqlCnx);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        int j = dt.Rows.Count;

        //1) Cargar grilla
        //GridView1.DataSource = dt;
        //GridView1.DataBind();

        //2) Cargar reporte
        ReportDataSource rptSrc = new ReportDataSource("dsStateProvince",
                                                       dt);
        ReportViewer1.LocalReport.DataSources.Add(rptSrc);
        ReportViewer1.LocalReport.Refresh();
    }
}
