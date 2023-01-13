using System;
using System.Collections.Generic;

namespace ModelTest.Models
{
    public partial class Client
    {
        public Client()
        {
            Sales = new HashSet<Sale>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastNames { get; set; }
        public int? AccountId { get; set; }
        public string? Address { get; set; }

        public virtual Account? Account { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
