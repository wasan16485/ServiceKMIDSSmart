using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using ServiceKMIDSSmart.Models;
using ServiceKMIDSSmart.Operation;

namespace ServiceKMIDSSmart.Controllers
{
    public class GetbusController :   ApiController
    {
        [HttpGet]
        public List<resGetbusModel> getbus()
        {
            try
            {
                var res = new ManagementData();
                return res.getbus();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

    public class GetbusdestinationController : ApiController
    {
        [HttpPost]
        public List<resGetbusdestinationModel>  get(sendGetbusdestinationModel model)
        {
            try
            {
                var res = new ManagementData();
                return res.Getbusdestination(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

    public class GetscaninbusController : ApiController
    {
        [HttpPost]
        public resGetscaninbusModel get(sendGetscaninbusModel model)
        {
            try
            {
                var res = new ManagementData();
                return res.Getscaninbus(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

    public class SetupdatestartjourneyController : ApiController
    {
        [HttpPost]
        public resSetupdatestartjourneyModel setupdatestartjourney(sendSetupdatestartjourneyModel model)
        {
            try
            {
                var res = new ManagementData();
                return res.setupdatestartjourney(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

    public class SetupdatearrivedestinationController : ApiController
    {
        [HttpPost]
        public resSetupdatearrivedestinationModel Setupdatearrivedestination(sendSetupdatearrivedestinationModel model)
        {
            try
            {
                var res = new ManagementData();
                return res.Setupdatearrivedestination(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

 
}