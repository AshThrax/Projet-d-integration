using ApplicationAnnonce.DTO;
using ApplicationTheather.Common.Interfaces.IRepository;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace InfraPublication.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        
        public async Task DeleteUser(string userId)
        {
            try
            {
                

                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Delete, $"https://dev-mhy3-faq.us.auth0.com/api/v2/users/{userId}");
                request.Headers.Add("Authorization", "Bearer eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6IjVLc0QzTmtoQXBsdE1GOU5URW9wXyJ9.eyJpc3MiOiJodHRwczovL2Rldi1taHkzLWZhcS51cy5hdXRoMC5jb20vIiwic3ViIjoibVBaS1NjdzY2UE5aTDZrY0tEUG5VdFppNHNuRjIydkZAY2xpZW50cyIsImF1ZCI6Imh0dHBzOi8vZGV2LW1oeTMtZmFxLnVzLmF1dGgwLmNvbS9hcGkvdjIvIiwiaWF0IjoxNzE2NDkwNTM0LCJleHAiOjE3MTY1NzY5MzQsInNjb3BlIjoicmVhZDpjb25uZWN0aW9ucyByZWFkOnJlc291cmNlX3NlcnZlcnMgdXBkYXRlOnJlc291cmNlX3NlcnZlcnMgZGVsZXRlOnJlc291cmNlX3NlcnZlcnMgcmVhZDpjbGllbnRzIGRlbGV0ZTpjbGllbnRzIHJlYWQ6dXNlcnMgcmVhZDpydWxlcyBjcmVhdGU6cnVsZXMgdXBkYXRlOnJ1bGVzX2NvbmZpZ3MgdXBkYXRlOnJ1bGVzIGRlbGV0ZTpydWxlcyIsImd0eSI6ImNsaWVudC1jcmVkZW50aWFscyIsImF6cCI6Im1QWktTY3c2NlBOWkw2a2NLRFBuVXRaaTRzbkYyMnZGIn0.OiKDnOlJVDTSFpNzvgmBP_SLsjRK8G61PDXpCXQfl1egfsRliwHaBGQcMQS-Zgr5hjb8V7DMOt4H_E3lAWYzjV9hzgABejVywnbNe-kaCTmOfIxAbqjVZ7fZaJ--5_5BEg_MxSRQlddUSeDCS2m1eptLp-3m6Yp6nSkE8T5rOAWPkZdNH53d5Kyt8f9kR3K174Ya2aizFLex4eIk5PPF3BFtHdKfyQyU-CHGL8zdhpXORvbYgioFfggw2tgiQAtkrgT2rEjS52Sj6aYKp-yjGxAEjeAkBwQK0SYDK47rYt3XPhHRIEsPllr5PvUaixSgwKSLqbVQZaRbRyCDMxxjrw");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<UserDto> GetUserById(string Id)
        {
            try
            {
               

                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, $"https://dev-mhy3-faq.us.auth0.com/api/v2/users/{Id}");
                request.Headers.Add("Accept", "application/json");
                request.Headers.Add("Authorization", $"Bearer eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6IjVLc0QzTmtoQXBsdE1GOU5URW9wXyJ9.eyJpc3MiOiJodHRwczovL2Rldi1taHkzLWZhcS51cy5hdXRoMC5jb20vIiwic3ViIjoienJQQVFRa3JyNm8ybGlaTnFPWGUxQzkzNmtmQUJQTHdAY2xpZW50cyIsImF1ZCI6Imh0dHBzOi8vaGVsbG8td29ybGQuZXhhbXBsZS5jb20iLCJpYXQiOjE3MTc1MzM3MjksImV4cCI6MTcxNzYyMDEyOSwiZ3R5IjoiY2xpZW50LWNyZWRlbnRpYWxzIiwiYXpwIjoienJQQVFRa3JyNm8ybGlaTnFPWGUxQzkzNmtmQUJQTHciLCJwZXJtaXNzaW9ucyI6W119.m4AsD9MI9Jjq_WK62bpTET_hN2d1CDyvduwFCE3Rgu1j_t0be0JwDgygvFkenW-7bZbHDAnQ1nDP6AVCbt5jHF_9nek4BhHJlcPYWgUWqY3yRlspE6y85dnlocx3DHa2F9UY-8IxaJ0cFS8yFOzn9DKOD-YBrMNLE9gi1_ORt0NCmB2w2aanhjer5ahZ77WrCJQlWmQRXDYH_KkR0hJ9T-rEVvMvIpnNuL5ErOPeR1RJ9w4jxINSupyaryb3UoCvs2Qqj3HEYjHt1k5FMF7ySSDAKzitq_tJWxzfT5617iTAKC2d2r5RdQ5gAbh_6gy1K0lWOy9oxU93x9XX0qx5eA");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var user = await response.Content.ReadAsStringAsync();
                var deserialize = Newtonsoft.Json.JsonConvert.DeserializeObject<UserDto>(user);
                return deserialize;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://dev-mhy3-faq.us.auth0.com/api/v2/users");
                request.Headers.Add("Accept", "application/json");
                request.Headers.Add("Authorization", "Bearer eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6IjVLc0QzTmtoQXBsdE1GOU5URW9wXyJ9.eyJpc3MiOiJodHRwczovL2Rldi1taHkzLWZhcS51cy5hdXRoMC5jb20vIiwic3ViIjoibVBaS1NjdzY2UE5aTDZrY0tEUG5VdFppNHNuRjIydkZAY2xpZW50cyIsImF1ZCI6Imh0dHBzOi8vZGV2LW1oeTMtZmFxLnVzLmF1dGgwLmNvbS9hcGkvdjIvIiwiaWF0IjoxNzE2NDkwNTM0LCJleHAiOjE3MTY1NzY5MzQsInNjb3BlIjoicmVhZDpjb25uZWN0aW9ucyByZWFkOnJlc291cmNlX3NlcnZlcnMgdXBkYXRlOnJlc291cmNlX3NlcnZlcnMgZGVsZXRlOnJlc291cmNlX3NlcnZlcnMgcmVhZDpjbGllbnRzIGRlbGV0ZTpjbGllbnRzIHJlYWQ6dXNlcnMgcmVhZDpydWxlcyBjcmVhdGU6cnVsZXMgdXBkYXRlOnJ1bGVzX2NvbmZpZ3MgdXBkYXRlOnJ1bGVzIGRlbGV0ZTpydWxlcyIsImd0eSI6ImNsaWVudC1jcmVkZW50aWFscyIsImF6cCI6Im1QWktTY3c2NlBOWkw2a2NLRFBuVXRaaTRzbkYyMnZGIn0.OiKDnOlJVDTSFpNzvgmBP_SLsjRK8G61PDXpCXQfl1egfsRliwHaBGQcMQS-Zgr5hjb8V7DMOt4H_E3lAWYzjV9hzgABejVywnbNe-kaCTmOfIxAbqjVZ7fZaJ--5_5BEg_MxSRQlddUSeDCS2m1eptLp-3m6Yp6nSkE8T5rOAWPkZdNH53d5Kyt8f9kR3K174Ya2aizFLex4eIk5PPF3BFtHdKfyQyU-CHGL8zdhpXORvbYgioFfggw2tgiQAtkrgT2rEjS52Sj6aYKp-yjGxAEjeAkBwQK0SYDK47rYt3XPhHRIEsPllr5PvUaixSgwKSLqbVQZaRbRyCDMxxjrw");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var users = await response.Content.ReadAsStringAsync();
                var deserialize = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<UserDto>>(users);
                return deserialize;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task Update(string userId, UserDto user)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Patch, $"https://dev-mhy3-faq.us.auth0.com/api/v2/users/{userId}");
                request.Headers.Add("Accept", "application/json");
                request.Headers.Add("Authorization", "Bearer eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6IjVLc0QzTmtoQXBsdE1GOU5URW9wXyJ9.eyJpc3MiOiJodHRwczovL2Rldi1taHkzLWZhcS51cy5hdXRoMC5jb20vIiwic3ViIjoibVBaS1NjdzY2UE5aTDZrY0tEUG5VdFppNHNuRjIydkZAY2xpZW50cyIsImF1ZCI6Imh0dHBzOi8vZGV2LW1oeTMtZmFxLnVzLmF1dGgwLmNvbS9hcGkvdjIvIiwiaWF0IjoxNzE2NDkwNTM0LCJleHAiOjE3MTY1NzY5MzQsInNjb3BlIjoicmVhZDpjb25uZWN0aW9ucyByZWFkOnJlc291cmNlX3NlcnZlcnMgdXBkYXRlOnJlc291cmNlX3NlcnZlcnMgZGVsZXRlOnJlc291cmNlX3NlcnZlcnMgcmVhZDpjbGllbnRzIGRlbGV0ZTpjbGllbnRzIHJlYWQ6dXNlcnMgcmVhZDpydWxlcyBjcmVhdGU6cnVsZXMgdXBkYXRlOnJ1bGVzX2NvbmZpZ3MgdXBkYXRlOnJ1bGVzIGRlbGV0ZTpydWxlcyIsImd0eSI6ImNsaWVudC1jcmVkZW50aWFscyIsImF6cCI6Im1QWktTY3c2NlBOWkw2a2NLRFBuVXRaaTRzbkYyMnZGIn0.OiKDnOlJVDTSFpNzvgmBP_SLsjRK8G61PDXpCXQfl1egfsRliwHaBGQcMQS-Zgr5hjb8V7DMOt4H_E3lAWYzjV9hzgABejVywnbNe-kaCTmOfIxAbqjVZ7fZaJ--5_5BEg_MxSRQlddUSeDCS2m1eptLp-3m6Yp6nSkE8T5rOAWPkZdNH53d5Kyt8f9kR3K174Ya2aizFLex4eIk5PPF3BFtHdKfyQyU-CHGL8zdhpXORvbYgioFfggw2tgiQAtkrgT2rEjS52Sj6aYKp-yjGxAEjeAkBwQK0SYDK47rYt3XPhHRIEsPllr5PvUaixSgwKSLqbVQZaRbRyCDMxxjrw");
                string data = Newtonsoft.Json.JsonConvert.SerializeObject(user);
                var content = new StringContent(data, null, "application/json");
                request.Content = content;
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                Console.WriteLine(await response.Content.ReadAsStringAsync());  
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
