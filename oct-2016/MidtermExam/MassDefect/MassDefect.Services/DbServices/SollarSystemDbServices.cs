namespace MassDefect.Services.DbServices
{
    using System.Collections.Generic;
    using System.Linq;

    using Data.Interfaces;
    using Models;
    using DTOs;
    using Interfaces;

    public class SollarSystemDbServices : ISollarSystemDbService
    {
        private readonly IDbUnitOfWork unitOfWork;

        public SollarSystemDbServices(IDbUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public void AddSollarSystem(ISollarSystemDto sollarSystemToAdd)
        {
            SolarSystem sollarSystem = new SolarSystem()
            {
                Name = sollarSystemToAdd.Name
            };

            this.unitOfWork.SolarSystemsDbRepository.Add(sollarSystem);
        }

        public void AddSollarSystemsInRange(IEnumerable<ISollarSystemDto> sollarSystemsToAdd)
        {
            IList<SolarSystem> sollarSystemTableEntries = new List<SolarSystem>();

            sollarSystemsToAdd = sollarSystemsToAdd.ToList();
            foreach (ISollarSystemDto solarSystem in sollarSystemsToAdd)
            {
                SolarSystem sollarSystemEntry = new SolarSystem()
                {
                    Name = solarSystem.Name
                };

                sollarSystemTableEntries.Add(sollarSystemEntry);
            }

            this.unitOfWork.SolarSystemsDbRepository.AddRange(sollarSystemTableEntries);
        }

        public void RemoveSollarSystem(int id)
        {
            this.unitOfWork.SolarSystemsDbRepository.Remove(id);
        }

        public ISollarSystemDto GetSollarSystemById(int id)
        {
            SolarSystem sollarSystem = this.unitOfWork.SolarSystemsDbRepository.Find(id);

            ISollarSystemDto sollarSystemDto = new SollarSystemDto()
            {
                Id = sollarSystem.Id,
                Name = sollarSystem.Name,
            };

            return sollarSystemDto;
        }

        public IEnumerable<ISollarSystemDto> GetSollarSystemByName(string name)
        {
            IList<SolarSystem> sollarSystems =
                this.unitOfWork.SolarSystemsDbRepository.GetAll(ss => ss.Name == name).ToList();

            IList<ISollarSystemDto> sollarSystemDtos = new List<ISollarSystemDto>(sollarSystems.Count());
            foreach (SolarSystem sollarSystem in sollarSystems)
            {
                ISollarSystemDto sollarSystemDto = new SollarSystemDto()
                {
                    Id = sollarSystem.Id,
                    Name = sollarSystem.Name
                };

                sollarSystemDtos.Add(sollarSystemDto);
            }

            return sollarSystemDtos;
        }

        public IEnumerable<IStarDto> GetStarsInSollarSystem(int sollarSystemId)
        {
            IList<Star> stars = this.unitOfWork.StarsDbRepository.GetAll(s => s.SollarSystemId == sollarSystemId).ToList();

            IList<IStarDto> starDtos = new List<IStarDto>(stars.Count);
            foreach (Star star in stars)
            {
                IStarDto starDto = new StarDto()
                {
                    Id = star.Id,
                    Name = star.Name,
                    SollarSystemId = star.SollarSystemId
                };

                starDtos.Add(starDto);
            }

            return starDtos;
        }

        public IEnumerable<IPlanetDto> GetPlanetsInSollarSystem(int sollarSystemId)
        {
            IList<Planet> planets =
                this.unitOfWork.PlanetsDbRepository.GetAll(p => p.SollarSystemId == sollarSystemId).ToList();

            IList<IPlanetDto> planetDtos = new List<IPlanetDto>(planets.Count);
            foreach (Planet planet in planets)
            {
                IPlanetDto planetDto = new PlanetDto()
                {
                    Id = planet.Id,
                    Name = planet.Name,
                    SolarSystemId = planet.SollarSystemId,
                    SunId = planet.SunId,
                };

                planetDtos.Add(planetDto);
            }

            return planetDtos;
        }
    }
}
