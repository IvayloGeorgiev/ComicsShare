
namespace ComicsShare.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ComicsShare.Data.Common.Models;    

    public class Genre : AuditInfo, IDeletableEntity
    {
        public Genre()
        {
            this.Series = new HashSet<Series>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Series> Series { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
