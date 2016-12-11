namespace MassDefect.Services.DbServices
{
    using System.Collections.Generic;
    using System.Linq;

    using Data.Interfaces;
    using Models;
    using DTOs;
    using Interfaces;

    public class AnomalyDbService : IAnomalyDbService
    {
        private readonly IDbUnitOfWork unitOfWork;

        public AnomalyDbService(IDbUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddAnomaly(IAnomalyDto anomaly)
        {
            int originPlanetId;
            int teleportPlanetId;

            if (anomaly.OriginPlanetId == null)
            {
                originPlanetId = this.unitOfWork.PlanetsDbRepository.First(p => p.Name == anomaly.OriginPlanet).Id;
            }
            else
            {
                originPlanetId = int.Parse(anomaly.OriginPlanetId.ToString());
            }

            if (anomaly.TeleportPlanetId == null)
            {
                teleportPlanetId = this.unitOfWork.PlanetsDbRepository.First(p => p.Name == anomaly.TeleportPlanet).Id;
            }
            else
            {
                teleportPlanetId = int.Parse(anomaly.TeleportPlanetId.ToString());
            }

            Anomaly anomalyEntity = new Anomaly()
            {
                OriginPlanetId = originPlanetId,
                TeleportPlanetId = teleportPlanetId
            };

            this.unitOfWork.AnomaliesDbRepository.Add(anomalyEntity);
        }

        public void AddAnomaliesInRange(IEnumerable<IAnomalyDto> anomalies)
        {
            IList<IAnomalyDto> anomalyDtos = anomalies.ToList();
            IList<Anomaly> anomalyEntities = new List<Anomaly>(anomalyDtos.Count);

            foreach (IAnomalyDto anomalyDto in anomalyDtos)
            {
                int originPlanetId;
                int teleportPlanetId;

                if (anomalyDto.OriginPlanetId == null)
                {
                    originPlanetId = this.unitOfWork.PlanetsDbRepository.First(p => p.Name == anomalyDto.OriginPlanet).Id;
                }
                else
                {
                    originPlanetId = int.Parse(anomalyDto.OriginPlanetId.ToString());
                }

                if (anomalyDto.TeleportPlanetId == null)
                {
                    teleportPlanetId = this.unitOfWork.PlanetsDbRepository.First(p => p.Name == anomalyDto.TeleportPlanet).Id;
                }
                else
                {
                    teleportPlanetId = int.Parse(anomalyDto.TeleportPlanetId.ToString());
                }

                Anomaly anomalyEntity = new Anomaly()
                {
                    OriginPlanetId = originPlanetId,
                    TeleportPlanetId = teleportPlanetId
                };

                anomalyEntities.Add(anomalyEntity);
            }

            this.unitOfWork.AnomaliesDbRepository.AddRange(anomalyEntities);
        }

        public void RemoveAnomaly(int anomalyId)
        {
            this.unitOfWork.AnomaliesDbRepository.Remove(anomalyId);
        }

        public IAnomalyDto GetAnomalyById(int anomalyId)
        {
            Anomaly anomaly = this.unitOfWork.AnomaliesDbRepository.Find(anomalyId);

            IAnomalyDto anomalyDto = new AnomalyDto()
            {
                Id = anomaly.Id,
                OriginPlanetId = anomaly.OriginPlanetId,
                TeleportPlanetId = anomaly.TeleportPlanetId
            };

            return anomalyDto;
        }

        public IEnumerable<IPersonDto> GetAnomalyVictims(int anomalyId)
        {
            Anomaly anomaly = this.unitOfWork.AnomaliesDbRepository.Find(anomalyId);
            IList<Person> persons = anomaly.Victims.ToList();
            IList<IPersonDto> personDtos = new List<IPersonDto>(persons.Count);

            foreach (Person person in persons)
            {
                IPersonDto personDto = new PersonDto()
                {
                    Id = person.Id,
                    Name = person.Name,
                    HomePlanetId = person.HomePlanetId
                };

                personDtos.Add(personDto);
            }

            return personDtos;
        }
    }
}
