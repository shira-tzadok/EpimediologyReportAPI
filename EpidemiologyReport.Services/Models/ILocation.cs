using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpidemiologyReport.Services.Models
{
    public interface ILocation
    {
        string City { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string Description { get; set; }
    }
}
