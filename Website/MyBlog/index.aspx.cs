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
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            List<Blog> blog = Blog.GetAll();
            StringBuilder sb = new StringBuilder();
            
            foreach (Blog i in blog)
            {
                sb.Append(i.ToHTML());
            }

            blogroll.Text = sb.ToString();
        }
    }
}