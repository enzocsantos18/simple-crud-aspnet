using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

using System.Threading.Tasks;

namespace crud_api.Models
{
    public class Book
    {
        [Required]
        [Key]
        public int id { get; set; }

        [Required]
        public string name { get; set; }
        public int pages { get; set; }
    }
}
