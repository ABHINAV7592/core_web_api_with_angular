using System.Data;
using System.Data.SqlClient;

namespace core_web_api_with_angular.Model
{
    public class UserDB
    {
        SqlConnection con = new SqlConnection(@"server=LAPTOP-USLUAF59\SQLEXPRESS;database=core_angular;integrated security=true");

        public string insertdb(User clsobj)
        {
            SqlCommand cmd = new SqlCommand("sp_insert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@na", clsobj.name);
            cmd.Parameters.AddWithValue("@ag", clsobj.age);
            cmd.Parameters.AddWithValue("@addr", clsobj.address);
            cmd.Parameters.AddWithValue("@email", clsobj.email);
            cmd.Parameters.AddWithValue("@photo", clsobj.photo);
            cmd.Parameters.AddWithValue("@una", clsobj.username);
            cmd.Parameters.AddWithValue("@pw", clsobj.password);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return ("Inserted Successfully");
        }


    }
}
