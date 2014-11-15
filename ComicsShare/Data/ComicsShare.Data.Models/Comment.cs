namespace ComicsShare.Data.Models
{    
    using System;

    using ComicsShare.Data.Common.Models;

    public class Comment : AuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string PosterId { get; set; }

        public virtual User Poster { get; set; }

        public int SeriesId { get; set; }

        public virtual Series Series { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
