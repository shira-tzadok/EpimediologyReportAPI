using EpidemiologyReport.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpidemiologyReport.Services.Repositorieis
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllPatients();
        Task<IEnumerable<Patient>> GetPatientByFirstName(string firstName);
        Task<IEnumerable<Patient>> GetPatientByLastName(string lastName);
        Task<Patient> GetPatientById(int id);
        Task<IEnumerable<Patient>> AddPatient(Patient patient,int id);
        Task<Patient> DeletePatientById(int id);
    }
}
