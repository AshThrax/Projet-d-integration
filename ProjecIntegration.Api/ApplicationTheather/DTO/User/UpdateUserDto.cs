using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApplicationUser.Dto.User
{
    public class UpdateUserDto
    {
        public dynamic? UserMetadata { get; set; }
        [JsonPropertyName("blocked")]
        public dynamic? App_metadata { get; set; }
        [JsonPropertyName("given_name")]
        public string? GivenName { get; set; }
        [JsonPropertyName("family_name")]
        public string FamilyName { get; set; } = string.Empty;
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("nickname")]
        public string NickName { get; set; } = string.Empty;
     
        [JsonPropertyName("username")]
        public string UserName { get; set; } = string.Empty;
    }
}
