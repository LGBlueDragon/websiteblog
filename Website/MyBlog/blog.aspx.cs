using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyBlog.Model;
using System.Text;

namespace MyBlog
{
    public partial class blogcomments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            int idblog = Convert.ToInt16(Request.Params["id"]);
            Blog tmp = new Blog(idblog, 0, null, DateTime.Now, "", "", 0);
            List<Blog> comments = tmp.Comments();

            StringBuilder sb = new StringBuilder();

            foreach (Blog i in comments)
            {
               // sb.Append(i.ToHTML());
            }
            
            labelcomments.Text = sb.ToString();

        }

        protected void printcommentok_Click(object sender, EventArgs e)
        {
            int iduser = 1; //temp
            int idblog = Convert.ToInt16(Request.Params["id"]);
            Blog addcomment = new Blog(iduser, null, DateTime.UtcNow, "Comment", printcomment.Text, idblog, true);
            Response.Redirect(String.Format("blog.aspx?id={0}", idblog));
        }
    }
}