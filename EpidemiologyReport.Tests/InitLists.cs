using EpidemiologyReport.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpidemiologyReport.Tests
{
    internal class InitLists
    {
        public static List<Location> location1 = new List<Location>()
        {
            new Location("bnei brack",new DateTime(2020/8/1),new DateTime(2020/8/1),"Restaurant"),
            new Location("Jerusalem",new DateTime(2020/8/6),new DateTime(2020/8/10),"Hotel")
        };
        public static List<Location> location2 = new List<Location>()
        {
            new Location("Ashdod",new DateTime(2020/8/1),new DateTime(2020/8/1),"Restaurant"),
            new Location("elad",new DateTime(2020/8/6),new DateTime(2020/8/10),"Hotel")
        };
        public static List<Patient> PatientList { get; set; } = new List<Patient>()
        {
            new Patient(111,"Cohen","Yonatan", location1),
            new Patient(222,"Levi","Shimon", location2),
        };
    }
}
