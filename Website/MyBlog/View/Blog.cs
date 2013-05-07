using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace MyBlog.Model
{
    public partial class Blog
    {
        public string ToHTML()
        {
            int numcomment = NumComments();
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<h1>{0}</h1>",this.title);
            sb.AppendFormat("{0} ", this.time);
            sb.AppendFormat("by {0} ", this.iduser);
            sb.AppendFormat("<p1>{0}</p1> ", this.content);
            sb.AppendFormat("<a href='blogcomments.aspx?id={0}'>Comments({1})</a><br />",this.idblog, numcomment);
            
            return sb.ToString();
        }
    }
}