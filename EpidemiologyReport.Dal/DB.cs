using EpidemiologyReport.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace EpidemiologyReport.DAL
{
    public class DB : IDB
    {
        //public List<Patient> PatientList { get; set; }

        //public DB()
        //{
        //    using (StreamReader reader = new StreamReader("DB.json"))
        //    {
        //        string json = reader.ReadToEnd();
        //        PatientList = JsonSerializer.Deserialize<List<Patient>>(json);
        //    }
        //}

        static List<Location> location1 = new List<Location>()
        {
            new Location("bnei brack",new DateTime(2020/8/1),new DateTime(2020/8/1),"Restaurant"),
            new Location("Jerusalem",new DateTime(2020/8/6),new DateTime(2020/8/10),"Hotel")
        };

        static List<Location> location2 = new List<Location>()
        {
            new Location("Ashdod",new DateTime(2020/8/1),new DateTime(2020/8/1),"Restaurant"),
            new Location("elad",new DateTime(2020/8/6),new DateTime(2020/8/10),"Hotel")
        };

        static List<Location> location3 = new List<Location>()
        {
            new Location("Netivot",new DateTime(2020/8/1),new DateTime(2020/8/1),"Restaurant"),
            new Location("bnei brack",new DateTime(2020/8/6),new DateTime(2020/8/10),"Hotel")
        };

        public List<Patient> PatientList { get; set; } = new List<Patient>()
        {
            new Patient(111,"Cohen","Yonatan", location1),
            new Patient(222,"Levi","Shimon", location2),
            new Patient(333,"ben tzvi","shira", location3)
        };
    }
}
