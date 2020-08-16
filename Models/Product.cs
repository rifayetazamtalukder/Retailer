using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Retailer.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [DisplayName("Product Code")]
        public string ProductCode { get; set; }

        [Required]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }

        [Required]
        [DisplayName("Product Details")]
        public string ProductDetails { get; set; }

        [Required]
        [DisplayName("Freeze Product?")]
        public bool ProductFreeze { get; set; }

        [DisplayName("Product Image Name")]
        public string ProductImageName { get; set; }

        [NotMapped]
        [Required]
        [DisplayName("Product Image")]
        public IFormFile ProductImageFile { get; set; }


    }
}
