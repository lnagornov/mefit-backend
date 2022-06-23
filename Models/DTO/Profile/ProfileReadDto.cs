using System.Text.Json.Serialization;
using MeFitCase_Assignment.Models.Domain;

namespace MeFitCase_Assignment.Models.DTO.Profile;

public class ProfileReadDto
{
    public int Id { get; set; }
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? AddressLine3 { get; set; }
    public string? PostalCode { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public double? Weight { get; set; }
    public double? Height { get; set; }
    public string[]? MedicalConditions { get; set; }
    public string[]? Disabilities { get; set; }
    public int? GoalId { get; set; }
    public string? GoalEndDate { get; set; }
    public bool? IsGoalAchieved { get; set; }
    public int? ProgramId { get; set; }
}