namespace ComicsShare.Data
{
    using ComicsShare.Data.Common.Repository;
    using ComicsShare.Data.Models;

    public interface IComicsShareData
    {
        ComicsShareDbContext Context { get; }

        IDeletableEntityRepository<Chapter> Chapters { get; }

        IDeletableEntityRepository<Comment> Comments { get; }

        IRepository<User> Users { get; }

        IDeletableEntityRepository<Genre> Genres { get; }

        IDeletableEntityRepository<Page> Pages { get; }

        IDeletableEntityRepository<Series> Series { get; }

        int SaveChanges();
    }
}
