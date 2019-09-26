using System;
using System.ComponentModel.DataAnnotations;

namespace NewWebPortal.ApplicationCore.Entities
{
    public class BaseEntity
    {
        [Key]
        public int ID { get; set; }
        public bool IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
