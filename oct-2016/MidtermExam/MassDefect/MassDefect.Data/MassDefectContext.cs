namespace MassDefect.Data
{
    using System.Data.Entity;

    using Models;

    public class MassDefectContext : DbContext
    {
        public MassDefectContext()
            : base("name=MassDefectContext")
        {
        }

        public virtual DbSet<SolarSystem> SolarSystems { get; set; }

        public virtual DbSet<Star> Stars { get; set; }

        public virtual DbSet<Planet> Planets { get; set; }

        public virtual DbSet<Person> Persons { get; set; }

        public virtual DbSet<Anomaly> Anomalies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anomaly>()
                .HasRequired(a => a.OriginPlanet)
                .WithMany(p => p.HomePlanetAnomalies)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Anomaly>()
                .HasRequired(a => a.TeleportPlanet)
                .WithMany(p => p.TeleportedAnomalies)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Anomaly>()
                .HasMany<Person>(a => a.Victims)
                .WithMany(p => p.Anomalies)
                .Map(av =>
                        {
                            av.MapLeftKey("AnomalyId");
                            av.MapRightKey("PersonId");
                            av.ToTable("AnomalyVictims");
                        });

            modelBuilder.Entity<Star>()
                .HasOptional(s => s.SolarSystem)
                .WithMany(ss => ss.Stars)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}