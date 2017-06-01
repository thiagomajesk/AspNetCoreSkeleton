using Project.Domain.Entities.Base;

namespace Project.Domain.Entities
{
    public class Post : Entity
    {
        public string Title { get; set; }

        public string Body { get; set; }

        public virtual User Author { get; set; }
    }
}