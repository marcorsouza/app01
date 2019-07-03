﻿namespace App01.Model.Domain.Entities
{
    public interface IEntity {
        object Id { get;  }
    }

    public interface IEntity<T> : IEntity
    {
        new T Id { get; set; }
    }

    /*public class Entity {
        public virtual object IdBase { get; set; }
    }

    public class Entity<T> : Entity, IEquatable<T> where T : Entity<T> {
        public virtual bool Equals (T other) {
            if (other == null) return false;
            return (this.IdBase.Equals (other.IdBase));
        }
    } */
}