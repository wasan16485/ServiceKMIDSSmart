using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceKMIDSSmart.Models
{
    public class resGetbusModel
    {
        public int BusID { get; set; }
        public string BusName { get; set; }   
    }



    public class sendGetbusdestinationModel
    {
        public int BusID { get; set; }
    }

    public class resGetbusdestinationModel
    {
        public int BusDestinationID { get; set; }
        public string Destination { get; set; }
        public int TotalSeat { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int FixDistance { get; set; }     
    }




    public class sendGetscaninbusModel
    {
        public string Code { get; set; }
        public int BusDestinationID { get; set; }
        public int MobileUserID { get; set; }
    }

    public class resGetscaninbusModel
    {
        public int PersonID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Grade { get; set; }
        public string Picture { get; set; }
    }



    public class sendSetupdatestartjourneyModel
    {
        public int MobileUserID { get; set; }
    }
    public class resSetupdatestartjourneyModel
    {
        public int Total { get; set; }
        public List<listSetupdatestartjourney> startjourney { get; set; }
    }

    public class listSetupdatestartjourney
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Grade { get; set; }
    }

    public class DBresSetupdatestartjourneyModel
    {
        public int Total { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Grade { get; set; }
    }




    public class sendSetupdatearrivedestinationModel
    {
        public int MobileUserID { get; set; }
    }

    public class resSetupdatearrivedestinationModel
    {
        public string Isstatus { get; set; }
    }
}