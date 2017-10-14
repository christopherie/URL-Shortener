using System.ComponentModel.DataAnnotations;

namespace URLShortener.Models
{
    public class URL
    {
        [Required]
        [Display(Name = "URL")]
        public string UrlString { get; set; }
    }
}