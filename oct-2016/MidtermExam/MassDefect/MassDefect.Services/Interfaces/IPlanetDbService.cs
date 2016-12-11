namespace MassDefect.Services.Interfaces
{
    using System.Collections.Generic;

    public interface IPlanetDbService
    {
        void AddPlanet(IPlanetDto planet);

        void AddPlanetsInRange(IEnumerable<IPlanetDto> planets);

        void RemovePlanet(int id);

        IPlanetDto GetPlanetById(int planetId);

        IEnumerable<IPlanetDto> GetPlanetsByName(string name);

        IEnumerable<IPersonDto> GetPersonsOnPlanet(int planetId);

        IEnumerable<IAnomalyDto> GetAnomaliesWithHomePlanet(int planetId);

        IEnumerable<IAnomalyDto> GetAnomaliesThatTeleportTo(int planetId);
    }
}
