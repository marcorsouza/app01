using System;
using App01.Model.Domain.ObjectValues;

namespace App01.Model.Domain.Entities
{
    public class User :Entity<User>
    {
        public virtual int Id
        {
            get { return (int)base.IdBase; }
            set
            {
                base.IdBase = value;
            }
        }
        
        public string Name { get; set; }

        public string Email{ get;set; }

        public DateTime BirthDate { get; set; }

        public string Cpf { get; set; }

        public Authentication Authentication {get;set;}
        public bool Active { get; set; }
    }
}