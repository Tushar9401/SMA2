using SM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Core.ViewModel
{
    public class PostManagerViewModel
    {
        public Post Post { get; set; }

        public IEnumerable<Category> categories { get; set; }
    }
}
