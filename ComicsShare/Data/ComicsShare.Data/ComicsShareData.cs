namespace ComicsShare.Data
{
    using ComicsShare.Data.Common.Models;
    using ComicsShare.Data.Common.Repository;
    using ComicsShare.Data.Models;
    using ComicsShare.Data.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    public class ComicsShareData : IComicsShareData
    {
        private ComicsShareDbContext context;

        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public ComicsShareData(ComicsShareDbContext context)
        {
            this.context = context;
        }

        public ComicsShareDbContext Context
        {
            get
            {
                return this.context;
            }
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }  

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                }
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {                               
                var type = typeof(GenericRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }

        private IDeletableEntityRepository<T> GetDeletableEntityRepository<T>() where T : class, IDeletableEntity
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                if (typeof(T) == typeof(Series))
                {
                    var type = typeof(SeriesRepository);
                    this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));

                }
                else if (typeof(T) == typeof(Chapter))
                {
                    var type = typeof(ChapterRepository);
                    this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
                }
                else
                {
                    var type = typeof(DeletableEntityRepository<T>);
                    this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
                }
            }

            return (IDeletableEntityRepository<T>)this.repositories[typeof(T)];
        }
    }
}
