using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyBlog.Model;

namespace MyBlog
{
    public partial class blogpostform : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
        }

        protected void postconfirm_Click(object sender, EventArgs e)
        {
            int iduser = 1; //temp
            Blog blog = new Blog(iduser, null, DateTime.UtcNow, titlebox.Text, postformarea.Text, 0,true);
            Response.Redirect("index.aspx");
        }

        protected void postcancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx"); 
        }
    }
}