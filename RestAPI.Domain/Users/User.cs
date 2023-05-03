using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI.Domain.Users
{
    public class User : IUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        private User()
        {
        }

        public User(UserCreateDto userCreateDto)
        {
            UserName = userCreateDto.UserName;
            Password = userCreateDto.Password;
        }
    }
}
