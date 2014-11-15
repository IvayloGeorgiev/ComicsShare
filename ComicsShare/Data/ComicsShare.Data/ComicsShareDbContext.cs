namespace ComicsShare.Data
{    
    using Microsoft.AspNet.Identity.EntityFramework;

    using ComicsShare.Data.Models;

    public class ComicsShareDbContext : IdentityDbContext<User>
    {
        public ComicsShareDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ComicsShareDbContext Create()
        {
            return new ComicsShareDbContext();
        }
    }
}
