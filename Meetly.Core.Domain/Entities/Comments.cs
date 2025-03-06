using Meetly.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetly.Core.Domain.Entities
{
    public class Comments : BaseEntity
    {
        public int PostId { get; set; }
        public Posts Post { get; set; }
        public int UserId { get; set; }
        public Users User { get; set; }
        public string CommmentContent { get; set; }
        public DateTime CommentTime { get; set; }
        public int? ParentCommentId { get; set; }
        public Comments ParentComment { get; set; }
        public ICollection<Comments> Replies { get; set; }


    }
}