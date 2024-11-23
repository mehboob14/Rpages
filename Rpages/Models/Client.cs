using System.ComponentModel.DataAnnotations;

namespace Rpages.Models
{
    public class Client
    {
            public int Id { get; set; }

            [Required]
            [StringLength(100)]
            public string Name { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            public string PhoneNumber { get; set; }
            public string Address { get; set; }
        
    }
}
