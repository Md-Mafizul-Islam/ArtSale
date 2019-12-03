using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project8MvcWithEntityFramework.Models
{
    public class Artist
    {
        public int ArtistID { get; set; }
        [DataType(DataType.Text)]
        [DisplayName("Artist Name")]
        [Required(ErrorMessage = "Name Must Be Validate"), MaxLength(15), MinLength(3)]
        public string ArtistName { get; set; }
        
      
       
    }
}