using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Entities
{
    public abstract class BaseEntity
    {
        [Column("created_at")]
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedAt { get; set; }

        [Column("modified_at")]
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModifiedAt { get; set; }
        
        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        public abstract bool IsNew();

        public BaseEntity()
        {
            CreatedAt = ModifiedAt = DateTime.Now;
        }
    }
}
