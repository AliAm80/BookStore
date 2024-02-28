using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Book
{
    public class UpdateBookDto
    {
        [Required(ErrorMessage = "Enter Name of The Book")]
        [MaxLength(50, ErrorMessage = "Enter Name, not be more 50 lengths")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Author of The Book")]
        [MaxLength(40, ErrorMessage = "Enter Name, not be more 40 lengths")]
        public string Author { get; set; }

        [Range(1000, 1000000, ErrorMessage = "Enter Amount Between 1000 and 1000000")]
        public int Amount { get; set; }

        [StringLength(70, ErrorMessage = "Enter Description, not be more 70 lengths")]
        public string Description { get; set; }
    }
}