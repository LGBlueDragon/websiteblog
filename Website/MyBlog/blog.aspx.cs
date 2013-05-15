using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyBlog.Model;
using System.Text;
using System.Web.Security;

namespace MyBlog
{
    public partial class blogcomments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            int idblog;
            if (!int.TryParse(Request.Params["id"],out idblog))
                Response.Redirect("index.aspx");

            if (idblog <= 0)
                Response.Redirect("index.aspx");

            Blog original = new Blog(idblog, 0, null, DateTime.Now, "", "", 0);
            if (!original.Load())
                Response.Redirect("index.aspx");

            List<Blog> commentslist = original.Comments();

            Template tempcomment = new Template("Comment.htm");
            Template tempblog = new Template("ViewBlog.htm");

            StringBuilder sb = new StringBuilder();

            foreach (Blog i in commentslist)
            {
               sb.Append(i.ToHTMLComment(tempcomment));
            }

            label_blogpost.Text = original.ToHTML(tempblog);

            if (commentslist.Count == 0)
                label_comments.Text = "This post has no comments.";
            else
                label_comments.Text = sb.ToString();

            if (Membership.GetUser() == null)
            {
                button_addcomment.Enabled = false;
                textbox_addcomment.Enabled = false;
                button_addcomment.Visible = false;
                textbox_addcomment.Visible = false;
            }

        }

        protected void button_addcomment_Click(object sender, EventArgs e)
        {
            int iduser = MyBlog.Model.User.GetID(Membership.GetUser().UserName.ToString());
            int idblog = Convert.ToInt16(Request.Params["id"]);
            Blog addcomment = new Blog(iduser, null, DateTime.UtcNow, "Comment", textbox_addcomment.Text, idblog, true);
            Response.Redirect(String.Format("blog.aspx?id={0}", idblog));
        }
    }
}