using System.Text.Json.Serialization;

namespace Blazor.UI.Data.ModelViews.Publication
{ 
    public class UserDto
    {       
      public string? Email { get; set; } = string.Empty;
               
      public string? GivenName { get; set; }
                
      public string? FamilyName { get; set; } = string.Empty;
               
      public string? Name { get; set; } = string.Empty;
               
      public string? Picture { get; set; } = string.Empty;
               
      public string? User_id { get; set; } = string.Empty;
               
      public string? UserName { get; set; } = string.Empty;
    }
 
}