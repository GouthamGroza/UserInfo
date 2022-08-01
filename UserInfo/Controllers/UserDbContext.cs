using Microsoft.EntityFrameworkCore;
using UserInfo.Models;

namespace UserInfo.Controllers
{
    public class UserInfoDbContext : DbContext
    {
        public UserInfoDbContext(DbContextOptions<UserInfoDbContext> options) 
            :base(options)
        {

        }

        public DbSet<UserInfos> Users { get; set; }
        public DbSet<userComposite> UserComposites { get; set; }
    }
}
