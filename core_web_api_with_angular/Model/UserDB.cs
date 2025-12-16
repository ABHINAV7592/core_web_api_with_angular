using System.Data;
using System.Data.SqlClient;

namespace core_web_api_with_angular.Model
{
    public class UserDB
    {
        public UserDB() 
        {
            SqlConnection con = new SqlConnection(@"server=LAPTOP-USLUAF59\SQLEXPRESS;database=core_angular;integrated security=true");
        }


    }
}
