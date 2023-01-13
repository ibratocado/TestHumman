using System;
using System.Collections.Generic;

namespace ModelTest.Models
{
    public partial class Article
    {
        public Article()
        {
            Inventaries = new HashSet<Inventary>();
        }

        public int Id { get; set; }
        public string? Description { get; set; }
        public float? Price { get; set; }
        public string? Image { get; set; }
        public int? Stock { get; set; }
        public bool? State { get; set; }

        public virtual ICollection<Inventary> Inventaries { get; set; }
    }
}
