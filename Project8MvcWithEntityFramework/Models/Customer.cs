using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project8MvcWithEntityFramework.Models
{
    public class Customer
    {
        public int ID { get; set; }
        [DataType(DataType.Text)]
        [DisplayName("Customer Name")]
        [Required(ErrorMessage = "Name Must Be Validate"), MaxLength(15), MinLength(3)]
        public string CustomerName { get; set; }
        public int ArtistID { get; set; }
        public int ArtID { get; set; }
       
        [DisplayName("Price")]
        [Required(ErrorMessage = "Price Must Be Validate")]
        [Range(.01,10000.00)]
        public decimal Price { get; set; }
        [DataType(DataType.Text)]
        [DisplayName("Customer Type")]
        [Required(ErrorMessage = "Name Must Be Validate"), MaxLength(9), MinLength(6)]
        public string CustomerType { get; set; }
        public virtual Art Art { get; set; }
        public virtual Artist Artist { get; set; }
    }
}