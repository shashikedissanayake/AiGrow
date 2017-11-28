using AiGrow.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AiGrow.Portal.Dashboards.Admin
{
    public partial class AdminGreenHouseView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.FindControl("errorDiv").Visible = false;
            Master.FindControl("successDiv").Visible = false;
            if (!IsPostBack)
            {
                treeViewGetDataSet();
            }
        }

        private void treeViewGetDataSet()
        {
            string greenHouseID = HttpContext.Current.Request.QueryString["greenhouseID"];
            
            DataTable dt = new BL_Greenhouse().selectComponentsByNetworkID(greenHouseID);
            ghView.ParentFieldName = "bay_unique_id";
            ghView.KeyFieldName = "";
            ghView.DataBind();
        }

    }
}