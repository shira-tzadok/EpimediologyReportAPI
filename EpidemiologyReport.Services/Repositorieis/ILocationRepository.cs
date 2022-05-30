using EpidemiologyReport.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpidemiologyReport.Services.Repositorieis
{
    public interface ILocationRepository
    {
        Task<IEnumerable<Location>> GetLocations();
        Task<IEnumerable<Location>> GetLocationByCity(string city);
        Task<IEnumerable<Location>> GetLocationByPatientId(int id);
        Task<IEnumerable<Location>> AddLocation(IEnumerable<Location> newLocation, int id);
        Task<IEnumerable<Location>> DeleteLocationById(int id);
    }
}
