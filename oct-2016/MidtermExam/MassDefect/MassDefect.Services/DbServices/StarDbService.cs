namespace MassDefect.Services.DbServices
{
    using System.Collections.Generic;
    using System.Linq;

    using Data.Interfaces;
    using Models;
    using DTOs;
    using Interfaces;

    public class StarDbService : IStarDbService
    {
        private readonly IDbUnitOfWork unitOfWork;

        public StarDbService(IDbUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddStar(IStarDto star)
        {
            int sollarSystemId;
            if (star.SollarSystemId == null)
            {
                sollarSystemId =
                    this.unitOfWork.SolarSystemsDbRepository.GetAll(ss => ss.Name == star.SolarSystem).First().Id;
            }
            else
            {
                sollarSystemId = int.Parse(star.SollarSystemId.ToString());
            }

            Star starEntity = new Star()
            {
                Name = star.Name,
                SollarSystemId = sollarSystemId
            };

            this.unitOfWork.StarsDbRepository.Add(starEntity);
        }

        public void AddStarsInRange(IEnumerable<IStarDto> stars)
        {
            IList<Star> starEntities = new List<Star>();

            IList<IStarDto> starDtos = stars.ToList();
            foreach (IStarDto starDto in starDtos)
            {
                int? sollarSystemId;
                if (starDto.SollarSystemId == null)
                {
                    SolarSystem sollarSystem =
                        this.unitOfWork.SolarSystemsDbRepository.GetAll(ss => ss.Name == starDto.SolarSystem)
                            .FirstOrDefault();
                    if (sollarSystem == default(SolarSystem))
                    {
                        sollarSystemId = null;
                    }
                    else
                    {
                        sollarSystemId = sollarSystem.Id;
                    }
                }
                else
                {
                    sollarSystemId = int.Parse(starDto.SollarSystemId.ToString());
                }

                Star starEntity = new Star()
                {
                    Name = starDto.Name,
                    SollarSystemId = sollarSystemId
                };

                starEntities.Add(starEntity);
            }

            this.unitOfWork.StarsDbRepository.AddRange(starEntities);
        }

        public void RemoveStar(int starId)
        {
            this.unitOfWork.StarsDbRepository.Remove(starId);
        }

        public IStarDto GetStarById(int starId)
        {
            Star star = this.unitOfWork.StarsDbRepository.Find(starId);

            IStarDto starDto = new StarDto()
            {
                Id = star.Id,
                Name = star.Name,
                SollarSystemId = star.SollarSystemId
            };

            return starDto;
        }

        public IEnumerable<IStarDto> GetStarsByName(string starName)
        {
            IList<Star> stars = this.unitOfWork.StarsDbRepository.GetAll(s => s.Name == starName).ToList();
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

        public IEnumerable<IPlanetDto> GetPlanetsForStar(int starId)
        {
            IList<Planet> planets = this.unitOfWork.PlanetsDbRepository.GetAll(p => p.SunId == starId).ToList();
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
