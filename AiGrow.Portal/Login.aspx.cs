using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AiGrow.Portal
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.QueryString["username"] != null)
            {
                userName.Text = Encryption.Base64Decode(HttpContext.Current.Request.QueryString["username"]);
            }
        }

        protected void signinClick(object sender, EventArgs e)
        {
            string user_Name = userName.Text.Trim();
            string pass_word = password.Text.Trim();

        }
    }
}