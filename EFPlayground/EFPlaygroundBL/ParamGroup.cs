using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFPlaygroundBL
{
    [Table("ParamGroups")]
    public class ParamGroup
    {
        [Key]
        public int ParamGroupId { get; set; }

        [StringLength(40)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Description { get; set; }
        
        public virtual ICollection<Param> Params { get; set; }
    }
}
