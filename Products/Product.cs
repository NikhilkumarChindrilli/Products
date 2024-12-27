using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Products
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ProductId {  get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string Quantity { get; set; }
        [Required]
        public int Price { get; set; }
    }
}