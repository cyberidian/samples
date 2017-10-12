namespace AtomicArcade.DataModels
{
    using System.Data.Entity;
    using AtomicArcade.DataModels;
    using AtomicArcade.DataModels.Content;
    using AtomicArcade.DataModels.LookupModels;
    using AtomicArcade.DataModels.Portal.Ads;
    using AtomicArcade.DataModels.Portal;


    public partial class AADbContext : DbContext
    {
        public AADbContext()
            : base("name=AADatabase")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<GameCategory> GameCategories { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<AdCycle> AdCycles { get; set; }
        public virtual DbSet<FeatureCycle> FeatureCycles { get; set; }
        public virtual DbSet<AdCategory> AdCategories { get; set; }
        public virtual DbSet<AdClient> AdClients { get; set; }
        public virtual DbSet<Ad> Ads { get; set; }
        public virtual DbSet<Configuration> Configurations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.BannerGraphicFile)
                .IsUnicode(false);

            modelBuilder.Entity<Game>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Game>()
                .Property(e => e.Link)
                .IsUnicode(false);

            modelBuilder.Entity<Game>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Game>()
                .Property(e => e.Graphic400x200)
                .IsUnicode(false);

            modelBuilder.Entity<Game>()
                .Property(e => e.Graphic200x100)
                .IsUnicode(false);

            modelBuilder.Entity<Game>()
                .Property(e => e.Graphic100x100)
                .IsUnicode(false);

            modelBuilder.Entity<Game>()
                .Property(e => e.TechNotes)
                .IsUnicode(false);

            modelBuilder.Entity<Game>()
                .Property(e => e.Developer)
                .IsUnicode(false);

            modelBuilder.Entity<AdCycle>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<FeatureCycle>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<AdCategory>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<AdCategory>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<AdCategory>()
                .Property(e => e.BannerGraphicFile)
                .IsUnicode(false);

            modelBuilder.Entity<AdClient>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<AdClient>()
                .Property(e => e.Organization)
                .IsUnicode(false);

            modelBuilder.Entity<Ad>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Ad>()
                .Property(e => e.Link)
                .IsUnicode(false);

            modelBuilder.Entity<Ad>()
                .Property(e => e.BannerGraphicFile)
                .IsUnicode(false);
        }
    }
}
