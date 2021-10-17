using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace Models {
public class Adult : Person {
    
    public Job JobTitle { get; set; }
    
    [Range(18, int.MaxValue, ErrorMessage = "Have to be at least 18 years old to be adult")]
    public int Age { get; set; }
    [ Required]
    public string Sex { get; set; }
}
}