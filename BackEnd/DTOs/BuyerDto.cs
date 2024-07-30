using System;

public class BuyerDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Type { get; set; }
    public string CpfCnpj { get; set; }
    public string StateRegistration { get; set; }
    public bool Exempt { get; set; }
    public string Gender { get; set; }
    public DateTime? BirthDate { get; set; }
    public bool IsBlocked { get; set; }
    public string Password { get; set; }
}
