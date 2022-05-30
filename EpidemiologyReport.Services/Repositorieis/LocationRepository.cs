using EpidemiologyReport.Services.Models;
using Serilog;

namespace EpidemiologyReport.Services.Repositorieis
{
    public class LocationRepository : ILocationRepository
    {
        private readonly List<Patient> _patient;
        public LocationRepository(IDB patientContext)
        {
            _patient = patientContext.PatientList;
            Log.Logger = new LoggerConfiguration()
                  .MinimumLevel.Debug()
                  .WriteTo.Console()
                  .WriteTo.File("var/location/log.json", rollingInterval: RollingInterval.Day).CreateLogger();
        }
        public async Task<IEnumerable<Location>> GetLocations()
        {
            Log.Logger.Information("GetLocations from LocationController called");
            return await Task.FromResult(_patient.SelectMany(patient => patient.LocationList).ToList());
        }
        
        public async Task<IEnumerable<Location>> GetLocationByCity(string city)
        {

            Log.Logger.Information($"GetLocationByCity from LocationController called with city:{city}");
            return await Task.FromResult(_patient.SelectMany(patient => patient.LocationList).Where(location => location.City == city).ToList());
        }

        public async Task<IEnumerable<Location>> GetLocationByPatientId(int id)
        {
            Log.Logger.Information($"GetLocationByPatientId from LocationController called with id:{id}");
            return await Task.FromResult(_patient.First(p => p.PatientId == id).LocationList);
        }

        public async Task<IEnumerable<Location>?> AddLocation(IEnumerable<Location> newLocation, int id)
        {
            Patient patient = _patient.First(l => l.PatientId == id);
            if (patient == null)
                return null;
            patient.LocationList.AddRange(newLocation);
            Log.Logger.Information($"AddLocation from LocationController called with id:{id} and new locations {newLocation}");
            //string patientContext=JsonSerializer.Serialize(_patient,new JsonSerializerOptions() { WriteIndented = true });
            //using(StreamWriter streamWriter=new StreamWriter("DB.json"))
            //{
            //    streamWriter.WriteLine(patientContext);
            //}
            return await Task.FromResult(newLocation);
        }

        public async Task<IEnumerable<Location>> DeleteLocationById(int id)
        {
            Log.Logger.Information($"DeleteLocationById from LocationController called but id {id} not found");
            List<Location> locations = _patient.First(p => p.PatientId == id).LocationList;
            _patient.First(p=>p.PatientId==id).LocationList.RemoveRange(0, locations.Count);
            return await await Task.FromResult(GetLocationByPatientId(id));
        }

    }
}
