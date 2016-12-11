namespace MassDefect.Services.DbServices
{
    using System.Collections.Generic;
    using System.Linq;

    using Data.Interfaces;
    using Models;
    using DTOs;
    using Interfaces;

    public class PlanetDbService : IPlanetDbService
    {
        private readonly IDbUnitOfWork unitOfWork;

        public PlanetDbService(IDbUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddPlanet(IPlanetDto planet)
        {
            int? sollarSystemId;
            int? sunId;

            if (planet.SolarSystemId == null)
            {
                SolarSystem solarSystem =
                    this.unitOfWork.SolarSystemsDbRepository.First(ss => ss.Name == planet.SolarSystem);
                if (solarSystem == default(SolarSystem))
                {
                    sollarSystemId = null;
                }
                else
                {
                    sollarSystemId = solarSystem.Id;
                }
            }
            else
            {
                sollarSystemId = planet.SolarSystemId;
            }

            if (planet.SunId == null)
            {
                Star star = this.unitOfWork.StarsDbRepository.First(s => s.Name == planet.Sun);
                if (star == default(Star))
                {
                    sunId = null;
                }
                else
                {
                    sunId = star.Id;
                }
            }
            else
            {
                sunId = planet.SunId;
            }

            Planet planetEntity = new Planet()
            {
                Name = planet.Name,
                SollarSystemId = sollarSystemId,
                SunId = sunId
            };

            this.unitOfWork.PlanetsDbRepository.Add(planetEntity);
        }

        public void AddPlanetsInRange(IEnumerable<IPlanetDto> planets)
        {
            IList<IPlanetDto> planetDtos = planets.ToList();
            IList<Planet> planetEntities = new List<Planet>(planetDtos.Count);

            foreach (IPlanetDto planetDto in planetDtos)
            {
                int? sollarSystemId;
                int? sunId;

                if (planetDto.SolarSystemId == null)
                {
                    SolarSystem solarSystem =
                        this.unitOfWork.SolarSystemsDbRepository.First(ss => ss.Name == planetDto.SolarSystem);
                    if (solarSystem == default(SolarSystem))
                    {
                        sollarSystemId = null;
                    }
                    else
                    {
                        sollarSystemId = solarSystem.Id;
                    }
                }
                else
                {
                    sollarSystemId = planetDto.SolarSystemId;
                }

                if (planetDto.SunId == null)
                {
                    Star star = this.unitOfWork.StarsDbRepository.First(s => s.Name == planetDto.Sun);
                    if (star == default(Star))
                    {
                        sunId = null;
                    }
                    else
                    {
                        sunId = star.Id;
                    }
                }
                else
                {
                    sunId = planetDto.SunId;
                }

                Planet planetEntity = new Planet()
                {
                    Name = planetDto.Name,
                    SollarSystemId = sollarSystemId,
                    SunId = sunId
                };

                planetEntities.Add(planetEntity);
            }

            this.unitOfWork.PlanetsDbRepository.AddRange(planetEntities);
        }

        public void RemovePlanet(int id)
        {
            this.unitOfWork.PlanetsDbRepository.Remove(id);
        }

        public IPlanetDto GetPlanetById(int planetId)
        {
            Planet planet = this.unitOfWork.PlanetsDbRepository.Find(planetId);
            IPlanetDto planetDto = new PlanetDto()
            {
                Id = planet.Id,
                Name = planet.Name,
                SolarSystemId = planet.SollarSystemId,
                SunId = planet.SunId
            };

            return planetDto;
        }

        public IEnumerable<IPlanetDto> GetPlanetsByName(string name)
        {
            IList<Planet> planets = this.unitOfWork.PlanetsDbRepository.GetAll(p => p.Name == name).ToList();
            IList<IPlanetDto> planetDtos = new List<IPlanetDto>(planets.Count);

            foreach (Planet planet in planets)
            {
                IPlanetDto planetDto = new PlanetDto()
                {
                    Id = planet.Id,
                    Name = planet.Name,
                    SolarSystemId = planet.SollarSystemId,
                    SunId = planet.SunId
                };

                planetDtos.Add(planetDto);
            }

            return planetDtos;
        }

        public IEnumerable<IPersonDto> GetPersonsOnPlanet(int planetId)
        {
            IList<Person> persons = this.unitOfWork.PersonsDbRepository.GetAll(p => p.HomePlanetId == planetId).ToList();
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

        public IEnumerable<IAnomalyDto> GetAnomaliesWithHomePlanet(int planetId)
        {
            IList<Anomaly> anomalies =
                this.unitOfWork.AnomaliesDbRepository.GetAll(a => a.OriginPlanetId == planetId).ToList();
            IList<IAnomalyDto> anomalyDtos = new List<IAnomalyDto>(anomalies.Count);

            foreach (Anomaly anomaly in anomalies)
            {
                IAnomalyDto anomalyDto = new AnomalyDto()
                {
                    Id = anomaly.Id,
                    OriginPlanetId = anomaly.OriginPlanetId,
                    TeleportPlanetId = anomaly.TeleportPlanetId
                };

                anomalyDtos.Add(anomalyDto);
            }

            return anomalyDtos;
        }

        public IEnumerable<IAnomalyDto> GetAnomaliesThatTeleportTo(int planetId)
        {
            IList<Anomaly> anomalies =
                this.unitOfWork.AnomaliesDbRepository.GetAll(a => a.TeleportPlanetId == planetId).ToList();
            IList<IAnomalyDto> anomalyDtos = new List<IAnomalyDto>(anomalies.Count);

            foreach (Anomaly anomaly in anomalies)
            {
                IAnomalyDto anomalyDto = new AnomalyDto()
                {
                    Id = anomaly.Id,
                    OriginPlanetId = anomaly.OriginPlanetId,
                    TeleportPlanetId = anomaly.TeleportPlanetId
                };

                anomalyDtos.Add(anomalyDto);
            }

            return anomalyDtos;
        }
    }
}
