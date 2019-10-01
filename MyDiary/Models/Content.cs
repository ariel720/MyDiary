using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyDiary.Models
{
    public class Content
    {
        [Key]
        public int ContentId { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public DateTime Created { get; set; }

        public string Writer { get; set; }

        public ICollection<Review> Reviews { get; set; }

    }
}
