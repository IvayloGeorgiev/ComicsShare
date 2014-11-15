namespace ComicsShare.Data.Models
{    
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ComicsShare.Data.Common.Models;

    public class Series : AuditInfo, IDeletableEntity
    {
        public Series()
        {
            this.Genres = new HashSet<Genre>();
            this.Chapters = new HashSet<Chapter>();
            this.Comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public double Rating { get; set; }        

        public string UploaderId { get; set; }

        public virtual User Uploader { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }

        public virtual ICollection<Chapter> Chapters { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
