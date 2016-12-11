namespace MassDefect.Services
{
    using Data;
    using Data.Interfaces;
    using DbServices;
    using Interfaces;

    public class ServicesUnitOfWork : IServicesUniOfWork
    {
        private static IServicesUniOfWork instance;

        private readonly IDbUnitOfWork dbUnitOfWork;

        private ISollarSystemDbService sollarSystemDbService;
        private IStarDbService starDbService;
        private IPlanetDbService planetDbService;
        private IAnomalyDbService anomalyDbService;
        private IPersonDbService personDbService;
        private IAnomaliesVictimsService anomaliesVictimsDbService;

        private ServicesUnitOfWork()
        {
            this.dbUnitOfWork = new GenericDbUnitOfWork();
        }

        public static IServicesUniOfWork GetInstance
        {
            get
            {
                if (instance == default(ServicesUnitOfWork))
                {
                    instance = new ServicesUnitOfWork();
                }

                return instance;
            }
        }

        public ISollarSystemDbService SollarSystemDbService
            =>
                this.sollarSystemDbService ??
                (this.sollarSystemDbService = new SollarSystemDbServices(this.dbUnitOfWork));

        public IStarDbService StarDbService
            => this.starDbService ?? (this.starDbService = new StarDbService(this.dbUnitOfWork));

        public IPlanetDbService PlanetDbService
            => this.planetDbService ?? (this.planetDbService = new PlanetDbService(this.dbUnitOfWork));

        public IAnomalyDbService AnomalyDbService
            => this.anomalyDbService ?? (this.anomalyDbService = new AnomalyDbService(this.dbUnitOfWork));

        public IPersonDbService PersonDbService
            => this.personDbService ?? (this.personDbService = new PersonDbService(this.dbUnitOfWork));

        public IAnomaliesVictimsService AnomaliesVictimsDbService
            =>
                this.anomaliesVictimsDbService ??
                (this.anomaliesVictimsDbService = new AnomaliesVictimsService(this.dbUnitOfWork));

        public void UpdateDb()
        {
            this.dbUnitOfWork.Commit();
        }
    }
}
