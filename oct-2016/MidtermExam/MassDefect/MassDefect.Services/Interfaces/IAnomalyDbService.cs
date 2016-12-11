namespace MassDefect.Services.Interfaces
{
    using System.Collections.Generic;

    public interface IAnomalyDbService
    {
        void AddAnomaly(IAnomalyDto anomaly);

        void AddAnomaliesInRange(IEnumerable<IAnomalyDto> anomalies);

        void RemoveAnomaly(int anomalyId);

        IAnomalyDto GetAnomalyById(int anomalyId);

        IEnumerable<IPersonDto> GetAnomalyVictims(int anomalyId);
    }
}
