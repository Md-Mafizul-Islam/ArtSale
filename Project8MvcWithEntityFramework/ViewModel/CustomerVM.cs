using Project8MvcWithEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project8MvcWithEntityFramework.ViewModel
{
    public class CustomerVM
    {
        [Key]
        public int ID { get; set; }
        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }
        [DisplayName("Artist Name")]
        public int ArtistID { get; set; }
        [DisplayName("Art Name")]
        public int ArtID { get; set; }
        public decimal Price { get; set; }
        public string CustomerType { get; set; }
        public List< Art> Art { get; set; }
        public  List<Artist> Artist { get; set; }
    }
}