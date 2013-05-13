using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace MyBlog.Model
{
    public partial class Blog
    {
        public string ToHTML(Template t)
        {
            int numcomment = NumComments();
            
            Dictionary<string,string> values = new Dictionary<string,string>();
            values.Add("title",this.title);
            values.Add("date",this.time.ToString());
            values.Add("user", this.user.Username);
            values.Add("content", this.content);
            values.Add("idpage", this.idblog.ToString());
            values.Add("numcomments", numcomment.ToString());

            return t.Render(values);
        }
    }
}