using System;
using System.ComponentModel.DataAnnotations;

public class Buyer
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(150)]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    [MaxLength(150)]
    public string Email { get; set; }

    [Required]
    [MaxLength(11)]
    public string Phone { get; set; }

    [Required]
    public string Type { get; set; } // "Física" or "Jurídica"

    [Required]
    [MaxLength(14)]
    public string CpfCnpj { get; set; }

    public string StateRegistration { get; set; }
    
    public bool Exempt { get; set; }

    public string Gender { get; set; }

    public DateTime? BirthDate { get; set; }

    public bool IsBlocked { get; set; }

    [Required]
    [MinLength(8)]
    [MaxLength(15)]
    public string Password { get; set; }
}
