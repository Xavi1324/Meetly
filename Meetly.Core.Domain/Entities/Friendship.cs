using Meetly.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetly.Core.Domain.Entities
{
    public class Friendship : BaseEntity
    {
        public int UserId { get; set; }
        public Users User { get; set; }
        public int FriendId { get; set; }
        public Users Friend { get; set; }

    }
}
