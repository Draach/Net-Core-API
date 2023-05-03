namespace RestAPI.Domain.Users
{
    public record UserCreateDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
