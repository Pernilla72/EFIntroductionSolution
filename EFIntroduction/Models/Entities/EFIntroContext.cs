using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFIntroduction.Models.Entities;

public partial class EFIntroContext : DbContext
{
    string? connectionstring = "";
    public EFIntroContext(DbContextOptions<EFIntroContext> options)
        : base(options)
    {
    }

    public EFIntroContext() : base()
    {
        var builder = new ConfigurationBuilder();
        builder.AddJsonFile("Appsetting.json", false);
        var app = builder.Build();
        connectionstring = app.GetConnectionString("DefaultConnection");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionstring);
    }

    public virtual DbSet<Patient> Patients { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Finnish_Swedish_CI_AI");

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Patients__3214EC07BA54544A");

            entity.Property(e => e.City).HasMaxLength(32);
            entity.Property(e => e.FirstName).HasMaxLength(32);
            entity.Property(e => e.LastName).HasMaxLength(32);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
