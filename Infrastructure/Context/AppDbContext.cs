using Infrastructure.Configurations;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new GameTypeConfiguration()
                .Configure(modelBuilder
                .Entity<Game>());

            new AlbumTypeConfiguration()
                .Configure(modelBuilder
                .Entity<Album>());

            new SongTypeConfiguration()
                .Configure(modelBuilder
                .Entity<Song>());

            new ControlTypeConfiguration()
                .Configure(modelBuilder
                .Entity<Control>());

            new RequirementTypeConfiguration()
                .Configure(modelBuilder
                .Entity<Requirement>());

            new CompanyTypeConfiguration()
                .Configure(modelBuilder
                .Entity<Company>());

            new ModManagerTypeConfiguration()
                .Configure(modelBuilder
                .Entity<ModManager>());

            new MediaTypeConfiguration()
                .Configure(modelBuilder
                .Entity<Media>());

            new PlatformTypeConfiguration()
                .Configure(modelBuilder
                .Entity<Platform>());

            new ChapterMissionTypeConfiguration()
                .Configure(modelBuilder
                .Entity<ChapterMission>());

            new CharacterTypeConfiguration()
                .Configure(modelBuilder
                .Entity<Character>());

            new PerformanceTypeConfiguration()
                .Configure(modelBuilder
                .Entity<Performance>());

            new GenresTypeConfiguration()
                .Configure(modelBuilder
                .Entity<Genre>());

            new DLCTypeConfiguration()
                .Configure(modelBuilder
                .Entity<DLC>());
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Control> Controls { get; set; }
        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<ModManager> ModManagers { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<ChapterMission> ChapterMissions { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Performance> Performances { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<DLC> DLCs { get; set; }
    }
}