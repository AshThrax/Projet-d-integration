using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entity.publicationEntity
{
    public class User
    {
            [JsonPropertyName("email")]
            public string Email { get; set; } = string.Empty;
            [JsonPropertyName("given_name")]
            public string? GivenName { get; set; }
            [JsonPropertyName("family_name")]
            public string FamilyName { get; set; } = string.Empty;
            [JsonPropertyName("name")]
            public string Name { get; set; } = string.Empty;
            [JsonPropertyName("picture")]
            public string Picture { get; set; } = string.Empty;
            [JsonPropertyName("user_id")]
            public string User_id { get; set; } = string.Empty;
            [JsonPropertyName("user_name")]
            public string UserName { get; set; } = string.Empty;
    }
}
