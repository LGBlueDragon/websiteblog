using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.Odbc;

namespace MyBlog.Model
{
    public class User
    {
        private int iduser;
        private string username;
        private string password;
        private string email;
        private int usergroup;

        public User(string username, string password, string email, int usergroup)
        {
            this.username = username;
            this.password = password;
            this.email = email;
            this.usergroup = usergroup;

           /* if (!Save())
            {
                throw new DataException("<b>ERROR: COULD NOT CREATE ENTRY!</b>");
            }*/

            this.iduser = GetUserID();
        }

        public bool Save()
        {
            string cstring = ConfigurationManager.ConnectionStrings["local"].ConnectionString;
            using(OdbcConnection connection = new OdbcConnection(cstring))
            {
                connection.Open();

                string insertcmd = "INSERT INTO website.user(username,password,email,usergroup)" + " " +
                                   "VALUES(@username,@password,@email,@usergroup)";
                OdbcCommand cmd = new OdbcCommand(insertcmd, connection);
                
                cmd.Parameters.AddWithValue("@username", this.username);
                cmd.Parameters.AddWithValue("@password", this.password);
                cmd.Parameters.AddWithValue("@email", this.email);
                cmd.Parameters.AddWithValue("@usergroup", this.usergroup);


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
            string cstring = ConfigurationManager.ConnectionStrings["local"].ConnectionString;
            using (OdbcConnection connection = new OdbcConnection(cstring))
            {
                connection.Open();

                string insertcmd = "DELETE FROM website.user WHERE username = @username";
                OdbcCommand cmd = new OdbcCommand(insertcmd, connection);

                cmd.Parameters.AddWithValue("@username", this.username);

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

        private int GetUserID()
        {
            int ouruserid;
            string cstring = ConfigurationManager.ConnectionStrings["local"].ConnectionString;
            using (OdbcConnection connection = new OdbcConnection(cstring))
            {
                connection.Open();
                string insertcmd = "SELECT iduser FROM website.user WHERE username = @username";
                OdbcCommand cmd = new OdbcCommand(insertcmd, connection);
                cmd.Parameters.AddWithValue("@username", this.username);
                OdbcDataReader dr = cmd.ExecuteReader();
                dr.Read();
                ouruserid = (int)dr["iduser"];
                connection.Close();
            }
            return ouruserid;
        }
    }
}