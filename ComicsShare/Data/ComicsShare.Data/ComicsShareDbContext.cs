namespace ComicsShare.Data
{
    using System;    
    using System.Data.Entity;
    using System.Linq;

    using Microsoft.AspNet.Identity.EntityFramework;

    using ComicsShare.Data.Models;
    using ComicsShare.Data.Common.Models;    

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

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
