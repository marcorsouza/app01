using FluentValidation;
using FluentValidation.Results;

namespace App01.Model.Domain.Entities
{
    public interface IEntity {
        object Id { get;  }
    }

    public interface IEntity<T> : IEntity
    {
        new T Id { get; set; }


        bool Valid { get; }
        bool Invalid {get;}
        ValidationResult ValidationResult { get; }
        bool Validate<T>(T model, AbstractValidator<T> validator);
    }
}