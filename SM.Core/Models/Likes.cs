using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Core.Models
{
    public class Likes:BaseEntity
    {
        public int LikeCount { get; set; }

        public string PostID { get; set; }
    }
}
