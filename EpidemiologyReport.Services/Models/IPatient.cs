using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpidemiologyReport.Services.Models
{
    public interface IPatient
    {
        int PatientId { get; set; }
        string LastName { get; set; }
        string FirstName { get; set; }
        List<Location> LocationList { get; set; }
    }
}
