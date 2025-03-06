using Meetly.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetly.Core.Domain.Entities
{
    public class Users : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ProfilePicture { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool isActive { get; set; }

        public ICollection<Posts> Posts { get; set; } = new List<Posts>();
        public ICollection<Comments> Comments { get; set; } = new List<Comments>();
        public ICollection<Friendship> FriendshipsAsUser { get; set; } = new List<Friendship>();
        public ICollection<Friendship> FriendshipsAsFriend { get; set; } = new List<Friendship>();
    }

}

