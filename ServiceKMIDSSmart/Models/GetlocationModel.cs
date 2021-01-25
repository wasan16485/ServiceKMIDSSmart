using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceKMIDSSmart.Models
{
    public class sendGetlocationModel
    {
        public string latitude { get; set; }
        public string Longitude { get; set; }
    }


    public class resGetlocationModel
    {
        public int Distance { get; set; }
        public int FixDistance { get; set; }            
    }

    public class resDBGetlocationModel
    {
        public string latitude { get; set; }
        public string Longitude { get; set; }
        public int  FixDistance { get; set; }
    }


    public class SendSearchModel
    {
        public string Search { get; set; }
    }

    public class resgetloginModel
    {
        public int MobileMenuID { get; set; }
        public string Menu { get; set; }
        public int MobileUserID { get; set; }
        public string Name { get; set; }
    }


    public class resgetstudentregModel
    {
        public int PersonID { get; set; }
        public string TitleName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StatusRegister { get; set; }
    }

    public class SendsetinsertparentregisterModel
    {
        public int PersonID { get; set; }
    }

    public class ressetinsertparentregisterModel
    {
        public int result { get; set; }
    }


    public class SendgetstatusbusModel
    {
        public int PersonID { get; set; }
    }

    public class resgetstatusbusModel
    {
        public int TranscationBusID { get; set; }
        public int UpDown { get; set; }
        public string UpDownName { get; set; }
        public string result_status { get; set; }
        public string result_status1 { get; set; }
    }
}