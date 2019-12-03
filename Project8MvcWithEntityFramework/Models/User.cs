using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project8MvcWithEntityFramework.Models
{
    public partial class User
    {
        public int Id { get;set; }
        [DataType(DataType.Text)]
        [DisplayName("User Name")]
        [Required(ErrorMessage ="Name Must Be Validate"),MaxLength(15),MinLength(3)]
        public string UserName { get; set;}
        [DataType(DataType.Password)]
        [DisplayName("PassWord")]
        [Required(ErrorMessage = "Name Must Be Validate"), MaxLength(15), MinLength(3)]
        public string Password { get; set;
        }
        public string Role { get; set; }
    }
}