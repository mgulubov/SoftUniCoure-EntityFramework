namespace MassDefect.Services.Interfaces
{
    using System.Collections.Generic;

    public interface IPersonDbService
    {
        void AddPerson(IPersonDto person);

        void AddPersonsInRange(IEnumerable<IPersonDto> persons);

        void RemovePerson(int personId);

        IPersonDto GetPersonById(int personId);

        IEnumerable<IPersonDto> GetPersonsByName(string personName);

        IEnumerable<IAnomalyDto> GetPersonAnomalies(int personId);
    }
}
