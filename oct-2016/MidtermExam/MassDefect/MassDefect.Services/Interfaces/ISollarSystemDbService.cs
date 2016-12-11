namespace MassDefect.Services.Interfaces
{
    using System.Collections.Generic;

    public interface ISollarSystemDbService
    {
        void AddSollarSystem(ISollarSystemDto sollarSystemToAdd);

        void AddSollarSystemsInRange(IEnumerable<ISollarSystemDto> sollarSystemsToAdd);

        void RemoveSollarSystem(int id);

        ISollarSystemDto GetSollarSystemById(int id);

        IEnumerable<ISollarSystemDto> GetSollarSystemByName(string name);

        IEnumerable<IStarDto> GetStarsInSollarSystem(int sollarSystemId);

        IEnumerable<IPlanetDto> GetPlanetsInSollarSystem(int sollarSystemId);
    }
}
