using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Core.Models
{
    public class Post:BaseEntity
    {
        [Required]
        [StringLength(20)]
        public string Title { get; set; }
        [Required]
        [DisplayName("What's On Your Mind")]
        public string Description { get; set; }

        public string Image { get; set; }
        [DisplayName("Category")]
        public string Category { get; set; }

        public int NumberOfLikes { get; set; }

        public string Pick { get; set; }

    }
}
