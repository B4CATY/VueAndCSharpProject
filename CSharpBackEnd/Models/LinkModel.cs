using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBackEnd.Models
{
    public class LinkModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Link must be provided")]
        [MinLength(5)]
        public string Link { get; set; }
    }
}
