using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApplicationUser.Dto.User
{
    public class UserDto
    {
        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;
        [JsonPropertyName("phone_number")]
        public string Phone_number { get; set; }
        [JsonPropertyName("user_metadata")]
        public dynamic UserMetadata { get; set; }
        [JsonPropertyName("blocked")]
        public bool Blocked { get; set; }
        [JsonPropertyName("email_verified")]
        public bool EmailVerified { get; set; }
        [JsonPropertyName("phone_verified")]
        public bool PhoneVerified { get; set; }
        [JsonPropertyName("app_metadata")]
        public dynamic App_metadata { get; set; }
        [JsonPropertyName("given_name")]
        public string? GivenName { get; set; }
        [JsonPropertyName("family_name")]
        public string FamilyName { get; set; } = string.Empty;
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("nickname")]
        public string NickName { get; set; } = string.Empty;
        [JsonPropertyName("picture")]
        public string Picture { get; set; } = string.Empty;
        [JsonPropertyName("user_id")]
        public string User_id { get; set; } = string.Empty;
        [JsonPropertyName("connection")]
        public string Connection { get; set; } = string.Empty;
        [JsonPropertyName("password")]
        public string Password { get; set; } = string.Empty;
        [JsonPropertyName("verify_email")]
        public bool VerifyMail { get; set; }
        [JsonPropertyName("username")]
        public string UserName { get; set; } = string.Empty;
    }
}
