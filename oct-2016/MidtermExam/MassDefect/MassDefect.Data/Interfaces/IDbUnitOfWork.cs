namespace MassDefect.Data.Interfaces
{
    using System;

    using Models;

    public interface IDbUnitOfWork : IDisposable
    {
        IDbRepository<SolarSystem> SolarSystemsDbRepository { get; }

        IDbRepository<Star> StarsDbRepository { get; }

        IDbRepository<Planet> PlanetsDbRepository { get; }

        IDbRepository<Anomaly> AnomaliesDbRepository { get; }

        IDbRepository<Person> PersonsDbRepository { get; }

        void Commit();
    }
}
