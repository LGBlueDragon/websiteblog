using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Model
{
    public class Blog
    {
        private int idblog;
        private int iduser;
        private DateTime time;
        private string content;
        private int reference;

        public Blog(int iduser, DateTime time, string content, int reference)
        {
            this.iduser = iduser;
            this.time = time;
            this.content = content;
            this.reference = reference;
        }
    }
}