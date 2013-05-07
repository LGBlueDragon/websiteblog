using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Text;
using MySql.Data.MySqlClient;

namespace MyBlog.Model
{
    public partial class Blog
    {
        private int idblog;
        private int iduser;
        private DateTime time;
        private string title;
        private string content;
        private int reference;
        
        public Blog(int idblog, int iduser, DateTime time, string title, string content, int reference)
        {
            this.idblog = idblog;
            this.iduser = iduser;
            this.time = time;
            this.title = title;
            this.content = content;
            this.reference = reference;
        }

        public Blog(int iduser, DateTime time, string title, string content, int reference, bool save)
        {
            this.iduser = iduser;
            this.time = time;
            this.title = title;
            this.content = content;
            this.reference = reference;

            if (save)
            {
                if (Save() == 0)
                {
                    throw new DataException("<b>ERROR: COULD NOT CREATE ENTRY!</b>");
                }
            }
        }

        public int Save()
        {
            string cstring = Settings.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(cstring))
            {
                connection.Open();

                string insertcmd = "INSERT INTO " +
                                   Settings.BlogTableName +
                                   "(iduser,time,title,content,ref) " +
                                   "VALUES(?,?,?,?,?)";
                MySqlCommand cmd = new MySqlCommand(insertcmd, connection);

                cmd.Parameters.Add("@p1", MySqlDbType.Int32).Value = this.iduser;
                cmd.Parameters.Add("@p2", MySqlDbType.DateTime).Value = this.time;
                cmd.Parameters.Add("@p3", MySqlDbType.String).Value = this.title;
                cmd.Parameters.Add("@p4", MySqlDbType.String, 5000).Value = this.content;
                cmd.Parameters.Add("@p5", MySqlDbType.Int16).Value = this.reference;

                if (cmd.ExecuteNonQuery() == 1)
                {
                    connection.Close();
                    this.idblog = GetPostID();
                    return this.idblog;
                }
                else
                {
                    connection.Close();
                    return 0;
                }
            }
        }

        public bool Delete()
        {
            string cstring = Settings.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(cstring))
            {
                connection.Open();

                string insertcmd = "DELETE FROM " +
                                   Settings.BlogTableName +
                                   " WHERE idblog = ?";
                MySqlCommand cmd = new MySqlCommand(insertcmd, connection);

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

        private int GetPostID()
        {
            int ourpostid;
            string cstring = Settings.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(cstring))
            {
                connection.Open();

                string insertcmd = "SELECT idblog FROM " +
                                    Settings.BlogTableName +
                                    " WHERE iduser = @p1 AND title = @p2";
                MySqlCommand cmd = new MySqlCommand(insertcmd, connection);

                cmd.Parameters.Add("@p1", MySqlDbType.Int32).Value = this.iduser;
                cmd.Parameters.Add("@p2", MySqlDbType.String).Value = this.title;

                MySqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                ourpostid = (int)dr["idblog"];

                connection.Close();

                return ourpostid;
            }
        }

        public static List<Blog> GetAll()
        {
            string cstring = Settings.ConnectionString;
            List<Blog> bl = new List<Blog>();
            using (MySqlConnection connection = new MySqlConnection(cstring))
            {
                connection.Open();

                string insertcmd = "SELECT * FROM " + Settings.BlogTableName + " ORDER BY time DESC";
                MySqlCommand cmd = new MySqlCommand(insertcmd, connection);

                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int idblog = (int)dr["idblog"];
                    int iduser = (int)dr["iduser"];
                    DateTime time = (DateTime)dr["time"];
                    string title = (string)dr["title"];
                    string content = (string)dr["content"];
                    int reference = (int)dr["ref"];

                    Blog tmp = new Blog(idblog, iduser, time, title, content, reference);
                    bl.Add(tmp);
                }
                connection.Close();

                return bl;
            }
        }

        public List<Blog> Comments()
        {
            List<Blog> comlist = new List<Blog>();
            string cstring = Settings.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(cstring))
            {
                connection.Open();

                string insertcmd = "SELECT * FROM " +
                                    Settings.BlogTableName +
                                    " WHERE ref = @p1";
                MySqlCommand cmd = new MySqlCommand(insertcmd, connection);

                cmd.Parameters.Add("@p1", MySqlDbType.Int16).Value = this.idblog;

                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int idblog = (int)dr["idblog"];
                    int iduser = (int)dr["iduser"];
                    DateTime time = (DateTime)dr["time"];
                    string title = (string)dr["title"];
                    string content = (string)dr["content"];
                    int reference = (int)dr["ref"];

                    Blog tmp2 = new Blog(idblog, iduser, time, title, content, reference);
                    comlist.Add(tmp2);
                }

                connection.Close();

                return comlist;
            }
        }

        public int NumComments()
        {
            int numcomments = Comments().Count();
            return numcomments;
        }
    }
}