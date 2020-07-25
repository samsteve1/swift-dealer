using System.ComponentModel.DataAnnotations;

namespace vega.Core.Models
{
    public class Feature
    {
        public int Id { get; set; }
        [Required]
        [StringLength(256)]
        public string Name { get; set; }
        
    }
}