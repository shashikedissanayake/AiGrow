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
    public partial class AdminDataVisualizer : System.Web.UI.Page
    {
        string location = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.FindControl("errorDiv").Visible = false;
            Master.FindControl("successDiv").Visible = false;
            selectDevice.Visible=false;
            selectId.Visible = false;
            Label1.Visible = false;
            Label2.Visible = false;

        }

        

        protected void table_Select(object sender, EventArgs e)
        {
            location = selectLocation.SelectedValue;
            selectId.Visible = true;
            Label1.Visible = true;
            Label2.Visible = false;
            selectDevice.Visible = false;
            selectId_DataBinding(location);
        }

       

        protected void id_select(object sender, EventArgs e)
        {
            string selected = selectId.SelectedValue;
            selectId.Visible = true;
            Label1.Visible = true;
            Label2.Visible = true;
            selectDevice.Visible = true;
            selectDevice_DataBinding(selected);
        }

        protected void device_select(object sender, EventArgs e)
        {

        }

        private void selectDevice_DataBinding(string tableName)
        {
            DataTable dt_device_names;
            //switch (location)
            //{
            //    case "bay_line":
            //        dt_device_names = new BL_BayLineDevice().selectUniqueIdsByTableName(tableName);
            //        break;
            //    case "greenhouse":
            //        dt_device_names = new BL_GreenhouseDevice().selectUniqueIdsByTableName(tableName);
            //        break;
            //    case "level":
            //        dt_device_names = new BL_Greenhouse().selectUniqueIdsByTableName(tableName);
            //        break;
            //    case "level_line":
            //        dt_device_names = new BL_Greenhouse().selectUniqueIdsByTableName(tableName);
            //        break;
            //    case "rack":
            //        dt_device_names = new BL_BayRackDevice().selectUniqueIdsByTableName(tableName);
            //        break;
            //    default:
            //        dt_device_names = new BL_BayDevice().selectUniqueIdsByTableName(tableName);
            //        break;
            //}


            dt_device_names = new BL_Greenhouse().selectUniqueIdsByTableName(tableName);
            //Map the list to the username list box.
            selectDevice.DataSource = dt_device_names;
            selectDevice.DataValueField = "device_unique_id";
            selectDevice.DataTextField = "device_unique_id";
            selectDevice.DataBind();

        }

        private void selectId_DataBinding(string tableName)
        {
            DataTable dt_id_names = new BL_Greenhouse().selectUniqueIdsByTableName(tableName);
            //Map the list to the username list box.
            selectId.DataSource = dt_id_names;
            selectId.DataValueField = tableName+"_unique_id";
            selectId.DataTextField = tableName + "_unique_id";
            selectId.DataBind();

        }
    }
}