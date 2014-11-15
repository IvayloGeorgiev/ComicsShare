
namespace ComicsShare.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ComicsShare.Data.Common.Models;

    public class Chapter : AuditInfo, IDeletableEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public uint? Volume { get; set; }

        public virtual ICollection<Page> Pages { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
