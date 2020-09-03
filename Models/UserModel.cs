using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RequestManager.Models
{
    public class UserModel
    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Name", ResourceType = typeof(RequestManager.Resources.Resource))]
        [Required(ErrorMessageResourceType = typeof(RequestManager.Resources.Resource), ErrorMessageResourceName = "AllField")]
        public string Name { get; set; }
  

        [Display(Name = "Password")]
        [Required(ErrorMessageResourceType = typeof(RequestManager.Resources.Resource), ErrorMessageResourceName = "AllField")]
        public string Password { set; get; }

        public int Type { get; set; }

        public string Department { get; set; }

    }
}