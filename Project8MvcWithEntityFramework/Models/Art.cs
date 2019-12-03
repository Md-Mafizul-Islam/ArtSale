using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project8MvcWithEntityFramework.Models
{
    public class Art
    {
        public int ArtID { get; set; }
        [DataType(DataType.Text)]
        [DisplayName("Arts Name")]
        [Required(ErrorMessage = "Arts Must Be Validate"), MaxLength(15), MinLength(3)]
        public string Arts { get; set; }

    }
}