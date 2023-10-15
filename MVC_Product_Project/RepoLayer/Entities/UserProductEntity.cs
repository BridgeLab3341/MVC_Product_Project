using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RepoLayer.Entities
{
    public class UserProductEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public string Status { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
