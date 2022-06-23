namespace MeFitCase_Assignment.Models.Domain;

public partial class Address
{
    public Address()
    {
        Profiles = new HashSet<Profile>();
    }

    public int Id { get; set; }
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? AddressLine3 { get; set; }
    public string? PostalCode { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }

    public virtual ICollection<Profile> Profiles { get; set; }
}