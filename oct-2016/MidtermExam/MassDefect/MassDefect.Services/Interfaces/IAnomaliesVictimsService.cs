namespace MassDefect.Services.Interfaces
{
    using System.Collections.Generic;

    public interface IAnomaliesVictimsService
    {
        void AddRecord(IAnomaliesVictimsDto record);

        void AddRecordsInRange(IEnumerable<IAnomaliesVictimsDto> records);
    }
}
