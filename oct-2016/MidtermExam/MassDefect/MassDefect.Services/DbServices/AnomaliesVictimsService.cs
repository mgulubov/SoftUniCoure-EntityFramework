namespace MassDefect.Services.DbServices
{
    using System.Collections.Generic;
    using System.Linq;

    using Data.Interfaces;
    using Models;
    using Interfaces;

    public class AnomaliesVictimsService : IAnomaliesVictimsService
    {
        private readonly IDbUnitOfWork unitOfWork;

        public AnomaliesVictimsService(IDbUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddRecord(IAnomaliesVictimsDto record)
        {
            Anomaly anomaly = this.unitOfWork.AnomaliesDbRepository.Find(record.Id);
            Person person = this.unitOfWork.PersonsDbRepository.First(p => p.Name == record.Person);

            anomaly.Victims.Add(person);
            person.Anomalies.Add(anomaly);
        }

        public void AddRecordsInRange(IEnumerable<IAnomaliesVictimsDto> records)
        {
            IList<IAnomaliesVictimsDto> recordDtos = records.ToList();
            foreach (IAnomaliesVictimsDto recordDto in recordDtos)
            {
                Anomaly anomaly = this.unitOfWork.AnomaliesDbRepository.Find(recordDto.Id);
                Person person = this.unitOfWork.PersonsDbRepository.First(p => p.Name == recordDto.Person);

                anomaly.Victims.Add(person);
                person.Anomalies.Add(anomaly);
            }
        }
    }
}
