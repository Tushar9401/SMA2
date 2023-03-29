using SM.Core.Contracts;
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
        IRepository<Post> postContext;
        
       
        public bool LeaveComment(Comment comment)
        {
            DataContext context = new DataContext();

            context.Comments.Add(comment);
             return context.SaveChanges() >0;

        }
        public List<Comment> GetComments(string PostID)
        {
            DataContext context = new DataContext();
            return context.Comments.Where(x=>x.PostID==PostID).ToList();
            
        }
        public Post GetPostById(string PostID)
        {
            
            DataContext context = new DataContext();
            return context.Posts.Find(PostID);
            
        }
    }
}
