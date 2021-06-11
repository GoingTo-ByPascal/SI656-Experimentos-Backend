using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Resources
{
    public class SaveReviewResource
    {
        [Required]
        [MaxLength(500)]
        public string Comment { get; set; }
        public int Stars { get; set; }
    }
}
