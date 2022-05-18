using System;
using System.Collections.Generic;

namespace CSharpBackEnd.Models
{
    public class Link
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfParce { get; set; } = DateTime.Now;
        public ICollection<ParcedLink> ParcedLinks { get; set; }
    }
}
