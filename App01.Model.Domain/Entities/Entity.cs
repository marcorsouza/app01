using System;
using FluentValidation;
using FluentValidation.Results;

namespace App01.Model.Domain.Entities
{
    public abstract class Entity<T> : IEntity<T>
    {
        public T Id { get; set; }
        object IEntity.Id {
            get { return this.Id; }
        }

        public bool Valid { get; private set; }
        //public bool Invalid => !Valid;
        public ValidationResult ValidationResult { get; private set; }

        public bool Validate<T1>(T1 model, AbstractValidator<T1> validator)
        {
            ValidationResult = validator.Validate(model);
            return Valid = ValidationResult.IsValid;
        }

        public bool Invalid
        {
           get {return !Valid; }
        }
    }
}