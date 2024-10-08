using System;
using System.Collections.Generic;

namespace EFIntroduction.Models.Entities;

public partial class Patient
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? City { get; set; }

    public int? YearOfBirth { get; set; }

    public double? HeightInCm { get; set; }

    public double? WeightInKg { get; set; }
}
