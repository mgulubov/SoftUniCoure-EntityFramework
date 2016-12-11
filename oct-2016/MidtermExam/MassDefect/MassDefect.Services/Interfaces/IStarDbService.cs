namespace MassDefect.Services.Interfaces
{
    using System.Collections.Generic;

    public interface IStarDbService
    {
        void AddStar(IStarDto star);

        void AddStarsInRange(IEnumerable<IStarDto> stars);

        void RemoveStar(int starId);

        IStarDto GetStarById(int starId);

        IEnumerable<IStarDto> GetStarsByName(string starName);

        IEnumerable<IPlanetDto> GetPlanetsForStar(int starId);
    }
}
