using System.Collections.Generic;

namespace App01.Model.Domain.ObjectValues
{
    public class Authentication :ValueObject
    {
        public string Username { get; set; }
        public string Password{ get;set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Username;
            yield return Password;
        }
    }
}