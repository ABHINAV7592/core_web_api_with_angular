using Microsoft.AspNetCore.Mvc;
using core_web_api_with_angular.Model;
using Microsoft.AspNetCore.Identity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace core_web_api_with_angular.Controllers
{
    [Route("user_management")]
    [ApiController]
    public class user_managementController : ControllerBase
    {
        private readonly string _uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
        public user_managementController()
        {
            if (!Directory.Exists(_uploadDir))
            {
                Directory.CreateDirectory(_uploadDir);
            }
        }
        UserDB dbobj=new UserDB();
        // GET: api/<user_management>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<user_management>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<user_management>
        [HttpPost]
        [Route("inserttab")]
        public async Task<IActionResult> Post([FromForm] usercreateDTO createdto)
        {
            User usercls = new User();
            if(createdto.path==null || createdto.path.Length == 0)
            {
                return BadRequest("No File Uploaded");
            }
            if (!createdto.path.ContentType.StartsWith("image/"))
            {
                return BadRequest("only Image Files Are Allowed");
            }
            var filepath = Path.Combine(_uploadDir, createdto.path.FileName);
            using(var stream =new FileStream(filepath, FileMode.Create))
            {
                await createdto.path.CopyToAsync(stream);
            }
            usercls.name = createdto.name;
            usercls.age= createdto.age;
            usercls.address = createdto.address;
            usercls.email = createdto.email;
            usercls.photo = createdto.path.FileName;
            usercls.username = createdto.username;
            usercls.password = createdto.password;
            dbobj.insertdb(usercls);
            return await Task.Run(() => Ok(new { message = "Registered Successfully" }));
        }
        [HttpPost]
        [Route("logintab")]
        public async Task<IActionResult> postlogin([FromBody]loginDTO createdto)
        {
            User usercls = new User();
            usercls.username = createdto.username;
            usercls.password = createdto.password;
            string cid = dbobj.logindb(usercls);
            if (cid == "1")
            {
                return await Task.Run(() => Ok(new { message = "Success" }));
            }
            else
            {
                return await Task.Run(() => Ok(new { message = "Invalid Login" }));
            }
        }

        // PUT api/<user_management>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<user_management>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
