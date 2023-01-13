using System;
using System.Collections.Generic;

namespace ModelTest.Models
{
    public partial class Rol
    {
        public Rol()
        {
            Accounts = new HashSet<Account>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
