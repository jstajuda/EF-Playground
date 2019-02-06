using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPlaygroundBL
{
    [Table("Items")]
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public int? CategoryId { get; set; } // pytajnik oznacza, że CategoryId może być null
        public virtual Category Category { get; set; }
    }
}
