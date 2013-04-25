using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Text;

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

            if (!Save())
            {
                throw new DataException("<b>ERROR: COULD NOT CREATE ENTRY!</b>");
            }
        }

        public bool Save()
        {
            string cstring = Settings.ConnectionString;
            using (OdbcConnection connection = new OdbcConnection(cstring))
            {
                connection.Open();

                string insertcmd = "INSERT INTO " +
                                   Settings.BlogTableName +
                                   "(iduser,time,content,ref) " +
                                   "VALUES(?,?,?,?)";
                OdbcCommand cmd = new OdbcCommand(insertcmd, connection);

                cmd.Parameters.Add("@p1", OdbcType.Int).Value = this.iduser;
                cmd.Parameters.Add("@p2", OdbcType.DateTime).Value = this.time;
                cmd.Parameters.Add("@p3", OdbcType.NVarChar, 5000).Value = this.content;
                cmd.Parameters.Add("@p4", OdbcType.TinyInt).Value = this.reference;

                if (cmd.ExecuteNonQuery() == 1)
                {
                    connection.Close();
                    return true;
                }
                else
                {
                    connection.Close();
                    return false;
                }

            }
        }

        public bool Delete()
        {
            string cstring = Settings.ConnectionString;
            using (OdbcConnection connection = new OdbcConnection(cstring))
            {
                connection.Open();

                string insertcmd = "DELETE FROM " +
                                   Settings.BlogTableName +
                                   " WHERE idblog = ?";
                OdbcCommand cmd = new OdbcCommand(insertcmd, connection);

                cmd.Parameters.AddWithValue("@username", this.idblog);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    connection.Close();
                    return true;
                }
                else
                {
                    connection.Close();
                    return false;
                }

            }
        }
    }
}