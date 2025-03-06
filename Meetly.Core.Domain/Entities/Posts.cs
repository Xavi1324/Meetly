using Meetly.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetly.Core.Domain.Entities
{
    public class Posts : BaseEntity
    {
        public int UserId { get; set; }
        public Users User { get; set; }
        public string Content { get; set; }
        public string? ImagePost { get; set; }
        public string? VideoPost { get; set; }
        public DateTime PublishingTime { get; set; }
        public ICollection<Comments> Comments { get; set; } = new List<Comments>();

    }
}
