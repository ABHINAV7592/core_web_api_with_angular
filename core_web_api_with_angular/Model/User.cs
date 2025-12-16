namespace core_web_api_with_angular.Model
{
    public class User
    {
        public int user_id { get; set; }
        public string? name { get; set; }
        public int age { get; set; }
        public string? address { get; set; }
        public string? email { get; set; }
        public string? photo { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
    }
    public class usercreateDTO
    {
        public string? name { get; set; }
        public int age { get; set; }
        public string? address { get; set; }
        public string? email { get; set; }
        public IFormFile? path { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
    }
    public class loginDTO
    {
        public string? username { get; set; }
        public string? password { get; set; }
    }
}
