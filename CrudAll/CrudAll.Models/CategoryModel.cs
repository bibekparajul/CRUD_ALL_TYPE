using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudAll.Models
{
    public class CategoryModel
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage ="Please Enter the Category name")]
        public string CategoryName { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
