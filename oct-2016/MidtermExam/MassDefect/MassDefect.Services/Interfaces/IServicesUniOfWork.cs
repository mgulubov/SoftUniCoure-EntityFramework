namespace MassDefect.Services.Interfaces
{
    public interface IServicesUniOfWork
    {
        ISollarSystemDbService SollarSystemDbService { get; }

        IStarDbService StarDbService { get; }

        IPlanetDbService PlanetDbService { get; }

        IAnomalyDbService AnomalyDbService { get; }

        IPersonDbService PersonDbService { get; }

        IAnomaliesVictimsService AnomaliesVictimsDbService { get; }

        void UpdateDb();
    }
}
