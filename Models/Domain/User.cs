namespace MeFitCase_Assignment.Models.Domain;

public partial class User
{
    public User()
    {
    }

    public int Id { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public bool? IsContributor { get; set; }
    public bool? IsAdmin { get; set; }

}