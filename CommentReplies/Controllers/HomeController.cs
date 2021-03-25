using CommentReplies.Models;
using CommentReplies.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CommentReplies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProjectContext context;

        public HomeController(ProjectContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var comments=context.Comments.ToList();
            var parentComments = comments.Where(c => c.Parent == null).ToList();
            
            return View(parentComments);
        }

        public IActionResult ReplyAdd(ReplyCommentViewModel comment)
        {
            context.Comments.Add(new Comment()
            {
                CreateAt=DateTime.Now,
                Email=comment.Email,
                Name=comment.Name,
                ParentId=comment.ParentId,
                Text=comment.Text
            });
            context.SaveChanges();
            return Ok();
        }

        public IActionResult CommentAdd(CommentViewModel comment)
        {
            context.Comments.Add(new Comment()
            {
                CreateAt=DateTime.Now,
                Email=comment.Email,
                Name=comment.Name,
                Text=comment.Text
            });
            context.SaveChanges();
            return Ok();
        }
    }

}
