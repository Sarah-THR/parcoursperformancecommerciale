using EcoleDeLaPerformance.API.Core.Domain.Entities.CRM;
using Microsoft.EntityFrameworkCore;

namespace EcoleDeLaPerformance.API.Infrastructure.Data;

public partial class XefiMscrmContext : DbContext
{
    public XefiMscrmContext()
    {
    }

    public XefiMscrmContext(DbContextOptions<XefiMscrmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ContractBase> Contracts { get; set; }
    public virtual DbSet<AccountBase> Accounts { get; set; }
    public virtual DbSet<SystemUserBase> SystemUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more intance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //=> optionsBuilder.UseSqlServer("Server=XFISRVSQL002; Database=XEFI_MSCRM;Integrated Security=True;Connect Timeout=30;TrustServerCertificate=True");
    => optionsBuilder.UseSqlServer("Server=XFISRVCRM005; Database=XEFI_MSCRM;Integrated Security=True;Connect Timeout=30;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("French_CI_AI");

        modelBuilder.Entity<ContractBase>(entity =>
        {
            entity.HasKey(e => e.ContractId).HasName("cndx_PrimaryKey_Contract");

            entity.ToTable("ContractBase");

            entity.HasIndex(e => e.OriginatingContract, "fndx_for_cascaderelationship_contract_originating_contract")
                .HasFilter("([OriginatingContract] IS NOT NULL)")
                .HasFillFactor(80);

            entity.HasIndex(e => e.CustomerIdName, "ndx_QF_CustomerIdName").HasFillFactor(80);

            entity.HasIndex(e => new { e.CustomerId, e.CustomerIdType }, "ndx_for_cascaderelationship_contract_customer_accounts").HasFillFactor(80);

            entity.Property(e => e.ContractId).ValueGeneratedNever();
            
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.CustomerIdName).HasMaxLength(4000);
            entity.Property(e => e.CustomerIdYomiName).HasMaxLength(4000);
           
            entity.Property(e => e.TotalPrice).HasColumnType("money");
           
            entity.HasOne(d => d.OriginatingContractNavigation).WithMany(p => p.InverseOriginatingContractNavigation)
                .HasForeignKey(d => d.OriginatingContract)
                .HasConstraintName("contract_originating_contract");
        });
        modelBuilder.Entity<AccountBase>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("cndx_PrimaryKey_Account");

            entity.ToTable("AccountBase");

            entity.Property(e => e.AccountId).ValueGeneratedNever();
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.XefiMoyendepaiement).HasColumnName("xefi_moyendepaiement");
        });
        modelBuilder.Entity<SystemUserBase>(entity =>
        {
            entity.HasKey(e => e.SystemUserId).HasName("cndx_PrimaryKey_SystemUser");

            entity.ToTable("SystemUserBase");

            entity.HasIndex(e => new { e.FullName, e.YomiFullName }, "ndx_Cover");

            entity.Property(e => e.SystemUserId).ValueGeneratedNever();
            
            entity.Property(e => e.FullName).HasMaxLength(200);
        });
        modelBuilder.HasSequence<int>("SO_currentcasenumber")
            .StartsAt(0L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("SO_currentinvoicenumber")
            .StartsAt(1000L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("SO_currentordernumber")
            .StartsAt(30877L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("SO_currentquotenumber")
            .StartsAt(50579L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("SO_NextEmailTrackingNumber")
            .StartsAt(0L)
            .HasMin(0L)
            .HasMax(9999L)
            .IsCyclic();

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
