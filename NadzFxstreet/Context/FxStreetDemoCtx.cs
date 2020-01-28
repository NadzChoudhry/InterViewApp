namespace Demo.PersistenceLayer
{
    using Demo.PersistenceLayer.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using System.IO;

    public class FxStreetDemoCtx : DbContext
    {
        public FxStreetDemoCtx()
        {
        }

        public FxStreetDemoCtx(DbContextOptions<FxStreetDemoCtx> options)
       : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("FxStreetDemoCtx");
                optionsBuilder.UseSqlServer(connectionString);
                optionsBuilder.UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }



        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<Referee> Refrees { get; set; }
        public virtual DbSet<PlayersOfMatch> PlayersOfMatch { get; set; }
        public virtual DbSet<Team> Teams { get; set; }


    }

}