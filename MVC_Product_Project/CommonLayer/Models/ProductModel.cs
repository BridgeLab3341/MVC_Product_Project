﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "{0} Should be given")]
        public string Code { get; set; }
        [Required(ErrorMessage = "{0} Should be given")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} Should be given")]
        public string Description { get; set; }
        [Required(ErrorMessage = "{0} Should be given")]
        public DateTime ExpiryDate { get; set; }
        [Required(ErrorMessage = "{0} Should be given")]
        public string Category { get; set; }
        [Required(ErrorMessage = "{0} Should be given")]
        public string Image { get; set; }
        [Required(ErrorMessage = "{0} Should be given")]
        public string Status { get; set; }
        [Required(ErrorMessage = "{0} Should be given")]
        public DateTime CreationDate { get; set; }
    }
}

