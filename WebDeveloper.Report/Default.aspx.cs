using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

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
        AdventureWorksDataSet ds = new AdventureWorksDataSet();
        ReportDataSource rptSrc = new ReportDataSource("AdventureWorksDataSet",
                                                       ds.Tables[0]);
        ReportViewer1.LocalReport.DataSources.Add(rptSrc);
        ReportViewer1.LocalReport.Refresh();
    }
}
