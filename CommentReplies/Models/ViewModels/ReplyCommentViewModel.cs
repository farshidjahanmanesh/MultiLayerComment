using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommentReplies.Models.ViewModels
{
    public class CommentViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Text { get; set; }
    }
    public class ReplyCommentViewModel:CommentViewModel
    {
        
        public int ParentId { get; set; }
    }
}
