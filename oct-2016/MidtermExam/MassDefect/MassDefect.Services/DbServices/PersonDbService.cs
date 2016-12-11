namespace MassDefect.Services.DbServices
{
    using System.Collections.Generic;
    using System.Linq;

    using Data.Interfaces;
    using Models;
    using DTOs;
    using Interfaces;

    public class PersonDbService : IPersonDbService
    {
        private readonly IDbUnitOfWork unitOfWork;

        public PersonDbService(IDbUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddPerson(IPersonDto person)
        {
            int homePlanetId;
            if (person.HomePlanetId == null)
            {
                homePlanetId = this.unitOfWork.PlanetsDbRepository.First(p => p.Name == person.HomePlanet).Id;
            }
            else
            {
                homePlanetId = int.Parse(person.HomePlanetId.ToString());
            }

            Person personEntity = new Person()
            {
                Name = person.Name,
                HomePlanetId = homePlanetId
            };

            this.unitOfWork.PersonsDbRepository.Add(personEntity);
        }

        public void AddPersonsInRange(IEnumerable<IPersonDto> persons)
        {
            IList<IPersonDto> personDtos = persons.ToList();
            IList<Person> personEntities = new List<Person>(personDtos.Count);

            foreach (IPersonDto personDto in personDtos)
            {
                int homePlanetId;
                if (personDto.HomePlanetId == null)
                {
                    homePlanetId = this.unitOfWork.PlanetsDbRepository.First(p => p.Name == personDto.HomePlanet).Id;
                }
                else
                {
                    homePlanetId = int.Parse(personDto.HomePlanetId.ToString());
                }

                Person personEntity = new Person()
                {
                    Name = personDto.Name,
                    HomePlanetId = homePlanetId
                };

                personEntities.Add(personEntity);
            }

            this.unitOfWork.PersonsDbRepository.AddRange(personEntities);
        }

        public void RemovePerson(int personId)
        {
            this.unitOfWork.PersonsDbRepository.Remove(personId);
        }

        public IPersonDto GetPersonById(int personId)
        {
            Person person = this.unitOfWork.PersonsDbRepository.Find(personId);
            IPersonDto personDto = new PersonDto()
            {
                Id = person.Id,
                Name = person.Name,
                HomePlanetId = person.HomePlanetId
            };

            return personDto;
        }

        public IEnumerable<IPersonDto> GetPersonsByName(string personName)
        {
            IList<Person> persons = this.unitOfWork.PersonsDbRepository.GetAll(p => p.Name == personName).ToList();
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

        public IEnumerable<IAnomalyDto> GetPersonAnomalies(int personId)
        {
            Person person = this.unitOfWork.PersonsDbRepository.Find(personId);
            IList<Anomaly> anomalies = person.Anomalies.ToList();
            IList<IAnomalyDto> anomaliDtos = new List<IAnomalyDto>(anomalies.Count);

            foreach (Anomaly anomaly in anomalies)
            {
                IAnomalyDto anomalyDto = new AnomalyDto()
                {
                    Id = anomaly.Id,
                    OriginPlanetId = anomaly.OriginPlanetId,
                    TeleportPlanetId = anomaly.TeleportPlanetId
                };

                anomaliDtos.Add(anomalyDto);
            }

            return anomaliDtos;
        }
    }
}
