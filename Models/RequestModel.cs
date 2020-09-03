using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace RequestManager.Models
{
    public class RequestModel
    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "ProjectName", ResourceType = typeof(RequestManager.Resources.Resource))]
        [Required(ErrorMessageResourceType = typeof(RequestManager.Resources.Resource), ErrorMessageResourceName = "AllField")]
        public string ProjectName { get; set; }


        [Display(Name = "DepartmentName")]
        [Required(ErrorMessageResourceType = typeof(RequestManager.Resources.Resource), ErrorMessageResourceName = "AllField")]
        public string DepartmentName { set; get; }


        [Display(Name = "RequestBy", ResourceType = typeof(RequestManager.Resources.Resource))]
        [Required(ErrorMessageResourceType = typeof(RequestManager.Resources.Resource), ErrorMessageResourceName = "AllField")]
        public string RequestBy { get; set; }


        [Display(Name = "DescriptionOfProblem", ResourceType = typeof(RequestManager.Resources.Resource))]
        [Required(ErrorMessageResourceType = typeof(RequestManager.Resources.Resource), ErrorMessageResourceName = "AllField")]
        public string DescriptionOfProblem { get; set; }

        public DateTime CreateTime { get; set; }
    }
}