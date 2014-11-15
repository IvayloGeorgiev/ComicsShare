namespace ComicsShare.Data.Repositories
{
    using ComicsShare.Data.Common.Repository;
    using ComicsShare.Data.Models;
    using System.Data.Entity;

    public class SeriesRepository : DeletableEntityRepository<Series>
    {
        public SeriesRepository(DbContext ctx)
            : base(ctx)
        {
        }

        public override void Delete(Series entity)
        {
            foreach (var chapter in entity.Chapters)
            {
                var chapRepo = new DeletableEntityRepository<Chapter>(this.Context);
                chapRepo.Delete(chapter);
            }

            foreach (var comment in entity.Comments)
            {
                var chapRepo = new DeletableEntityRepository<Comment>(this.Context);
                chapRepo.Delete(comment);
            }

            base.Delete(entity);
        }

    }
}
