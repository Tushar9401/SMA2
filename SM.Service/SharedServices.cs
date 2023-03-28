using SM.Core.Models;
using SM.SQL;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Service
{
    public class SharedServices
    {
        public bool LeaveComment(Comment comment)
        {
            DataContext context = new DataContext();

            context.Comments.Add(comment);
             return context.SaveChanges() >0;

        }
    }
}
