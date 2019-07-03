using System;

namespace App01.Model.Domain.Entities
{
    public abstract class Entity<T> : IEntity<T>
    {
        public T Id { get; set; }
        object IEntity.Id {
            get { return this.Id; }
        }

    }
}