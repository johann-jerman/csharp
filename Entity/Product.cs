﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public int? CategoryId { get; set; }
        
        [ForeignKey("CategoryId")]
        public virtual Categorys Category { get; set; }
    }
}
