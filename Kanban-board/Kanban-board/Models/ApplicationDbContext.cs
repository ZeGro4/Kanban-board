using Kanban_board.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Kanban_board.Models
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {

        public DbSet<Project> Projects => Set<Project>();
        public DbSet<ApplicationUser> ApplicationUsers => Set<ApplicationUser>();
        public DbSet<Board> Boards => Set<Board>();

        public DbSet<BoardTask> BoardTasks => Set<BoardTask>();


        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options) { 
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>(entity =>
            {

                entity.HasMany(u => u.Projects)
                      .WithMany(p => p.ApplicationUsers)
                      .UsingEntity<UserProject>(up =>
                      {
                          up
                             .HasOne(up => up.ApplicationUsers)
                             .WithMany(u => u.UserProjects)
                             .HasForeignKey(up => up.UserId);
                          up
                            .HasOne(up => up.Project)
                            .WithMany(p => p.UserProjects)
                            .HasForeignKey(up => up.ProjectId);

                          up
                            .HasKey(up => new { up.UserId, up.ProjectId });
                          up
                            .ToTable("UserProject");

                          up.Property(up => up.RoleName)
                            .HasConversion<string>()
                            .HasMaxLength(50);
                      }         

                      );

            });

            builder.Entity<Project>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name)
                      .HasMaxLength(50);

                entity.Property(p=> p.Description)
                      .HasMaxLength(1000);

                entity.HasOne(p => p.CreatedUser)
                       .WithMany(u=> u.CreatedProjects)
                       .HasForeignKey(p => p.CreatedByUserId);

            });

            builder.Entity<Board>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.HasOne(b=> b.Project)
                      .WithMany(p=> p.Boards)
                      .HasForeignKey(b=> b.ProjectId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.Property(b => b.Name)
                       .IsRequired();

            });

            builder.Entity<BoardTask>(entity =>
            {
                entity.HasKey(bt => bt.Id);
                entity.Property(bt => bt.Comments)
                       .HasMaxLength(1500);

                entity.HasOne(b => b.UserCreator)
                       .WithMany(u => u.CreatedBoardTasks)
                       .HasForeignKey(b=> b.UserCreatorId);

                entity.HasOne(b=> b.UserExecutor)
                       .WithMany(u=> u.ExecutTasks)
                       .HasForeignKey(b=> b.UserExecutorId);

            });
                
        }
    }
}
