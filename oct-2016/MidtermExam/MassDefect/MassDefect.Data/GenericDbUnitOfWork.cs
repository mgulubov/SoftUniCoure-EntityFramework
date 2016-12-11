namespace MassDefect.Data
{
    using System;

    using Interfaces;
    using Models;

    public class GenericDbUnitOfWork : IDbUnitOfWork
    {
        private readonly MassDefectContext dbContext;

        private IDbRepository<SolarSystem> solarSystemsDbRepository;
        private IDbRepository<Star> starsDbRepository;
        private IDbRepository<Planet> planetsDbRepository;
        private IDbRepository<Anomaly> anomaliesDbRepository;
        private IDbRepository<Person> personsDbRepository;

        private bool isDisposed;

        public GenericDbUnitOfWork()
        {
            this.dbContext = new MassDefectContext();
            this.isDisposed = false;
        }

        public IDbRepository<SolarSystem> SolarSystemsDbRepository
            =>
                this.solarSystemsDbRepository ??
                (this.solarSystemsDbRepository = new GenericDbRepository<SolarSystem>(this.dbContext));

        public IDbRepository<Star> StarsDbRepository
            => this.starsDbRepository ?? (this.starsDbRepository = new GenericDbRepository<Star>(this.dbContext));

        public IDbRepository<Planet> PlanetsDbRepository
            => this.planetsDbRepository ?? (this.planetsDbRepository = new GenericDbRepository<Planet>(this.dbContext));

        public IDbRepository<Anomaly> AnomaliesDbRepository
            =>
                this.anomaliesDbRepository ??
                (this.anomaliesDbRepository = new GenericDbRepository<Anomaly>(this.dbContext));

        public IDbRepository<Person> PersonsDbRepository
            => this.personsDbRepository ?? (this.personsDbRepository = new GenericDbRepository<Person>(this.dbContext));

        public void Commit()
        {
            this.dbContext.SaveChanges();
        }

        public void Dispose(bool isDisposing)
        {
            if (!this.isDisposed)
                if (isDisposing)
                {
                    this.dbContext.Dispose();
                }

            this.isDisposed = true;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
