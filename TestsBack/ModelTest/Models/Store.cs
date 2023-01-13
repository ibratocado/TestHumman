using System;
using System.Collections.Generic;

namespace ModelTest.Models
{
    public partial class Store
    {
        public Store()
        {
            Inventaries = new HashSet<Inventary>();
        }

        public int Id { get; set; }
        public string? BranchOffice { get; set; }
        public string? Address { get; set; }

        public virtual ICollection<Inventary> Inventaries { get; set; }
    }
}
