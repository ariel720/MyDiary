using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyDiary.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [ForeignKey("Content")]
        public int ContentId { get; set; }

        public string Text { get; set; }

        public DateTime Created { get; set; }

        public string Writer { get; set; }

    }
}
