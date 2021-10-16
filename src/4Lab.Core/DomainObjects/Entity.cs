using System;

namespace _4Lab.Core.DomainObjects
{
    public abstract class Entity
    {
        public bool Active { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = null;
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }

    public abstract class Entity<T> : Entity
    {
        public T Id { get; set; }

    }
}
