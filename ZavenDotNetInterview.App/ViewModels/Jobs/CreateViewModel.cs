using System;
using System.ComponentModel.DataAnnotations;

namespace ZavenDotNetInterview.App.ViewModels.Jobs
{
    public class CreateViewModel
    {
        [Required(ErrorMessage = "The field is required")]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        public string Name { get; set; }
        public DateTime? DoAfter { get; set; }
    }
}