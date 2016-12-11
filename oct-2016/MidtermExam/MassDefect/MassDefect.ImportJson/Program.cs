namespace MassDefect.ImportJson
{
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;

    using Services;
    using Services.DTOs;
    using Services.Interfaces;

    public class Program
    {
        private static readonly string SollarSystemJsonFilePath = @"../../../ImportData/solar-systems.json";
        private static readonly string StarJsonFilePath = @"../../../ImportData/stars.json";
        private static readonly string PlanetJsonFilePath = @"../../../ImportData/planets.json";
        private static readonly string AnomalyJsonFilePath = @"../../../ImportData/anomalies.json";
        private static readonly string PersonJsonFilePath = @"../../../ImportData/persons.json";
        private static readonly string AnomaliesVictomsJsonFilePath = @"../../../ImportData/anomaly-victims.json";

        static void Main(string[] args)
        {
            IServicesUniOfWork unitOfWork = ServicesUnitOfWork.GetInstance;

            //ImportSollarSystems(unitOfWork);
            //ImportStars(unitOfWork);
            //ImportPlanets(unitOfWork);
            //ImportAnomalies(unitOfWork);
            //ImportPersons(unitOfWork);
            ImportAnomaliesVictims(unitOfWork);
        }

        private static void ImportSollarSystems(IServicesUniOfWork unitOfWork)
        {
            string json = File.ReadAllText(SollarSystemJsonFilePath);
            IEnumerable<ISollarSystemDto> sollarSystems = JsonConvert.DeserializeObject<IEnumerable<SollarSystemDto>>(json);

            unitOfWork.SollarSystemDbService.AddSollarSystemsInRange(sollarSystems);
            unitOfWork.UpdateDb();
        }

        private static void ImportStars(IServicesUniOfWork unitOfWork)
        {
            string json = File.ReadAllText(StarJsonFilePath);

            IEnumerable<IStarDto> stars = JsonConvert.DeserializeObject<IEnumerable<StarDto>>(json);

            unitOfWork.StarDbService.AddStarsInRange(stars);
            unitOfWork.UpdateDb();
        }

        private static void ImportPlanets(IServicesUniOfWork unitOfWork)
        {
            string json = File.ReadAllText(PlanetJsonFilePath);

            IEnumerable<IPlanetDto> planets = JsonConvert.DeserializeObject<IEnumerable<PlanetDto>>(json);

            unitOfWork.PlanetDbService.AddPlanetsInRange(planets);
            unitOfWork.UpdateDb();
        }

        private static void ImportAnomalies(IServicesUniOfWork unitOfWork)
        {
            string json = File.ReadAllText(AnomalyJsonFilePath);

            IEnumerable<IAnomalyDto> anomalies = JsonConvert.DeserializeObject<IEnumerable<AnomalyDto>>(json);

            unitOfWork.AnomalyDbService.AddAnomaliesInRange(anomalies);
            unitOfWork.UpdateDb();
        }

        private static void ImportPersons(IServicesUniOfWork unitOfWork)
        {
            string json = File.ReadAllText(PersonJsonFilePath);

            IEnumerable<IPersonDto> persons = JsonConvert.DeserializeObject<IEnumerable<PersonDto>>(json);

            unitOfWork.PersonDbService.AddPersonsInRange(persons);
            unitOfWork.UpdateDb();
        }

        private static void ImportAnomaliesVictims(IServicesUniOfWork unitOfWork)
        {
            string json = File.ReadAllText(AnomaliesVictomsJsonFilePath);

            IEnumerable<IAnomaliesVictimsDto> anomaliesVictims =
                JsonConvert.DeserializeObject<IEnumerable<AnomaliesVictimsDto>>(json);

            unitOfWork.AnomaliesVictimsDbService.AddRecordsInRange(anomaliesVictims);
            unitOfWork.UpdateDb();
        }
    }
}
