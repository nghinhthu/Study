using LiveSport.Models;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LiveSport.Data
{
    public partial class FootballDbContext : DbContext
    {
        public FootballDbContext()
        {
        }

        public FootballDbContext(DbContextOptions<FootballDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Match>(entity =>
            {
                entity.HasOne(d => d.Team1Navigation)
                    .WithMany(p => p.MatchTeam1Navigations)
                    .HasForeignKey(d => d.Team1);
                // .HasConstraintName("FK_Matches_Team1_Teams_Id");

                entity.HasOne(d => d.Team2Navigation)
                    .WithMany(p => p.MatchTeam2Navigations)
                    .HasForeignKey(d => d.Team2);
                // .HasConstraintName("FK_Matches_Team2_Teams_Id");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.Property(e => e.Logo).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
