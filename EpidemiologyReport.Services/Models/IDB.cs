using EpidemiologyReport.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpidemiologyReport.Services.Models
{
    public interface IDB
    {
        List<Patient> PatientList { get; set; }
    }
}
