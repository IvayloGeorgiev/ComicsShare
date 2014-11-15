namespace ComicsShare.Data.Repositories
{
    using System.Data.Entity;

    using ComicsShare.Data.Common.Repository;
    using ComicsShare.Data.Models;    

    public class ChapterRepository : DeletableEntityRepository<Chapter>
    {
        public ChapterRepository(DbContext ctx)
            : base(ctx)
        {
        }

        public override void Delete(Chapter entity)
        {
            foreach (var page in entity.Pages)
            {
                var pageRepo = new GenericRepository<Page>(this.Context);
                pageRepo.Delete(page);
            }

            base.Delete(entity);
        }
    }
}
