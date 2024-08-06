using Microsoft.AspNetCore.Mvc;

using web_api_curd.BAL;
using web_api_curd.Model;

namespace web_api_curd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpDelete]
        public IActionResult Delete(int parsonID)
        {
            User_BALBase balUser = new User_BALBase();
            bool IsSuccess = balUser.API_User_Delete(parsonID);

            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                response.Add("status", true);
                response.Add("msg", "successfully deleted");
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("msg", "data fail to deleted");    
                return Ok(response);
            }
        }

        [HttpPost]
        public IActionResult PersonInsert([FromBody] PersonModel person)
        {
            User_BALBase balUser = new User_BALBase();
            bool IsSuccess = balUser.API_User_Insert(person);

            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                response.Add("status", true);
                response.Add("msg", "successfully insert");
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("msg", "data fail to insert");
                return Ok(response);
            }
        }

        [HttpGet]
        public IActionResult PersonSelectById(int parsonID)
        {
            User_BALBase balUser = new User_BALBase();
            PersonModel person = balUser.API_User_SelectById(parsonID);

            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if(person != null)
            {
                response.Add("status", true);
                response.Add("msg", "data GET Successfully");
                response.Add("data", person);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("msg", "data fail to GET");
                response.Add("data", null);
                return Ok(response);
            }
            
            }
        [HttpGet]
        public IActionResult PersonSelectAll()
        {
            User_BALBase balUser = new User_BALBase();
            List<PersonModel> personList = balUser.API_User_SelectALL();

            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if(personList != null)
            {
                response.Add("status", true);
                response.Add("msg", "data GET Successfully");
                response.Add("data", personList);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("msg", "data fail to GET");
                response.Add("data", null);
                return Ok(response);
            }
            
            }
        
        [HttpPut]
        public IActionResult PersonUpdate(int personID,[FromBody] PersonModel person)
        {
            User_BALBase balUser = new User_BALBase();
            bool IsSuccess = balUser.API_User_Update(personID, person);

            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                response.Add("status", true);
                response.Add("msg", "successfully update");
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("msg", "data fail to update");
                return Ok(response);
            }
        }
    }
}
