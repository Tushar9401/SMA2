using SM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Core.ViewModel
{
    public abstract class PostViewModel
    {
        public class PostDetailsViewModel
        {
            public Post Post { get; set; }
            public List<Comment> Comments { get; set; }

            public Likes Like { get; set; }
        }
    }
}
