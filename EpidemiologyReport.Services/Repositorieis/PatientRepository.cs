using EpidemiologyReport.Services.Models;
using Serilog;

namespace EpidemiologyReport.Services.Repositorieis
{
    public class PatientRepository : IPatientRepository
    {
        private readonly List<Patient> _patients;
        public PatientRepository(IDB patientContext)
        {
            _patients = patientContext.PatientList;
            Log.Logger = new LoggerConfiguration()
                  .MinimumLevel.Debug()
                  .WriteTo.Console()
                  .WriteTo.File("var/patient/log.json", rollingInterval: RollingInterval.Day).CreateLogger();
        }
        public async Task<IEnumerable<Patient>?> AddPatient(Patient patient, int id)
        {
            Log.Logger.Information($"AddPatient from PatientConroller called with id {id}");
            Patient p = _patients.First(p => p.PatientId == id);
            if(p == null)
            {
                Log.Logger.Information($"patient with id {id} added successfully");
                _patients.Add(patient);
                return await Task.FromResult(_patients);
            }
            Log.Logger.Error($"patient with id {id} allready exists");
            return null;
        }

        public async Task<Patient?> DeletePatientById(int id)
        {
            Log.Logger.Information($"DeletePatientById from PatientConroller called with id {id}");
            Patient? patient = _patients.Where(p => p.PatientId == id)?.FirstOrDefault();
            if (patient == null)
            {
                Log.Logger.Error($"patient with id {id} not exist");
                return await Task.FromResult(patient);
            }
            _patients.Remove(patient);
            Log.Logger.Warning($"patient with id {id} deleted");
            return await Task.FromResult(patient);
        }

        public async Task<IEnumerable<Patient>> GetAllPatients()
        {
            Log.Logger.Information("GetAllPatients from PatientConroller called");
            return await Task.FromResult(_patients);
        }

        public async Task<IEnumerable<Patient>> GetPatientByLastName(string lastName)
        {
            Log.Logger.Information($"GetPatientByLastName from PatientConroller called with lastName {lastName}");
            return await Task.FromResult(_patients.Where(p => p.LastName == lastName).ToList());
        }

        public async Task<IEnumerable<Patient>> GetPatientByFirstName(string firstName)
        {
            Log.Logger.Information($"GetPatientByFirstName from PatientConroller called with firstName {firstName}");
            return await Task.FromResult(_patients.Where(p => p.FirstName == firstName).ToList()); 
        }

        public async Task<Patient> GetPatientById(int id)
        {
            Log.Logger.Information($"GetPatientById from PatientConroller called with id {id}");
            return await Task.FromResult(_patients.First(p => p.PatientId == id));
        }
    }
}
