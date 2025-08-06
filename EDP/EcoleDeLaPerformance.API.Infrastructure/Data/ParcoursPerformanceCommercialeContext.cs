using EcoleDeLaPerformance.API.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcoleDeLaPerformance.API.Infrastructure.Data;

public partial class ParcoursPerformanceCommercialeContext : DbContext
{
    public ParcoursPerformanceCommercialeContext()
    {
    }

    public ParcoursPerformanceCommercialeContext(DbContextOptions<ParcoursPerformanceCommercialeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brief> Briefs { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Debrief> Debriefs { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Evaluation> Evaluations { get; set; }

    public virtual DbSet<Formation> Formations { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Planning> Plannings { get; set; }

    public virtual DbSet<PlanningsTask> PlanningsTasks { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Core.Domain.Entities.Task> Tasks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UsersFormation> UsersFormations { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=ParcoursPerformanceCommerciale; Integrated Security=True; TrustServerCertificate=True;");
        //=> optionsBuilder.UseSqlServer("Server=XFISRVSQLPREPROD; Database=ParcoursPerformanceCommerciale; Integrated Security=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brief>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__briefs__3213E83F8E97A8C8");

            entity.ToTable("briefs");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IsDraft).HasColumnName("is_draft");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.FilesToCheck)
                .HasMaxLength(255)
                .HasColumnName("files_to_check");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .HasColumnName("note");
            entity.Property(e => e.SignatureCommitment)
                .HasMaxLength(255)
                .HasColumnName("signature_commitment");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Briefs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_briefs_user");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__categori__3213E83F971B5BFD");

            entity.ToTable("categories");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Debrief>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__debriefs__3213E83F75622013");

            entity.ToTable("debriefs");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IsDraft).HasColumnName("is_draft");
            entity.Property(e => e.BusinessInProgress)
                .HasMaxLength(255)
                .HasColumnName("business_in_progress");
            entity.Property(e => e.CompletedBusiness)
                .HasMaxLength(255)
                .HasColumnName("completed_business");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Debriefs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_debriefs_user");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__document__3213E83F8CDF0AE3");

            entity.ToTable("documents");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.ContentPath)
                .HasMaxLength(255)
                .HasColumnName("content_path");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Category).WithMany(p => p.Documents)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_documents_category");

            entity.HasOne(d => d.User).WithMany(p => p.Documents)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_documents_user");
        });

        modelBuilder.Entity<Evaluation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__evaluati__3213E83FEFDC4BB3");

            entity.ToTable("evaluations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Formation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__formatio__3213E83FF5152FEA");

            entity.ToTable("formations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Grade).WithMany(p => p.Formations)
                .HasForeignKey(d => d.GradeId)
                .HasConstraintName("FK_formations_grade");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__grades__3213E83F3D2A0444");

            entity.ToTable("grades");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Planning>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__planning__3213E83FEFD1DABD");

            entity.ToTable("plannings");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Plannings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_plannings_user");
        });

        modelBuilder.Entity<PlanningsTask>(entity =>
        {
            entity.HasKey(e => new { e.PlanningId, e.TaskId });

            entity.ToTable("plannings_tasks");

            entity.Property(e => e.PlanningId).HasColumnName("planning_id");
            entity.Property(e => e.TaskId).HasColumnName("task_id");
            entity.Property(e => e.Identifier)
               .HasMaxLength(255)
               .HasColumnName("identifier");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.TimeOfDay)
                .HasMaxLength(255)
                .HasColumnName("time_of_day");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Planning).WithMany(p => p.PlanningsTasks)
                .HasForeignKey(d => d.PlanningId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_plannings_tasks_planning");

            entity.HasOne(d => d.Task).WithMany(p => p.PlanningsTasks)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_plannings_tasks_task");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__statuses__3213E83F8BFA154D");

            entity.ToTable("statuses");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__roles__3213E83F8BFA154D");

            entity.ToTable("roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Core.Domain.Entities.Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tasks__3213E83FB9325923");

            entity.ToTable("tasks");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.Identifier)
                .HasMaxLength(255)
                .HasColumnName("identifier");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83F389B100E");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "UQ__users__AB6E616424F4F6E3").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IsFirstConnection).HasColumnName("is_first_connection");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DirectorId).HasColumnName("director_id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Entity)
                .HasMaxLength(255)
                .HasColumnName("entity");
            entity.Property(e => e.GradeId).HasColumnName("grade_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.ProfilePicturePath)
                .HasMaxLength(255)
                .HasColumnName("profile_picture_path");
            entity.Property(e => e.StartFollowUp).HasColumnName("start_follow_up");
            entity.Property(e => e.SupervisorId).HasColumnName("supervisor_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Director).WithMany(p => p.InverseDirector)
                .HasForeignKey(d => d.DirectorId)
                .HasConstraintName("FK_users_director");

            entity.HasOne(d => d.Grade).WithMany(p => p.Users)
                .HasForeignKey(d => d.GradeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_users_grade");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_users_role");

            entity.HasOne(d => d.Supervisor).WithMany(p => p.InverseSupervisor)
                .HasForeignKey(d => d.SupervisorId)
                .HasConstraintName("FK_users_supervisor");
        });

        modelBuilder.Entity<UsersFormation>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.FormationId });

            entity.ToTable("users_formations");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.FormationId).HasColumnName("formation_id");
            entity.Property(e => e.Comment)
                .HasMaxLength(255)
                .HasColumnName("comment");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.DocumentId).HasColumnName("document_id");
            entity.Property(e => e.EvaluationId).HasColumnName("evaluation_id");
            entity.Property(e => e.IsValidated).HasColumnName("is_validated");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Document).WithMany(p => p.UsersFormations)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_users_formations_document");

            entity.HasOne(d => d.Evaluation).WithMany(p => p.UsersFormations)
                .HasForeignKey(d => d.EvaluationId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_users_formations_evaluation");

            entity.HasOne(d => d.Formation).WithMany(p => p.UsersFormations)
                .HasForeignKey(d => d.FormationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_users_formations_formation");

            entity.HasOne(d => d.Status).WithMany(p => p.UsersFormations)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_users_formations_status");

            entity.HasOne(d => d.User).WithMany(p => p.UsersFormations)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_users_formations_user");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
