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

           if (!Save())
           {
               throw new DataException("<b>ERROR: COULD NOT CREATE ENTRY!</b>");
           }

           this.iduser = GetUserID();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("User ID: ");
            sb.AppendLine(Convert.ToString(this.iduser));
            sb.Append("Username: ");
            sb.AppendLine(this.username);
            sb.Append("Password: ");
            sb.AppendLine(this.password);
            sb.Append("Email: ");
            sb.AppendLine(this.email);
            sb.Append("Usergroup: ");
            sb.AppendLine(Convert.ToString(this.usergroup));
            return sb.ToString();
        }

        public bool Save()
        {
            string cstring = Settings.ConnectionString;
            using(OdbcConnection connection = new OdbcConnection(cstring))
            {
                connection.Open();

                string insertcmd = "INSERT INTO " + 
                                   Settings.UserTableName + 
                                   "(username,password,email,usergroup) " + 
                                   "VALUES(?,?,?,?)";
                OdbcCommand cmd = new OdbcCommand(insertcmd, connection);

                cmd.Parameters.Add("@p1", OdbcType.NVarChar, 50).Value = this.username;
                cmd.Parameters.Add("@p2", OdbcType.NVarChar, 50).Value = this.password;
                cmd.Parameters.Add("@p3", OdbcType.NVarChar, 50).Value = this.email;
                cmd.Parameters.Add("@p4", OdbcType.TinyInt).Value = this.usergroup;

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
                                   Settings.UserTableName +
                                   " WHERE username = ?";
                OdbcCommand cmd = new OdbcCommand(insertcmd, connection);

                cmd.Parameters.AddWithValue("@username", this.username);

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


        private int GetUserID()
        {
            int ouruserid;
            string cstring = Settings.ConnectionString;
            using (OdbcConnection connection = new OdbcConnection(cstring))
            {
                connection.Open();
                string selectcmd = "SELECT iduser FROM " +
                                   Settings.UserTableName +
                                   " WHERE username = ?";

                OdbcCommand cmd = new OdbcCommand(selectcmd, connection);
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