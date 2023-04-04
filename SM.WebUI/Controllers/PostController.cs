using SM.Core.Contracts;
using SM.Core.Models;
using SM.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SM.WebUI.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        IRepository<Post> context;
        IRepository<Category> categoryContext;


        public PostController(IRepository<Post> postContext, IRepository<Category> postcategorycontext)
        {
            context = postContext;
            categoryContext = postcategorycontext;
        }

        //GET: ProductManager
        [Authorize(Roles ="Admin")]
        public ActionResult Index()
        {
            //List<Post> post = context.Collection().ToList();
            //return View(post);
            List<Post> posts= context.Collection().ToList(); 
            List<Category> categories = categoryContext.Collection().ToList();
            PostListViewModel model = new PostListViewModel();

            model.Posts = posts;
            model.Categories = categories;
            return View(model);
        }
      

        public ActionResult Create()
        {
            PostManagerViewModel viewModel = new PostManagerViewModel();


            viewModel.Post = new Post();
            viewModel.categories = categoryContext.Collection();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Post post, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View(post);
            }
            else
            {

                if (file != null)
                {
                    post.Image = post.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//PostImages//") + post.Image);
                }

                context.Insert(post);
                context.Commit();

                return RedirectToAction("Index");

            }
        }
        [HttpPost]
        public async Task<List<Post>> Likes(string id, bool like)
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
        //public ActionResult Edit(string ID)
        //{
        //    Post post = context.Find(ID);

        //    if (post == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    else
        //    {
        //        PostManagerViewModel viewModel = new PostManagerViewModel();
        //        viewModel.Post = new Post();
        //        viewModel.categories = categoryContext.Collection();
        //        return View(viewModel);
        //    }
        //}

        //[HttpPost]
        //public ActionResult Edit(Post post, string Id, HttpPostedFileBase file)
        //{
        //    Post postToEdit = context.Find(Id);

        //    if (postToEdit == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    else
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return View(post);
        //        }

        //        if (file != null)
        //        {
        //            postToEdit.Image = postToEdit.Id + Path.GetExtension(file.FileName);
        //            file.SaveAs(Server.MapPath("//Content//ProductImages//") + postToEdit.Image);
        //        }


        //        postToEdit.Description = post.Description;
        //        postToEdit.Title = post.Title;
        //        postToEdit.Category = post.Category;

        //        context.Commit();

        //        return RedirectToAction("Index");
        //    }
        //}
        public ActionResult Delete(string ID)
        {
            Post postToDelete = context.Find(ID);

            if (postToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(postToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string ID)
        {
            Post postToDelete = context.Find(ID);

            if (postToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(ID);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        
        
    }
}