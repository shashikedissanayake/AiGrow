using AiGrow.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AiGrow.Portal.Dashboards.Admin
{
    public partial class AdminGreenHouses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.FindControl("errorDiv").Visible = false;
            Master.FindControl("successDiv").Visible = false;
            if (!IsPostBack)
            {
                gridGetDataSet();
                gvNetworks.DataBind();
            }
        }

        protected void gvNetworks_DataBinding(object sender, EventArgs e)
        {
            gridGetDataSet();
        }

        private void gridGetDataSet()
        {
            gvNetworks.DataSource = new BL_GreenHouses().select();

        }
    }
}