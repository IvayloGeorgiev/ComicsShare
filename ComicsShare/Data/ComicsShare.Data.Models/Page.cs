
namespace ComicsShare.Data.Models
{    
    using System;
    using System.ComponentModel.DataAnnotations;

    using ComicsShare.Data.Common.Models;

    public class Page
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Location { get; set; }

        public int ChapterId { get; set; }

        public virtual Chapter Chapter { get; set; }
    }
}
