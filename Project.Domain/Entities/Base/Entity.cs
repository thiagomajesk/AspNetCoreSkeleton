using System;

namespace Project.Domain.Entities.Base
{
    public abstract class Entity
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}