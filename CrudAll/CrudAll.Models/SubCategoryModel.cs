using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudAll.Models
{
    public class SubCategoryModel
    {
        [Key]
        public int SubId { get; set; }
        [Required]
        [Display(Name ="SubCategory Name")]
        public string Title { get; set; }
        public string? Description { get; set; }

        // Foreign Key
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        
        public CategoryModel Category{ get; set; }
    }
}
