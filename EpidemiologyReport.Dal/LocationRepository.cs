using EpidemiologyReport.Services.Models;
using EpidemiologyReport.Services.Repositorieis;
using Serilog;

namespace EpidemiologyReport.DAL
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ILogger<LocationRepository> _logger;
        public LocationRepository(ILogger<LocationRepository> logger)
        {
            _logger = logger;
            //Log.Logger = new LoggerConfiguration()
            //      .MinimumLevel.Debug()
            //      .WriteTo.Console()
            //      .WriteTo.File("var/location/log.json", rollingInterval: RollingInterval.Day).CreateLogger();
            //_logger = logger;
        }
        public async Task<List<Location>> GetLocations()
        {
            _logger.Information("GetLocations from LocationController called");
            return await Task.FromResult(DB.PatientList.SelectMany(patient => patient.LocationList).ToList());
        }
        
        public async Task<List<Location>> GetLocationByCity(string city)
        {

            _logger.Information($"GetLocationByCity from LocationController called with city:{city}");
            return await Task.FromResult(DB.PatientList.SelectMany(patient => patient.LocationList).Where(location => location.City == city).ToList());
        }

        public async Task<List<Location>> GetLocationByPatientId(int id)
        {
            _logger.Information($"GetLocationByPatientId from LocationController called with id:{id}");
            return await Task.FromResult(DB.PatientList.First(p => p.PatientId == id).LocationList);
        }

        public async Task<List<Location>?> AddLocation(List<Location> newLocation, int id)
        {
            Patient patient = DB.PatientList.First(l => l.PatientId == id);
            if (patient == null)
                return null;
            patient.LocationList.AddRange(newLocation);
            _logger.Information($"AddLocation from LocationController called with id:{id} and new locations {newLocation}");
            //string patientContext=JsonSerializer.Serialize(_patient,new JsonSerializerOptions() { WriteIndented = true });
            //using(StreamWriter streamWriter=new StreamWriter("DB.json"))
            //{
            //    streamWriter.WriteLine(patientContext);
            //}
            return await Task.FromResult(newLocation);
        }

        public async Task<List<Location>> DeleteLocationById(int id)
        {
            _logger.Information($"DeleteLocationById from LocationController called but id {id} not found");
            List<Location> locations = DB.PatientList.First(p => p.PatientId == id).LocationList;
            DB.PatientList.First(p=>p.PatientId==id).LocationList.RemoveRange(0, locations.Count);
            return await await Task.FromResult(GetLocationByPatientId(id));
        }

    }
}
