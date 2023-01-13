using System;
using System.Collections.Generic;

namespace ModelTest.Models
{
    public partial class Inventary
    {
        public Inventary()
        {
            Sales = new HashSet<Sale>();
        }

        public int Id { get; set; }
        public int? ArticleId { get; set; }
        public int? StoreId { get; set; }
        public DateTime? Date { get; set; }

        public virtual Article? Article { get; set; }
        public virtual Store? Store { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
