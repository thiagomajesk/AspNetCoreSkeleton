using Project.Domain.Entities.Base;
using System.Collections.Generic;

namespace Project.Domain.Entities
{
    public class User : Entity
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}