using EpidemiologyReport.Services.Models;
using EpidemiologyReport.Services.Repositorieis;
using Serilog;

namespace EpidemiologyReport.DAL
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ILogger<PatientRepository> _logger;
        public PatientRepository(Serilog.ILogger<PatientRepository> logger)
        {
            _logger = logger;
        }
        public async Task<List<Patient>?> AddPatient(Patient patient, int id)
        {
            _logger.Information($"AddPatient from PatientConroller called with id {id}");
            Patient p = DB.PatientList.First(p => p.PatientId == id);
            if(p == null)
            {
                _logger.Information($"patient with id {id} added successfully");
                DB.PatientList.Add(patient);
                return await Task.FromResult(DB.PatientList);
            }
            Log.Logger.Error($"patient with id {id} allready exists");
            return null;
        }

        public async Task<Patient?> DeletePatientById(int id)
        {
            _logger.Information($"DeletePatientById from PatientConroller called with id {id}");
            Patient? patient = DB.PatientList.Where(p => p.PatientId == id)?.FirstOrDefault();
            if (patient == null)
            {
                _logger.Error($"patient with id {id} not exist");
                return await Task.FromResult(patient);
            }
            DB.PatientList.Remove(patient);
            _logger.Warning($"patient with id {id} deleted");
            return await Task.FromResult(patient);
        }

        public async Task<List<Patient>> GetAllPatients()
        {
            _logger.Information("GetAllPatients from PatientConroller called");
            return await Task.FromResult(DB.PatientList);
        }

        public async Task<List<Patient>> GetPatientByLastName(string lastName)
        {
            _logger.Information($"GetPatientByLastName from PatientConroller called with lastName {lastName}");
            return await Task.FromResult(DB.PatientList.Where(p => p.LastName == lastName).ToList());
        }

        public async Task<List<Patient>> GetPatientByFirstName(string firstName)
        {
            _logger.Information($"GetPatientByFirstName from PatientConroller called with firstName {firstName}");
            return await Task.FromResult(DB.PatientList.Where(p => p.FirstName == firstName).ToList()); 
        }

        public async Task<Patient> GetPatientById(int id)
        {
            _logger.Information($"GetPatientById from PatientConroller called with id {id}");
            return await Task.FromResult(DB.PatientList.First(p => p.PatientId == id));
        }
    }
}
