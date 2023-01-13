using System;
using System.Collections.Generic;

namespace ModelTest.Models
{
    public partial class Account
    {
        public Account()
        {
            Clients = new HashSet<Client>();
        }

        public int Id { get; set; }
        public string? Count { get; set; }
        public string? Pount { get; set; }
        public int? RolId { get; set; }

        public virtual Rol? Rol { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
    }
}
