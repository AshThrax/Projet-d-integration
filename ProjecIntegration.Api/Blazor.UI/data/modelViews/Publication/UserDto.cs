using System.Text.Json.Serialization;

namespace Blazor.UI.Data.ModelViews.Publication
{ 
    public class UserDto
    {
        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;
        [JsonPropertyName("phone_number")]
        public string Phone_number { get; set; } = string.Empty;
        [JsonPropertyName("user_metadata")]
        public dynamic? UserMetadata { get; set; }
        [JsonPropertyName("blocked")]
        public bool Blocked { get; set; }
        [JsonPropertyName("email_verified")]
        public bool EmailVerified { get; set; }
        [JsonPropertyName("phone_verified")]
        public bool PhoneVerified { get; set; }
        [JsonPropertyName("app_metadata")]
        public dynamic? App_metadata { get; set; }
        [JsonPropertyName("given_name")]
        public string? GivenName { get; set; }
        [JsonPropertyName("family_name")]
        public string FamilyName { get; set; }=  string.Empty;
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("nickname")]
        public string NickName { get; set; } = string.Empty;
        [JsonPropertyName("picture")]
        public string Picture { get; set; } = string.Empty;
        [JsonPropertyName("user_id")]
        public string User_id { get; set; } = string.Empty;

        [JsonPropertyName("verify_email")]
        public bool VerifyMail { get; set; } = false;
        [JsonPropertyName("username")]
        public string UserName { get; set; } = string.Empty;
    }
 
}