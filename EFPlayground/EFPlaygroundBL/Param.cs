using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFPlaygroundBL
{
    [Table("Params")]
    public class Param
    {
        [Key]
        [Column(Order = 0)]
        public int ParamId { get; set; }

        [StringLength(40)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GroupID { get; set; }

        public virtual ParamGroup ParamGroup { get; set; }
        
        public virtual ICollection<Item> Items { get; set; }
    }
}
