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

        protected void button_confirmpost_Click(object sender, EventArgs e)
        {
            int iduser = 1; //temp
            Blog blog = new Blog(iduser, null, DateTime.UtcNow, textbox_title.Text, textbox_content.Text, 0, true);
            int idblog = blog.GetPostID();
            Response.Redirect(String.Format("blog.aspx?id={0}", idblog));
        }

        protected void button_cancelpost_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx"); 
        }
    }
}