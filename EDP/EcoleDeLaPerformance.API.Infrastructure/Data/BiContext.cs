using System;
using System.Collections.Generic;
using EcoleDeLaPerformance.API.Core.Domain.Entities.BI;
using Microsoft.EntityFrameworkCore;

namespace EcoleDeLaPerformance.API.Infrastructure.Data;

public partial class BiContext : DbContext
{
    public BiContext()
    {
    }

    public BiContext(DbContextOptions<BiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FicheCrm> FicheCrms { get; set; }
    public virtual DbSet<EcolePerformanceSm> EcolePerformanceSms { get; set; }
    public virtual DbSet<EcolePerformanceNewContrat> EcolePerformanceNewContrats { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more intance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=XFISRVSQL002; Database=BI;Integrated Security=True;Connect Timeout=30;TrustServerCertificate=True");
    //=> optionsBuilder.UseSqlServer("Server=XFISRVSQLPREPROD; Database=BI;Integrated Security=True;Connect Timeout=30;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FicheCrm>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("fiche_crm", "dbo");

            entity.Property(e => e.Accountid).HasColumnName("accountid");
            entity.Property(e => e.Agence)
                .HasMaxLength(160)
                .UseCollation("French_CI_AI");
            entity.Property(e => e.Agenceid).HasColumnName("agenceid");
            entity.Property(e => e.Commercial)
                .HasMaxLength(200)
                .UseCollation("French_CI_AI")
                .HasColumnName("commercial");
            entity.Property(e => e.Commercialid).HasColumnName("commercialid");
            entity.Property(e => e.Nom)
                .HasMaxLength(184)
                .UseCollation("French_CI_AI");
            entity.Property(e => e.NuméroSage)
                .HasMaxLength(100)
                .UseCollation("French_CI_AI")
                .HasColumnName("Numéro Sage");
            entity.Property(e => e.Relation)
                .HasMaxLength(4000)
                .UseCollation("French_CI_AI");
            entity.Property(e => e.Slot).HasColumnName("slot");
            entity.Property(e => e.SlotCrm).HasColumnName("slot_crm");
        });

        modelBuilder.Entity<EcolePerformanceSm>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ecole_performance_SMS", "dbo");

            entity.Property(e => e.Commercial)
                .HasMaxLength(200)
                .UseCollation("French_CI_AI")
                .HasColumnName("commercial");
            entity.Property(e => e.DateSignature).HasColumnName("date_signature");
            entity.Property(e => e.Maintenance)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Sauvegarde)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Sécurité)
                .HasMaxLength(3)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EcolePerformanceNewContrat>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ecole_performance_new_contrat", "dbo");

            entity.Property(e => e.Agence)
                .HasMaxLength(160)
                .UseCollation("French_CI_AI");
            entity.Property(e => e.Commercial)
                .HasMaxLength(200)
                .UseCollation("French_CI_AI")
                .HasColumnName("commercial");
            entity.Property(e => e.ContractNumber)
                .HasMaxLength(100)
                .UseCollation("French_CI_AI");
            entity.Property(e => e.DateContrat).HasColumnName("date_contrat");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
