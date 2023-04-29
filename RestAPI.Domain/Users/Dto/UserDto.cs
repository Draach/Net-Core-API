using System.Text.Json.Serialization;

namespace RestAPI.Domain.Users
{
    public record UserDto
    {
        [JsonIgnore]
        public string Id { get; set; }
        public string UserName { get; set; }
    }
}
