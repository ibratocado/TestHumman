using System;
using System.Collections.Generic;

namespace ModelTest.Models
{
    public partial class Sale
    {
        public int Id { get; set; }
        public int? ClientId { get; set; }
        public int? InventaryId { get; set; }
        public int? Pieces { get; set; }
        public float? TotalPrice { get; set; }
        public DateTime? Date { get; set; }
        public bool? State { get; set; }

        public virtual Client? Client { get; set; }
        public virtual Inventary? Inventary { get; set; }
    }
}
