using Microsoft.AspNet.Identity;
using SM.Core.Contracts;
using SM.Core.Models;
using SM.Core.ViewModel;
using SM.Service;
using SM.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static SM.Core.ViewModel.PostViewModel;

namespace SM.WebUI.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        IRepository<Post> context;
        IRepository<Category> contextCategory;
        IRepository<Comment> commentContext;
        IRepository<Likes> likesContext;

        SharedServices services = new SharedServices();

        public HomeController(IRepository<Post> context, IRepository<Category> contextCategory)
        {
            this.context = context;
            this.contextCategory = contextCategory;
        }

        public ActionResult Index(string option, string search, string category = null)
        {
            List<Post> posts;
            List<Category> categories = contextCategory.Collection().ToList();
           
            //if (option == "Title")
            //{
            //    //Index action method will return a view with a student records based on what a user specify the value in textbox  
            //    return View(db.Posts.Where(x => x.Title == search || search == null).ToList());
            //}
            //else if (option == "Category")
            //{
            //    return View(db.Posts.Where(x => x.Category == search || search == null).ToList());
            //}


            if (category == null)
            {
                posts = context.Collection().ToList();
            }
            else
            {
                posts = context.Collection().Where(p => p.Category == category).ToList();
            }
            PostListViewModel model = new PostListViewModel();
            model.Posts = posts;
            model.Categories = categories;
            return View(model);
        }
        [HttpPost]
        public async Task<List<Post>> Edit(string id, bool like)
        {
            Post post = context.Find(id);
            if (like)
            {
                post.NumberOfLikes++;
            }

            context.Update(post);
            context.Commit();
            return context.Collection().ToList();
        }
        [HttpGet]
        public ActionResult Details(string Id)
        {
           
            //Post post = context.Find(Id);
            //Comment comment = SharedServices.GetComments(Id);
            //if (post == null)
            //{
            //    return HttpNotFound();
            //}
            //else
            //{
            //    return View(post);
            //}
            PostDetailsViewModel model = new PostDetailsViewModel();
            model.Post = services.GetPostById(Id);
            model.Comments = services.GetComments(Id);
           
            return View(model);

        }

        [HttpPost]
        public JsonResult LeaveComment(CommentViewModel model)
        {
            JsonResult result = new JsonResult();
            SharedServices service = new SharedServices();
            try
            {
                //Creating comment Object.
                var comment = new Comment();
                //Getting Comment From FrontEnd
                comment.Text = model.Text;
                comment.PostID = model.PostID;
                comment.Likes = model.Likes;

                comment.UserID = User.Identity.GetUserId();
                comment.TimeStamp = DateTime.Now;
                result.Data = new { Success = service.LeaveComment(comment) };
            }
             catch(Exception ex)
            {
                result.Data = new { Success=false,Message=ex.Message };
            }
            return result;
        }
        
    }
}