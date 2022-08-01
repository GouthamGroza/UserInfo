using System.ComponentModel.DataAnnotations;

namespace UserInfo.Models
{
    public class UserInfos
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

    }
}
