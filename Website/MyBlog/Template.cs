using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;

namespace MyBlog
{
    public class Template
    {
        private List<string> lines = new List<string>();
        public Template(string filename)
        {
            using (StreamReader sr = new StreamReader(Settings.TemplateFolderDefault + filename))
            {
                while (!sr.EndOfStream)
                {
                    this.lines.Add(sr.ReadLine());
                }
            }
        }

        public string Render(Dictionary<string, string> values)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string line in this.lines)
            {
                string tmpline = line;
                foreach (string kay in values.Keys)
                {
                    tmpline = tmpline.Replace("{"+kay+"}", values[kay]);
                }
                sb.AppendLine(tmpline);
            }

            return sb.ToString();
        }
    }
}