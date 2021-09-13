using System;

namespace Domain.Entities
{
    public abstract class Entity
    {
        public bool Active { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = null;
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
    /// <summary>
    /// base entity
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Entity<T> : Entity
    {
        public T Id { get; set; }

    }
}
