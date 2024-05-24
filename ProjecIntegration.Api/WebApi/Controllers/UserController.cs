using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;
using Auth0.ManagementApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApplicationTheather.DTO;
using ApplicationAnnonce.DTO;
using MongoDB.Bson.IO;
using Newtonsoft.Json;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize("Admin")]
    public class UserController : ControllerBase
    {

        private readonly IManagementApiClient _managementApiClient;
        private readonly ICustomGetToken _tok;
        public UserController(IManagementApiClient managementApiClient,ICustomGetToken tok) 
        {
            _managementApiClient = managementApiClient;
            _tok= tok;  
        }

        [HttpGet]
        //[Authorize("Administrator")]
        public async Task<ActionResult> GetUserinfo()
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://dev-mhy3-faq.us.auth0.com/api/v2/users");
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Authorization", "Bearer eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6IjVLc0QzTmtoQXBsdE1GOU5URW9wXyJ9.eyJpc3MiOiJodHRwczovL2Rldi1taHkzLWZhcS51cy5hdXRoMC5jb20vIiwic3ViIjoibVBaS1NjdzY2UE5aTDZrY0tEUG5VdFppNHNuRjIydkZAY2xpZW50cyIsImF1ZCI6Imh0dHBzOi8vZGV2LW1oeTMtZmFxLnVzLmF1dGgwLmNvbS9hcGkvdjIvIiwiaWF0IjoxNzE2NDkwNTM0LCJleHAiOjE3MTY1NzY5MzQsInNjb3BlIjoicmVhZDpjb25uZWN0aW9ucyByZWFkOnJlc291cmNlX3NlcnZlcnMgdXBkYXRlOnJlc291cmNlX3NlcnZlcnMgZGVsZXRlOnJlc291cmNlX3NlcnZlcnMgcmVhZDpjbGllbnRzIGRlbGV0ZTpjbGllbnRzIHJlYWQ6dXNlcnMgcmVhZDpydWxlcyBjcmVhdGU6cnVsZXMgdXBkYXRlOnJ1bGVzX2NvbmZpZ3MgdXBkYXRlOnJ1bGVzIGRlbGV0ZTpydWxlcyIsImd0eSI6ImNsaWVudC1jcmVkZW50aWFscyIsImF6cCI6Im1QWktTY3c2NlBOWkw2a2NLRFBuVXRaaTRzbkYyMnZGIn0.OiKDnOlJVDTSFpNzvgmBP_SLsjRK8G61PDXpCXQfl1egfsRliwHaBGQcMQS-Zgr5hjb8V7DMOt4H_E3lAWYzjV9hzgABejVywnbNe-kaCTmOfIxAbqjVZ7fZaJ--5_5BEg_MxSRQlddUSeDCS2m1eptLp-3m6Yp6nSkE8T5rOAWPkZdNH53d5Kyt8f9kR3K174Ya2aizFLex4eIk5PPF3BFtHdKfyQyU-CHGL8zdhpXORvbYgioFfggw2tgiQAtkrgT2rEjS52Sj6aYKp-yjGxAEjeAkBwQK0SYDK47rYt3XPhHRIEsPllr5PvUaixSgwKSLqbVQZaRbRyCDMxxjrw");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var users =await response.Content.ReadAsStringAsync();
            var deserialize= Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Userdto>>(users);
            return Ok(deserialize);

        }
        [HttpGet("{userId}")]
        public async Task<ActionResult> GetUserById(string userId)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, $"https://dev-mhy3-faq.us.auth0.com/api/v2/users/{userId}");
                request.Headers.Add("Accept", "application/json");
                request.Headers.Add("Authorization", "Bearer eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6IjVLc0QzTmtoQXBsdE1GOU5URW9wXyJ9.eyJpc3MiOiJodHRwczovL2Rldi1taHkzLWZhcS51cy5hdXRoMC5jb20vIiwic3ViIjoibVBaS1NjdzY2UE5aTDZrY0tEUG5VdFppNHNuRjIydkZAY2xpZW50cyIsImF1ZCI6Imh0dHBzOi8vZGV2LW1oeTMtZmFxLnVzLmF1dGgwLmNvbS9hcGkvdjIvIiwiaWF0IjoxNzE2NDkwNTM0LCJleHAiOjE3MTY1NzY5MzQsInNjb3BlIjoicmVhZDpjb25uZWN0aW9ucyByZWFkOnJlc291cmNlX3NlcnZlcnMgdXBkYXRlOnJlc291cmNlX3NlcnZlcnMgZGVsZXRlOnJlc291cmNlX3NlcnZlcnMgcmVhZDpjbGllbnRzIGRlbGV0ZTpjbGllbnRzIHJlYWQ6dXNlcnMgcmVhZDpydWxlcyBjcmVhdGU6cnVsZXMgdXBkYXRlOnJ1bGVzX2NvbmZpZ3MgdXBkYXRlOnJ1bGVzIGRlbGV0ZTpydWxlcyIsImd0eSI6ImNsaWVudC1jcmVkZW50aWFscyIsImF6cCI6Im1QWktTY3c2NlBOWkw2a2NLRFBuVXRaaTRzbkYyMnZGIn0.OiKDnOlJVDTSFpNzvgmBP_SLsjRK8G61PDXpCXQfl1egfsRliwHaBGQcMQS-Zgr5hjb8V7DMOt4H_E3lAWYzjV9hzgABejVywnbNe-kaCTmOfIxAbqjVZ7fZaJ--5_5BEg_MxSRQlddUSeDCS2m1eptLp-3m6Yp6nSkE8T5rOAWPkZdNH53d5Kyt8f9kR3K174Ya2aizFLex4eIk5PPF3BFtHdKfyQyU-CHGL8zdhpXORvbYgioFfggw2tgiQAtkrgT2rEjS52Sj6aYKp-yjGxAEjeAkBwQK0SYDK47rYt3XPhHRIEsPllr5PvUaixSgwKSLqbVQZaRbRyCDMxxjrw");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var user =await response.Content.ReadAsStringAsync();
                var deserialize = Newtonsoft.Json.JsonConvert.DeserializeObject<Userdto>(user);
                return Ok(deserialize);

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost("create-user")]
        public async Task<ActionResult> CreateUserInfo([FromBody] Userdto createUser)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, "https://dev-mhy3-faq.us.auth0.com/api/v2/users");
                request.Headers.Add("Accept", "application/json");
                request.Headers.Add("Authorization", "Bearer eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6IjVLc0QzTmtoQXBsdE1GOU5URW9wXyJ9.eyJpc3MiOiJodHRwczovL2Rldi1taHkzLWZhcS51cy5hdXRoMC5jb20vIiwic3ViIjoibVBaS1NjdzY2UE5aTDZrY0tEUG5VdFppNHNuRjIydkZAY2xpZW50cyIsImF1ZCI6Imh0dHBzOi8vZGV2LW1oeTMtZmFxLnVzLmF1dGgwLmNvbS9hcGkvdjIvIiwiaWF0IjoxNzE2NDkwNTM0LCJleHAiOjE3MTY1NzY5MzQsInNjb3BlIjoicmVhZDpjb25uZWN0aW9ucyByZWFkOnJlc291cmNlX3NlcnZlcnMgdXBkYXRlOnJlc291cmNlX3NlcnZlcnMgZGVsZXRlOnJlc291cmNlX3NlcnZlcnMgcmVhZDpjbGllbnRzIGRlbGV0ZTpjbGllbnRzIHJlYWQ6dXNlcnMgcmVhZDpydWxlcyBjcmVhdGU6cnVsZXMgdXBkYXRlOnJ1bGVzX2NvbmZpZ3MgdXBkYXRlOnJ1bGVzIGRlbGV0ZTpydWxlcyIsImd0eSI6ImNsaWVudC1jcmVkZW50aWFscyIsImF6cCI6Im1QWktTY3c2NlBOWkw2a2NLRFBuVXRaaTRzbkYyMnZGIn0.OiKDnOlJVDTSFpNzvgmBP_SLsjRK8G61PDXpCXQfl1egfsRliwHaBGQcMQS-Zgr5hjb8V7DMOt4H_E3lAWYzjV9hzgABejVywnbNe-kaCTmOfIxAbqjVZ7fZaJ--5_5BEg_MxSRQlddUSeDCS2m1eptLp-3m6Yp6nSkE8T5rOAWPkZdNH53d5Kyt8f9kR3K174Ya2aizFLex4eIk5PPF3BFtHdKfyQyU-CHGL8zdhpXORvbYgioFfggw2tgiQAtkrgT2rEjS52Sj6aYKp-yjGxAEjeAkBwQK0SYDK47rYt3XPhHRIEsPllr5PvUaixSgwKSLqbVQZaRbRyCDMxxjrw");
                string data=Newtonsoft.Json.JsonConvert.SerializeObject(createUser);
                var content = new StringContent(data, null, "application/json");                
                request.Content = content;
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                await response.Content.ReadAsStringAsync();



                return Ok();

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut("update-user/{userId}")]
        public async Task<ActionResult> UpdateUserInfo(int userId,[FromBody] UserUpdateRequest updateUser)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Patch, $"https://dev-mhy3-faq.us.auth0.com/api/v2/users/{userId}");
                request.Headers.Add("Accept", "application/json");
                request.Headers.Add("Authorization", "Bearer eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6IjVLc0QzTmtoQXBsdE1GOU5URW9wXyJ9.eyJpc3MiOiJodHRwczovL2Rldi1taHkzLWZhcS51cy5hdXRoMC5jb20vIiwic3ViIjoibVBaS1NjdzY2UE5aTDZrY0tEUG5VdFppNHNuRjIydkZAY2xpZW50cyIsImF1ZCI6Imh0dHBzOi8vZGV2LW1oeTMtZmFxLnVzLmF1dGgwLmNvbS9hcGkvdjIvIiwiaWF0IjoxNzE2NDkwNTM0LCJleHAiOjE3MTY1NzY5MzQsInNjb3BlIjoicmVhZDpjb25uZWN0aW9ucyByZWFkOnJlc291cmNlX3NlcnZlcnMgdXBkYXRlOnJlc291cmNlX3NlcnZlcnMgZGVsZXRlOnJlc291cmNlX3NlcnZlcnMgcmVhZDpjbGllbnRzIGRlbGV0ZTpjbGllbnRzIHJlYWQ6dXNlcnMgcmVhZDpydWxlcyBjcmVhdGU6cnVsZXMgdXBkYXRlOnJ1bGVzX2NvbmZpZ3MgdXBkYXRlOnJ1bGVzIGRlbGV0ZTpydWxlcyIsImd0eSI6ImNsaWVudC1jcmVkZW50aWFscyIsImF6cCI6Im1QWktTY3c2NlBOWkw2a2NLRFBuVXRaaTRzbkYyMnZGIn0.OiKDnOlJVDTSFpNzvgmBP_SLsjRK8G61PDXpCXQfl1egfsRliwHaBGQcMQS-Zgr5hjb8V7DMOt4H_E3lAWYzjV9hzgABejVywnbNe-kaCTmOfIxAbqjVZ7fZaJ--5_5BEg_MxSRQlddUSeDCS2m1eptLp-3m6Yp6nSkE8T5rOAWPkZdNH53d5Kyt8f9kR3K174Ya2aizFLex4eIk5PPF3BFtHdKfyQyU-CHGL8zdhpXORvbYgioFfggw2tgiQAtkrgT2rEjS52Sj6aYKp-yjGxAEjeAkBwQK0SYDK47rYt3XPhHRIEsPllr5PvUaixSgwKSLqbVQZaRbRyCDMxxjrw");
                string data = Newtonsoft.Json.JsonConvert.SerializeObject(updateUser);
                var content = new StringContent(data, null, "application/json");
                request.Content = content;
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                Console.WriteLine(await response.Content.ReadAsStringAsync());

                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }

          
        }
        [HttpDelete("delete-user/{userId}")]
        public async Task<ActionResult> DeleteUser(string userId)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Delete, $"https://dev-mhy3-faq.us.auth0.com/api/v2/users/{userId}");
                request.Headers.Add("Authorization", "Bearer eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6IjVLc0QzTmtoQXBsdE1GOU5URW9wXyJ9.eyJpc3MiOiJodHRwczovL2Rldi1taHkzLWZhcS51cy5hdXRoMC5jb20vIiwic3ViIjoibVBaS1NjdzY2UE5aTDZrY0tEUG5VdFppNHNuRjIydkZAY2xpZW50cyIsImF1ZCI6Imh0dHBzOi8vZGV2LW1oeTMtZmFxLnVzLmF1dGgwLmNvbS9hcGkvdjIvIiwiaWF0IjoxNzE2NDkwNTM0LCJleHAiOjE3MTY1NzY5MzQsInNjb3BlIjoicmVhZDpjb25uZWN0aW9ucyByZWFkOnJlc291cmNlX3NlcnZlcnMgdXBkYXRlOnJlc291cmNlX3NlcnZlcnMgZGVsZXRlOnJlc291cmNlX3NlcnZlcnMgcmVhZDpjbGllbnRzIGRlbGV0ZTpjbGllbnRzIHJlYWQ6dXNlcnMgcmVhZDpydWxlcyBjcmVhdGU6cnVsZXMgdXBkYXRlOnJ1bGVzX2NvbmZpZ3MgdXBkYXRlOnJ1bGVzIGRlbGV0ZTpydWxlcyIsImd0eSI6ImNsaWVudC1jcmVkZW50aWFscyIsImF6cCI6Im1QWktTY3c2NlBOWkw2a2NLRFBuVXRaaTRzbkYyMnZGIn0.OiKDnOlJVDTSFpNzvgmBP_SLsjRK8G61PDXpCXQfl1egfsRliwHaBGQcMQS-Zgr5hjb8V7DMOt4H_E3lAWYzjV9hzgABejVywnbNe-kaCTmOfIxAbqjVZ7fZaJ--5_5BEg_MxSRQlddUSeDCS2m1eptLp-3m6Yp6nSkE8T5rOAWPkZdNH53d5Kyt8f9kR3K174Ya2aizFLex4eIk5PPF3BFtHdKfyQyU-CHGL8zdhpXORvbYgioFfggw2tgiQAtkrgT2rEjS52Sj6aYKp-yjGxAEjeAkBwQK0SYDK47rYt3XPhHRIEsPllr5PvUaixSgwKSLqbVQZaRbRyCDMxxjrw");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                Console.WriteLine(await response.Content.ReadAsStringAsync());

                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
